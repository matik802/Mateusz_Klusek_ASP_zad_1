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
using FizzBuzzWeb.Services;

namespace FizzBuzzWeb.Pages.Forms
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IFormService _formService;
        public EditModel(IFormService formService)
        {
            _formService = formService;
        }

        [BindProperty]
        public Form Form { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _formService.IsEmpty())
            {
                return NotFound();
            }

            var form = _formService.GetForm((int)id);
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

            _formService.Attach(Form);

            try
            {
                _formService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_formService.FormExists(Form.Id))
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
    }
}
