#include "arith.h"
#include <Wire.h>
int D0;
int D1;
int CNTR0;
bool CNTR0L;
bool CNTR0D;
int TON0;
bool M0;
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
D0 = (1)+(2);
}
if (dugum){
D1 = (1000)+(1500);
}
//New Network Start ---------------
dugum = true;
NO_M(I1);
CNTU(D0,CNTR0,CNTR0L,CNTR0D);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I2);
cON(D1, TON0);
Coil_M(M0);
//New Network Start ---------------
dugum = true;
NO_M(M0);
Coil_M(O1);
//end of loop ---------------
IO_Write();
}

