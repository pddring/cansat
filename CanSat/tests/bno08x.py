# Hardware: Raspberry pi pico on Pico explorer board
#  BNO08x 9DoF IMU        => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#				    SDA   => SDA (GP18)
#					SCL	  => SCL (GP19)
# Firmware: CircuitPython 8
# Tests: Measures temperature, pressure and altitude and sends them via LoRa
# Success: Sends values to REPL and via LoRa. Flashes LED every second


import board
import busio
import time
import digitalio
from adafruit_bno08x.i2c import BNO08X_I2C
from adafruit_bno08x import BNO_REPORT_ACCELEROMETER, BNO_REPORT_MAGNETOMETER


# set up bmp sensor
PINS_BNO = {"sda": board.GP18, "scl": board.GP19}
i2c = busio.I2C(**PINS_BNO)

imu = BNO08X_I2C(i2c)
imu.enable_feature(BNO_REPORT_ACCELEROMETER)
imu.enable_feature(BNO_REPORT_MAGNETOMETER)


led = digitalio.DigitalInOut(board.LED)
led.direction = digitalio.Direction.OUTPUT
led.value = True
if True:
    x,y,z = imu.acceleration
    msg = "AX:{} AY:{} AZ:{} ".format(x, y, z)
    print(msg)
    
    x,y,z = imu.magnetic
    msg = "MX:{} MY:{} MZ:{} ".format(x, y, z)
    print(msg)
    time.sleep(1)
    led.value = not led.value


