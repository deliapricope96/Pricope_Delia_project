using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pricope_Delia_project.Data;
using Pricope_Delia_project.Models;

namespace Pricope_Delia_project.Pages.Comenzi
{
    public class IndexModel : PageModel
    {
        private readonly Pricope_Delia_project.Data.Pricope_Delia_projectContext _context;

        public IndexModel(Pricope_Delia_project.Data.Pricope_Delia_projectContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comanda { get;set; } = default!;

        public async Task OnGetAsync(string searchString, List<string> selectedStatuses)
        {
            ViewData["CurrentFilter"] = searchString;
            // Salvăm statusurile selectate pentru a păstra checkbox-urile bifate după refresh
            ViewData["SelectedStatuses"] = selectedStatuses ?? new List<string>();

            var comenziQuery = _context.Comanda
                .Include(c => c.Client)
                .Include(c => c.Produs)
                .AsQueryable();

            // 1. Filtrare după SearchString (ID sau Nume)
            if (!String.IsNullOrEmpty(searchString))
            {
                bool isNumeric = int.TryParse(searchString, out int searchId);
                if (isNumeric)
                    comenziQuery = comenziQuery.Where(s => s.ID == searchId);
                else
                    comenziQuery = comenziQuery.Where(s => s.Client.Nume.Contains(searchString)
                                                   || s.Client.Prenume.Contains(searchString));
            }

            // 2. Filtrare după Checkbox-uri (Status)
            if (selectedStatuses != null && selectedStatuses.Any())
            {
                comenziQuery = comenziQuery.Where(s => selectedStatuses.Contains(s.Status));
            }

            Comanda = await comenziQuery.ToListAsync();
        }
    }
}
