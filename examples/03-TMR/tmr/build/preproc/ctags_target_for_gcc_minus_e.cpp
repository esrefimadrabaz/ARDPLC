# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 2
int TON0;
int TOFF0;
int TRO0;
bool TRB0;
//End Of Declaration ----------------
void setup() {

# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
    = 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
           | 0b01100000;

# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
    = 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
           | 0b00001110;

# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
    = 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\03-TMR\\tmr\\tmr.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
NO_M(I0);
cON(2000, TON0);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
cOFF(2000, TOFF0);
Coil_M(O1);
//New Network Start ---------------
dugum = true;
NO_M(I2);
cRTO(5000, TRO0, TRB0);
Coil_M(O2);
//New Network Start ---------------
dugum = true;
NO_M(I3);
Reset_T(TON0);
//New Network Start ---------------
dugum = true;
NO_M(I3);
Reset_O(TOFF0);
//New Network Start ---------------
dugum = true;
NO_M(I3);
Reset_T(TRO0);
//end of loop ---------------
IO_Write();
}
