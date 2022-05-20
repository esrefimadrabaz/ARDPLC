#include "stf.h"
#include <Wire.h>
int DK1;
void function1(){
	int pi = 3.14;
	int fval;
	if ((DK1>pi)) {
		DK1 = pi*DK1;
		}
	fval = 10*DK1/1024;
	I0 = true;
	I1 = false;
}
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
function1();

//end of loop ---------------
IO_Write();
}
