using senai.hroads.webApi.Context;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizada)
        {

            TipoHabilidade TipoHabBuscada = BuscarPorId(idTipoHabilidade);

            if (TipoHabilidadeAtualizada.NomeTipoHabilidade != null)
            {
                TipoHabBuscada.NomeTipoHabilidade = TipoHabilidadeAtualizada.NomeTipoHabilidade;
            }

            ctx.TipoHabilidades.Update(TipoHabBuscada);

            ctx.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int idTipoHabilidade)
        {
            return ctx.TipoHabilidades.FirstOrDefault(cb => cb.IdTipoHabilidade == idTipoHabilidade);
        }

        public void Cadastrar(TipoHabilidade TipoHabilidade)
        {
            ctx.TipoHabilidades.Add(TipoHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHabilidade)
        {
            TipoHabilidade tipoHabBuscada = BuscarPorId(idTipoHabilidade);

            ctx.TipoHabilidades.Add(tipoHabBuscada);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
