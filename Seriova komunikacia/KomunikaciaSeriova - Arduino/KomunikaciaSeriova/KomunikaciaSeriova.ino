int Loop = 1;
int ledPin = 13;
int incomingByte = 0;
int cislo = 0 ;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);

}

void loop() {
  //Serial.println("Data Loop " + String(Loop));
  cislo = random(0, 50);
  Serial.println(String(cislo));
  Loop++;
  delay(500);
  incomingByte = Serial.read();
  //Serial.println(incomingByte, DEC);
  if ( ( incomingByte = Serial.read() ) == 49) {
    Serial.println("Primam data");
    digitalWrite(ledPin, HIGH);
  }
}
