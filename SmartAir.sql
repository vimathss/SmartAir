CREATE DATABASE SmartAir;
USE SmartAir;

CREATE TABLE Lab (
    ID_Lab INT(3) PRIMARY KEY NOT NULL,
    Nome VARCHAR(15),
    Localizacao VARCHAR(15),
    Descricao TEXT
);

CREATE TABLE ESP32 (
    ID_ESP32 INT(3) PRIMARY KEY,
    ID_Lab INT(3),
    Endereço_IP VARCHAR(15),
    Estado ENUM('online', 'offline'),
    FOREIGN KEY (ID_Lab) REFERENCES Lab(ID_Lab)
);

CREATE TABLE Comando (
    ID_Comando INT PRIMARY KEY,
    ID_ESP32 INT(3),
    Tipo_Comando VARCHAR(50) NOT NULL,
    Valor_Comando VARCHAR(100),
    Data_Hora_Envio DATETIME,
    FOREIGN KEY (ID_ESP32) REFERENCES ESP32(ID_ESP32)
);

CREATE TABLE Usuario (
    ID_Usuario INT(3) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Senha VARCHAR(20) NOT NULL
);

/*Inserts*/
insert into Lab Values (001,"lab 1", "P1", " ");
insert into Lab Values (002,"lab 2", "P1", " ");
insert into Lab Values (003,"lab 3", "P2", " ");

insert into ESP32 Values (001, 001, "8.206.117.235", "offline");
insert into ESP32 Values (002, 002, "12.138.141.229", "online");
insert into ESP32 Values (003, 003, "15.79.89.102", "online");

insert into Comando Values (1, 1, 'Ligar', 'ON', '2024-08-24 10:30:00');
insert into Comando Values (2, 2, 'Temperatura', '16C', '2024-08-24 10:30:00');
insert into Comando Values (3, 3, 'Desligar', 'OFF', '2024-08-24 12:10:00');	

insert into Usuario Values (001, "Pedro", "lerodentario@gmail.com", "hermes");
insert into Usuario Values (002, "Samuel", "zedalinguiça@bol.com", "serieT");
insert into Usuario Values (003, "Paulo", "LigaMetalica@gerson.com", "kripto");

/* Consultas com INNER JOIN */

/* Exibir informações dos ESP32 e o laboratório em que estão localizados */
SELECT ESP32.*, Lab.Nome AS Nome_Lab, Lab.Localizacao FROM ESP32 
INNER JOIN Lab ON ESP32.ID_Lab = Lab.ID_Lab;

/* Exibir comandos enviados e as informações dos ESP32 */
SELECT Comando.*, ESP32.Endereço_IP, ESP32.Estado FROM Comando 
INNER JOIN ESP32 ON Comando.ID_ESP32 = ESP32.ID_ESP32;

/* Exibir informações dos laboratórios e seus respectivos ESP32 */
SELECT Lab.*, ESP32.Endereço_IP, ESP32.Estado FROM Lab 
INNER JOIN ESP32 ON Lab.ID_Lab = ESP32.ID_Lab;

/* Exibir comandos com informações do laboratório associado ao ESP32 */
SELECT Comando.*, Lab.Nome AS Nome_Lab, Lab.Localizacao FROM Comando 
INNER JOIN ESP32 ON Comando.ID_ESP32 = ESP32.ID_ESP32 
INNER JOIN Lab ON ESP32.ID_Lab = Lab.ID_Lab;

/* Criação de Relatórios */

/* Criar uma VIEW para relatório de comandos por laboratório */
CREATE VIEW Relatorio_Comandos_Lab AS SELECT Lab.Nome AS Nome_Lab, Lab.Localizacao, Comando.Tipo_Comando, Comando.Valor_Comando, Comando.Data_Hora_Envio FROM Comando
INNER JOIN ESP32 ON Comando.ID_ESP32 = ESP32.ID_ESP32
INNER JOIN Lab ON ESP32.ID_Lab = Lab.ID_Lab;

/* Exibir a VIEW do relatório de comandos por laboratório */
SELECT * FROM Relatorio_Comandos_Lab;

/* Criar uma VIEW para relatório de todos os ESP32 e seus estados */
CREATE VIEW Relatorio_ESP32_Estados AS SELECT ESP32.ID_ESP32, ESP32.Endereço_IP, ESP32.Estado, Lab.Nome AS Nome_Lab, Lab.Localizacao FROM ESP32
INNER JOIN Lab ON ESP32.ID_Lab = Lab.ID_Lab;

/* Exibir a VIEW do relatório de ESP32 e seus estados */
SELECT * FROM Relatorio_ESP32_Estados;

/* ------------------ ETAPA 4 ------------------ */

/* Mostra o prédio com 2 ou mais ESP32 */
SELECT Localizacao, COUNT(*) FROM Lab GROUP BY Localizacao HAVING COUNT(*) >= 2;

/* Verifica qual o email de um determinado usuario */
SELECT Nome, Email FROM Usuario WHERE Nome IN('Paulo', 'Pedro');

-- PROCEDURE --

DELIMITER //

CREATE PROCEDURE nome_usuario_inf()
BEGIN
    SELECT Nome FROM Usuario;
END //

DELIMITER ;

CALL nome_usuario_inf();


