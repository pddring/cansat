# Hardware: Raspberry pi pico with pico display
#       433MHz RFM9x LORA => Pico
# 					VIN	  => 3.3v (36)
#					GND	  => GND  (28)
#					SCK   => GP26 (31)
#					MISO  => GP28 (34)
#					MOSI  => GP27 (32)
#                   CS    => GP22 (29)
#                   RST   => GP21 (27)
# Firmware: CircuitPython 8
# Tests: Displaying text on the screen
# Success: LoRa sends X,Y A or B when you press corresponding button
#          RGB light should flash red on send
#          If data received, message should appear on screen and led flash green

import board
import busio
import adafruit_rfm9x
import time
import digitalio
import picodisplay as display

spi_mosi = board.GP27
spi_clk = board.GP26
spi_miso = board.GP28
spi_lora = busio.SPI(spi_clk, MOSI=spi_mosi, MISO=spi_miso)
cs_lora = digitalio.DigitalInOut(board.GP22)
cs_lora.direction = digitalio.Direction.OUTPUT
cs_lora.value = False
reset_lora = digitalio.DigitalInOut(board.GP21)
rfm9x = adafruit_rfm9x.RFM9x(spi_lora, cs_lora, reset_lora, 433.0, baudrate=1000000)
print("Started")
display.rectangle(0, 0, 240, 135, 0x0000FF)
display.rectangle(0, 0, 240, 20, 0xFFFFFF)
text = "CanSat:"
text_title = display.text(text, 0, 10, 0, 2)
text_acceleration = display.text("Acceleration:", 0, 80, 0, 1)
text_magnetic = display.text("Magnetic:", 0, 100, 0, 1)
labels = {
    "Temp": display.text("Temperature: ", 0, 50, 0, 1),
    "Press": display.text("Pressure: ", 0, 60, 0, 1),
    "Alt": display.text("Altitude: ", 0, 70, 0, 1),
    "AX": display.text("X: ", 10, 90, 0, 1),
    "AY": display.text("Y: ", 90, 90, 0, 1),
    "AZ": display.text("Z: ", 170, 90, 0, 1),
    "MX": display.text("X: ", 10, 110, 0, 1),
    "MY": display.text("Y: ", 90, 110, 0, 1),
    "MZ": display.text("Z: ", 170, 110, 0, 1),
    "Batt": display.text("Battery: ", 0, 120, 0, 1),
    "Char": display.text("Charging: ", 120, 120, 0, 1),
    "Fix": display.text("Fix: ", 0, 30, 0, 1),
    "3D": display.text("3D: ", 100, 30, 0, 1),
    "Sat": display.text("Sat: ", 200, 30, 0, 1),
    "Lat": display.text("Lat: ", 0, 40, 0, 1),
    "Lng": display.text("Lng: ", 100, 40, 0, 1),
    "P": display.text("P: 0", 140, 10, 0, 2)
    }
display.set_rgb(0, 0, 0)

# convert a bytearray received from LoRa to a dictionary of values
# byte array must be a string formatted like this: "Temp:10.4 Alt: 34.2 "
# notice the colon before the value and the space after it
def process_data(rx):
    s = ""
    label = ""
    values = {}
    for b in rx:
        c = chr(b)
        s += c
        if c == ":":
            label = s[0:-1]
            s = ""
        if c == " ":
            try:
                value = float(s)
                values[label] = value
                s = ""
            except:
                print("Could not read", label)
    return values
        
while True:
    text = "CanSat: "
    for b in display.buttons:
        if display.buttons[b].value == False:
            text += b
            display.set_rgb(10, 0, 0)
            rfm9x.send(b)
            display.set_rgb(0, 0, 0)
            
    text_title.text = text
    data = rfm9x.receive()
    
    if data:
        display.set_rgb(0, 10, 0)
        values = process_data(data)
        for label in values:
            if label in labels:
                msg = "{}: {}".format(label, values[label])
                labels[label].text = msg
                print(msg)
            else:
                print("Unknown value:", label, values[label])
    else:
        display.set_rgb(0, 0, 0)