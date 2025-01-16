/**
 * @file ReadSensorDataArduino.ino
 * @author your name (you@domain.com)
 * @brief Smart Rooms - Project
 * @version 0.1
 * @date 2022-12-21
 * @UC Sistemas Embebidos e de Tempo Real
 * @copyright Copyright (c) 2022
 * 
 */


#define wait delay(1000)
#include <stdio.h>
#include <ArduinoJson.h>

const int N = 9;

/**
 * @brief Estrutura dos dados
 * e
 */
typedef struct _data {
  int idRoom;
  int idHardware;
  int idDataType;
  int idFuncionalityType;
  String value;
} Data;

/**
 * @brief Estrutura de Hardware
 * 
 */
typedef struct _hardware {
  Data hardware[N];
  int count;
} Hardwares;

// Declaração da estrutura Hardware
Hardwares data;
const byte ledRed = 8;
int interruptPin = 2;
volatile byte stateLight = LOW;

void setup() {
  data.count = 1;
  
  //Innput
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(interruptPin, INPUT_PULLUP);


  //Interrupt
  attachInterrupt(digitalPinToInterrupt(interruptPin), TurnOnLight, RISING);

  //Output
  pinMode(ledRed, OUTPUT);
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, HIGH);
  
  //Pisca led builtin do arduino para inicializar
  Blink(25);
  Serial.begin(9600);
}

void loop() {
  int n = 4;
  data.hardware[1].idRoom = 1;
  data.hardware[1].idHardware = 2;
  data.hardware[1].idDataType = 1;
  data.hardware[1].idFuncionalityType = 1;
  data.hardware[1].value = String(TemperatureConverter(A1));

  data.hardware[2].idRoom = 1;
  data.hardware[2].idHardware = 1;
  data.hardware[2].idDataType = 5;
  data.hardware[1].idFuncionalityType = 1;
  data.hardware[2].value = String(Hardware(A0));

  data.hardware[3].idRoom = 1;
  data.hardware[3].idHardware = 4;
  data.hardware[3].idDataType = 6;
  data.hardware[1].idFuncionalityType = 1;
  data.hardware[3].value = String(Hardware(A2));


  data.hardware[4].idRoom = 1;
  data.hardware[4].idHardware = 3;
  data.hardware[4].idDataType = 5;
  data.hardware[1].idFuncionalityType = 2;
  data.hardware[4].value = String(digitalRead(ledRed));

  if (Serial.available() > 0) {
    String data = Serial.readStringUntil('\n');
    DeserializeData(data);
    //processMessage(data);
    //Serial.print("Recebi:");
    //Serial.print(data);
    //Serial.println(";");
  }

  Serial.print("[");
  for (int i = 1; i <= n; i++) {
    SerialSendData(data.hardware[i]);
    if ((n) > i) Serial.print(",");
  }
  Serial.println("]");
  
  digitalWrite(ledRed, stateLight);

  wait;
}

enum ActuatorState { ON, OFF };
ActuatorState convertActuatorState(String x);

ActuatorState convertActuatorState(String x) {
  if (x == "Ligado") return ON;
  if (x == "Desligado") return OFF;
}

/**
 * @brief Função que converte os dados analógicos do sensor para a temperatura
 * 
 * @param port 
 * @return int 
 */
int TemperatureConverter(int port) {
  return (float(Hardware(port)) * 5 / (1023)) / 0.01;
}


/**
 * @brief    Função que recebe os dados provenientes da porta analógica do sensor
 * 
 * @param port 
 * @return int 
 */
int Hardware(int port) {
  return analogRead(port);
}

typedef struct ActuatorSetter{
  int ID;
  String Operation;
  String Value;
};

void DeserializeData(String setter){
  StaticJsonDocument<200> doc;

  deserializeJson(doc, setter);
  const char* tmpValue = doc["Value"];
  String value = String(tmpValue);
  //String message = "Op:" + value;
  //Serial.println(message);
  
  ActuatorState state = convertActuatorState(value);

  if (state == ON)
    stateLight = HIGH;
  if (state == OFF)
    stateLight = LOW;
}

/**
 * @brief Função que transforma os dados num ficheiro json
 * 
 * @param dat 
 * @param index 
 * @param idRoom 
 * @param idHardware 
 */
void SerialSendData(Data hardware) {
  StaticJsonDocument<200> doc;

  doc["idRoom"] = hardware.idRoom;
  doc["idHardware"] = hardware.idHardware;
  doc["idDataType"] = hardware.idDataType;
  doc["value"] = hardware.value;

  serializeJson(doc, Serial);
}

/**
 * @brief Ligar a luz
 */
void TurnOnLight(){
  if(stateLight == LOW){
     stateLight = HIGH;
    // Serial.println("Luz ligada");
  }else{
    stateLight = LOW;
    //Serial.println("Luz desligada");
  }
}

/**
 * @brief Piscar led para sinalizar uma operação
 */
void Blink(int count){
  for(int i =0; i < count; i++){
    digitalWrite(LED_BUILTIN, HIGH);
    delay(100);
    digitalWrite(LED_BUILTIN,LOW);
    delay(100);
  }
}
