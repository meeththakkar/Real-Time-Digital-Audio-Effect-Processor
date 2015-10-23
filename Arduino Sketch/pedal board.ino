/*
  this is part of RTDEAP , pedal board programm.
 */
 
 
 
 //  sample array ...int myPins[] = {2, 4, 8, 3, 6};

 // int buttonstate[] = { LOW , LOW , LOW , LOW , LOW , LOW , LOW } 


int buttonState0 = LOW;
int buttonState1 = 0;
int buttonState2 = 0;
int buttonState3 = 0;
int buttonState4 = 0;
int buttonState5 = 0;
int buttonState6 = 0;


int last0 = LOW;
int last1 = LOW;
int last2 = LOW;
int last3 = LOW;
int last4 = LOW;
int last5 = LOW;
int last6 = LOW;


int ef_state0 = LOW;  // effect state  ( current ) 
int ef_state1 = LOW;  // effect state  ( current ) 
int ef_state2 = LOW;  // effect state  ( current ) 
int ef_state3 = LOW;  // effect state  ( current ) 
int ef_state4 = LOW;  // effect state  ( current ) 
int ef_state5 = LOW;  // effect state  ( current ) 
int ef_state6 = LOW;  // effect state  ( current ) 


long lastDebounceTime0 = 0;  // the last time the output pin was toggled
long lastDebounceTime1 = 0;  // the last time the output pin was toggled
long lastDebounceTime2 = 0;  // the last time the output pin was toggled
long lastDebounceTime3 = 0;  // the last time the output pin was toggled
long lastDebounceTime4 = 0;  // the last time the output pin was toggled
long lastDebounceTime5 = 0;  // the last time the output pin was toggled
long lastDebounceTime6 = 0;  // the last time the output pin was toggled


long lastchangetime0 = 0;
long lastchangetime1 = 0;
long lastchangetime2 = 0;
long lastchangetime3 = 0;
long lastchangetime4 = 0;
long lastchangetime5 = 0;
long lastchangetime6 = 0;

long debounceDelay = 100; // the debounce time; increase if the output flickers
long debouceRelease = 500; // its a time delay between two successive changes ...
void setup() {                
  // initialize the digital pin as an output.
  // Pin 13 has an LED connected on most Arduino boards:
  pinMode(2, INPUT);
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  
  
  pinMode(13, OUTPUT);     
  pinMode(12, OUTPUT);  
  pinMode(11, OUTPUT);  
  pinMode(10, OUTPUT);  
  pinMode(9, OUTPUT);  
  pinMode(8, OUTPUT);  
  pinMode(7, OUTPUT);  
        
  Serial.begin(9600); 
         
}

