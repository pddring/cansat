import board
import busio
import displayio
from adafruit_display_text import label
from adafruit_st7789 import ST7789
import terminalio
from adafruit_display_shapes.rect import Rect
from adafruit_display_shapes.triangle import Triangle
from adafruit_display_shapes.circle import Circle
import digitalio
# set up buttons
buttons = {
    "A": digitalio.DigitalInOut(board.GP12),
    "B": digitalio.DigitalInOut(board.GP13),
    "X": digitalio.DigitalInOut(board.GP14),
    "Y": digitalio.DigitalInOut(board.GP15)
    }
for b in buttons:
    buttons[b].direction = digitalio.Direction.INPUT
    buttons[b].pull = digitalio.Pull.UP

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

displayio.release_displays()
tft_cs = board.GP17
tft_dc = board.GP16
spi_mosi = board.GP19
spi_clk = board.GP18
spi = busio.SPI(spi_clk, spi_mosi)
try:
    from fourwire import FourWire
except ImportError:
    from displayio import FourWire

display_bus = FourWire(spi, command=tft_dc, chip_select=tft_cs)

display = ST7789(display_bus, width=240, height=240, rowstart=80, rotation=180)
splash = displayio.Group()
display.root_group = splash

color_bitmap = displayio.Bitmap(240, 240, 1)
color_palette = displayio.Palette(1)
color_palette[0] = 0x000000  # Black

bg_sprite = displayio.TileGrid(color_bitmap, pixel_shader=color_palette, x=0, y=0)
splash.append(bg_sprite)
