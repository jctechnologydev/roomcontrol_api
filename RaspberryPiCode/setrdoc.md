# Sistemas Embebidos  - Smart Rooms

## Contextualização e motivação do projeto
  - Sistema para monitorizar o estado das salas do IPCA.

Cada sala deverá estar equipada com um sistema contendo um arduino e raspberry pi os diferentes sensores respetivos a sala.
Os dados lidos pelos sensores serão enviados para o raspberry pi via serial e por meio do protocolo MQTT será feita a comunicação entre o servidor "elaborado na UC de Sistemas de Integração de Software" e os sistema IOT.

## Requisitos Funcionais

 - 
 - output como uma função de input 

 ## Requisitos Não Funcionais

  - O tempo necessário para processar a informação em tempo real
  - Tamanho: 4cm x 4cm x 2cm, peso: 200 gramas
  - Consumo de energia o mínimo possível xx kWh
  - Quanto a fiabilidade o sistema deve fornecer a informação lida em tempo real

##  Descrição da arquitetura do sistema 

|ID| Componentes | Quantidade|
|--| ----------- | ---------|
|AD| Arduino     |    1      |
|RPI| Raspberry PI| 1 |
|ST| Sensor de temperatura (LM35)| 2  |
|SM| sensor de movimento| 2  |
|SL| Sensor de luminosidade | 2 |
|RT| Resistências  |   xx  |
|LVM| Led vermelho   |   xx |
|BT| Bateria | 1 |

O sistema embebido é composto por um arduino que faz a leitura dados provenientes dos sensores e o acionamento dos equipamentos a associados ao sistema.
O Raspberry pi está ligado 



## Código(s) desenvolvido(s)


## Justificação das decisões tomadas (hardware e software)

Inicialmente o sistema foi desenhado para que a comunicação entre o raspberry pi e o arduino fosse feita por meio de uma comunicação sem fio, utilizado dois módulos XBee's um no arduino e o outro no raspberry pi, mas devido a problemas de envio de dados que estes módulos apresentaram, ficou decidido que a conexão entre o arduino e o raspberry pi seria feita via serial.
No sistema foram adicionados sensores nomeadamente : de temperatura, de movimento e de luminosidade, importa destacar este sistema está construido de modo a que possa receber menos ou mais sensores do que os mencionados posteriormente, isto porque pode existir locais em que não seja necessário fazer a monitorização da temperatura ou existir locais que seja necessário monitorizar a temperatura com mais do que um sensor.
O Envio de ordens/operações para ligar e desligar equipamentos como por exemplo um Led pode ser feito por meio da nossa aplicação móvel ou por meio de um botão.
O Envio de ordens/operações é feito por meio do protocolo 





# Considerações finais


# Bibliografia

https://www.delftstack.com/howto/python/get-ip-address-python/#:~:text=Use%20the%20socket.getsockname%20%28%29%20Funtion%20to%20Get%20the,form%20of%20a%20tuple.%20See%20the%20code%20below.