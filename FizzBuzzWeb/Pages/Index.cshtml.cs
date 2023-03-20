using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzzForm fizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            fizzBuzz = new FizzBuzzForm();
            if((string.IsNullOrWhiteSpace(Name))) Name = "User";
        }

        public IActionResult OnPost() 
        {
            if(ModelState.IsValid)
            {
                if (fizzBuzz.Number % 15 == 0)
                {
                    ViewData["Info"] = "FizzBuzz";
                    ViewData["Check"] = "True";
                }
                else if (fizzBuzz.Number % 3 == 0)
                {
                    ViewData["Info"] = "Fizz";
                    ViewData["Check"] = "True";
                }
                else if (fizzBuzz.Number % 5 == 0)
                {
                    ViewData["Info"] = "Buzz";
                    ViewData["Check"] = "True";
                }
                else
                {
                    ViewData["Info"] = "Liczba: "+fizzBuzz.Number+" nie spelnia kryteriow";
                    ViewData["Check"] = "False";
                }
            }
            return Page();
        }
    }
}