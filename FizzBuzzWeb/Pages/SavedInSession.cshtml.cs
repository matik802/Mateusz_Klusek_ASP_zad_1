using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public LinkedList<Form> forms;
        public void OnGet()
        {
            forms = new LinkedList<Form>();
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null) forms = JsonConvert.DeserializeObject<LinkedList<Form>>(Data);
			//TempData["Data2"] = HttpContext.Session.GetInt32("Data2"); ;
		}
    }
}
