using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pricope_Delia_project.Data;
using Pricope_Delia_project.Models;

namespace Pricope_Delia_project.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly Pricope_Delia_project.Data.Pricope_Delia_projectContext _context;

        public IndexModel(Pricope_Delia_project.Data.Pricope_Delia_projectContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            // Păstrăm valoarea căutată pentru a o reafișa în input
            ViewData["CurrentFilter"] = searchString;

            // Pornim de la interogarea de bază
            var clientiQuery = from c in _context.Client
                               select c;

            // Dacă utilizatorul a scris ceva în căutare
            if (!String.IsNullOrEmpty(searchString))
            {
                clientiQuery = clientiQuery.Where(s => s.Nume.Contains(searchString)
                                               || s.Prenume.Contains(searchString)
                                               || s.Email.Contains(searchString));
            }

            Client = await clientiQuery.ToListAsync();
        }
    }
}
