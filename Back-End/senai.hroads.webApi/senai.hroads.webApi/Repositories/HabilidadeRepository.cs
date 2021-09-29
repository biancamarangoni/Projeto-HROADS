using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Context;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(idHabilidade);

            if (HabilidadeAtualizado.NomeHabilidade != null)
            {
                habilidadeBuscada.IdTipoHabilidade = HabilidadeAtualizado.IdTipoHabilidade;
                habilidadeBuscada.NomeHabilidade = HabilidadeAtualizado.NomeHabilidade;

            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();

        }

        public Habilidade BuscarPorId(int IdHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == IdHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            Habilidade habilidaeeBuscada = BuscarPorId(idHabilidade);

            ctx.Remove(habilidaeeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.Select(x => new Habilidade
            {
                IdTipoHabilidade = x.IdTipoHabilidade,
                IdTipoHabilidadeNavigation = new TipoHabilidade
                {
                    NomeTipoHabilidade = x.IdTipoHabilidadeNavigation.NomeTipoHabilidade
                }
            }).Include(x => x.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
