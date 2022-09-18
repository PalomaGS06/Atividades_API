using APIMaisEventos.Interfaces;
using APIMaisEventos.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace APIMaisEventos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        readonly string connectionString = "Data Source=WORKSTATIONSOUZ\\SQLEXPRESS;Integrated Security=true;Initial Catalog=MaisEventos";



        public bool Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "DELETE FROM Categorias WHERE Id=@id";

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

        public ICollection<Categorias> GetAll()
        {
            var categorias = new List<Categorias>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Categorias";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorias.Add(new Categorias
                            {
                                Id = (int)reader[0],
                                Categoria = (string)reader[1],
                                Imagem = (string)reader[2].ToString(),
                            });
                        }
                    }
                }

            }

            return categorias;
        }

        public Categorias GetById(int id)
        {
            var categoria = new Categorias();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Categorias WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            categoria.Id = (int)reader[0];
                            categoria.Categoria = reader[1].ToString();
                            categoria.Imagem = reader[2].ToString();

                        }
                    }
                }

            }
            return categoria;
        }

        public Categorias Insert(Categorias categoria)
        {
            // Abre uma conexao
            // parametro gerencia certos comandos/conexão. Fecha tudo o que estiver aberto.
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "INSERT INTO Categorias (Categoria, Imagem) VALUES (@Categoria, @Imagem)";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = categoria.Categoria;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NVarChar).Value = categoria.Imagem;

                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

            }

            return categoria;

        }
        public Categorias Update(int id, Categorias categoria)

        {
            using (SqlConnection conexao = new SqlConnection(connectionString)) // dentro do parametro se passa a string de conexao
            {
                conexao.Open();

                // escrever a nossa consulta
                string script = "UPDATE Categorias SET Categoria=@Categoria, Imagem=@Imagem WHERE Id=@id";

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    //fazemos as declarações das variaveis por parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = categoria.Categoria;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NVarChar).Value = categoria.Imagem;


                    // Tipo de comando, tipo texto. CommandType é um Enum
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    categoria.Id = id;
                }

            }

            return categoria;
        }

        Categorias ICategoriaRepository.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
