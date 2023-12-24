# Hardware: Raspberry pi pico on a pico explorer board
#   Ultimate GPS breakout => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#					RX    => GP0
#					TX	  => GP1
# Firmware: CircuitPython 8
# Tests: Displays GPS stats on screen
# Success: GPS status (red no fix, green fix found). Satellite count, time, pos and altitude

import picoexplorer as display
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
t = display.text("Connecting to GPS...", 0, 10, 0, 1)
t_fix = display.text("Fix: 0", 0, 30, 0, 1)
t_date = display.text("Date: Unknown", 0, 60, 0, 1)
t_lat = display.text("Latitude: Unknown", 0, 90, 0, 1)
t_lng = display.text("Longitude: Unknown", 0, 120, 0, 1)
t_alt = display.text("Altitude: Unknown", 0, 150, 0, 1)
while True:
    gps.update()
    if gps.has_fix:
        t_fix.color = 0x00FF00
    t_fix.text = "Fix: {} 3D: {} Satellites: {}".format(gps.fix_quality,
                                                        gps.fix_quality_3d,
                                                        gps.satellites)
    if gps.datetime:
        t_date.text = "Time: {}/{}/{} {}:{}:{}".format(gps.datetime.tm_mday,
                                                    gps.datetime.tm_mon,
                                                    gps.datetime.tm_year,
                                                    gps.datetime.tm_hour,
                                                    gps.datetime.tm_min,
                                                    gps.datetime.tm_sec)
    t_lat.text = "Latitude: {}".format(gps.latitude)
    t_lng.text = "Longitude: {}".format(gps.longitude)
    t_alt.text = "Altitude: {}".format(gps.altitude_m)
    time.sleep(0.5)
    