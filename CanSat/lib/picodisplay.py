import board
import busio
import digitalio
import displayio
import pwmio
import time
from adafruit_display_text import label
from adafruit_st7789 import ST7789
import terminalio
from adafruit_display_shapes.rect import Rect
from adafruit_display_shapes.triangle import Triangle
from adafruit_display_shapes.circle import Circle

def rectangle(x1: int, y1: int, width: int, height: int, fill=None, outline=None, stroke=None):
    r = Rect(x1, y1, width, height, fill=fill, outline=outline, stroke=stroke)
    splash.append(r)
    return r

def triangle(x1, y1, x2, y2, x3, y3, fill=None, outline=None):
    t = Triangle(x1, y1, x2, y2, x3, y3, fill=fill, outline=outline)
    splash.append(t)
    return t

def circle(x, y, r, fill=None, outline=None, stroke=1):
    c = Circle(x, y, r, fill=fill, outline=outline, stroke=stroke)
    splash.append(c)
    return c

def text(text: str, x: int, y: int, wrap: int, scale:int):
    # Draw a label
    text_group = displayio.Group(scale=scale, x=x, y=y)
    text = text
    text_area = label.Label(terminalio.FONT, text=text, color=0xFF0000)
    text_group.append(text_area)  # Subgroup for text scaling
    splash.append(text_group)
    return text_area    

# set up display
displayio.release_displays()
tft_cs = board.GP17
tft_dc = board.GP16
spi_mosi = board.GP19
spi_clk = board.GP18
spi = busio.SPI(spi_clk, MOSI=spi_mosi)
try:
    from fourwire import FourWire
except ImportError:
    from displayio import FourWire

display_bus = FourWire(spi, command=tft_dc, chip_select=tft_cs)

display = ST7789(display_bus, width=240, height=135, rowstart=40, colstart=53, rotation=90)
splash = displayio.Group()
display.root_group = splash

color_bitmap = displayio.Bitmap(240, 135, 1)
color_palette = displayio.Palette(1)
color_palette[0] = 0x000000  # Black

bg_sprite = displayio.TileGrid(color_bitmap, pixel_shader=color_palette, x=0, y=0)
splash.append(bg_sprite)

# set up buttons
buttons = {
    "A": digitalio.DigitalInOut(board.GP12),
    "B": digitalio.DigitalInOut(board.GP13),
    "X": digitalio.DigitalInOut(board.GP14),
    "Y": digitalio.DigitalInOut(board.GP15)
    }

leds = {
    "R": pwmio.PWMOut(board.GP6),
    "G": pwmio.PWMOut(board.GP7),
    "B": pwmio.PWMOut(board.GP8)
    }

def set_rgb(r, g, b):
    r = min(max(0, r), 255)
    g = min(max(0, g), 255)
    b = min(max(0, b), 255)
    leds["R"].duty_cycle = 65535 - (r * 255)
    leds["G"].duty_cycle = 65535 - (g * 255)
    leds["B"].duty_cycle = 65535 - (b * 255)

set_rgb(0, 0, 0)

for b in buttons:
    buttons[b].direction = digitalio.Direction.INPUT
    buttons[b].pull = digitalio.Pull.UP

if __name__ == "__main__":
    r = rectangle(0, 0, 240, 135, 0xFFFF00)
    t = text("Buttons: ", 0, 10, 0, 2)
    
    while True:
        s = ""
        time.sleep(0.5)
        for b in buttons:
            if buttons[b].value == False:
                s += b
        t.text = "Buttons: " + s
