using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Services;

namespace FizzBuzzWeb
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        private readonly IFormService _formService;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IFormService formService)
        {
            _formService= formService;
            _logger = logger;
        }

        public Form form { get; set; }

        public void OnGet()
        {
            form = new Form();
		}
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            form.Created = DateTime.Now;
            if (form.Year % 4 == 0) form.Result = "Rok przestepny";
            else form.Result = "Rok nieprzestepny";
            _formService.AddForm(form);
            _formService.Save();

            return Page();
        }
    }
}