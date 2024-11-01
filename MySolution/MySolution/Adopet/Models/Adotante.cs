using System;
using System.Collections.Generic;

namespace Adopet.Models
{
    public class Adotante
    {
        public int AdotanteId { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public List<Adocao> Adocoes { get; set; } = new List<Adocao>();
    }
}
