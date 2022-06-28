using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PruebaTecnicaNet.Web.Pages
{
    public class GenerateOrderModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
