
using System.ComponentModel.DataAnnotations;

namespace Zenestudio.Models
{
    public class Sav
    {
        public int Id { get; set; }

        public int ProjektId { get; set; }

        public ZeneiProjekt? Projekt { get; set; }

        [Required(ErrorMessage = "A sáv neve kötelező!")]
        [StringLength(100)]
        public string SavNev { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Hangszer { get; set; }

        [Range(1, 3600)]
        public int HosszMasodperc { get; set; }
    }
}
