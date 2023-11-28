using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
namespace PersistenceTests
{

    [Serializable]
    class Location
    {
        public int Id { get; init; }
        
        public string TagName { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public string Address { get; }
        
        

        public Location(int id, string tagName, double latitude, double longitude, string address)
        {
            Id = id;
            TagName = tagName;
            Latitude = latitude;
            Longitude = longitude;
            Address = address;

        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Location otherLocation = (Location)obj;
            return Id == otherLocation.Id;
        }

        public override string ToString()
        {
            return $"Location(Id: {Id}, TagName: {TagName}, Latitude: {Latitude}, Longitude: {Longitude}, Address: {Address})";
        }
    }
    [Serializable]
    class Sensor
    {
        //[JsonProperty("id")]
        public int Id { get;init; }
        //[JsonProperty("serialNum")]
        public string SerialNum { get; }
        //[JsonProperty("modelName")]
        public string ModelName { get; }
        //[JsonProperty("lastUpdateDateTime")]
        public DateTime LastUpdateDateTime { get; }

        public bool IsDeployed { get; set; }

        public Sensor(int id, string serialNum, string modelName,DateTime lastUpdateDateTime)
        {
            Id = id;
            SerialNum = serialNum;
            ModelName = modelName;
            LastUpdateDateTime = lastUpdateDateTime;
            IsDeployed = false;
        }

        public override string ToString()
        {
            return
                $"Sensor(Id: {Id}, SerialNum: {SerialNum}, ModelName: {ModelName}, LastUpdateDateTime: {LastUpdateDateTime})";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; // Prime number
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (SerialNum?.GetHashCode() ?? 0);
                hash = hash * 23 + (ModelName?.GetHashCode() ?? 0);
                hash = hash * 23 + LastUpdateDateTime.GetHashCode();
                //hash = hash * 23 + IsDeployed.GetHashCode();
                return hash;
            }
        }
    }
    class Temperature
    {
        public double value;

        public Temperature(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return $"{value} \u00b0C";
        }
    }

    static class SensorTemperatureTable
    {
        public static Dictionary<Sensor, Temperature> stDictionary = new Dictionary<Sensor, Temperature>();
        
        public static Temperature getTemperature(Sensor sensor)
        {
            return stDictionary[sensor];
        }

        public static void addSensorTemperature(Sensor sensor, Temperature temperature)
        {
            stDictionary.Add(sensor, temperature);
        }
    }
    
    static class SensorLocationTable
    {
       public static Dictionary<Sensor, Location> slDictionary = new Dictionary<Sensor, Location>();

        public static Sensor getSensor(Location location)
        {
            Sensor sensor = null;
            foreach (var keyValuePair in slDictionary)
            {
                if (keyValuePair.Value.Equals(location))
                {
                    sensor = keyValuePair.Key;
                    break;
                }
            }
            return sensor;
        }

        public static bool isCovered(Location location)
        {
            foreach (var keyValuePair in slDictionary)
            {
                if (keyValuePair.Value.Equals(location))
                {
                    return true;
                }
            }
            return false;
        }
        
        public static void addSensorLocation(Sensor sensor, Location location)
        {
            slDictionary.Add(sensor, location);
        }
    }
    
    
    
    
    class DataRepository
    {
        private const int version  = 2;

        private string SensorsFilePath;
        private string LocationsFilePath;
        private string slMapFilePath;
        private string stMapFilePath;
        public List<Location> locations;
        public List<Sensor> sensors;
        // public Dictionary<int, int> slMap;
        
        public DataRepository()
        {
            string projDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            SensorsFilePath = $"{projDirectory}\\sensors.json";
            LocationsFilePath = $"{projDirectory}\\locations.json";
            slMapFilePath = $"{projDirectory}\\sl_table.json";
            stMapFilePath = $"{projDirectory}\\st_table.json";
            LoadData();
        }

