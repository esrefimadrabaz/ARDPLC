#include "adc_pwm.h"
#include <Wire.h>
int D0;
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
ADC_Alt(A0,D0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
PWM(0,D0);
//end of loop ---------------
IO_Write();
}

