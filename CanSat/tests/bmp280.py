# Hardware: Raspberry pi pico 
#  BMP280 pressure sensor => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#				    SDA   => SDA (GP18)
#					SCL	  => SCL (GP19)
# Firmware: CircuitPython 8
# Tests: Displays pressure, temperature and altitude on screen
# Success: Sends values to REPL and displays them on screen


import board
import adafruit_bmp280
import busio
import time


PINS_PICO_EXPLORER = {"sda": board.GP18, "scl": board.GP19}

i2c = busio.I2C(**PINS_PICO_EXPLORER)

sensor = adafruit_bmp280.Adafruit_BMP280_I2C(i2c, address=118)
while True:
    print("Temp: {:.2f} Press: {:.2f} Alt {:.2f}".format(sensor.temperature, sensor.pressure, sensor.altitude))
    time.sleep(1)