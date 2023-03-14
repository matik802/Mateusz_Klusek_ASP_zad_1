using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzWeb.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

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

        public void OnPost() 
        {
            if(ModelState.IsValid)
            {
                if (fizzBuzz.Number % 15 == 0) ViewData["Info"] = "FizzBuzz";
                else if (fizzBuzz.Number % 3 == 0) ViewData["Info"] = "Fizz";
                else if (fizzBuzz.Number % 5 == 0) ViewData["Info"] = "Buzz";
                else ViewData["Info"] = "Liczba: "+fizzBuzz.Number+" nie spelnia kryteriow";
            }
        }
    }
}