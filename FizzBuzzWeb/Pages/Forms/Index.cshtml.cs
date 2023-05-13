using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ContosoUniversity;
using FizzBuzzWeb.Pages;

namespace FizzBuzzWeb.Pages.Forms
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.AppDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public IdentityUser applicationUser { get; set; }
        public string userId { get; set; }

        public PaginatedList<Form> Form { get; set; } = default!;
        public int pageIndex { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            if (_context.Form != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                applicationUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                //Form = await _context.Form.ToListAsync();
                //pageIndex = 1;
                IQueryable<Form> FormIQ = from s in _context.Form
                                          select s;
                FormIQ = FormIQ.OrderByDescending(s => s.Created);
                var pageSize = Configuration.GetValue("PageSize", 4);
                Form = await PaginatedList<Form>.CreateAsync(
                    FormIQ, pageIndex ?? 1, pageSize);
            }
        }
    }
}
