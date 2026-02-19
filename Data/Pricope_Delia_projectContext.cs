using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pricope_Delia_project.Models;

namespace Pricope_Delia_project.Data
{
    public class Pricope_Delia_projectContext : DbContext
    {
        public Pricope_Delia_projectContext (DbContextOptions<Pricope_Delia_projectContext> options)
            : base(options)
        {
        }

        public DbSet<Pricope_Delia_project.Models.Categorie> Categorie { get; set; } = default!;
        public DbSet<Pricope_Delia_project.Models.Comanda> Comanda { get; set; } = default!;
        public DbSet<Pricope_Delia_project.Models.Produs> Produs { get; set; } = default!;
        public DbSet<Pricope_Delia_project.Models.Client> Client { get; set; } = default!;
        public DbSet<Pricope_Delia_project.Models.Angajat> Angajat { get; set; } = default!;
    }
}
