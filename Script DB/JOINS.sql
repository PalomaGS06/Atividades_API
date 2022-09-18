/* JOINS - Junções */

INSERT INTO UsuarioEvento (EventoId) VALUES (3);
INSERT INTO UsuarioEvento (UsuarioId) VALUES (1);

/* SELECT Padrão */
SELECT * FROM UsuarioEvento;

/* INNER JOIN  */
SELECT * FROM UsuarioEvento
	INNER JOIN Usuarios ON Usuarios.Id = UsuarioEvento.UsuarioId;


/* LEFT JOIN  */
SELECT * FROM UsuarioEvento
	LEFT JOIN Usuarios ON Usuarios.Id = UsuarioEvento.UsuarioId;

/* RIGHT JOIN  */
SELECT * FROM UsuarioEvento
	RIGHT JOIN Usuarios ON Usuarios.Id = UsuarioEvento.UsuarioId;