using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;

namespace FizzBuzzWeb.Pages.Forms
{
    public class CreateModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.AppDbContext _context;

        public CreateModel(FizzBuzzWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Form Form { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Form == null || Form == null)
            {
                return Page();
            }

            _context.Form.Add(Form);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
