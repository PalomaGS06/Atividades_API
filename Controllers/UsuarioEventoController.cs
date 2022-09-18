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
    public class UsuarioEventoController : ControllerBase
    {
        private UsuarioEventoRepository repositorio = new UsuarioEventoRepository();


        // POST - Cadastrar
        /// <summary>
        /// Cadastra usuários e eventos
        /// </summary>
        /// <param name="usuarioEvento">Id do usuário e do evento</param>
        /// <returns> Registros dos usuários e eventos cadastrados</returns>

        [HttpPost]
        public IActionResult Cadastrar([FromForm] UsuarioEvento usuarioEvento)
        {
            try
            {
                repositorio.Insert(usuarioEvento);
                return Ok(usuarioEvento);
                
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
        /// Lista todos os usuários e eventos da aplicação
        /// </summary>
        /// <returns>Lista do usuários e eventos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                //conexao.Close() = fecha a conexao 
                var usuariosEventos = repositorio.GetAll();
                return Ok(usuariosEventos); 

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
        /// Altera os dados de um usuario e/ou de um evento
        /// </summary>
        /// <param name="id"> Ids do usuário e evento</param>
        /// <param name="usuariosEventos">Todas as informações do usuário e dos eventos</param>
        /// <returns>Usuário e Evento Alterados!</returns>

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, UsuarioEvento usuariosEventos)
        {
            try
            {
                var buscarUsuarioEvento = repositorio.GetById(id);
                if (buscarUsuarioEvento == null)
                {
                    return NotFound();
                }

                var usuarioAlterado = repositorio.Update(id, usuariosEventos);
                return Ok(usuariosEventos);

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
        /// Exclui um usuário ou evento da aplicação
        /// </summary>
        /// <param name="id">Id do usuário e Id do evento</param>
        /// <returns>Mensagem de exclusão</returns>

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                var buscarUsuarioEvento = repositorio.GetById(id);
                if (buscarUsuarioEvento == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Usuário e/ou excluído com sucesso"
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


        }
    }
}
