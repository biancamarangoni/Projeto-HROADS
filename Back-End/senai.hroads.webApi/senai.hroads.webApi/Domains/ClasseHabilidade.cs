using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    public class ClasseHabilidade
    {
        public int IdClasseHabilidade { get; set; }
        public Classe classe { get; set; }
        public Habilidade habilidade { get; set; }
    }
}
