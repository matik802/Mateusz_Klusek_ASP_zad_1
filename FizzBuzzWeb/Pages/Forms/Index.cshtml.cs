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
using FizzBuzzWeb.Services;

namespace FizzBuzzWeb.Pages.Forms
{
    public class IndexModel : PageModel
    {
        private readonly IFormService _formService;
        private readonly IUserService _userService;
        private readonly IConfiguration Configuration;

        public IndexModel(IFormService formService, IUserService userService, IConfiguration configuration)
        {
            _formService = formService;
            _userService = userService;
            Configuration = configuration;
        }
        public IdentityUser applicationUser { get; set; }
        public string userId { get; set; }

        public PaginatedList<Form> Form { get; set; } = default!;
        public int pageIndex { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            if (_formService != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                applicationUser = _userService.GetUser(userId);
                IQueryable<Form> FormIQ = from s in _formService.GetForms()
                                          select s;
                FormIQ = FormIQ.OrderByDescending(s => s.Created);
                var pageSize = Configuration.GetValue("PageSize", 4);
                Form = await PaginatedList<Form>.CreateAsync(
                    FormIQ, pageIndex ?? 1, pageSize);
            }
        }
    }
}
