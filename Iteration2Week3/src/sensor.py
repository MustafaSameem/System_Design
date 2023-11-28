class Sensor:
    def __init__(self, sensor_id, deployed):
        self.sensor_id = sensor_id
        self.deployed = deployed

    def get_sensor_id(self):
        return self.sensor_id

    def set_sensor_id(self, new_id):
        self.sensor_id = new_id

    def is_deployed(self):
        return self.deployed

    def set_deployed(self, deployed_status):
        self.deployed = deployed_status

    def __str__(self):
        return f"Sensor ID: {self.sensor_id}\nDeployed: {'Yes' if self.is_deployed() else 'No'}\n"