void loop() {
 

  buttonState0 =  analogRead(A0);
  if( buttonState0 > 500 ) buttonState0 = HIGH ;  
  else buttonState0 = LOW;   
     
     
     if((lastchangetime0+debouceRelease) < millis())
{
     // if state is going from low to high 
   if ( buttonState0 == HIGH  && LOW == last0  ) {
    lastDebounceTime0 = millis();
    delay (debounceDelay );
  
  // read button after delay time ....
    buttonState0 = analogRead(A0);
    if( buttonState0 > 500 ) buttonState0 = HIGH ;  
    else buttonState0 = LOW;   
  
  // if button is still hig after a delay ..
    if ( buttonState0 = HIGH  ) 
        { 
       // set curr time for dealy in change for 1 sec
       lastchangetime0 = millis(); 
       // toggle  
        if ( ef_state0 == HIGH )
       { ef_state0 = LOW; 
          Serial.write("0 LOW\n");  
   }
        else { ef_state0 = HIGH; 
                Serial.write("0 HIGH\n");}
          }  // end toggle  
  }
}  
    
  
  
    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
  buttonState1 =  analogRead(A1);
  if( buttonState1 > 500 ) buttonState1 = HIGH ;  
else buttonState1 = LOW;   


 if((lastchangetime1+debouceRelease) < millis())
{
     // if state is going from low to high 
   if ( buttonState1 == HIGH  && LOW == last1  ) {
    lastDebounceTime1 = millis();
    delay (debounceDelay );
  
  // read button after delay time ....
    buttonState1 = analogRead(A1);
    if( buttonState1 > 500 ) buttonState1 = HIGH ;  
    else buttonState1 = LOW;   
  
  // if button is still hig after a delay ..
    if ( buttonState1 = HIGH  ) 
    
     // set curr time for dealy in change for 1 sec
       lastchangetime1 = millis(); 
        { // toggle   
        if ( ef_state1 == HIGH ) {ef_state1 = LOW;
                 Serial.write("1 LOW\n");} 
        else { ef_state1 = HIGH; 
                  Serial.write("1 HIGH\n"); }
          }  // end toggle  
  }   
    
}
  
   
   
     
  // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
   buttonState2 = digitalRead(2); 


 if((lastchangetime2+debouceRelease) < millis())
{
  // if state is going from low to high 
   if ( buttonState2 == HIGH  && LOW == last2  ) {
    lastDebounceTime2 = millis();
    delay (debounceDelay );
  
  // read button after delay time ....
    buttonState2 = digitalRead(2);
  
  // if button is still hig after a delay ..
    if ( buttonState2 = HIGH  ) 
        { 
           // set curr time for dealy in change for 1 sec
       lastchangetime2 = millis(); 
          // toggle   
        if ( ef_state2 == HIGH ) {ef_state2 = LOW; 
                  Serial.write("2 LOW\n");}
        else { ef_state2 = HIGH;
                  Serial.write("2 HIGH\n");}
          }  // end toggle  
  }
}  
    
  
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++  
   buttonState3 = digitalRead(3);

 if((lastchangetime3+debouceRelease) < millis())
{
  // if state is going from low to high 
   if ( buttonState3 == HIGH  && LOW == last3  ) {
    lastDebounceTime3 = millis();
    delay (debounceDelay ); //debounceDelay is 100 ms 
  
  // read button after delay time ....
    buttonState3 = digitalRead(3);
  
  // if button is still hig after a delay ..
    if ( buttonState3 = HIGH  ) 
        {
          // set curr time for dealy in change for 1 sec
       lastchangetime3 = millis(); 
          // toggle   
        if ( ef_state3 == HIGH ){ ef_state3 = LOW;           Serial.write("3 LOW\n");}
        else   { ef_state3 = HIGH;           Serial.write("3 HIGH\n"); }
          }  // end toggle  
  }   
}



 // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=
 
 

  buttonState4 = digitalRead(4);

 if((lastchangetime4+debouceRelease) < millis())
{
  // if state is going from low to high 
   if ( buttonState4 == HIGH  && LOW == last4  ) {
    lastDebounceTime4 = millis();
    delay (debounceDelay );
  
  // read button after delay time ....
    buttonState4 = digitalRead(4);
  
  // if button is still hig after a delay ..
    if ( buttonState4 = HIGH  ) 
        {
          // set curr time for dealy in change for 1 sec
       lastchangetime4 = millis(); 
          // toggle   
        if ( ef_state4 == HIGH ) {
          ef_state4 = LOW; 
                 Serial.write("4 LOW\n");
        }
        else
      {  ef_state4 = HIGH;
         Serial.write("4 HIGH\n")  ;
  }
          }  // end toggle  
  }   
}


  buttonState5 = digitalRead(5);

 if((lastchangetime5+debouceRelease) < millis())
{
  // if state is going from low to high 
   if ( buttonState5 == HIGH  && LOW == last5  ) {
    lastDebounceTime5 = millis();
    delay (debounceDelay );
  
  // read button after delay time ....
    buttonState5 = digitalRead(5);
  
  // if button is still hig after a delay ..
    if ( buttonState5 = HIGH  ) 
        {
         
          // set curr time for dealy in change for 1 sec
       lastchangetime5 = millis(); 
          // toggle   
        if ( ef_state5 == HIGH )
       { ef_state5 = LOW; 
       Serial.write("5 LOW\n");
       }
        else{  ef_state5 = HIGH;
             Serial.write("5 HIGH\n")  ;
      }
          }  // end toggle  
  }   
  
}
  
  buttonState6 = digitalRead(6);
 
 if((lastchangetime6+debouceRelease) < millis())
{ 
  // if state is going from low to high 
   if ( buttonState6 == HIGH  && LOW == last6  ) {
    lastDebounceTime6 = millis();
    delay (debounceDelay );
  // read button after delay time ....
    buttonState6 = digitalRead(6);
  // if button is still hig after a delay ..
    if ( buttonState6 = HIGH  ) 
        { 
           // set curr time for dealy in change for 1 sec
       lastchangetime6 = millis(); 
          // toggle   
        if ( ef_state6 == HIGH )
       { ef_state6 = LOW; 
       Serial.write("6 LOW\n");
   }
        else 
       { ef_state6 = HIGH;
       Serial.write ( "6 HIGH\n");
       }
          }  // end toggle  
  }  
 
} 
///////////////////////////////////////////////////////////////////////////////////////////////////////

 digitalWrite(13, ef_state6);  
 digitalWrite(12, ef_state5);  
 digitalWrite(11, ef_state4);  
 digitalWrite(10, ef_state3);  
 digitalWrite(9, ef_state2);  
 digitalWrite(8, ef_state1);  
 digitalWrite(7, ef_state0);  
  
  
  last0 = buttonState0;
  last1 = buttonState1;
  last2 = buttonState2;
  last3 = buttonState3;
  last4 = buttonState4;
  last5 = buttonState5;
  last6 = buttonState6;
  
  
       

         
}
