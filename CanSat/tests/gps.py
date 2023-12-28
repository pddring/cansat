# Hardware: Raspberry pi pico 
#   Ultimate GPS breakout => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#					RX    => UART TX: GP0 (1)
#					TX	  => UART RX: GP1 (2)
# Firmware: CircuitPython 8
# Tests: Displays GPS stats on screen
# Success: GPS status (red no fix, green fix found). Satellite count, time, pos and altitude

import time
import time
import board
import busio
import adafruit_gps

uart = busio.UART(board.GP0, board.GP1, baudrate=9600, timeout=30)
gps = adafruit_gps.GPS(uart, debug=False)

# Turn on the basic GGA and RMC info (what you typically want)
gps.send_command(b"PMTK314,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0")

# Set update rate to once a second (1hz) which is what you typically want.
gps.send_command(b"PMTK220,1000")

# Main loop runs forever printing data as it comes in
timestamp = time.monotonic()
print("Connecting to GPS...")
while True:
    gps.update()
    print("Fix: {} 3D: {} Satellites: {}".format(gps.fix_quality,
                                                        gps.fix_quality_3d,
                                                        gps.satellites))
    if gps.datetime:
        print("Time: {}/{}/{} {}:{}:{}".format(gps.datetime.tm_mday,
                                                    gps.datetime.tm_mon,
                                                    gps.datetime.tm_year,
                                                    gps.datetime.tm_hour,
                                                    gps.datetime.tm_min,
                                                    gps.datetime.tm_sec))
    print("Latitude: {}".format(gps.latitude))
    print("Longitude: {}".format(gps.longitude))
    print("Altitude: {}".format(gps.altitude_m))
    time.sleep(0.5)
    
