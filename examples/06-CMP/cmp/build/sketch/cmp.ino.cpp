#include <Arduino.h>
#line 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
#include "cmp.h"
#include <Wire.h>
int D0;
int D1;
bool M0;
bool M1;
bool M2;
//End Of Declaration ----------------
#line 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
void setup();
#line 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
void loop();
#line 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
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
D0 = 15;
}
if (dugum){
D1 = 10;
}
//New Network Start ---------------
dugum = true;
NO_M(I1);
CMP(D0,D1,M0,M1,M2);
//New Network Start ---------------
dugum = true;
NO_M(M0);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(M1);
Coil_M(O1);
//New Network Start ---------------
dugum = true;
NO_M(M2);
Coil_M(O2);
//end of loop ---------------
IO_Write();
}


