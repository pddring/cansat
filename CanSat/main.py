# Water quality sensor
# Designed for use with a pico explorer board and a TDS sensor attached to ADC0

import machine
import time
from breakout_bmp280 import BreakoutBMP280
from pimoroni_i2c import PimoroniI2C
from picographics import PicoGraphics, DISPLAY_PICO_EXPLORER, PEN_P8

# set up screen
display = PicoGraphics(display=DISPLAY_PICO_EXPLORER, pen_type=PEN_P8)
display.set_backlight(1.0)
WIDTH, HEIGHT = display.get_bounds()

# set up sensors
PINS_PICO_EXPLORER = {"sda": 20, "scl": 21}
i2c = PimoroniI2C(**PINS_PICO_EXPLORER)
bmp = BreakoutBMP280(i2c)

BLACK = display.create_pen(0,0,0)
WHITE = display.create_pen(255,255,255)

while True:
    display.set_pen(BLACK)
    display.clear()
    temperature,pressure = bmp.read()

    display.set_pen(WHITE)
    display.text("Temp: {}'C Pressure: {}".format(temperature, pressure), 0, 0, 0, 3)
    display.update()
    time.sleep(1.0)
