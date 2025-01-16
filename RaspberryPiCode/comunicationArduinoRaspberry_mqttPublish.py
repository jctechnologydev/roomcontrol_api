# Projeto SmartRooms
# 12/2022
# Authors: 
import socket
import serial, time
import paho.mqtt.client as client
import paho.mqtt.publish as publish

PORT = "/dev/ttyACM0"
BAUND = 9600
topic = "IPCA/TEST"
hostname = "test.mosquitto.org"

def PublishData(topic, data, hostname):
    """Publish  data to the specified  topic and hostname"""
    publish.single(topic, data, hostname= hostname)
    


def ConnectionArduinoRaspberryMQTT(PORT, BAUND):
    """Get data from Arduino"""
    with serial.Serial(PORT,BAUND, timeout=1) as arduino:
        time.sleep(0.1) #wait for seiral open
        if arduino.isOpen():
            print("conected".format(arduino.port))
            answer = f"Hostname: {socket.gethostname()} \n Local IP Address: {GetIpAddress()}\n"
            PublishData(topic, answer, hostname)
            time.sleep(10)
            try:
                while True:
                    client.loop()
                    while arduino.inWaiting() == 0: pass
                    if arduino.inWaiting() > 0:
                        answer = arduino.readline().decode("utf-8")
                        print(answer)
                        PublishData(topic, answer, hostname)
                        arduino.flushInput()
            except KeyboardInterrupt:
                 print("closed")


# The callback for when the client receives a CONNACK response from the server.
def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))
    # Subscribing in on_connect() means that if we lose the connection and
    # reconnect then subscriptions will be renewed.
    client.subscribe(f"{topic}/room")

# The callback for when a PUBLISH message is received from the server.
def on_message(client, userdata, msg):
    with serial.Serial(PORT,BAUND, timeout=1) as arduino:
        print(msg.topic+" "+str(msg.payload))
        arduino.write(msg.payload)

# Function to send ip adress by MQTT
def GetIpAddress():
    ip_address = ''
    helper = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    helper.connect(("8.8.8.8", 80))
    ip_address = helper.getsockname()[0]
    helper.close
    return ip_address

client = client.Client()
client.on_connect = on_connect
client.on_message = on_message

client.connect(hostname)

ConnectionArduinoRaspberryMQTT(PORT, BAUND)
