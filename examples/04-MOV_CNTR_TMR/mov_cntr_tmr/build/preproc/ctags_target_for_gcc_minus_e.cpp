# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 2
int D0;
int TON0;
int D1;
int CNTR0;
bool CNTR0L;
bool CNTR0D;
int D2;
int CNTR1;
bool CNTR1L;
bool CNTR1D;
//End Of Declaration ----------------
void setup() {

# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
    = 
# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
           | 0b01100000;

# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
    = 
# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
           | 0b00001110;

# 17 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 17 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
    = 
# 17 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 17 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\04-MOV_CNTR_TMR\\mov_cntr_tmr\\mov_cntr_tmr.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
NO_M(I0);
if (dugum){
D0 = 2500;
}
if (dugum){
D1 = 3;
}
//New Network Start ---------------
dugum = true;
NO_M(I1);
cON(D0, TON0);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I2);
CNTU(D1,CNTR0,CNTR0L,CNTR0D);
Coil_M(O1);
//New Network Start ---------------
dugum = true;
NO_M(I3);
if (dugum){
D2 = CNTR0;
}
//New Network Start ---------------
dugum = true;
NO_M(I4);
CNTU(D2,CNTR1,CNTR1L,CNTR1D);
Coil_M(O2);
//end of loop ---------------
IO_Write();
}
