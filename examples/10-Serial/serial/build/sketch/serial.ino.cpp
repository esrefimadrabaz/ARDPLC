#include <Arduino.h>
#line 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
#include "serial.h"
#include <Wire.h>
int D0;
//End Of Declaration ----------------
#line 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
void setup();
#line 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
void loop();
#line 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
void setup() {
DDRD = DDRD | 0b01100000;
DDRB = DDRB | 0b00001110;
DDRC = DDRC | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
NO_M(I0);
if (dugum){
D0 = 1000;
}
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
Serial.begin(9600);
Serial.print(D0, DEC);
Serial.end();
//end of loop ---------------
IO_Write();
}


