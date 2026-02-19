using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pricope_Delia_project.Data;
using Pricope_Delia_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pricope_Delia_project.Pages.Angajati
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Pricope_Delia_project.Data.Pricope_Delia_projectContext _context;

        public IndexModel(Pricope_Delia_project.Data.Pricope_Delia_projectContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Angajat = await _context.Angajat.ToListAsync();
        }
    }
}
