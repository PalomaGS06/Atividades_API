/* DQL - Data Language - Linguagem de Consulta de Dados */

SELECT * FROM Usuarios;
GO

SELECT
	Nome, 
	Email 
FROM 
	Usuarios;
GO

SELECT * FROM Categorias ORDER BY Categoria DESC;  /* ORDER BY seleciona por ordem alfabética. ASC = Forma ascendente; DESC = Forma descedente*/
GO

SELECT * FROM Categorias WHERE Id > 16 AND Id < 19;