# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 2
int D0;
//End Of Declaration ----------------
void setup() {

# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
    = 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
           | 0b01100000;

# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
    = 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
           | 0b00001110;

# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
    = 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 8 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\10-Serial\\serial\\serial.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
NO_M(I0);
if (dugum){
D0 = 1000;
}
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
Serial.begin(9600);
Serial.print(D0, 10);
Serial.end();
//end of loop ---------------
IO_Write();
}
