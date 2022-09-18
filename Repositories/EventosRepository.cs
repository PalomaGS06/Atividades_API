using APIMaisEventos.Interfaces;
using APIMaisEventos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIMaisEventos.Repositories
{
    public class EventosRepository : IEventosRepository
    {
        readonly string connectionString = "Data Source=WORKSTATIONSOUZ\\SQLEXPRESS;Integrated Security=true;Initial Catalog=MaisEventos";

        public bool Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // escrever a consulta
                string script = "DELETE FROM Eventos WHERE Id=@id";

                // comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    // declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Comando do tipo texto
                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public ICollection<Eventos> GetAll()
        {
            var eventos = new List<Eventos>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = @"SELECT 
                                    E.Id AS 'Id_Evento',
                                    E.DataHora AS 'Data_Evento',
                                    E.Ativo AS 'Ativo_Evento',
                                    E.Preco AS 'Preço_Evento',
                                    E.CategoriaId AS 'Id_Categoria_Evento',
                                    C.Categoria 
                                    FROM Eventos AS E                               
                                    JOIN Categorias AS C ON E.CategoriaId = C.Id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Usando o laço while 
                        while (reader.Read() && reader != null)
                        {
                            eventos.Add(new Eventos
                            {
                                Id = (int)reader[0],
                                DataHora = Convert.ToDateTime(reader[1]),
                                Ativo = (bool)reader[2],
                                Preco = (decimal)reader[3],
                                Categoria = new Categorias
                                {
                                    Id = (int)reader["Id_Categoria_Evento"],
                                    Categoria = (string)reader[5],
                                    Imagem = null
                                }
                            });
                        }
                    }
                }

            }

            return eventos;
        }

  
        public Eventos GetById(int id)
        {
            var evento = new Eventos();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = @"SELECT * FROM Eventos WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader resultReader = cmd.ExecuteReader())
                    {
                        while (resultReader.Read())
                        {

                            evento.Id = (int)resultReader[0];
                            evento.DataHora = Convert.ToDateTime(resultReader[1]);
                            evento.Ativo = (bool)resultReader[2];
                            evento.Preco = (decimal)resultReader[3];
                            evento.Categoria = new Categorias
                            {
                                Id = (int)resultReader[4],
                                Imagem = null
                            };

                        }
                    }
                }

            }
            return evento;
        }

        public Eventos Insert(Eventos evento)
        {
            // Abre uma conexao
            // parametro gerencia certos comandos/conexão. Fecha tudo que estiver aberto.
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "INSERT INTO Eventos (DataHora, Ativo, Preco, CategoriaId) VALUES (@DataHora, @Ativo, @Preco, @CategoriaId)";

                // Criamos o comando de execução no BD
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = evento.DataHora;
                    cmd.Parameters.Add("@Ativo", SqlDbType.Bit).Value = evento.Ativo;
                    cmd.Parameters.Add("@Preco", SqlDbType.Decimal).Value = evento.Preco;
                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = evento?.Categoria?.Id ?? 0;


                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

            }

            return evento;

        }
        public Eventos Update(int id, Eventos eventos)

        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "UPDATE Eventos SET DataHora = @DataHora, Ativo = @Ativo, Preco = @Preco, CategoriaId = @CategoriaId WHERE Id=@id";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = eventos.DataHora;
                    cmd.Parameters.Add("@Ativo", SqlDbType.Bit).Value = eventos.Ativo;
                    cmd.Parameters.Add("@Preco", SqlDbType.Decimal).Value = eventos.Preco;
                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = eventos.Categoria.Id;


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    eventos.Id = id;
                }

            }

            return eventos;
        }

        Eventos IEventosRepository.Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
