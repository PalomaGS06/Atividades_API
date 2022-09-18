using APIMaisEventos.Models;
using APIMaisEventos.Repositories;
using APIMaisEventos.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace APIMaisEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase

    {

        private CategoriaRepository repositorio = new CategoriaRepository();



        // POST - Cadastrar
        /// <summary>
        /// Cadastra as categorias do evento
        /// </summary>
        /// <param name="categorias">Categorias presentes</param>
        /// <param name="arquivo"></param>
        /// <returns>Dados das categorias cadastradas</returns>

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Categorias categorias, IFormFile arquivo)
        {
            try
            {
                #region Upload de Imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas, "Images");

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extensão não permitida!");
                }

                categorias.Imagem = uploadResultado;

                #endregion

                repositorio.Insert(categorias);
                return Ok(categorias);
                
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
        /// Lista todas as categorias da aplicação
        /// </summary>
        /// <returns>Lista de Categorias</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
 
                var categorias = repositorio.GetAll();
                return Ok(categorias); //retorna a lista de categorias

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
        /// Altera uma categoria
        /// </summary>
        /// <param name="id"> Id da categoria</param>
        /// <param name="categoria"> Todas as categorias contidas</param>
        /// <returns>Categoria Alterada!</returns>

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Categorias categoria)
        {
            try
            {
                var buscarCategoria = repositorio.GetById(id);
                if (buscarCategoria == null)
                {
                    return NotFound();
                }

                var categoriaAlterada = repositorio.Update(id, categoria);
                return Ok(categoria);

            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na sintaxe do código SQL",
                    erro = ex.Message,
                });
            }
            // Sempre o ultimo
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na definição do código",
                    erro = ex.Message
                });
            }
        }

        // DELETE - Excluir
        /// <summary>
        /// Exclui uma categoria contida no evento
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        /// <returns>Mensagem de exclusão</returns>

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {

                var buscarCategoria = repositorio.GetById(id);
                if (buscarCategoria == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Categoria excluída com sucesso"
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
