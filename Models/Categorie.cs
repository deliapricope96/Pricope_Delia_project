using System.ComponentModel.DataAnnotations;

namespace Pricope_Delia_project.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        [Display(Name = "Categorie")]
        public string NumeCategorie { get; set; }

        public ICollection<Produs>? Produse { get; set; } 
    }
}