# Hardware: Raspberry pi pico 
#  BMP280 pressure sensor => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#				    SDA   => SDA (GP18)
#					SCL	  => SCL (GP19)
#       433MHz RFM9x LORA => Pico
# 					VIN	  => 3.3v (36)
#					GND	  => GND  (28)
#					SCK   => GP26 (31)
#					MISO  => GP28 (34)
#					MOSI  => GP27 (32)
#                   CS    => GP22 (29)
#                   RST   => GP21 (27)
#  BNO08x 9DoF IMU        => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#				    SDA   => SDA (GP18)
#					SCL	  => SCL (GP19)
#   Ultimate GPS breakout => Pico
# 					VIN	  => 3.3v
#					GND	  => GND
#					RX    => GP0
#					TX	  => GP1

# Firmware: CircuitPython 8
# Tests: Measures temperature, pressure and altitude and sends them via LoRa
# Success: Sends values to REPL and via LoRa. Flashes LED every second


import board
import adafruit_bmp280
import busio
import time
import digitalio
import adafruit_rfm9x
import power
import adafruit_gps
import logger
log = logger.LogWriter()
DELAY = 0.01
# set up GPS
uart = busio.UART(board.GP0, board.GP1, baudrate=9600, timeout=30)
gps = adafruit_gps.GPS(uart, debug=False)
# Turn on the basic GGA and RMC info (what you typically want)
gps.send_command(b"PMTK314,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0")
# Set update rate to once a second (1hz) which is what you typically want.
gps.send_command(b"PMTK220,1000")


# set up power shim for battery readings
p = power.Power()

# set up bmp sensor
PINS_BMP280 = {"sda": board.GP18, "scl": board.GP19}
i2c = busio.I2C(**PINS_BMP280)
sensor = adafruit_bmp280.Adafruit_BMP280_I2C(i2c, address=118)

# replace with local ground altitude
sensor.altitude = 0

# set up Inertial Measurement Unit
from adafruit_bno08x.i2c import BNO08X_I2C
from adafruit_bno08x import BNO_REPORT_ACCELEROMETER, BNO_REPORT_MAGNETOMETER
imu = BNO08X_I2C(i2c)
imu.enable_feature(BNO_REPORT_ACCELEROMETER)
imu.enable_feature(BNO_REPORT_MAGNETOMETER)

# set up LoRa
cs_lora = digitalio.DigitalInOut(board.GP22)
cs_lora.direction = digitalio.Direction.OUTPUT
cs_lora.value = False
reset_lora = digitalio.DigitalInOut(board.GP21)
spi_mosi = board.GP27
spi_clk = board.GP26
spi_miso = board.GP28
spi_lora = busio.SPI(spi_clk, MOSI=spi_mosi, MISO=spi_miso)
rfm9x = adafruit_rfm9x.RFM9x(spi_lora, cs_lora, reset_lora, 433.0, baudrate=5000000)
rfm9x.tx_power = 23

led = digitalio.DigitalInOut(board.LED)
led.direction = digitalio.Direction.OUTPUT
led.value = True
gps.satellites = 0
packet_count = 1
recording = 0

while True:
    data = rfm9x.receive()
    if data:
        if data == "B":
            log.start()
            recording = 1
        if data == "A":
            log.stop()
            recording = 0
    gps.update()
    msg = "Fix:{} 3D:{} Sat:{} P:{} R:{} T:{} ".format(gps.fix_quality,
                                             gps.fix_quality_3d,
                                             gps.satellites,
                                             packet_count,
                                             recording,
                                             time.monotonic())
    print(msg)
    rfm9x.send(msg)
    
    if recording:
        data = log.process_values(bytearray(msg))
        log.write(data)
    packet_count += 1
    time.sleep(DELAY)
    
    if gps.fix_quality > 0:
        msg = "Lat:{} Lng:{} GPSAlt:{} P:{} R:{} T:{} ".format(gps.latitude,
                                                     gps.longitude,
                                                     gps.altitude_m,
                                                     packet_count,
                                                     recording,
                                                     time.monotonic())
        print(msg)
        rfm9x.send(msg)
        if recording:
            data = log.process_values(bytearray(msg))
            log.write(data)
        packet_count += 1
    time.sleep(DELAY)
    
    msg = "Temp:{:.2f} Press:{:.2f} Alt:{:.2f} P:{} R:{} T:{} ".format(sensor.temperature,
                                                            sensor.pressure,
                                                            sensor.altitude,
                                                            packet_count,
                                                            recording,
                                                            time.monotonic())
    print(msg)
    rfm9x.send(msg)
    if recording:
        data = log.process_values(bytearray(msg))
        log.write(data)
    packet_count += 1
    time.sleep(DELAY)
    
    ax,ay,az = imu.acceleration
    msg = "AX:{:.3f} AY:{:.3f} AZ:{:.3f} P:{} R:{} T:{} ".format(ax, ay, az,
                                                            packet_count,
                                                            recording,
                                                            time.monotonic())
    print(msg)
    rfm9x.send(msg)
    if recording:
        data = log.process_values(bytearray(msg))
        log.write(data)
    packet_count += 1
    time.sleep(DELAY)
    
    mx,my,mz = imu.magnetic
    msg = "MX:{:.3f} MY:{:.3f} MZ:{:.3f} P:{} R:{} T:{} ".format(mx, my, mz,
                                                            packet_count,
                                                            recording,
                                                            time.monotonic())
    print(msg)
    rfm9x.send(msg)
    if recording:
        data = log.process_values(bytearray(msg))
        log.write(data)
    packet_count += 1
    time.sleep(DELAY)
    
    charging = 0
    if p.isCharging():
        charging = 1
    msg = "Batt:{} Char:{} P:{} R:{} T:{} ".format(p.getVoltage(), charging,
                                              packet_count,
                                              recording,
                                              time.monotonic())
    rfm9x.send(msg)
    if recording:
        data = log.process_values(bytearray(msg))
        log.write(data)
    packet_count += 1
    print(msg)
    
    time.sleep(DELAY)
    led.value = not led.value


