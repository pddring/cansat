# Hardware: Raspberry pi pico 
#       433MHz RFM9x LORA => Pico
# 					VIN	  => 3.3v (36)
#					GND	  => GND  (28)
#					SCK   => GP26 (31)
#					MISO  => GP28 (34)
#					MOSI  => GP27 (32)
#                   CS    => GP22 (29)
#                   RST   => GP21 (27)
# Firmware: CircuitPython 8
# Tests: Displays all received messages via REPL
# Success: Any received messages should be displayed as a string on the REPL
import board
import busio
import adafruit_rfm9x
import digitalio
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
print("Started")

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
    data = rfm9x.receive()
    
    if data:
        values = process_data(data)
        for label in values:
            msg = "{}: {}".format(label, values[label])
            print(msg)
    time.sleep(0.1)