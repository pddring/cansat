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
# Firmware: CircuitPython 8
# Tests: Measures temperature, pressure and altitude and sends them via LoRa
# Success: Sends values to REPL and via LoRa. Flashes LED every second


import board
import adafruit_bmp280
import busio
import time
import digitalio
import adafruit_rfm9x

# set up bmp sensor
PINS_BMP280 = {"sda": board.GP18, "scl": board.GP19}
i2c = busio.I2C(**PINS_BMP280)
sensor = adafruit_bmp280.Adafruit_BMP280_I2C(i2c, address=118)

# set up LoRa
cs_lora = digitalio.DigitalInOut(board.GP22)
cs_lora.direction = digitalio.Direction.OUTPUT
cs_lora.value = False
reset_lora = digitalio.DigitalInOut(board.GP21)
spi_mosi = board.GP27
spi_clk = board.GP26
spi_miso = board.GP28
spi_lora = busio.SPI(spi_clk, MOSI=spi_mosi, MISO=spi_miso)
rfm9x = adafruit_rfm9x.RFM9x(spi_lora, cs_lora, reset_lora, 433.0, baudrate=1000000)

led = digitalio.DigitalInOut(board.LED)
led.direction = digitalio.Direction.OUTPUT
led.value = True
while True:
    msg = "Temp:{:.2f} Press:{:.2f} Alt:{:.2f} ".format(sensor.temperature, sensor.pressure, sensor.altitude)
    print(msg)
    rfm9x.send(msg)
    time.sleep(1)
    led.value = not led.value


