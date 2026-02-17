using System.ComponentModel.DataAnnotations;

namespace Pricope_Delia_project.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string Nume { get; set; }

        [Required, StringLength(50)]
        public string Prenume { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Telefonul trebuie să aibă 10 cifre și să înceapă cu 07")]
        public string? Telefon { get; set; }

        [Display(Name = "Client")]
        public string? FullName => $"{Nume} {Prenume}";

        public ICollection<Comanda>? Comenzi { get; set; }
    }
}