#include "basic_led.h"
#include <Wire.h>
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

prl,next = false;
if(dugum) {prl = true;}
NO_M(I0);
if (prl)  {dugum=true;}
NO_M(O0);
if (next) { dugum = true; }

NC_M(I1);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
Coil_M(O1);
//end of loop ---------------
IO_Write();
}
