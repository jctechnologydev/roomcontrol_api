Link interessante: https://core-electronics.com.au/guides/getting-started-with-home-automation-using-mqtt/
iniciar o Raspberry pi: https://www.makeuseof.com/how-to-run-a-raspberry-pi-program-script-at-startup/
ip do raspberry joel linux: 10.42.0.70
ip do raspberry joel windows: 169.254.156.111

Primeiro seguir tutorial para fazer comunicação serial entre o arduino e o raspberry pi: https://www.aranacorp.com/en/serial-communication-between-raspberry-pi-and-arduino/

DEVE SER FEITO NO RASPBERRY:

    * É necessário construir o circuito ilustrado neste link: https://www.tinkercad.com/things/al6GTePRSXo-frantic-jaban-maimu/editel?tenant=circuits

DEVE SER FEITO NO ARDUINO:

    * Depois de construir compilar o código denominado ReadSensorDataArduino.ino no arduino, este ficheiro encontra-se na area de Desenvolvimento/SETR no repósitorio.

DEVE SER FEITO NO RASPBERRY:

    * De seguida tendo o arduino conectado via USB ao raspberry pi é necessário correr o ficheiro comunicationArduinoRaspberry_mqttPublish.py no raspberry pi, para iniciar a comunicação serial com o arduino

Finalmente se pretender ver os dados gerados pelo sensor via mqtt, basta correr o ficheiro mqttClient.py ou o commando "mosquitto_sub -h test.mosquitto.org -t IPCA/TEST"
