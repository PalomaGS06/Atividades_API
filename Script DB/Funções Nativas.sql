/* Funções Nativas */

/* Soma */
SELECT SUM(UsuarioId) AS Soma FROM UsuarioEvento

/* Média */
SELECT AVG(UsuarioId) AS Media FROM UsuarioEvento

/* Mínimo */
SELECT MIN(UsuarioId) AS Minimo FROM UsuarioEvento

/* Máximo */
SELECT MAX(UsuarioId) AS Maximo FROM UsuarioEvento

/* Contagem */
SELECT COUNT(*) AS Total FROM Categorias


/* SUBSELECT */
SELECT 
	*,
	(SELECT COUNT(*) AS Total FROM Categorias) AS TotalCategorias,
	(SELECT SUM(UsuarioId) AS Soma FROM UsuarioEvento) AS Soma
FROM Categorias