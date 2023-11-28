class SensorLocationTable:
    
    def __init__(self):
        self.data = {}
    
    def add_sensor_location(self, sensor, location):
        self.data[sensor] = location

    def replace_sensor_location(self, old_sensor, new_sensor, location):
        if old_sensor in self.data:
            del self.data[old_sensor]
            if new_sensor is not None:
                self.data[new_sensor] = location

    def delete_sensor_location(self, sensor):
        if sensor in self.data:
            del self.data[sensor]
        
    def get_location(self, sensor):
        return self.data.get(sensor)

    def get_sensor(self, location_id):
        for sensor, location in self.data.items():
            if location.get_location_id() == location_id:
                return sensor
        return None

    def is_covered(self, location_id):
        for key, value in self.data.items():
            if value.get_location_id() == location_id:
                return True
        return False

    def __str__(self):
        result = "SensorLocationTable:\n"
        for sensor, location in self.data.items():
            result += f"{sensor}\n-->\n{location}\n----------\n"
        return result

# location_registry = LocationRegistry()
# location1 = Location("L1", "Central Park")
# location2 = Location("L2", "Downtown Park")
# location_registry.add_location(location1)
# location_registry.add_location(location2)

# sensor_registry = SensorRegistry()
# sensor1 = Sensor("S1", False, False)
# sensor2 = Sensor("S2", False, False)
# sensor_registry.add_sensor(sensor1)
# sensor_registry.add_sensor(sensor2)

# sensor_location_table = SensorLocationTable(sensor_registry, location_registry)

# sensor_location_table.add_location("S1", "L1")
# sensor_location_table.add_location("S2", "L2")

# print(sensor_location_table)
# print(sensor_location_table.is_covered("L2"))
# sensor_location_table.delete_location("S2")

# print(sensor_location_table)
# print(sensor_location_table.is_covered("L2"))

# print(sensor_location_table)
