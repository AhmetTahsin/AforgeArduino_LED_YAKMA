void setup() 
{
  Serial.begin(9600);
  pinMode(2,OUTPUT);
  pinMode(3,OUTPUT);
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(6,OUTPUT);
  pinMode(7,OUTPUT);
  pinMode(8,OUTPUT);
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  int a=0;
}
void loop() 
{
  if(Serial.available()) 
  {
    while(1){
    char a = Serial.read();
    if(a=='a')
    { 
      digitalWrite(2,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='b')
    { 
      digitalWrite(3,HIGH);
      digitalWrite(2,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='c')
    { 
      digitalWrite(4,HIGH);
      digitalWrite(3,LOW);digitalWrite(2,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='d')
    { 
      digitalWrite(5,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(2,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='e')
    { 
      digitalWrite(6,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(2,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='f')
    { 
      digitalWrite(7,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(2,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='g')
    { 
      digitalWrite(8,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(2,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='h')
    { 
      digitalWrite(9,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(2,LOW);digitalWrite(10,LOW);
      delay(50);
    }
    else if(a=='i')
    { 
      digitalWrite(10,HIGH);
      digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(2,LOW);
      delay(50);
    }
    else
    { 
      digitalWrite(2,LOW);digitalWrite(3,LOW);digitalWrite(4,LOW);digitalWrite(5,LOW);digitalWrite(6,LOW);digitalWrite(7,LOW);digitalWrite(8,LOW);digitalWrite(9,LOW);digitalWrite(10,LOW);
    }
   }
  }
  
}
