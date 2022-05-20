# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 2
int D0;
int D1;
bool M0;
bool M1;
bool M2;
int D2;
int CNTR0;
bool CNTR0L;
bool CNTR0D;
//End Of Declaration ----------------
void setup() {

# 14 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 14 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
    = 
# 14 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 14 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
           | 0b01100000;

# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
    = 
# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 15 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
           | 0b00001110;

# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
    = 
# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 16 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
NO_M(I0);
if (dugum){
D0 = 15;
}
if (dugum){
D1 = 10;
}
//New Network Start ---------------
dugum = true;
NO_M(I1);
CMP(D0,D1,M0,M1,M2);
//New Network Start ---------------
dugum = true;
NO_M(M0);
if (dugum){
D2 = 5;
}
//New Network Start ---------------
dugum = true;
NO_M(M1);
if (dugum){
D2 = 4;
}
//New Network Start ---------------
dugum = true;
NO_M(M2);
if (dugum){
D2 = 3;
}
//New Network Start ---------------
dugum = true;
NO_M(I2);
CNTU(D2,CNTR0,CNTR0L,CNTR0D);
Coil_M(O0);
//end of loop ---------------
IO_Write();
}
