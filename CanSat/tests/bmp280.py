# Hardware: Raspberry pi pico 
#  BMP280 pressure sensor => Pico
#                   VIN   => 3.3v
#                   GND   => GND
#                   SDA   => SDA (GP18)
#                   SCL   => SCL (GP19)
# Firmware: CircuitPython 8
# Tests: Displays pressure, temperature and altitude on screen
# Success: Sends values to REPL 

import board
import adafruit_bmp280
import busio
import time

i2c = busio.I2C(sda=board.GP18, scl=board.GP19)

sensor = adafruit_bmp280.Adafruit_BMP280_I2C(i2c, address=118)

# change to known starting altitude
print("Calibrating altitude")
sensor.altitude = 110
print("Sea level pressure: {} Altitude: {}".format(sensor.sea_level_pressure, sensor.altitude))

while True:
    print("Temp: {:.2f} Press: {:.2f} Alt {:.2f}".format(sensor.temperature, sensor.pressure, sensor.altitude))
    time.sleep(1)