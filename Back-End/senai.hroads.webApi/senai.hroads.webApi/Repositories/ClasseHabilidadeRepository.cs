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
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClassHab, ClasseHabilidade ClassHabAtualizada)
        {
            ClasseHabilidade Buscado = BuscarPorId(idClassHab);

            if (ClassHabAtualizada.IdHabilidade != null)
            {
                Buscado.IdHabilidade = ClassHabAtualizada.IdHabilidade;
            }
            else if (ClassHabAtualizada.IdClasse != null)
            {
                Buscado.IdClasse = ClassHabAtualizada.IdClasse;
            }

            ctx.ClasseHabilidades.Update(Buscado);

            ctx.SaveChanges();
        }

        public ClasseHabilidade BuscarPorId(int idClassHab)
        {

            return ctx.ClasseHabilidades.FirstOrDefault(cb => cb.IdClasseHabilidade == idClassHab);
        }

        public void Cadastrar(ClasseHabilidade ClassHab)
        {
            ctx.ClasseHabilidades.Add(ClassHab);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasseHab)
        {
            ClasseHabilidade Buscado = BuscarPorId(idClasseHab);

            ctx.ClasseHabilidades.Add(Buscado);

            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ListarTodos()
        {
            return ctx.ClasseHabilidades.Select(x => new ClasseHabilidade
            {
                IdClasseHabilidade = x.IdClasseHabilidade,
                IdClasseNavigation = new Classe
                {
                    NomeClasse = x.IdClasseNavigation.NomeClasse
                },
                IdHabilidadeNavigation = new Habilidade
                {
                    NomeHabilidade = x.IdHabilidadeNavigation.NomeHabilidade
                }
            }).Include(x => x.IdClasseNavigation).Include(x => x.IdHabilidadeNavigation).ToList();
        }
    }
}