        private void LoadData() //From .json to lists and dictionnaries
        {
            if (File.Exists(LocationsFilePath))
            {
                string locationsJson = File.ReadAllText(LocationsFilePath);
                locations = JsonConvert.DeserializeObject<List<Location>>(locationsJson) ?? new List<Location>();
            }
            else
            {
                locations = new List<Location>();
            }

            if (File.Exists(SensorsFilePath))
            {
                string sensorsJson = File.ReadAllText(SensorsFilePath);
                sensors = JsonConvert.DeserializeObject<List<Sensor>>(sensorsJson) ?? new List<Sensor>();
            }
            else
            {
                sensors = new List<Sensor>();
            }
            if (File.Exists(slMapFilePath))
            {
                string mapJson = File.ReadAllText(slMapFilePath);
                Dictionary<int, Location> serilializableDict = JsonConvert.DeserializeObject<Dictionary<int, Location>>(mapJson) ?? new Dictionary<int, Location>();
                foreach (var SensorIdLocationPair in serilializableDict)
                {
                    SensorLocationTable.slDictionary[GetSensorById(SensorIdLocationPair.Key)] = SensorIdLocationPair.Value;
                }
            }
            else
            {
                SensorLocationTable.slDictionary = new Dictionary<Sensor, Location>();
            }
            if (File.Exists(stMapFilePath))
            {
                string mapJson = File.ReadAllText(stMapFilePath);
                Dictionary<int, Temperature> serilializableDict = JsonConvert.DeserializeObject<Dictionary<int, Temperature>>(mapJson) ?? new Dictionary<int, Temperature>();
                foreach (var SensorIdTemperaturePair in serilializableDict)
                {
                    SensorTemperatureTable.stDictionary[GetSensorById(SensorIdTemperaturePair.Key)] = SensorIdTemperaturePair.Value;
                }
            }
            else
            {
                SensorTemperatureTable.stDictionary = new Dictionary<Sensor, Temperature>();
            }
        }

        public void SaveData() //From lists and dictionaries to .json
        {
            string locationsJson = JsonConvert.SerializeObject(locations,Formatting.Indented);
            File.WriteAllText(LocationsFilePath, locationsJson);
            string sensorsJson = JsonConvert.SerializeObject(sensors,Formatting.Indented);
            File.WriteAllText(SensorsFilePath, sensorsJson);
            
            Dictionary<int, Location> serilializableLocDict = new Dictionary<int, Location>();
            foreach (var SensorLocationPair in SensorLocationTable.slDictionary)
            {
                serilializableLocDict[SensorLocationPair.Key.Id] = SensorLocationPair.Value;
            }
            
            string slmapjson = JsonConvert.SerializeObject(serilializableLocDict,Formatting.Indented);
            File.WriteAllText(slMapFilePath, slmapjson);
            
            
            Dictionary<int, Temperature> serilializableTempDict = new Dictionary<int, Temperature>();
            foreach (var SensorTemperaturePair in SensorTemperatureTable.stDictionary)
            {
                serilializableTempDict[SensorTemperaturePair.Key.Id] = SensorTemperaturePair.Value;
            }
            
            string stmapjson = JsonConvert.SerializeObject(serilializableTempDict,Formatting.Indented);
            File.WriteAllText(stMapFilePath, stmapjson);
        }

        public void AddLocations(params Location[] newLocations)
        {
            foreach (var location in newLocations)
            {
                if (!DoesLocationExist(location.Id))
                {
                    locations.Add(location);
                    
                }
            }
            SaveData();

        }

        public void AddSensors(params Sensor[] newSensors)
        {

            foreach (var sensor in newSensors)
            {
                if (!DoesSensorExist(sensor.Id))
                {
                    sensors.Add(sensor);
                    
                }
            }
            SaveData();
            
        }

        public Location GetLocationById(int id)
        {
            return locations.Find(location => location.Id == id);
        }

        public Sensor GetSensorById(int id)
        {
            return sensors.Find(sensor => sensor.Id == id);
        }

        public bool DoesLocationExist(int id)
        {
            return locations?.Exists(location => location.Id == id) ?? false;
        }

        public bool DoesSensorExist(int id)
        {
            return sensors?.Exists(sensor => sensor.Id == id) ?? false;
        }

