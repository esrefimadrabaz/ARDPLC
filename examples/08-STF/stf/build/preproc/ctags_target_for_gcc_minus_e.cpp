# 1 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
# 2 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 2
# 3 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 2
void function1(){
 int pi = 3.14;
 int fval;
 if ((DK1>pi)) {
  DK1 = pi*DK1;

  }
 fval = 10*DK1/1024;
 I0 = true;
 I1 = false;
 }
//End Of Declaration ----------------
void setup() {

# 16 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 3
(*(volatile uint8_t *)((0x0A) + 0x20)) 
# 16 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
    = 
# 16 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 3
      (*(volatile uint8_t *)((0x0A) + 0x20)) 
# 16 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
           | 0b01100000;

# 17 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 3
(*(volatile uint8_t *)((0x04) + 0x20)) 
# 17 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
    = 
# 17 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 3
      (*(volatile uint8_t *)((0x04) + 0x20)) 
# 17 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
           | 0b00001110;

# 18 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 3
(*(volatile uint8_t *)((0x07) + 0x20)) 
# 18 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
    = 
# 18 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino" 3
      (*(volatile uint8_t *)((0x07) + 0x20)) 
# 18 "C:\\Users\\Oguz\\Desktop\\STF\\stf\\stf.ino"
           | 0b00000000;
}
//End of Setup Func ------------------
void loop() {
IO_Scan();
//New Network Start ---------------
dugum = true;
function1();

//end of loop ---------------
IO_Write();
}
