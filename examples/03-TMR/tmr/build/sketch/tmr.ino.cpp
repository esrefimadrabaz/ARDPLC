#include <Arduino.h>
#line 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
#include "tmr.h"
#include <Wire.h>
int TON0;
int TOFF0;
int TRO0;
bool TRB0;
//End Of Declaration ----------------
#line 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
void setup();
#line 14 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
void loop();
#line 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
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
cON(2000, TON0);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
cOFF(2000, TOFF0);
Coil_M(O1);
//New Network Start ---------------
dugum = true;
NO_M(I2);
cRTO(5000, TRO0, TRB0);
Coil_M(O2);
//New Network Start ---------------
dugum = true;
NO_M(I3);
Reset_T(TON0);
//New Network Start ---------------
dugum = true;
NO_M(I3);
Reset_O(TOFF0);
//New Network Start ---------------
dugum = true;
NO_M(I3);
Reset_T(TRO0);
//end of loop ---------------
IO_Write();
}


