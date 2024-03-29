# Hardware: Raspberry pi pico with pico display
#       433MHz RFM9x LORA => Pico
#                   VIN   => 3.3v (36)
#                   GND   => GND  (28)
#                   SCK   => GP18  (4)
#                   MISO  => GP0  (6)
#                   MOSI  => GP19  (5)
#                   CS    => GP1  (2)
#                   RST   => GP2  (1)
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
import picoexplorer as display
display.display.auto_refresh = False
import logger
log = logger.LogWriter(debug=True)
recordingLocal = False
recordingRemote = False
updateScreen = True

def refreshScreen():
    if updateScreen:
        updateScreenLabel.color = 0x00FF00
        updateScreenLabel.text = "Display ACTIVE"
    else:
        updateScreenLabel.color = 0xFF0000
        updateScreenLabel.text = "DISPLAY INACTIVE"

    cs_lora.value = True
    display.display.refresh()
    cs_lora.value = False
    
#spi_mosi = board.GP3
#spi_clk = board.GP2
#spi_miso = board.GP4
#spi_lora = busio.SPI(spi_clk, MOSI=spi_mosi, MISO=spi_miso)
cs_lora = digitalio.DigitalInOut(board.GP1)
cs_lora.direction = digitalio.Direction.OUTPUT
cs_lora.value = False
reset_lora = digitalio.DigitalInOut(board.GP2)
rfm9x = adafruit_rfm9x.RFM9x(display.spi, cs_lora, reset_lora, 433.0, baudrate=5000000)
rfm9x.tx_power = 23
print("Started")
display.rectangle(0, 0, 240, 240, 0x0000FF)
display.rectangle(0, 0, 240, 20, 0xFFFFFF)
indicator = display.rectangle(0, 230, 240, 10, 0xFF0000)
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
    "GPSAlt": display.text("GPSAlt: ", 10, 160, 0, 1),
    "Sat": display.text("Sat: ", 180, 30, 0, 1),
    "Lat": display.text("Lat: ", 0, 40, 0, 1),
    "Lng": display.text("Lng: ", 100, 40, 0, 1),
    "P": display.text("P: 0", 140, 5, 0, 1),
    "T": display.text("T: 0", 140, 15, 0, 1),
    "RSSI": display.text("RSSI: 0", 0, 140, 0, 2)
    }
updateScreenLabel = display.text("Display ACTIVE", 0, 180, 0, 2)
indicator.fill = 0x000000

while True:
    text = "CanSat:["
    if recordingLocal:
        text += "L"
    else:
        text += "!"
    if recordingRemote:
        text += "R"
    else:
        text += "!"
    text += "]"
    for b in display.buttons:
        if display.buttons[b].value == False:
            if b == "B":
                recordingLocal = True
                log.start()
            elif b == "A":
                recordingLocal = False
                log.stop()
            elif b == "Y":
                updateScreen = True
                refreshScreen()
            elif b == "X":
                updateScreen = False
                refreshScreen()
            text += b
            indicator.fill = 0x100000
            rfm9x.send(b)
            indicator.fill = 0x000000
            
    text_title.text = text
    data = rfm9x.receive()
    strength = rfm9x.rssi
    labels["RSSI"].text = "RSSI: {} dB".format(strength)
    print("RSSI: {} ". format(strength))
    
    if data:
        indicator.fill = 0x00FF00        
        values = log.process_values(data)
        if recordingLocal:
            log.write(values)
        for label in values:
            if label in labels:
                msg = "{}: {}".format(label, values[label])
                labels[label].text = msg
                print(msg)
            else:
                if label == "R":
                    recordingRemote = values[label]
                    msg = "{}: {}".format(label, values[label])
                    print(msg)
                else:
                    print("Unknown value:", label, values[label])
    else:
        indicator.fill = 0x000000
    
    
    if updateScreen:
        refreshScreen()