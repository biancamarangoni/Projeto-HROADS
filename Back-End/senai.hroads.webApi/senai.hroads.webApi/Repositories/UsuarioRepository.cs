using senai.hroads.webApi.Context;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();


        public void Atualizar(int IdUsuario, Usuario usuarioAtualizado)
        {

            Usuario usuarioBuscado = BuscarId(IdUsuario);

            if (usuarioAtualizado.Email != null || usuarioAtualizado.Senha != null || usuarioAtualizado.IdTipoUsuario != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarId(int IdUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int IdUsuario)
        {
            Usuario usuarioBuscado = BuscarId(IdUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.Select(x => new Usuario
            {
                IdTipoUsuarioNavigation = x.IdTipoUsuarioNavigation,
                IdUsuario = x.IdUsuario,
                Email = x.Email,
            }).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
