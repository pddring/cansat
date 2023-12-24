import board
import busio
import displayio
from adafruit_display_text import label
from adafruit_st7789 import ST7789
import terminalio
from adafruit_display_shapes.rect import Rect
from adafruit_display_shapes.triangle import Triangle
from adafruit_display_shapes.circle import Circle

class Enum:
    pass
class Button(Enum):
    BUTTON_A = 0
    BUTTON_B = 1
    BUTTON_X = 3
    BUTTON_Y = 4

class ADC(Enum):
    ADC0 = 0
    ADC1 = 1
    ADC2 = 2

class Motor(Enum):
    MOTOR1 = 0
    MOTOR2 = 1

class Motion(Enum):
    FORWARD = 0
    REVERSE = 1
    STOP = 2

class GP(Enum):
    GP0 = 0
    GP1 = 1
    GP2 = 2
    GP3 = 3
    GP4 = 4
    GP5 = 5
    GP6 = 6
    GP7 = 7

def get_width() -> int:
    return 240

def get_height() -> int:
    return 240

def init(buffer: bytearray) -> None:
    pass

def get_adc(adc: ADC) -> int:
    pass

def update() -> None:
    pass

def is_pressed(button: Button) -> bool:
    pass

def set_motor(motor: Motor, motion: Motion, speed: float = 0.0):
    pass

def set_pen(r: int, g: int, b: int):
    pass

def clear() -> None:
    pass

def pixel(x: int, y: int) -> None:
    pass

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
