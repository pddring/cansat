# this uses circuitpython rather than micropython

import board
import adafruit_bmp280
import busio
import time

PINS_PICO_EXPLORER = {"sda": board.GP20, "scl": board.GP21}

i2c = busio.I2C(**PINS_PICO_EXPLORER)

sensor = adafruit_bmp280.Adafruit_BMP280_I2C(i2c, address=118)
while True:
    print("Temperature: {} Pressure: {} Altitude {}".format(sensor.temperature, sensor.pressure, sensor.altitude))
    time.sleep(1)
