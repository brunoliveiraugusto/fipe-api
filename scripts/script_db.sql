IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Parametro')
BEGIN
    CREATE TABLE Parametro(
    IdParametro INT IDENTITY NOT NULL,
	NomeParametro VARCHAR(200) NOT NULL,
    Valor VARCHAR(200) NOT NULL,
    DataCadastro DATETIME NOT NULL,
	Ativo BIT NOT NULL,
    PRIMARY KEY (IdParametro),
    );
END

IF NOT EXISTS (SELECT * FROM Parametro WHERE NomeParametro = 'BaseEndPointFipe')
BEGIN
	INSERT INTO Parametro(NomeParametro, Valor, DataCadastro, Ativo)
	VALUES('BaseEndPointFipe', 'http://fipeapi.appspot.com/api/1/', GETDATE(), 1)
END