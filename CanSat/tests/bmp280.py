# Hardware: Raspberry pi pico on a pico explorer board
#  BMP280 pressure sensor => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#				    SDA   => SDA (GP20)
#					SCL	  => SLC (GP21)
# Firmware: CircuitPython 8
# Tests: Displays pressure, temperature and altitude on screen
# Success: Sends values to REPL and displays them on screen


import board
import adafruit_bmp280
import busio
import time
import picoexplorer as display

PINS_PICO_EXPLORER = {"sda": board.GP20, "scl": board.GP21}

i2c = busio.I2C(**PINS_PICO_EXPLORER)

sensor = adafruit_bmp280.Adafruit_BMP280_I2C(i2c, address=118)
t_temp = display.text("Temperature: ", 0, 10, 0, 2)
t_pressure = display.text("Pressure: ", 0, 40, 0, 2)
t_altitude = display.text("Altitude: ", 0, 70, 0, 2)
while True:
    t_temp.text = "Temperature: {:.2f}'C".format(sensor.temperature)
    t_pressure.text = "Pressure: {:.2f}hPA".format(sensor.pressure)
    t_altitude.text = "Altitude: {:.2f}m".format(sensor.altitude)
    print("Temperature: {} Pressure: {} Altitude {}".format(sensor.temperature, sensor.pressure, sensor.altitude))
    time.sleep(1)

    