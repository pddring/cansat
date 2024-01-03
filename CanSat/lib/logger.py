class LogWriter:
    def __init__(self, debug=False):
        self.files = {
            "imu_acc":None,
            "imu_mag":None,
            "bmp":None,
            "gps_stats":None,
            "gps_pos":None,
            "battery": None
            }
        self.debug = debug
        self.columns = {
            "imu_acc": ["P", "AX", "AY", "AZ"],
            "imu_mag": ["P", "MX", "MY", "MZ"],
            "bmp": ["P", "Temp", "Press", "Alt"],
            "gps_stats": ["P", "Fix", "3D", "Sat"],
            "gps_pos": ["P", "Lat", "Lng", "GPSAlt"],
            "battery": ["P", "Batt", "Char"]
        }
        
    def getFileName(self, values):
        filename = ""
        for file in self.columns:
            match = True
            for valueName in values:
                if valueName not in self.columns[file]:
                    match = False
                    break
            if match:
                return file
    
    def write(self, values):
        file = self.getFileName(values)
        if file:
            self.files[file].write("\n")
            for col in self.columns[file]:
                self.files[file].write("{},".format(values[col]))

    
    def start(self):
        self.stop()    
        if self.debug: print("Starting")
        for file in self.files:
            if self.debug: print("Opening", file + ".csv")
            self.files[file] = open(file + ".csv", "w")
            for col in self.columns[file]:
                self.files[file].write(col + ",")
        
    def stop(self):
        for file in self.files:
            if self.files[file]:
                if self.debug: print("Closing file", file)
                self.files[file].close()
                self.files[file] = None
                
if __name__ == "__main__":
    log = LogWriter()
    log.start()
    print("Testing")
    values = {"P": 1, "Batt": 3.7, "Char": 0.0}
    log.write(values)
    log.stop()