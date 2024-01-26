# Hardware: Raspberry pi pico on a pico explorer board
# Firmware: CircuitPython 8
# Tests: Displaying text on the screen
# Success: Red text "CanSat test" at the top of the screen

import picoexplorer as display
import busio
import board

class RGBEncoder:
    def __init__(self):
        print("Connecting")
        
rgb = RGBEncoder()
display.text("CanSat test", 0, 10, 0, 1)
i2c = busio.I2C(board.GP21, board.GP20)