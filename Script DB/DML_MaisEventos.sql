/* DML = Data Manipulation Language - Linguagem de Manipulação de Dados */

/* Inserir*/
INSERT INTO Categorias (Categoria) VALUES ('Show');
INSERT INTO Categorias (Categoria) VALUES ('Teatro');

/* Forma 2 */
INSERT INTO Categorias(Categoria) VALUES 
									('Musical'),
									('Meet Up'),
									('Palestra');
	
INSERT INTO Usuarios (Nome, Email, Senha) VALUES ('Paloma', 'paloma.souza112@gmail.com', '123456') , ('Fernando', 'mnakauti@gmail.com', '654321');

INSERT INTO Eventos (DataHora, Ativo, Preco, CategoriaId) VALUES ('2022-09-07T22:20:00', 1, 650.00, 15);

INSERT INTO UsuarioEvento (UsuarioId, EventoId) VALUES (1, 3) , (2, 3);



/* Alterar*/
UPDATE Categorias SET Categoria = 'Show ' WHERE Id = 1;


/* Excluir*/
DELETE FROM Categorias WHERE Id = 18 ;