#include <Arduino.h>
#line 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
#include "adc_pwm.h"
#include <Wire.h>
int D0;
//End Of Declaration ----------------
#line 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
void setup();
#line 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
void loop();
#line 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
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


