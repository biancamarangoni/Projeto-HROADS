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
    [Produces("application/jsn")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }


        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Personagem> listaPersonagem = _personagemRepository.ListarTodos();
                return Ok(listaPersonagem);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPersonagem);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Personagem personagemBuscado = _personagemRepository.BuscarPorId(id);
            if (personagemBuscado != null)
            {
                try
                {
                    _personagemRepository.Deletar(id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum personagem foi encontrado!");
        }


        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = _personagemRepository.BuscarPorId(id);
            if (personagemBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Personagem não encontrado!",
                        erro = true
                    });
            }
            try
            {
                _personagemRepository.Atualizar(id, personagemAtualizado);
              
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }


        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Personagem personagemBuscado = _personagemRepository.BuscarPorId(id);
              
                return Ok(personagemBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
