using APIMaisEventos.Models;
using APIMaisEventos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace APIMaisEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase 
    {
      
        private EventosRepository repositorio = new EventosRepository();

        // POST - Cadastrar
        /// <summary>
        /// Cadastra os eventos
        /// </summary>
        /// <param name="eventos">Informações dos eventos disponíveis</param>
        /// <returns>Dados dos eventos cadastrados</returns>

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Eventos eventos)
        {
            try
            {

                repositorio.Insert(eventos);
                return Ok(eventos);

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
        /// Lista todos os eventos da aplicação
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                var eventos = repositorio.GetAll();
                return Ok(eventos); //retorna a lista de eventos

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
        /// Altera um evento
        /// </summary>
        /// <param name="id"> Id do evento</param>
        /// <param name="evento">Todos os Eventos existentes</param>
        /// <returns>Evento Alterado!</returns>

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Eventos evento)
        {
            try
            {
                var buscarEvento = repositorio.GetById(id);
                if (buscarEvento == null)
                {
                    return NotFound();
                }

                var eventoAtualizado = repositorio.Update(id, evento);
                return Ok(evento);

            }
            catch (InvalidOperationException e)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão...",
                    erro = e.Message,
                });
            }
            catch (SqlException e)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na sintaxe do código SQL...",
                    erro = e.Message,
                });
            }
            // Sempre será o ultimo
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na definição do código...",
                    erro = e.Message
                });
            }
        }

        // DELETE - Excluir
        /// <summary>
        /// Exclui um evento
        /// </summary>
        /// <param name="id">Id do Evento </param>
        /// <returns>Mensagem de remoção</returns>

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                var buscarEvento = repositorio.GetById(id);
                if (buscarEvento == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Evento deletado com sucesso!"
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
