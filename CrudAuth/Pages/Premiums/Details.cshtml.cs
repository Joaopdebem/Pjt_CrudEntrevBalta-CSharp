using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudAuth.Data;
using CrudAuth.Models;

namespace CrudAuth.Pages_Premiums
{
    public class DetailsModel : PageModel
    {
        private readonly CrudAuth.Data.ApplicationDbContext _context;

        public DetailsModel(CrudAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Premium Premium { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Premiums == null)
            {
                return NotFound();
            }

            var premium = await _context.Premiums.FirstOrDefaultAsync(m => m.Id == id);
            if (premium == null)
            {
                return NotFound();
            }
            else 
            {
                Premium = premium;
            }
            return Page();
        }
    }
}
