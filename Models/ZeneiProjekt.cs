
using System.ComponentModel.DataAnnotations;

namespace Zenestudio.Models
{
    public class ZeneiProjekt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A projekt címe kötelező!")]
        [StringLength(150)]
        public string Cim { get; set; } = string.Empty;

        public int EloadoId { get; set; }

        public Eloado? Eloado { get; set; }

        [Required(ErrorMessage = "A műfaj megadása kötelező!")]
        public string Stilus { get; set; } = string.Empty;

        [Range(40, 250, ErrorMessage = "A BPM 40 és 250 közé essen!")]
        public int BPM { get; set; } = 120;

        [Required]
        public string Statusz { get; set; } = "Ötlet";

        public DateTime LetrehozasDatum { get; set; }
            = DateTime.Today;

        public List<Sav> Savok { get; set; } = new();
    }
}
