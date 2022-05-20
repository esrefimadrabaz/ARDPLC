# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 2
bool M0;
bool M1;
bool M2;
int D0;
//End Of Declaration ----------------
void setup() {

# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
    = 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
           | 0b01100000;

# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
    = 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
           | 0b00001110;

# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
    = 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\09-EXTI\\EXTI\\EXTI.ino"
           | 0b00000000;
attachInterrupt(0,EXTI0,3);
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
