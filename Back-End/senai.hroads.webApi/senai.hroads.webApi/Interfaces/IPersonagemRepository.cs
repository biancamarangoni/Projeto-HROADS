using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Retorna todos os Personagem
        /// </summary>
        /// <returns>Uma lista de Personagem</returns>
        List<Personagem> ListarTodos();

        /// <summary>
        /// Busca um Personagem através do seu id
        /// </summary>
        /// <param name="idPersonagem">Id do Personagem que será buscado</param>
        /// <returns>Um objeto do tipo Personagem que foi buscado</returns>
        Personagem BuscarPorId(int idPersonagem);

        /// <summary>
        /// Deleta um Personagem
        /// </summary>
        /// <param name="idPersonagem">Id do Personagem que será deletado</param>
        void Deletar(int idPersonagem);

        /// <summary>
        /// Atualiza um Personagem existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idPersonagem">id do Personagem que será atualizado</param>
        /// <param name="PersonagemAtualizado">Objeto PersonagemAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/Personagem/atualizar/3
        void Atualizar(int idPersonagem, Personagem PersonagemAtualizado);


        public void Cadastrar(Personagem personagem);
    }
}
