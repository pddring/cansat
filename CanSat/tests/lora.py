# Hardware: Raspberry pi pico on a pico explorer board
#       433MHz RFM9x LORA => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#					SCK   => SCLK (GP18)
#					MISO  => MISO (GP16)
#					MOSI  => MOSI (GP19)
#                   CS    => GP2
#                   RST   => GP3
# Firmware: CircuitPython 8
# Tests: Displaying text on the screen
# Success: Red text "CanSat test" at the top of the screen
#  with a white triangle, a yellow circle and green and blue rectangles

import board
import busio

import picoexplorer as display

spi_mosi = board.GP19
spi_clk = board.GP18


spi = display.spi
import digitalio
import adafruit_rfm9x
cs_lora = digitalio.DigitalInOut(board.GP2)
cs_lora.direction = digitalio.Direction.OUTPUT
cs_lora.value = False

cs_screen = digitalio.DigitalInOut(board.GP17)
cs_screen.direction = digitalio.Direction.OUTPUT
cs_screen.value = True
reset = digitalio.DigitalInOut(board.GP3)
rfm9x = adafruit_rfm9x.RFM9x(spi, cs_lora, reset, 433.0, baudrate=1000000)
#rfm9x.send('Hello world!')
