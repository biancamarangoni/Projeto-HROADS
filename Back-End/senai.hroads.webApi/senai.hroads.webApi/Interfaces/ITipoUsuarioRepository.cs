using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Retorna todos os TipoUsuario
        /// </summary>
        /// <returns>Uma lista de TipoUsuario</returns>
        List<TipoUsuario> ListarTodos();

        /// <summary>
        /// Busca um TipoUsuario através do seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do TipoUsuario que será buscado</param>
        /// <returns>Um objeto do tipo TipoUsuario que foi buscado</returns>
        TipoUsuario BuscarPorId(int idTipoUsuario);

        /// <summary>
        /// Deleta um TipoUsuario
        /// </summary>
        /// <param name="idTipoUsuario">Id do TipoUsuario que será deletado</param>
        void Deletar(int idTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoUsuario">id do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/TipoUsuario/atualizar/3
        void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado);

        public void Cadastrar(TipoUsuario TipoUsuario);
    }
}
