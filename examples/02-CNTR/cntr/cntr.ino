#include "cntr.h"
#include <Wire.h>
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
CNTU(5,CNTR0,CNTR0L,CNTR0D);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
Reset_O(CNTR0);
//end of loop ---------------
IO_Write();
}

