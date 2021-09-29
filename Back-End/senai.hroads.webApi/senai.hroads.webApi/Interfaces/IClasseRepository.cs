using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {

        /// <summary>
        /// Retorna todos as Classe
        /// </summary>
        /// <returns>Uma lista de Classes</returns>
        List<Classe> ListarTodos();

        /// <summary>
        /// Busca uma Classe através do seu id
        /// </summary>
        /// <param name="idClasse">Id da Classe que será buscado</param>
        /// <returns>Um objeto do tipo Classe que foi buscada</returns>
        Classe BuscarPorId(int idClasse);

        public void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Deleta uma Classe
        /// </summary>
        /// <param name="idClasse">Id da Classe que será deletado</param>
        void Deletar(int idClasse);

        /// <summary>
        /// Atualiza uma Classe existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idClasse">id da Classe que será atualizado</param>
        /// <param name="ClasseAtualizado">Objeto ClasseAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/Classe/atualizar/3
        void Atualizar(int idClasse, Classe ClasseAtualizado);
    }
}
