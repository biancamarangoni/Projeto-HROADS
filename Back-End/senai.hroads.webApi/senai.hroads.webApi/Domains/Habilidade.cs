using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    public class Habilidade
    {
        public int IdHabilidades { get; set; }
        public TipoHabilidade TipoHabilidade { get; set; }
        public string NomeHabilidade { get; set; }
    }
}
