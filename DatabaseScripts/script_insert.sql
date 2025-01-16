-- Inserir HardwareType
INSERT INTO public."HardwareType"(name)VALUES ('Temperatura');
INSERT INTO public."HardwareType"(name)VALUES ('Humidade');
INSERT INTO public."HardwareType"(name)VALUES ('CO2');
INSERT INTO public."HardwareType"(name)VALUES ('Luminosidade');
INSERT INTO public."HardwareType"(name)VALUES ('Ruído');
INSERT INTO public."HardwareType"(name)VALUES ('Movimento');


-- Inserir FuncionalityType
INSERT INTO public."FuncionalityType"(name)VALUES ('Sensor');
INSERT INTO public."FuncionalityType"(name)VALUES ('Actuador');

-- Inserir Hardware
INSERT INTO public."Hardware"("HardwareTypeidHardwareType", "FuncionalityTypeidFunctionality", name) VALUES ( 4, 1,  'Sensor luminosidade');
INSERT INTO public."Hardware"("HardwareTypeidHardwareType", "FuncionalityTypeidFunctionality", name) VALUES ( 1, 1,   'Sensor temperatura');
INSERT INTO public."Hardware"("HardwareTypeidHardwareType", "FuncionalityTypeidFunctionality", name) VALUES ( 4, 2, 'Led');
INSERT INTO public."Hardware"("HardwareTypeidHardwareType", "FuncionalityTypeidFunctionality", name) VALUES ( 6, 1,   'Sensor movimento');

-- Inserir Alert
INSERT INTO public."Alert"("HardwareidHardware","maxValue", "minValue")VALUES (1, 99999, 0);
INSERT INTO public."Alert"("HardwareidHardware","maxValue", "minValue")VALUES (2, 24, 10);
INSERT INTO public."Alert"("HardwareidHardware","maxValue", "minValue")VALUES (3, 2, -1);
INSERT INTO public."Alert"("HardwareidHardware","maxValue", "minValue")VALUES (4, 100, -1);

-- Inserir InstallationHistoric
INSERT INTO public."InstallationHistoric"("HardwareidHardware","idRoom", "registrationDate", "idUser")VALUES (1, 1, '2022-12-02',1);
INSERT INTO public."InstallationHistoric"("HardwareidHardware","idRoom", "registrationDate", "idUser")VALUES (2, 1, '2023-01-02',1);
INSERT INTO public."InstallationHistoric"("HardwareidHardware","idRoom", "registrationDate", "idUser")VALUES (3, 1, '2022-11-02',1);
INSERT INTO public."InstallationHistoric"("HardwareidHardware","idRoom", "registrationDate", "idUser")VALUES (4, 1, '2022-12-10',1);

-- Inserir States
INSERT INTO public."State"(name) VALUES ('Ocupado');
INSERT INTO public."State"(name) VALUES ('Aberto');
INSERT INTO public."State"(name) VALUES ('Fechado');
INSERT INTO public."State"(name) VALUES ('Livre');
INSERT INTO public."State"(name) VALUES ('Ligado');
INSERT INTO public."State"(name) VALUES ('Desligado');

-- Inserir DataType
INSERT INTO public."DataType"(name)VALUES ('Celsius');
INSERT INTO public."DataType"(name)VALUES ('Fahrenheit');
INSERT INTO public."DataType"(name)VALUES ('Kelvin');
INSERT INTO public."DataType"(name)VALUES ('Decibeis');
INSERT INTO public."DataType"(name)VALUES ('Lumen');
INSERT INTO public."DataType"(name)VALUES ('None');

-- Inserir histórico estado


"InstallationHistoric"."idRoom"

---Hardware, Historic, Estado
---Hardware, Historic, Estado
Select "Hardware"."idHardware", "State".name, "InstallationHistoric"."idRoom", "Data"."value"
From "Hardware" 
inner join "StateHistoric" on "Hardware"."idHardware" = "StateHistoric"."HardwareidHardware" 
inner join "State" on "State"."idState" = "StateHistoric"."StateidState"  
inner join "InstallationHistoric" on "InstallationHistoric"."HardwareidHardware" = "Hardware"."idHardware"
inner join "Data" on "Data"."HardwareidHardware" = "Hardware"."idHardware" and "Data"."registrationDate"
 = (select max ("Data"."registrationDate") 
from "Data"  where "Data"."HardwareidHardware" = "Hardware"."idHardware")
and "StateHistoric"."registrationDate" = (select max ("StateHistoric"."registrationDate") 
From "StateHistoric" where "InstallationHistoric"."idRoom" = 4)




