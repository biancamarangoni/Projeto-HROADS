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
    public class TiposUsuariosController : ControllerBase
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = _tipoUsuarioRepository.ListarTodos();
                return Ok(listaTipoUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

     
        [Authorize(Roles = "1")]
        [HttpGet("{IdTipoUsuario}")]
        public IActionResult BuscarPorId(int IdTipoUsuario)
        {
            try
            {
                TipoUsuario tiposUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(IdTipoUsuario);
                return Ok(tiposUsuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

       
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        
        [Authorize(Roles = "1")]
        [HttpPut("{IdTipoUsuario}")]
        public IActionResult Atualizar(int IdTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(IdTipoUsuario);
            if (tipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "tipos de Usuários não encontrado!",
                        erro = true
                    });
            }
            try
            {
                _tipoUsuarioRepository.Atualizar(IdTipoUsuario, tipoUsuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{IdTipoUsuario}")]
        public IActionResult Deletar(int IdTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(IdTipoUsuario);
            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Deletar(IdTipoUsuario);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Tipo Usuário foi encontrado!");
        }
    }
}
