# Hardware: Raspberry pi pico
# pico display plugged in underneath pico: https://shop.pimoroni.com/products/pico-display-pack?variant=32368664215635
# power shim soldered between pico and display: https://shop.pimoroni.com/products/lipo-shim?variant=23979864391
# Firmware: CircuitPython 8
# Tests: Displaying text on the screen
# Success: Charging and power status

import picodisplay as display
import power
import time
p = power.Power()
display.rectangle(0, 0, 240, 30, fill=0x00FF00)
display.rectangle(0, 30, 240, 210, fill=0x0000FF)
text_p = display.text("Power: ", 0, 10, 0, 2)
while True:
    text_p.text = "Power: {}v".format(p.getVoltage())
    if p.isCharging():
        display.set_rgb(10, 0, 0)
    else:
        display.set_rgb(0, 0, 0)
    time.sleep(0.5)
