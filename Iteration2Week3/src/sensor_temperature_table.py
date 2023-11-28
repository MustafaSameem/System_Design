from temperature import Temperature


class SensorTemperatureTable:
    def __init__(self):
        self.data = {}

    def add_sensor_temperature(self, sensor, temperature):
        temperature = Temperature(temperature)
        self.data[sensor] = temperature

    def replace_sensor_temperature(self, old_sensor, new_sensor, temperature):
        if old_sensor in self.data:
            del self.data[old_sensor]
            if new_sensor is not None:
                self.data[new_sensor] = temperature

    def delete_sensor_temperature(self, sensor):
        if sensor in self.data:
            del self.data[sensor]

    def get_temperature(self, sensor):
        return self.data.get(sensor)

    def __str__(self):
        result = "SensorTemperatureTable:\n"
        for sensor, temperature in self.data.items():
            result += f"{sensor}\n-->\n{temperature.get_temperature()}\n----------\n"
        return result
