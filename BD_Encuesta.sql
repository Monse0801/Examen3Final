CREATE DATABASE BD_Monserrat;.


USE BD_Monserrat;


CREATE TABLE encuestas (
    Numero_de_encuesta INT PRIMARY KEY,
    Nombre_de_participante VARCHAR(255),
    Fecha_de_nacimiento DATE,
    Correo_electronico VARCHAR(255),
    Partido_Politico VARCHAR(255),
    FOREIGN KEY (Partido_Politico) REFERENCES Partidos_Politicos(Partido)
);


CREATE TABLE Partidos_Politicos (
    Partido VARCHAR(255)PRIMARY KEY
);


CREATE PROCEDURE sp_ingreso_encuesta
    @Numero_de_encuesta INT,
    @Nombre_de_participante VARCHAR(255),
    @Fecha_de_nacimiento DATE,
    @Correo_electronico VARCHAR(255),
    @Partido_Politico VARCHAR(255)
AS
BEGIN
    INSERT INTO encuestas (Numero_de_encuesta, Nombre_de_participante, Fecha_de_nacimiento, Correo_electronico, Partido_Politico)
    VALUES (@Numero_de_encuesta, @Nombre_de_participante, @Fecha_de_nacimiento, @Correo_electronico, @Partido_Politico);
END;


INSERT INTO Partidos_Politicos (Partido)
VALUES ('PLN'), ('PUSC'), ('PAC');


