CREATE DATABASE SENAI_HROADS_MANHA;
GO

USE SENAI_HROADS_MANHA;
GO

CREATE TABLE TipoHabilidade(
	idTipoHabilidade INT PRIMARY KEY IDENTITY,
	nomeTipoHabilidade VARCHAR(50),
);
GO

CREATE TABLE Classe(
	idClasse INT PRIMARY KEY IDENTITY,
	nomeClasse VARCHAR(50),
); 
GO

CREATE TABLE Personagem(
	idPersonagem INT PRIMARY KEY IDENTITY,
	idClasse INT FOREIGN KEY REFERENCES Classe(idClasse),
	nome VARCHAR(50),
	capMana TINYINT,
	capVida TINYINT,
	dataAtt DATE,
	dataCriacao DATE
);
GO

CREATE TABLE Habilidade(
	idHabilidade INT PRIMARY KEY IDENTITY,
	idTipoHabilidade INT FOREIGN KEY REFERENCES TipoHabilidade(idTipoHabilidade),
	nomeHabilidade VARCHAR(100)
);
GO

CREATE TABLE ClasseHabilidade(
	idClasseHabilidade INT PRIMARY KEY IDENTITY,
	idClasse INT FOREIGN KEY REFERENCES Classe(idClasse),
	idHabilidade INT FOREIGN KEY REFERENCES Habilidade(idHabilidade),
);
GO

CREATE TABLE TipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tiposUsuario VARCHAR(15),
);
GO

CREATE TABLE Usuario(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario), 
	email VARCHAR(30),
	senha VARCHAR(8),
);
GO

