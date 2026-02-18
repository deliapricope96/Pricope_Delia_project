using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pricope_Delia_project.Models
{
    public class Produs
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Denumire { get; set; }

        [Range(1, 500)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Descriere Produs")]
        public string? Descriere { get; set; }

        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; }

        public ICollection<Comanda>? Comenzi { get; set; }


    }
}