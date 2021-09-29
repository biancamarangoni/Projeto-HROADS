using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClassesHabilidadesController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<ClasseHabilidade> listaClasseHabilidade = _classeHabilidadeRepository.ListarTodos();
                return Ok(listaClasseHabilidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarPorId(Id);

                return Ok(classeHabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novoClasseHabilidade)
        {
            try
            {
                _classeHabilidadeRepository.Cadastrar(novoClasseHabilidade);
              
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, ClasseHabilidade classeHabilidadeAtualizado)
        {
            ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarPorId(Id);
            if (classeHabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "ClasseHabilidade não encontrada!",
                        erro = true
                    });
            }
            try
            {
                _classeHabilidadeRepository.Atualizar(Id, classeHabilidadeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarPorId(Id);
            if (classeHabilidadeBuscado != null)
            {
                try
                {
                    _classeHabilidadeRepository.Deletar(Id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhuma Classe_Habilidade foi encontrado!");
        }
    }
}
