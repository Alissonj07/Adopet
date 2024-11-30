using System.Collections.Generic;

namespace Adopet.Models
{
    public class Adotante
    {
        public int AdotanteId { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }

        // Propriedade de navegação para representar as adoções feitas pelo adotante
        public List<Adocao> Adocoes { get; set; } = new List<Adocao>();
    }
}
