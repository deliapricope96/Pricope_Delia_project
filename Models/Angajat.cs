using System.ComponentModel.DataAnnotations;

namespace Pricope_Delia_project.Models
{
    public class Angajat
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Display(Name = "Nume Complet")]
        public string FullName => $"{Nume} {Prenume}";

        [Required, EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Telefonul trebuie să înceapă cu 07 și să aibă 10 cifre.")]
        public string Telefon { get; set; }


        [Required]
        public string Functie { get; set; } // Cofetar sau Administrator
    }
}