class Location:
    def __init__(self, location_id, location_name):
        self.location_id = location_id
        self.location_name = location_name

    def get_location_id(self):
        return self.location_id

    def set_location_id(self, new_id):
        self.location_id = new_id

    def get_location_name(self):
        return self.location_name

    def set_location_name(self, new_name):
        self.location_name = new_name

    def __str__(self):
        return f"Location ID: {self.location_id}\nLocation Name: {self.location_name}"