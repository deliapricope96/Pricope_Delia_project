using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pricope_Delia_project.Data;
using Pricope_Delia_project.Models;

namespace Pricope_Delia_project.Pages.Categorii
{
    public class DetailsModel : PageModel
    {
        private readonly Pricope_Delia_project.Data.Pricope_Delia_projectContext _context;

        public DetailsModel(Pricope_Delia_project.Data.Pricope_Delia_projectContext context)
        {
            _context = context;
        }

        public Categorie Categorie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, string sortOrder)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Def param de sortare pentru a-i folosi in link-uri
            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSort"] = sortOrder == "Pret" ? "pret_desc" : "Pret";

            var categorieQuery = _context.Categorie
                .Include(c => c.Produse)
                .Where(c => c.ID == id);

            var categorie = await categorieQuery.FirstOrDefaultAsync();

            if (categorie == null)
            {
                return NotFound();
            }

            // Logica de sortare 
            if (categorie.Produse != null)
            {
                categorie.Produse = sortOrder switch
                {
                    "name_desc" => categorie.Produse.OrderByDescending(p => p.Denumire).ToList(),
                    "Pret" => categorie.Produse.OrderBy(p => p.Pret).ToList(),
                    "pret_desc" => categorie.Produse.OrderByDescending(p => p.Pret).ToList(),
                    _ => categorie.Produse.OrderBy(p => p.Denumire).ToList(),
                };
            }

            Categorie = categorie;
            return Page();
        }
    }
}
