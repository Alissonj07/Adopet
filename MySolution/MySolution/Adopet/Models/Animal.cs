using System.Collections.Generic;

namespace Adopet.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public bool DisponivelParaAdocao { get; set; }

        public int AbrigoId { get; set; } // Chave estrangeira
        public Abrigo Abrigo { get; set; } // Propriedade de navegação para o Abrigo
    }
}
