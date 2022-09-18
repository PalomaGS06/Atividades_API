/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Categoria]
      ,[Imagem]
  FROM [MaisEventos].[dbo].[Categorias]

SELECT 
E.Id AS 'Id_Evento',
E.DataHora AS 'Data_Evento',
E.Ativo AS 'Ativo_Evento',
E.Preco AS 'Preço_Evento',
E.CategoriaId AS 'Id_Categoria_Evento',
Categorias.Categoria 
FROM Eventos AS E
JOIN Categorias ON E.CategoriaId = Categorias.Id

