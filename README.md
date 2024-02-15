# Fulford Interstellar Robotics & Space Team CanSat
This is the code for all of the subprojects linked to the FIRST CanSat project

There are three sub projects within CanSat:
![image](https://github.com/pddring/cansat/assets/760604/12ae0549-d2b8-4834-bc62-eb3a570ad290)

CanSat is a Raspberry Pi Pico project that will be launched up in a rocket and descend with a parachute whilst transmitting sensor values.
GroundStation is another Raspberry Pi Pico project that will receive the sensor values and feed them into a laptop.
Visualiser is the desktop application that will run on the laptop to visualise all of the sensor data.


## CanSat
CanSat a drinks can sized satellite that uses a raspberry pi pico to transmit live measurements after being launched by a rocket whilst it descends using a parachute.

### Instructions:
1) Download the CircuitPython raspberry pi pico firmware from: https://circuitpython.org/board/raspberry_pi_pico/

2) Hold down the bootsel button on the raspberry pi pico and connect the USB cable. Copy the .uf2 firmware to the usb drive that will appear

3) The pico will restart when the firmware has copied. You will then see a drive called CIRCUITPY

4) Copy all the code in the CanSat folder from this repository into the CanSat drive

