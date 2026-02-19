using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pricope_Delia_project.Data;
using Pricope_Delia_project.Models;

namespace Pricope_Delia_project.Pages.Comenzi
{
    public class CreateModel : PageModel
    {
        private readonly Pricope_Delia_project.Data.Pricope_Delia_projectContext _context;

        public CreateModel(Pricope_Delia_project.Data.Pricope_Delia_projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "FullName");
        ViewData["ProdusID"] = new SelectList(_context.Set<Produs>(), "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            Comanda.Status = "In Asteptare"; // aici bagam statusul initial
            _context.Comanda.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
