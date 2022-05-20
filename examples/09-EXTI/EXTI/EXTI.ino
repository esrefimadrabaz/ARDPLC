#include "EXTI.h"
#include <Wire.h>
bool M0;
bool M1;
bool M2;
int D0;
//End Of Declaration ----------------
void setup() {
DDRD = DDRD | 0b01100000;
DDRB = DDRB | 0b00001110;
DDRC = DDRC | 0b00000000;
attachInterrupt(0,EXTI0,RISING);
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
//New Network Start ---------------
dugum = true;
NO_M(I1);
CMP(D0,30,M0,M1,M2);
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
//New Network Start ---------------
dugum = true;
NO_M(I2);
if (dugum){
D0 = 0;
}
//end of loop ---------------
IO_Write();
}
void EXTI0(){
dugum = true;
if (dugum){
D0 = (D0)+(1);
}
//New Network Start ---------------
dugum = true;

}

