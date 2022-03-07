# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 2
int D0;
int D1;
bool M0;
bool M1;
bool M2;
//End Of Declaration ----------------
void setup() {

# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
    = 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
           | 0b01100000;

# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
    = 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 11 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
           | 0b00001110;

# 12 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 12 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
    = 
# 12 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 12 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.ino"
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
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(M1);
Coil_M(O1);
//New Network Start ---------------
dugum = true;
NO_M(M2);
Coil_M(O2);
//end of loop ---------------
IO_Write();
}
