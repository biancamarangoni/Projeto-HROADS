using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Retorna todos as TipoHabilidade
        /// </summary>
        /// <returns>Uma lista de TipoHabilidade</returns>
        List<TipoHabilidade> ListarTodos();

        /// <summary>
        /// Busca uma TipoHabilidade através do seu id
        /// </summary>
        /// <param name="idTipoHabilidade">Id da TipoHabilidade que será buscado</param>
        /// <returns>Um objeto do tipo TipoHabilidade que foi buscada</returns>
        TipoHabilidade BuscarPorId(int idTipoHabilidade);

        /// <summary>
        /// Deleta uma TipoHabilidade
        /// </summary>
        /// <param name="idTipoHabilidade">Id da TipoHabilidade que será deletado</param>
        void Deletar(int idTipoHabilidade);

        /// <summary>
        /// Atualiza uma TipoHabilidade existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoHabilidade">id da TipoHabilidade que será atualizado</param>
        /// <param name="TipoHabilidadeAtualizado">Objeto TipoHabilidadeAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/TipoHabilidade/atualizar/3
        void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizado);

        public void Cadastrar(TipoHabilidade TipoHabilidade);
    }
}
