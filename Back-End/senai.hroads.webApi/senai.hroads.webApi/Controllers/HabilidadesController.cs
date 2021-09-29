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
    public class HabilidadesController : ControllerBase
    {

        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Habilidade> listaHabilidade = _habilidadeRepository.ListarTodos();
                return Ok(listaHabilidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabiliade)
        {
            try
            {
                _habilidadeRepository.Cadastrar(novaHabiliade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Habilidade habilidadeBuscado = _habilidadeRepository.BuscarPorId(id);
            if (habilidadeBuscado != null)
            {
                try
                {
                    _habilidadeRepository.Deletar(id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhuma Habilidade foi encontrado!");
        }


        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscado = _habilidadeRepository.BuscarPorId(id);
            if (habilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Habilidade não encontrada!",
                        erro = true
                    });
            }
            try
            {
                _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }


        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Habilidade habilidadeBuscado = _habilidadeRepository.BuscarPorId(id);
            
                return Ok(habilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
