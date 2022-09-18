/* DDL -> Data Definition Language -> Linguagem de Definição de Dados */

/* CRIAR*/
CREATE DATABASE MaisEventos;
GO

/* USAR*/
USE MaisEventos;
GO

/*	
	/* ALTERAR*/
	/*ALTER DATABASE MaisEventosAlterado MODIFY NAME = MaisEventos;
	GO

	/* EXCLUIR*/
	DROP DATABASE MaisEventos;
	GO
	*/
*/

CREATE TABLE Categorias(
	Id INT PRIMARY KEY IDENTITY, /* IDENTITY -> Incrementar o ID automaticamente */ 
	Categoria NVARCHAR(MAX)
);
GO

CREATE TABLE Usuarios(
	Id INT PRIMARY KEY IDENTITY,
	Nome NVARCHAR(MAX),
	Email NVARCHAR(MAX),
	Senha NVARCHAR(MAX)
);
GO

CREATE TABLE Eventos(
	Id INT PRIMARY KEY IDENTITY,
	DataHora DATETIME,
	Ativo BIT, /* Booleano */
	Preco DECIMAL(6,2), /* 1234,56 */

	/* FKs */
	CategoriaId INT
	FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO

CREATE TABLE UsuarioEvento(
	Id INT PRIMARY KEY IDENTITY,
	/* FKs */
	UsuarioId INT
	FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),

	EventoId INT
	FOREIGN KEY (EventoId) REFERENCES Eventos(Id)
);

