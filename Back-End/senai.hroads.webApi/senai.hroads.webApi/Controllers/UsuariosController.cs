using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Usuario> listaUsuario = _usuarioRepository.ListarTodos();
                return Ok(listaUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        
        [Authorize(Roles = "1")]
        [HttpGet("{IdUsuario}")]
        public IActionResult BuscarPorId(int IdUsuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{IdUsuario}")]
        public IActionResult Atualizar(int IdUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
            if (usuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuários não encontrado!",
                        erro = true
                    });
            }
            try
            {
                _usuarioRepository.Atualizar(IdUsuario, usuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{IdUsuario}")]
        public IActionResult Deletar(int IdUsuario)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Deletar(IdUsuario);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Usuário foi encontrado!");
        }
    }
}
