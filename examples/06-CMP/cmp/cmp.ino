#include "cmp.h"
#include <Wire.h>
int D0;
int D1;
bool M0;
bool M1;
bool M2;
int D2;
int CNTR0;
bool CNTR0L;
bool CNTR0D;
//End Of Declaration ----------------
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
if (dugum){
D2 = 5;
}
//New Network Start ---------------
dugum = true;
NO_M(M1);
if (dugum){
D2 = 4;
}
//New Network Start ---------------
dugum = true;
NO_M(M2);
if (dugum){
D2 = 3;
}
//New Network Start ---------------
dugum = true;
NO_M(I2);
CNTU(D2,CNTR0,CNTR0L,CNTR0D);
Coil_M(O0);
//end of loop ---------------
IO_Write();
}

