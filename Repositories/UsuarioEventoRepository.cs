using APIMaisEventos.Interfaces;
using APIMaisEventos.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIMaisEventos.Repositories
{
    public class UsuarioEventoRepository : IUsuarioEventoRepository
    {
        readonly string connectionString = "Data Source=WORKSTATIONSOUZ\\SQLEXPRESS;Integrated Security=true;Initial Catalog=MaisEventos";

        public bool Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "DELETE FROM UsuarioEvento WHERE Id=@id";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Tipo de comando, tipo texto. CommandType é um Enum
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

        public ICollection<UsuarioEvento> GetAll()
        {
            var usuariosEventos = new List<UsuarioEvento>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = @"SELECT * FROM UsuarioEvento
                                    JOIN Usuarios ON UsuarioEvento.UsuarioId = Usuarios.Id
                                    JOIN Eventos ON UsuarioEvento.EventoId = Eventos.Id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Ler todos os itens da consulta
                    using (SqlDataReader result = cmd.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            usuariosEventos.Add(new UsuarioEvento
                            {
                                Id = (int)result[0],
                                UsuarioId = (int)result[1],
                                EventoId = (int)result[2],

                            });
                        }
                    }
                }

            }

            return usuariosEventos;
        }

        public UsuarioEvento GetById(int id)
        {
            var usuariosEventos = new UsuarioEvento();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "SELECT * FROM UsuarioEvento WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            usuariosEventos.Id = (int)reader[0];
                            usuariosEventos.UsuarioId = (int)reader[1];
                            usuariosEventos.EventoId = (int)reader[2];


                        }
                    }
                }

            }
            return usuariosEventos;
        }

        public UsuarioEvento Insert(UsuarioEvento usuarioEvento)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "INSERT INTO UsuarioEvento (UsuarioId, EventoId) VALUES (@UsuarioId, @EventoId)";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = usuarioEvento.UsuarioId;
                    cmd.Parameters.Add("@EventoId", SqlDbType.Int).Value = usuarioEvento.EventoId;

                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

            }

            return usuarioEvento;
        }

        public UsuarioEvento Update(int id, UsuarioEvento usuarioEvento)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "UPDATE UsuarioEvento SET UsuarioId = @UsuarioId, EventoId = @EventoId WHERE Id=@id";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = usuarioEvento.UsuarioId;
                    cmd.Parameters.Add("@EventoId", SqlDbType.Int).Value = usuarioEvento.EventoId;
                   
                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    usuarioEvento.Id = id;
                }

            }

            return usuarioEvento;
        }

        UsuarioEvento IUsuarioEventoRepository.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        UsuarioEvento IUsuarioEventoRepository.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
