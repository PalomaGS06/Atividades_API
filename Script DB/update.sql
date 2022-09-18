/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Categoria]
      ,[Imagem]
  FROM [MaisEventos].[dbo].[Categorias]

  UPDATE Categorias SET Imagem = NULL WHERE Id = 20;