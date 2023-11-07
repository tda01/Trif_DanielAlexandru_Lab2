using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trif_DanielAlexandru_Lab2.Data;
using Trif_DanielAlexandru_Lab2.Models;

namespace Trif_DanielAlexandru_Lab2.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Trif_DanielAlexandru_Lab2.Data.Trif_DanielAlexandru_Lab2Context _context;

        public DetailsModel(Trif_DanielAlexandru_Lab2.Data.Trif_DanielAlexandru_Lab2Context context)
        {
            _context = context;
        }

      public Member Member { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }
    }
}
