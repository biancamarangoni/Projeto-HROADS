using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Retorna todos os Usuario
        /// </summary>
        /// <returns>Uma lista de Usuario</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um Usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">Id do Usuario que será buscado</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="idUsuario">Id do Usuario que será deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Atualiza um Usuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoUsuario">id do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/Usuario/atualizar/3
        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto Usuario com os dados que serão cadastrados</param>
        void Inserir(Usuario novoTipoUsuario);
    }
}
