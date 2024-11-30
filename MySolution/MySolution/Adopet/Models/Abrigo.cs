using System.Collections.Generic;

namespace Adopet.Models
{
    public class Abrigo
    {
        public int AbrigoId { get; set; } // Identificador do abrigo
        public string Nome { get; set; } // Nome do abrigo
        public string Localizacao { get; set; } // Localização do abrigo

        // Relacionamento com os animais que estão no abrigo
        public List<Animal> Animais { get; set; } = new List<Animal>(); // Lista de animais no abrigo
    }
}
