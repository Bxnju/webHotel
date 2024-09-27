using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class IndexRegistradoModel : PageModel
    {
        public IActionResult OnPostLogout()
        {

            LoginModel.usuarioGlobal = null;
            LoginModel.Exitoso = false;

            return RedirectToPage("Login");

        }

        public void OnGet()
        {
        }
    }
}
