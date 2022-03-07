# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 2
int CNTR0;
bool CNTR0L;
bool CNTR0D;
//End Of Declaration ----------------
void setup() {

# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
    = 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
           | 0b01100000;

# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
    = 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 9 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
           | 0b00001110;

# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
    = 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 10 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\02-CNTR\\cntr\\cntr.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
NO_M(I0);
CNTU(5,CNTR0,CNTR0L,CNTR0D);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
Reset_O(CNTR0);
//end of loop ---------------
IO_Write();
}