        public void LinkSensorToLocation(Sensor sensor, Location location)
        {

            if (!(DoesLocationExist(location.Id) && DoesSensorExist(sensor.Id)))
            {
                Console.WriteLine("LinkSensorToLocation failed because sensor or location instances were not found in registries. use Add...()");
                return;
            }
            Location locValue = null;
            if (SensorLocationTable.slDictionary.TryGetValue(sensor, out locValue))
            {
                if (locValue == location)
                {
                    Console.WriteLine("Sensor #{0} already covers Location #{1}",sensor.Id,location.Id);
                }
                else
                {
                    Console.WriteLine("Sensor #{0} already deployed to other Location #{1}", sensor.Id, locValue);
                }
            }
            else if (SensorLocationTable.slDictionary.Any(kvp => kvp.Value == location))
            {
                Console.WriteLine("Location #{0} is already covered by another sensor",location.Id);
            }
            else
            {
                sensor.IsDeployed = true;
                SensorLocationTable.slDictionary[sensor] = location;
                SaveData();
            }
            
        }
        public void UnlinkSensorByFromLocation(Location locationToRemove)
        {

            Sensor sensorToRemove = null;
            foreach (var pair in SensorLocationTable.slDictionary)
            {
                if (pair.Value == locationToRemove)
                {
                    sensorToRemove = pair.Key;//GetSensorById(pair.Key);
                    break;
                }
            }

            if (sensorToRemove != null)
            {
                sensorToRemove.IsDeployed = false;
                SensorLocationTable.slDictionary.Remove(sensorToRemove);
                Console.WriteLine("Pair removed successfully based on location.");
            }
            else
            {
                Console.WriteLine("Pair not found based on the specified location or sensor not linked anymore.");
            }
            
        }

        public void UnlinkLocationByFromSensor(Sensor sensorToRemove)
        {
            if (SensorLocationTable.slDictionary.ContainsKey(sensorToRemove))
            {
                sensorToRemove.IsDeployed = false;
                SensorLocationTable.slDictionary.Remove(sensorToRemove);
                Console.WriteLine("Pair removed successfully based on sensor.");
            }
            else
            {
                Console.WriteLine("Pair not found based on the specified sensor.");
            }
        }
        
        public void DeploySensor(Sensor sensor, Location location, Temperature temperature)
        {
            if (sensor.IsDeployed)
            {
                Console.WriteLine("Sensor already deployed");
            }
            else if(SensorLocationTable.isCovered(location))
            {
                Console.WriteLine("Location already covered");
            }
            else
            {
                DeploySensorOK(sensor, location, temperature);
                Console.WriteLine("OK");
            }
        }

        public void DeploySensorOK(Sensor sensor, Location location, Temperature temperature)
        {
            sensor.IsDeployed = true;
            SensorLocationTable.addSensorLocation(sensor, location);
            SensorTemperatureTable.addSensorTemperature(sensor, temperature);
            
            SaveData();
            
            
        }

        public Temperature ReadTemperature(Location location)
        {
            if (!SensorLocationTable.isCovered(location)) {
                Console.WriteLine("Location Unknown");
                return null;
            }else
            {
                Console.WriteLine("OK");
                return ReadTemperatureOK(location);
            }
        }

        public Temperature ReadTemperatureOK(Location location)
        {
            Sensor sensor = SensorLocationTable.getSensor(location);
            return SensorTemperatureTable.getTemperature(sensor);
        }
    }

    public partial record GenerationValuesRecord;
    

