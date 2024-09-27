using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class LoginModel : PageModel
    {

		public LoginModel()
		{
			this.hotel = Hotel.Obtener_Instancia_Hotel();
		}

		public readonly Hotel hotel;

		public static bool Exitoso { get; set; }

        public bool Fallo { get; set;  }

        public static Usuario usuarioGlobal { get; set; }

        public static bool EsCliente { get; set; }

		[BindProperty]
        public string Usuario { get; set; }

		[BindProperty]
		public string Contrasenia { get; set; }

        public IActionResult OnPostIniciarSesion()
        {

			if (hotel.Hacer_Login(Usuario, Contrasenia) != null)
            {

                usuarioGlobal = hotel.Hacer_Login(Usuario, Contrasenia);
                Exitoso = true;

                if (usuarioGlobal.TieneReserva)
                {
					return RedirectToPage("/IndexIngresado");
                }
                else
                {
                    if(usuarioGlobal is Cliente)
                    {
                        EsCliente = true;
						return RedirectToPage("/Reservar");
                    }
                    else
                    {

                        EsCliente = false;
						return RedirectToPage("/IndexRegistrado");
					}

				}

			}
            else
            {
                Fallo = true;
				return Page();
			}

        }

        public void OnGet()
        {
		}
    }
}
