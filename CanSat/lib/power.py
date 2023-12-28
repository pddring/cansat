import analogio
import digitalio
import board

# class to read from the lipo power shim
# available from https://thepihut.com/products/lipo-shim-for-pico
class Power:
    def __init__(self):
        # reads the system input voltage
        self.vsys = analogio.AnalogIn(board.VOLTAGE_MONITOR)				
        self.charging = digitalio.DigitalInOut(board.VBUS_SENSE)
        
        # reading GP24 tells us whether or not USB power is connected
        self.charging.direction = digitalio.Direction.INPUT
        
    def isCharging(self):
        return self.charging.value
    
    def getVoltage(self):
        return self.vsys.value * self.vsys.reference_voltage / 65535 * 2.938