    public partial class Program
    { 
        static void DisplayThumbnails<T>(List<T> jsonObjects, int currentIndex)
        {
            Console.WriteLine("Available IDs:");
            for (int i = 0; i < jsonObjects.Count; i++)
            {
                if (i == currentIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Type myType = jsonObjects[i].GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                
                Console.WriteLine($"[{i}] {props[1].GetValue(jsonObjects[i],null)}");
                Console.ResetColor();
            }
        }

        static ConsoleKey RegistryUIRoutine<T>(List<T> jsonObjects,string pageTitle)
        { 
            Console.Clear();
            int currentIndex = 0;
            ConsoleKeyInfo keyInfo;
            bool viewModeActive = false;
            
            ViewJsonObjectMode:
                if (viewModeActive)
                { 
                    
                        string jsonObjectDetails = JsonConvert.SerializeObject(jsonObjects[currentIndex], Formatting.Indented);
                        Console.WriteLine(jsonObjectDetails);
            
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                }



            Console.Title = pageTitle;
            Console.CursorVisible = false;
            
            DisplayThumbnails<T>(jsonObjects, currentIndex);
            do
            {
                keyInfo = Console.ReadKey(true);
                
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentIndex > 0)
                        {
                            currentIndex--;
                            Console.Clear();
                            DisplayThumbnails(jsonObjects, currentIndex);
                        }else
                        {
                            currentIndex = jsonObjects.Count;
                            goto case ConsoleKey.UpArrow;
                        }
                        break;
            
                    case ConsoleKey.DownArrow:
                        if (currentIndex < jsonObjects.Count - 1)
                        {
                            currentIndex++;
                            Console.Clear();
                            DisplayThumbnails(jsonObjects, currentIndex);
                        }
                        else
                        {
                            currentIndex = -1;
                            goto case ConsoleKey.DownArrow;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        viewModeActive = true;
                        goto ViewJsonObjectMode;
                        
                        
                }
            } while (keyInfo.Key != ConsoleKey.Q && keyInfo.Key != ConsoleKey.LeftArrow && keyInfo.Key != ConsoleKey.RightArrow);

            return keyInfo.Key;
        }

