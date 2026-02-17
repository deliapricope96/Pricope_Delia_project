using System.ComponentModel.DataAnnotations;

namespace Pricope_Delia_project.Models
{
    public class Comanda
    {
        public int ID { get; set; }

        [Display(Name = "Data Comenzii")]
        [DataType(DataType.Date)]
        public DateTime DataComanda { get; set; }

        [Range(1, 100)]
        public int Cantitate { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? ProdusID { get; set; }
        public Produs? Produs { get; set; }
    }
}