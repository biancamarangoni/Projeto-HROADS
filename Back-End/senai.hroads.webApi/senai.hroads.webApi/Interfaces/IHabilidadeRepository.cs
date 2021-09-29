using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Retorna todos as Habilidade
        /// </summary>
        /// <returns>Uma lista de Habilidade</returns>
        List<Habilidade> ListarTodos();

        /// <summary>
        /// Busca uma Habilidade através do seu id
        /// </summary>
        /// <param name="idHabilidade">Id da Habilidade que será buscado</param>
        /// <returns>Um objeto do tipo Habilidade que foi buscada</returns>
        Habilidade BuscarPorId(int idHabilidade);

        /// <summary>
        /// Deleta uma Habilidade
        /// </summary>
        /// <param name="idHabilidade">Id da Habilidade que será deletado</param>
        void Deletar(int idHabilidade);

        public void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma Habilidade existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idHabilidade">id da Habilidade que será atualizado</param>
        /// <param name="HabilidadeAtualizado">Objeto HabilidadeAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/Habilidade/atualizar/3
        void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado);
    }
}
