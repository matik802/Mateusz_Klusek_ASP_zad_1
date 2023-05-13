using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using FizzBuzzWeb.Data;

namespace FizzBuzzWeb
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _context = context;
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
            form.Result = (string)TempData["1"];
            _context.Form.Add(form);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}