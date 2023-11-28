class Temperature:
    def __init__(self, value):
        self.value = value

    def get_temperature(self):
        return self.value

    def set_temperature(self, new_value):
        self.value = new_value

    def __str__(self):
        return f"{self.value}°C"
