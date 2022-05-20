#include <Arduino.h>
#line 1 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
#include "stf.h"
#include <Wire.h>
#line 3 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
void function1();
#line 15 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
void setup();
#line 21 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
void loop();
#line 3 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
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


