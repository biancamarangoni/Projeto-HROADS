using senai.hroads.webApi.Context;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int IdClasse, Classe classeAtualizado)
        {
            Classe classeBuscado = BuscarId(IdClasse);

            if (classeAtualizado.NomeClasse != null)
            {
                classeBuscado.NomeClasse = classeAtualizado.NomeClasse;
            }

            ctx.Classes.Update(classeBuscado);

            ctx.SaveChanges();
        }

        public Classe BuscarId(int IdClasse)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == IdClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int IdClasse)
        {
            Classe classeBuscado = BuscarId(IdClasse);

            ctx.Classes.Remove(classeBuscado);

            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }

        Classe IClasseRepository.BuscarPorId(int IdClasse)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == IdClasse);
        }
    }
}

