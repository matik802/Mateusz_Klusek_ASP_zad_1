using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using FizzBuzzWeb.Services;

namespace FizzBuzzWeb.Pages.Forms
{
    public class DetailsModel : PageModel
    {
        private readonly IFormService _formService;
        public DetailsModel(IFormService formService)
        {
            _formService = formService;
        }

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
    }
}
