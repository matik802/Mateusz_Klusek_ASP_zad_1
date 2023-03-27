using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace FizzBuzzWeb.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public LinkedList<Form> forms { get; set; }

        public Form[] tab { get; set; }

        public Form form { get; set; }

        public void OnGet()
        {
			var Data = HttpContext.Session.GetString("Data");
            forms = new LinkedList<Form>();
			if(Data != null)
			{
                LinkedList<Form> list = JsonConvert.DeserializeObject<LinkedList<Form>>(Data);
                tab = new Form[list.Count];
                int i = 0;
				foreach(var var in list)
                {
                    tab[i] = var;
                    i++;
                }
			}
			//         lista = new List<int>();
			//         lista.Add(2);
			//         lista.Add(4);
		}

        public IActionResult OnPost() 
        {
            if(ModelState.IsValid)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    forms.AddLast(tab[i]);
                }
                forms.AddLast(form);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(forms));
				//HttpContext.Session.SetInt32("Data2", (int)fizzBuzz.Number);
				//return RedirectToPage("./SavedInSession");
			}
            return RedirectToPage("./SavedInSession"); ;
        }
    }
}