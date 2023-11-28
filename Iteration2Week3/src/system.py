from sensor_location_table import SensorLocationTable
from sensor_temperature_table import SensorTemperatureTable
from sensor_registry import SensorRegistry
from location_registry import LocationRegistry
from sensor import Sensor
from location import Location


class System:
    def __init__(self):
        self.sensor_registry = SensorRegistry()
        self.location_registry = LocationRegistry()
        self.sensor_temperature_table = SensorTemperatureTable()
        self.sensor_location_table = SensorLocationTable()

    def deploy_sensor(self, sensor_id, location_id, temperature):
        sensor = self.sensor_registry.get_sensor_by_id(sensor_id)
        location = self.location_registry.get_location_by_id(location_id)
        if sensor is None:
            self.sensor_unknown()
            return
        if location is None:
            self.location_unknown()
            return
        if sensor.is_deployed():
            self.sensor_already_deployed()
            return
        elif self.sensor_location_table.is_covered(location_id):
            self.location_already_covered()
            return
        else:
            self.success()
            self.deploy_sensor_ok(sensor, location, temperature)
            return

    def deploy_sensor_ok(self, sensor, location, temperature):
        sensor.set_deployed(True)
        self.sensor_location_table.add_sensor_location(sensor, location)
        self.sensor_temperature_table.add_sensor_temperature(sensor, temperature)

    def read_temperature(self, location_id):
        if not self.sensor_location_table.is_covered(location_id):
            self.location_unknown()
            return
        else:
            self.success()
            return self.read_temperature_ok(location_id)

    def read_temperature_ok(self, location_id):
        sensor = self.sensor_location_table.get_sensor(location_id)
        temperature = self.sensor_temperature_table.get_temperature(sensor)
        return temperature

    def replace_sensor(self, old_sensor_id, new_sensor_id):
        old_sensor = self.sensor_registry.get_sensor_by_id(old_sensor_id)
        new_sensor = self.sensor_registry.get_sensor_by_id(new_sensor_id)
        if old_sensor is None:
            print("Old")
            self.sensor_unknown()
            return
        elif new_sensor is None:
            print("New")
            self.sensor_unknown()
            return
        elif not old_sensor.is_deployed():
            print("Old")
            self.sensor_not_deployed()
            return
        elif new_sensor.is_deployed():
            print("New")
            self.sensor_already_deployed()
            return
        else:
            self.replace_sensor_ok(old_sensor, new_sensor)
            self.success()
            return

    def replace_sensor_ok(self, old_sensor, new_sensor):
        location = self.sensor_location_table.get_location(old_sensor)
        temperature = self.sensor_temperature_table.get_temperature(old_sensor)
        old_sensor.set_deployed(False)
        new_sensor.set_deployed(True)
        self.sensor_location_table.replace_sensor_location(old_sensor, new_sensor, location)
        self.sensor_temperature_table.replace_sensor_temperature(old_sensor, new_sensor, temperature)

    def delete_sensor(self, sensor_id):
        sensor = self.sensor_registry.get_sensor_by_id(sensor_id)
        if sensor is None:
            self.sensor_unknown()
            return
        else:
            self.delete_sensor_ok(sensor)
            self.success()
            return

    def delete_sensor_ok(self, sensor):
        self.sensor_location_table.delete_sensor_location(sensor)
        self.sensor_temperature_table.delete_sensor_temperature(sensor)
        self.sensor_registry.delete_sensor(sensor)

    def get_temperature_by_location(self):
        temperature_by_location = {}
        for sensor, location in self.sensor_location_table.data.items():
            location = self.sensor_location_table.get_location(sensor)
            temperature = self.sensor_temperature_table.get_temperature(sensor)
            temperature_by_location[location] = temperature

        # Print the results
        print("LocationTemperatureTable:")
        for location, temperature in temperature_by_location.items():
            print(f"{location}\n-->\n{temperature}\n----------")

    @staticmethod
    def success():
        print("OK")

    @staticmethod
    def location_unknown():
        print("Location Unknown")

    @staticmethod
    def sensor_unknown():
        print("Sensor Unknown")

    @staticmethod
    def sensor_already_deployed():
        print("Sensor Already Deployed")

    @staticmethod
    def sensor_not_deployed():
        print("Sensor Not Deployed")

    @staticmethod
    def location_already_covered():
        print("Location Already Covered")

    
    
if __name__ == '__main__':

    system = System()
    
    location1 = Location("L1", "Tilted Towers")
    location2 = Location("L2", "Salty Springs")
    location3 = Location("L3", "Lucky Landing")
    location4 = Location("L4", "Pleasant Park")
    location5 = Location("L5", "Fatal Field")
    
    sensor1 = Sensor("S1", False)
    sensor2 = Sensor("S2", False)
    sensor3 = Sensor("S3", False)
    sensor4 = Sensor("S4", False)
    sensor5 = Sensor("S5", False)
    
    system.sensor_registry.add_sensor(sensor1)
    system.sensor_registry.add_sensor(sensor2)
    system.sensor_registry.add_sensor(sensor3)
    system.sensor_registry.add_sensor(sensor4)
    system.sensor_registry.add_sensor(sensor5)
    
    system.location_registry.add_location(location1)
    system.location_registry.add_location(location2)
    system.location_registry.add_location(location3)
    system.location_registry.add_location(location4)
    system.location_registry.add_location(location5)
    
    while True:
        print("TempMonitor\'s menu:")
        print("[0] - Exit")
        print("[1] - Display the sensor's registry")
        print("[2] - Display the location's registry")
        print("[3] - Display the sensor-location's table")
        print("[4] - Display the sensor-temperature's table")
        print("[5] - Deploy a sensor")
        print("[6] - Read a temperature")
        print("[7] - Replace a sensor")
        print("[8] - Delete a sensor")
        print("[9] - Display the location-temperature's table")
    
        user_input = input("\nEnter something: ")
        print()
    
        if user_input.lower() == "0":
            print("Program terminated")
            break
        elif user_input.lower() == "1":
            print(system.sensor_registry)
        elif user_input.lower() == "2":
            print(system.location_registry)
        elif user_input.lower() == "3":
            print(system.sensor_location_table)
        elif user_input.lower() == "4":
            print(system.sensor_temperature_table)
        elif user_input.lower() == "5":
            sensor_id = input("Enter the sensor id: ")
            location_id = input("Enter the location id: ")
            temperature = input("Enter the temperature: ")
            system.deploy_sensor(sensor_id, location_id, float(temperature))
        elif user_input.lower() == "6":
            location_id = input("Enter the location id: ")
            print(system.read_temperature(location_id))
        elif user_input.lower() == "7":
            old_sensor_id = input("Enter the old sensor id: ")
            new_sensor_id = input("Enter the new sensor id: ")
            system.replace_sensor(old_sensor_id, new_sensor_id)
        elif user_input.lower() == "8":
            sensor_id = input("Enter the sensor id: ")
            system.delete_sensor(sensor_id)
        elif user_input.lower() == "9":
            system.get_temperature_by_location()
        else:
            print("Invalid Input")
    
        input("Press Enter to continue...\n")
        print("--------------------------")
    
    # system.deploy_sensor("S1", "L1", 20)
    #
    # system.deploy_sensor("S2", "L2", 25)
    #
    # print(system.location_table)
    # print(system.temperature_table)
    #
    # print(system.read_temperature("L1"))
    # print(system.read_temperature("L2"))
    #
    # system.deploy_sensor("S1", "L3", 100) # Sensor already deployed
    # system.deploy_sensor("S3", "L1", 100)
    #
    # print(system.temperature_table.get_temperature("S1"))
