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

namespace FizzBuzzWeb.x
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.AppDbContext _context;
		public IdentityUser applicationUser { get; set; }
        public string userId { get; set; }
        public IndexModel(FizzBuzzWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Form> Form { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Form != null)
            {
				userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                applicationUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
				Form = await _context.Form.ToListAsync();
            }
        }
    }
}
