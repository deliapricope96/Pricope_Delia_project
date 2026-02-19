using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pricope_Delia_project.Data;
using Pricope_Delia_project.Models;

namespace Pricope_Delia_project.Pages.Angajati
{
    public class DetailsModel : PageModel
    {
        private readonly Pricope_Delia_project.Data.Pricope_Delia_projectContext _context;

        public DetailsModel(Pricope_Delia_project.Data.Pricope_Delia_projectContext context)
        {
            _context = context;
        }

        public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajat.FirstOrDefaultAsync(m => m.ID == id);
            if (angajat == null)
            {
                return NotFound();
            }
            else
            {
                Angajat = angajat;
            }
            return Page();
        }
    }
}
