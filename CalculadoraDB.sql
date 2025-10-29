-- Script para crear base de datos y tabla
CREATE DATABASE CalculadoraDB;
GO

USE CalculadoraDB;
GO

CREATE TABLE Calculations
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Expression NVARCHAR(200) NOT NULL,
    Result NVARCHAR(100) NOT NULL,
    DatePerformed DATETIME NOT NULL DEFAULT(GETDATE())
);
GO

-- Ejemplo: insertar registro de prueba
INSERT INTO Calculations (Expression, Result) VALUES ('2 + 2', '4');
GO
