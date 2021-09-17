using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Retorna todos as ClasseHabilidade
        /// </summary>
        /// <returns>Uma lista de ClasseHabilidade</returns>
        List<ClasseHabilidade> ListarTodos();

        /// <summary>
        /// Busca uma ClasseHabilidade através do seu id
        /// </summary>
        /// <param name="idClasseHabilidade">Id da ClasseHabilidade que será buscado</param>
        /// <returns>Um objeto do tipo ClasseHabilidade que foi buscada</returns>
        ClasseHabilidade BuscarPorId(int idClasseHabilidade);

        /// <summary>
        /// Deleta uma ClasseHabilidade
        /// </summary>
        /// <param name="idClasseHabilidade">Id da ClasseHabilidade que será deletado</param>
        void Deletar(int idClasseHabilidade);

        /// <summary>
        /// Atualiza uma ClasseHabilidade existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idClasseHabilidade">id da ClasseHabilidade que será atualizado</param>
        /// <param name="ClasseHabilidadeAtualizado">Objeto ClasseHabilidadeAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/ClasseHabilidade/atualizar/3
        void Atualizar(int idClasseHabilidade, ClasseHabilidade ClasseHabilidadeAtualizado);

        /// <summary>
        /// Cadastra uma novo ClasseHabilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto novaClasseHabilidade com os dados que serão cadastrados</param>
        void Inserir(ClasseHabilidade novaClasseHabilidade);
    }
}
