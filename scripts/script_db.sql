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

GO

IF NOT EXISTS (SELECT * FROM Parametro WHERE NomeParametro = 'BaseEndPointFipe')
BEGIN
	INSERT INTO Parametro(NomeParametro, Valor, DataCadastro, Ativo)
	VALUES('BaseEndPointFipe', 'http://fipeapi.appspot.com/api/1/', GETDATE(), 1)
END

GO

IF NOT EXISTS (SELECT * FROM Parametro WHERE NomeParametro = 'EndPointFipeCarro')
BEGIN
	INSERT INTO Parametro(NomeParametro, Valor, DataCadastro, Ativo)
	VALUES('EndPointFipeCarro', 'carros/marcas.json', GETDATE(), 1)
END

GO

IF NOT EXISTS (SELECT * FROM Parametro WHERE NomeParametro = 'EndPointFipeMoto')
BEGIN
	INSERT INTO Parametro(NomeParametro, Valor, DataCadastro, Ativo)
	VALUES('EndPointFipeMoto', 'motos/marcas.json', GETDATE(), 1)
END

GO

IF NOT EXISTS (SELECT * FROM Parametro WHERE NomeParametro = 'EndPointFipeCaminhao')
BEGIN
	INSERT INTO Parametro(NomeParametro, Valor, DataCadastro, Ativo)
	VALUES('EndPointFipeCaminhao', 'caminhoes/marcas.json', GETDATE(), 1)
END

GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TipoVeiculo')
BEGIN
    CREATE TABLE TipoVeiculo(
    IdTipoVeiculo INT IDENTITY NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
    DataCadastro DATETIME NOT NULL,
    PRIMARY KEY (IdTipoVeiculo),
    );
END

GO

IF NOT EXISTS (SELECT * FROM TipoVeiculo WHERE Descricao = 'carro')
BEGIN
	INSERT INTO TipoVeiculo(Descricao, DataCadastro)
	VALUES('carro', GETDATE())
END

GO

IF NOT EXISTS (SELECT * FROM TipoVeiculo WHERE Descricao = 'moto')
BEGIN
	INSERT INTO TipoVeiculo(Descricao, DataCadastro)
	VALUES('moto', GETDATE())
END

GO

IF NOT EXISTS (SELECT * FROM TipoVeiculo WHERE Descricao = 'caminhao')
BEGIN
	INSERT INTO TipoVeiculo(Descricao, DataCadastro)
	VALUES('caminhao', GETDATE())
END

GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Marca')
BEGIN
    CREATE TABLE Marca(
    IdMarca INT IDENTITY NOT NULL,
	Nome VARCHAR(100) NOT NULL,
    NomeFipe VARCHAR(100) NOT NULL,
    OrderFipe INT NOT NULL,
	Chave VARCHAR(50) NOT NULL,
	IdMarcaFipe INT NOT NULL,
	MesReferencia VARCHAR(10) NOT NULL,
	AnoReferencia VARCHAR(10) NOT NULL,
	IdTipoVeiculo INT NOT NULL,
    PRIMARY KEY (IdMarca),
	FOREIGN KEY (IdTipoVeiculo) REFERENCES TipoVeiculo(IdTipoVeiculo)
    );
END

GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LogFipe')
BEGIN
    CREATE TABLE LogFipe(
    IdLogFipe INT IDENTITY NOT NULL,
	TipoExcecao VARCHAR(100) NOT NULL,
    MensagemExcecao VARCHAR(MAX) NOT NULL,
	Rastreamento VARCHAR(MAX) NOT NULL,
    DataExcecao DATETIME NOT NULL,
    PRIMARY KEY (IdLogFipe)
    );
END
