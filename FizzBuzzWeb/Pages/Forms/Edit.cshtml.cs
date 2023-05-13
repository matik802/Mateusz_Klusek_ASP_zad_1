using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FizzBuzzWeb.Pages.Forms
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.AppDbContext _context;

        public EditModel(FizzBuzzWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Form Form { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Form == null)
            {
                return NotFound();
            }

            var form =  await _context.Form.FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }
            Form = form;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(Form.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FormExists(int id)
        {
          return (_context.Form?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
