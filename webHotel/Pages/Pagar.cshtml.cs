using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class PagarModel : PageModel
    {

		public IActionResult OnPostLogout()
		{

			LoginModel.usuarioGlobal = null;
			LoginModel.Exitoso = false;

			return RedirectToPage("Login");

		}

		public PagarModel()
        {
            precioAPagar = TuReservaModel.precioAPagar;
		}

		public string precioAPagar { get; set; }

        public void OnPostPagar()
        {
            OnPostLogout();
        }

        public void OnGet()
        {
        }
    }
}
