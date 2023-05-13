using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Authorization;
using FizzBuzzWeb.Services;

namespace FizzBuzzWeb.Pages.Forms
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IFormService _formService;

        public DeleteModel(IFormService formService)
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
            else 
            {
                Form = form;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _formService.IsEmpty())
            {
                return NotFound();
            }
            var form = _formService.GetForm((int)id);

            if (form != null)
            {
                Form = form;
                
                _formService.Remove(Form);
                _formService.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
