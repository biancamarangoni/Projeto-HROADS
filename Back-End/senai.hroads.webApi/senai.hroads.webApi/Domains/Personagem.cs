using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    public class Personagem
    {
        public int IdPersonagem { get; set; }
        public Classe Classe { get; set; }
        public string Nome { get; set; }
        public int CapacidadeMana { get; set; }
        public int CapacidadeVida { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
