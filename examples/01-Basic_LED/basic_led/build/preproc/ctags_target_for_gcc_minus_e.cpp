# 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 2
//End Of Declaration ----------------
void setup() {

# 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
    = 
# 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 5 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
           | 0b01100000;

# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
    = 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 6 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
           | 0b00001110;

# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
    = 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 7 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\01-Basic_LED\\basic_led\\basic_led.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
prl,next = false;

if(dugum) {prl = true;}
NO_M(I0);
if (prl) {dugum=true;}
NO_M(O0);
if (next) { dugum = true; }
prl,next = false;
NC_M(I1);
Coil_M(O0);
//New Network Start ---------------
dugum = true;
NO_M(I1);
Coil_M(O1);
//end of loop ---------------
IO_Write();
}
