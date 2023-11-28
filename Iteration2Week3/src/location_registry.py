from location import Location


class LocationRegistry:
    def __init__(self):
        self.locations = []

    def add_location(self, location):
        try:
            if isinstance(location, Location):
                self.locations.append(location)
            else:
                raise ValueError("Invalid location object. Only Location objects can be added to the registry.")
        except ValueError as e:
            print(f"Error: {e}")

    def get_location_by_id(self, location_id):
        for location in self.locations:
            if location.location_id == location_id:
                return location
        return None

    def does_exist(self, location_id):
        return not self.get_location_by_id(location_id) is None

    def __str__(self):
        location_str = "\n\n".join(str(location) for location in self.locations)
        return f"Location Registry:\n{location_str}\n"