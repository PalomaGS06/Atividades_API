using APIMaisEventos.Interfaces;
using APIMaisEventos.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIMaisEventos.Repositories
{

    // REPOSITORY PATTERN ---> Padrão de repositórios que visa desacoplar a interação com o BD.

    public class UsuarioRepository : IUsuarioRepository
    {

        // Criar string de conexão com o Banco de Dados
        //variável de apenas leitura = readonly
        readonly string connectionString = "Data Source=WORKSTATIONSOUZ\\SQLEXPRESS;Integrated Security=true;Initial Catalog=MaisEventos";



        public bool Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "DELETE FROM Usuarios WHERE Id=@id";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                     if(linhasAfetadas == 0)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public ICollection<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Usuarios";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                Id = (int)reader[0],
                                Nome = (string)reader[1],
                                Email = (string)reader[2],
                                Senha = (string)reader[3],
                                Imagem = (string)reader[4].ToString(),
                            });
                        }
                    }
                }

            }

            return usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = null;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Usuarios WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new Usuario
                            {

                                Id = (int)reader[0],
                                Nome = (string)reader[1],
                                Email = (string)reader[2],
                                Senha = (string)reader[3]

                            };                  
                            
                        }
                    }
                }

            }
            return usuario;
        }

        public Usuario Insert(Usuario usuario)
        {
            // Abre uma conexao
            // parametro gerencia certos comandos/conexão. Fecha tudo o que estiver aberto.
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "INSERT INTO Usuarios (Nome, Email, Senha, Imagem) VALUES (@Nome, @Email, @Senha, @Imagem)";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = usuario.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = usuario.Email;
                    cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = usuario.Senha;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NVarChar).Value = usuario.Imagem;

                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

            }

            return usuario;

        }
            public Usuario Update(int id, Usuario usuario)

       {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "UPDATE Usuarios SET Nome=@Nome, Email=@Email, Senha=@Senha WHERE Id=@id";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = usuario.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = usuario.Email;
                    cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = usuario.Senha;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NVarChar).Value = usuario.Imagem;

                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    usuario.Id = id;
                }

            }

            return usuario;
        }

        Usuario IUsuarioRepository.Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
