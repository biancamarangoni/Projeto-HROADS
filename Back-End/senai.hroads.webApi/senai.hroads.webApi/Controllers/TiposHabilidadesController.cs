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
    public class TiposHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tiposHabilidadeRepository { get; set; }

        public TiposHabilidadesController()
        {
            _tiposHabilidadeRepository = new TipoHabilidadeRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<TipoHabilidade> listaTiposHabilidade = _tiposHabilidadeRepository.ListarTodos();
                return Ok(listaTiposHabilidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            try
            {
                _tiposHabilidadeRepository.Cadastrar(novoTipoHabilidade);
                return StatusCode(201);
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
            TipoHabilidade tiposHabilidadeBuscado = _tiposHabilidadeRepository.BuscarPorId(Id);
            if (tiposHabilidadeBuscado != null)
            {
                try
                {
                    _tiposHabilidadeRepository.Deletar(Id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Tipo Habilidade foi encontrado!");
        }


        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                TipoHabilidade tiposHabilidadeBuscado = _tiposHabilidadeRepository.BuscarPorId(Id);
                return Ok(tiposHabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            TipoHabilidade tiposHabilidadeBuscado = _tiposHabilidadeRepository.BuscarPorId(Id);
            if (tiposHabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "tipos de habilidade não encontrado!",
                        erro = true
                    });
            }
            try
            {
                _tiposHabilidadeRepository.Atualizar(Id, tipoHabilidadeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
