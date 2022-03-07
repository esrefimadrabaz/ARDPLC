# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 2
int D0;
//End Of Declaration ----------------
void setup() {

# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
    = 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
           | 0b01100000;

# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
    = 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
           | 0b00001110;

# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
    = 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\07-ADC_PWM\\adc_pwm\\adc_pwm.ino"
           | 0b00000000;
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
