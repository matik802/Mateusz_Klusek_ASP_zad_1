using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;

namespace FizzBuzzWeb.Pages.Forms
{
    public class DetailsModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.AppDbContext _context;

        public DetailsModel(FizzBuzzWeb.Data.AppDbContext context)
        {
            _context = context;
        }

      public Form Form { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Form == null)
            {
                return NotFound();
            }

            var form = await _context.Form.FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }
            else 
            {
                Form = form;
            }
            return Page();
        }
    }
}