        static void UNIX_CLEAR()
        {
            Console.Clear(); // Attempt to clear the console screen
            //Console.Write("\u001b[H\u001b[2J");
            //Console.Write("\u001b[2J\u001b[H");
            Console.Write("\f\u001bc\x1b[3J");
            // Console.SetCursorPosition(0, 0);
            // Console.Write(new string(' ', Console.WindowWidth * Console.WindowHeight));
            // Console.SetCursorPosition(0, 0);
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;
        enum MENU_PAGE {MAIN_MENU = 0,SENSOR_REGISTRY, LOCATION_REGISTRY, SL_TABLE, ST_TABLE,
            OPERATION_DEPLOYSENSOR,OPERATION_READTEMP}
        static void Main(string[] args)
        {
        

            // Console.WindowWidth = 100; // Sets the console window width
            // Console.WindowHeight = 40; // Sets the console window height
            // Console.BufferWidth = 100; // Sets the console buffer width (horizontal scroll)
            // Console.BufferHeight = 100; // Sets the console buffer height (vertical scroll)
            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow != IntPtr.Zero)
            {
                SetWindowPos(consoleWindow, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
                                
            }
            
            DataRepository repository = new DataRepository();
            
            // repository.slMap.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

            int currentMenuPageOrdinal = 0;
            
            
            ConsoleKeyInfo keyInfo;
            ConsoleKey subMenuRetKey = ConsoleKey.A;
            do
            {


                switch ((MENU_PAGE)currentMenuPageOrdinal)
                {
                    case MENU_PAGE.LOCATION_REGISTRY:
                        subMenuRetKey = RegistryUIRoutine(repository.locations, $"Location Registry [Page {currentMenuPageOrdinal}]");
                        goto default;
                    case MENU_PAGE.SENSOR_REGISTRY:
                        subMenuRetKey = RegistryUIRoutine(repository.sensors, $"Sensor Registry [Page {currentMenuPageOrdinal}]");
                        goto default;
                    case MENU_PAGE.SL_TABLE:
                        Console.Clear();
                        Console.Title = $"SensorLocation Table [Page {currentMenuPageOrdinal}]";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("\nHANDLING FOR SL TABLE");
                        keyInfo = Console.ReadKey(true);
                        subMenuRetKey = keyInfo.Key;
                        goto default;
                    case MENU_PAGE.ST_TABLE:
                        Console.Clear();
                        Console.Title = $"SensorTemperature Table [Page {currentMenuPageOrdinal}]";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("\nHANDLING FOR ST TABLE");
                        keyInfo = Console.ReadKey(true);
                        subMenuRetKey = keyInfo.Key;
                        goto default;
                    case MENU_PAGE.OPERATION_DEPLOYSENSOR:
                        Console.Clear();
                        Console.Title = $"Operation: DeploySensor [Page {currentMenuPageOrdinal}]";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("DEPLOY_SENSOR()\n\n\r");
                        Console.Write("Press 'Enter' to do this operation");
                        
                        keyInfo = Console.ReadKey(true);
                        subMenuRetKey = keyInfo.Key;
                        if (subMenuRetKey == ConsoleKey.Enter)
                        {
                            int currentLineCursor = Console.CursorTop;
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(new string(' ', Console.WindowWidth)); 
                            Console.SetCursorPosition(0, currentLineCursor);
                            
                            
                            Console.Write("\nEnter the sensor id: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Sensor sensor = repository.GetSensorById(int.Parse(Console.ReadLine()));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(sensor);
                            Console.Write("Enter the location id: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Location location = repository.GetLocationById(int.Parse(Console.ReadLine()));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(location);
                            Console.Write("Enter the temperature: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Temperature temperature = new Temperature(double.Parse(Console.ReadLine()));
                            
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            repository.DeploySensor(sensor, location, temperature);
                            keyInfo = Console.ReadKey(true);
                            subMenuRetKey = keyInfo.Key;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        goto default;
                    case MENU_PAGE.OPERATION_READTEMP:
                        Console.Clear();
                        Console.Title = $"Operation: ReadTemp [Page {currentMenuPageOrdinal}]";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("READ_TEMP()\n\n\r");
                        Console.Write("Press 'Enter' to do this operation");
                        
                        keyInfo = Console.ReadKey(true);
                        subMenuRetKey = keyInfo.Key;
                        if (subMenuRetKey == ConsoleKey.Enter)
                        {
                            int currentLineCursor = Console.CursorTop;
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, currentLineCursor);
                            keyInfo = Console.ReadKey(true);
                            subMenuRetKey = keyInfo.Key;
                            Console.Write("Enter location id: ");
                            Location mylocation = repository.GetLocationById(int.Parse(Console.ReadLine()));
                            Console.WriteLine(repository.ReadTemperature(mylocation));
                            Console.ReadKey(true);
                        }
                        goto default;
                        
                    case MENU_PAGE.MAIN_MENU:
                        Console.Clear();
                        Console.Title = $"TempMonitor: Main Menu [Page {currentMenuPageOrdinal}]";
                        Console.WriteLine("\nWelcome to TempMonitor Solutions System !");
                        const int frequencyMilliseconds = 1000;
                        bool continuePrinting = true;
                        
                        while (continuePrinting && !Console.KeyAvailable)
                        {
                        
                            // Console.BufferWidth = 100; 
                            // Console.BufferHeight = 100; 
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(GenerationValuesRecord.MAIN_MENU_ASCII_ART1);
                            Console.WriteLine("\nWelcome to TempMonitor Solutions System !");
                            Thread.Sleep(frequencyMilliseconds);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(GenerationValuesRecord.MAIN_MENU_ASCII_ART2);
                            Console.WriteLine("\nWelcome to TempMonitor Solutions System !");
                            Thread.Sleep(frequencyMilliseconds);
                            Console.Clear();
                            // Console.SetWindowSize(120,100);
                            // Thread.Sleep(50);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine(GenerationValuesRecord.MAIN_MENU_ASCII_ART3);
                            Console.WriteLine("\nWelcome to TempMonitor Solutions System !");
                            Thread.Sleep(frequencyMilliseconds);
                            Console.Clear();
                        
                        }
                        // Console.WindowWidth = 100;
                        // Console.WindowHeight = 90;
                        // Console.SetWindowSize(60,60);
                        keyInfo = Console.ReadKey(true);
                        subMenuRetKey = keyInfo.Key;
                        goto default;

                    default:

                        if (subMenuRetKey == ConsoleKey.LeftArrow)
                        {
                            currentMenuPageOrdinal = ((currentMenuPageOrdinal - 1) % 7) + 7;
                            currentMenuPageOrdinal %= 7;

                        }
                        else if (subMenuRetKey == ConsoleKey.RightArrow)
                        {
                            currentMenuPageOrdinal = (currentMenuPageOrdinal + 1) % 7;
                        }
                        else
                        {
                            subMenuRetKey = subMenuRetKey != ConsoleKey.Q ? ConsoleKey.A : subMenuRetKey;

                        }

                        break;

                }




            } while (subMenuRetKey != ConsoleKey.Q); //&& keyInfo.Key != ConsoleKey.Q);




        }



    }
}