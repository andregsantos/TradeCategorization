CREATE DATABASE TradeDb;

USE TradeDb;

-- Criar tabela de Trades
CREATE TABLE Trades (
    TradeId INT IDENTITY(1,1) PRIMARY KEY,
    Value DECIMAL(18, 2),
    ClientSector NVARCHAR(50)
);

-- Criar tabela de Categorias
CREATE TABLE TradeCategories (
    TradeId INT,
    Category NVARCHAR(50),
    FOREIGN KEY (TradeId) REFERENCES Trades(TradeId)
);

-- Inserir dados de exemplo na tabela de Trades
INSERT INTO Trades (Value, ClientSector) VALUES (2000000, 'Private');
INSERT INTO Trades (Value, ClientSector) VALUES (400000, 'Public');
INSERT INTO Trades (Value, ClientSector) VALUES (500000, 'Public');
INSERT INTO Trades (Value, ClientSector) VALUES (3000000, 'Public');

-- Procedimento para categorizar os Trades
CREATE PROCEDURE CategorizeTrades
AS
BEGIN
    TRUNCATE TABLE TradeCategories;

    INSERT INTO TradeCategories (TradeId, Category)
    SELECT 
        TradeId,
        CASE
            WHEN Value < 1000000 AND ClientSector = 'Public' THEN 'LOWRISK'
            WHEN Value >= 1000000 AND ClientSector = 'Public' THEN 'MEDIUMRISK'
            WHEN Value >= 1000000 AND ClientSector = 'Private' THEN 'HIGHRISK'
            ELSE 'UNKNOWN'
        END AS Category
    FROM Trades;
END;

-- Executar o procedimento
EXEC CategorizeTrades;

-- Consultar as Categorias
SELECT * FROM TradeCategories;
