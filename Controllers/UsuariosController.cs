using APIMaisEventos.Models;
using APIMaisEventos.Repositories;
using APIMaisEventos.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIMaisEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //criar uma instância

        private UsuarioRepository repositorio = new UsuarioRepository();



        // POST - Cadastrar
        /// <summary>
        /// Cadastra usuários na aplicação
        /// </summary>
        /// <param name="usuario">Dados dos usuários</param>
        /// <returns>Dados do usuário cadastrado</returns>

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Usuario usuario, IFormFile arquivo)
        {
            try
            {
                #region Upload de Imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas, "Images");

                if(uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extensão não permitida!");
                }

                usuario.Imagem = uploadResultado;

                #endregion

                repositorio.Insert(usuario);
                return Ok(usuario);
                // BadRequest()= quando está faltando parâmetros.
                // NoContent() = Não tem conteúdo de retorno.
                // NoFound() = Quando não encontra o usuário, objeto por exemplo.
            }
            catch (System.Exception e)
            {
                return StatusCode(500, new      //retornar código e mensagem
                {
                    msg = "Falha na conexão",
                    erro = e.Message,
                }); 
            }
        }

        // GET - Listar
        /// <summary>
        /// Lista todos os usuários da aplicação
        /// </summary>
        /// <returns>Lista do usuário</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                //conexao.Close() = fecha a conexao 
               var usuarios = repositorio.GetAll();
                return Ok(usuarios); //retorna a lista de usuarios

            }
            catch (System.Exception e)
            {

                return StatusCode(500, new      
                {
                    msg = "Falha na conexão",
                    erro = e.Message,
                });
            }

        }


        // PUT - Alterar
        /// <summary>
        /// Altera os dados de um usuario
        /// </summary>
        /// <param name="id"> Id do usuário</param>
        /// <param name="usuario">Todas as informações do usuário</param>
        /// <returns>Usuário Alterado!</returns>

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario) 
        {
            try
            {
                var buscarUsuario = repositorio.GetById(id);
                if (buscarUsuario == null)
                {
                    return NotFound();
                }

                var usuarioAlterado = repositorio.Update(id, usuario);
                return Ok(usuario);

            }
            catch (System.Exception e)
            {

                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = e.Message,
                });
            }
        }

        // DELETE - Excluir
        /// <summary>
        /// Exclui um usuário da aplicação
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Mensagem de exclusão</returns>

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {

                var buscarUsuario = repositorio.GetById(id);
                if (buscarUsuario is null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Usuário excluído com sucesso"
                });
            }
            catch (System.Exception e)
            {

                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = e.Message,
                });
            }



            // SINGLETON --> Muito usado em projetos de Consoles
            //Upload de Imagens




        }

    }
}
