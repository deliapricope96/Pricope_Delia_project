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

        public async Task OnGetAsync()
        {
            Comanda = await _context.Comanda
                .Include(c => c.Client)
                .Include(c => c.Produs).ToListAsync();
        }
    }
}
