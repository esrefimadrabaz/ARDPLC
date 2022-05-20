#line 1 "C:\\Users\\Oguz\\Desktop\\pl\\WindowsFormsApp1\\examples\\06-CMP\\cmp\\cmp.h"
bool I0, I1, I2, I3, I4, O0, O1, O2, O3, O4;
//bool An0, An1, An2, An3, An4;
bool dugum = true, prl, next;


void IO_Scan(){
//reading and buffering IO
I0 = PIND & 0b00000100;
I1 = PIND & 0b00001000;
I2 = PIND & 0b00010000;
I3 = PIND & 0b10000000;
I4 = PINB & 0b00000001;
}

void IO_Write(){
if(O0 == true) {PORTD |= 0b00100000;}
else {PORTD &= ~(0b00100000);}
if(O1 == true) {PORTD |= 0b01000000;}
else {PORTD &= ~(0b01000000);}
if(O2 == true) {PORTB |= 0b00000010;}
else {PORTB &= ~(0b00000010);}
if(O3 == true) {PORTB |= 0b00000100;}
else {PORTB &= ~(0b00000100);}
if(O4 == true) {PORTB |= 0b00001000;}
else {PORTB &= ~(0b00001000);}
}


void cON(int time, int &timer) {
  if (!dugum) {
    timer = millis();
  }
  if (dugum) {
    if (millis() - timer >= time) {
      dugum = true;
      next = true;
    }
    else {
      dugum = false;
    }
  }
}

void cRTO(int time, int &timer, bool &rtn) {
  if (dugum) {
    if (!rtn) {timer = millis(); rtn = true;}
    if (millis() - timer >= time) {
      dugum = true;
      next = true;
    }
    else {
      dugum = false;
    }
  }
}

void cOFF(int time, int &timer) {
  if (dugum) {
    timer = millis();
    dugum = true;
    next = true;
  }

  if (!dugum && timer != 0) {
    if (millis() - timer >= time) {
      dugum = false;
    }
    else {
      dugum = true;
      next = true;
    }
  }
}


void Reset_O(int &contact) {
  if (dugum) {
    contact = 0;
  }
}

void Reset_T(int &timer){
  if(dugum){
    timer = millis();
  }
}

void CNTU(int Preset, int &CNTR, bool &CNT_Last, bool &CNT_Done) {
  if(Preset == 0){return;} // may remove
  if (dugum) {
    if (!CNT_Last) {
      CNTR = 1 + CNTR;
      delayMicroseconds(50);
      CNT_Last = true;
    }
  } else {
    CNT_Last = false;
  }

  if (CNTR >= Preset) {
    dugum = true;
    CNT_Done = true;
    next = true;
  } else {
    dugum = false;
    CNT_Done = false;
  }
}

void CNTD(int Preset, int &CNTR, bool &CNT_Last, bool &CNT_Done) {
  if(Preset == 0){return;} // may remove
  if (dugum) {
    if (!CNT_Last) {
      CNTR = CNTR - 1;
      delayMicroseconds(50);
      CNT_Last = true;
    }
  } else {
    CNT_Last = false;
  }

  if (CNTR >= Preset) {
    dugum = true;
    CNT_Done = true;
    next = true;
  } else {
    dugum = false;
    CNT_Done = false;
  }
}


void CMP(float first, float last, bool &MF, bool &MM, bool &ML)
{
  if(dugum)
  {
    if(first > last){MF = true;}
    else if (first == last) {MM = true;}
    else if ( first < last) {ML = true;}
  }
}
void ZCMP(float first, float middle, float last, bool &MF, bool &MM, bool &ML)
{
  if(dugum)
  {
    if(first > last){MF = true;}
    else if ((first <= last) && (last <= middle)) {MM = true;}
    else if ( last > middle) {ML = true;}
  }
}

void ADC_Alt(int pin, int &destination)
{
  if(dugum)
   {
     destination = analogRead(pin);
   }
}

void PWM (int pin, int value)
{
  int real_pin;
  if(dugum)
  {
    if(pin == 0) {real_pin = 5;}
    else if (pin == 1){real_pin = 6;}
    else if (pin == 2){real_pin = 9;}
    else if (pin == 3){real_pin = 10;}
    else if (pin == 4){real_pin = 11;}
    analogWrite(real_pin, value);
  }
}


// ************ virtual pin inits, may delete
void NO_M(bool &x1) {
  if (dugum) {
    if (x1 == true) {
      dugum = true;
      next = true;
    }
    else if (x1 == false) {
      dugum = false;
    }
  }
}
void NC_M(bool &x1) {
  if (dugum) {
    if (x1 == false) {
      dugum = true;
      next = true;
    }
    else if (x1 == true) {
      dugum = false;
    }
  }
}
void Coil_M(bool &x1) {
  if (dugum) {
    x1 = true;
  }
  else {
    x1 = false;
  }
}
void Set_M(bool &contact) {
  if (dugum) {
    contact = true;
  }
}
void Reset_M(bool &contact) {
  if (dugum) {
    contact = false;
  }
}
//************** ends here

