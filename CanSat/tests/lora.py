# Hardware: Raspberry pi pico 
#       433MHz RFM9x LORA => Pico
# 					VIN	  => 3.3v (36)
#					GND	  => GND  (28)
#					SCK   => GP26 (31)
#					MISO  => GP28 (34)
#					MOSI  => GP27 (32)
#                   CS    => GP22 (29)
#                   RST   => GP21 (27)
#       Pico display => Pico (underneath, all pins)               
# Firmware: CircuitPython 8
# Tests: Displaying text on the screen
# Success: LoRa sends X,Y A or B when you press corresponding button
#          RGB light should flash red on send
#          If data received, message should appear on screen and led flash green

import board
import busio
import digitalio
import adafruit_rfm9x
import picodisplay as display
import time

spi_mosi = board.GP27
spi_clk = board.GP26
spi_miso = board.GP28
spi_lora = busio.SPI(spi_clk, MOSI=spi_mosi, MISO=spi_miso)
cs_lora = digitalio.DigitalInOut(board.GP22)
cs_lora.direction = digitalio.Direction.OUTPUT
cs_lora.value = False
reset_lora = digitalio.DigitalInOut(board.GP21)
rfm9x = adafruit_rfm9x.RFM9x(spi_lora, cs_lora, reset_lora, 433.0, baudrate=1000000)

title = display.text("LoRa", 0, 10, 0, 2)
instructions = display.text("Press X,Y,A or B to send", 0, 30, 0, 1)
rx = display.text("RX:", 0, 50, 0, 1)
while True:
    for b in ["X", "Y", "A", "B"]:
        if display.buttons[b].value == False:
            display.set_rgb(10, 0, 0)
            title.text = "LoRa: " + b
            rfm9x.send(b)
    data = rfm9x.receive()
    if data:
        rx.text = "RX: {}".format(data)
        display.set_rgb(0, 10, 0)
    time.sleep(0.1)
    display.set_rgb(0, 0, 0)
    title.text = "LoRa"