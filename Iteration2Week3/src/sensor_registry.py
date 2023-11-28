from sensor import Sensor


class SensorRegistry:
    def __init__(self):
        self.sensors = []

    def add_sensor(self, sensor):
        try:
            if isinstance(sensor, Sensor):
                self.sensors.append(sensor)
            else:
                raise ValueError("Invalid sensor object. Only Sensor objects can be added to the registry.")
        except ValueError as e:
            print(f"Error: {e}")

    def delete_sensor(self, sensor):
        try:
            self.sensors.remove(sensor)
        except ValueError as e:
            print(f"Error: {e}")

    def get_sensor_by_id(self, sensor_id):
        for sensor in self.sensors:
            if sensor.sensor_id == sensor_id:
                return sensor
        return None

    def __str__(self):
        sensor_str = "\n\n".join(str(sensor) for sensor in self.sensors)
        return f"Sensor Registry:\n{sensor_str}\n"