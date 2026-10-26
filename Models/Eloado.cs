
using System.ComponentModel.DataAnnotations;

namespace Zenestudio.Models
{
    public class Eloado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Az előadó neve kötelező!")]
        [StringLength(100)]
        public string Nev { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Muvesznev { get; set; }

        [EmailAddress(ErrorMessage = "Érvénytelen e-mail cím!")]
        public string? Email { get; set; }

        public List<ZeneiProjekt> Projektek { get; set; } = new();
    }
}
