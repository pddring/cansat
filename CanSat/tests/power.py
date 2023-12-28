# Hardware: Raspberry pi pico with power shim
# Firmware: CircuitPython 8
# Tests: Displaying text on the screen
# Success: LoRa sends X,Y A or B when you press corresponding button
#          RGB light should flash red on send
#          If data received, message should appear on screen and led flash green
import power
import time
p = power.Power()
while True:
    print(p.getVoltage())
    time.sleep(0.1)
print("Done")