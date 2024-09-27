using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class ServicioModel : PageModel
    {

		public ServicioModel()
		{

			this.hotel = Hotel.Obtener_Instancia_Hotel();

			foreach (var reserva in hotel.oficinaHotel.L_reservas)
			{

				if (LoginModel.usuarioGlobal == reserva.UsuarioReserva)
				{
					reservaActual = reserva;
				}

			}


		}


		public readonly Hotel hotel;
		public Reserva reservaActual { get; set; }



		[BindProperty]
		public string Lavar { get; set; }

		[BindProperty]
		public string Planchar { get; set; }

		[BindProperty]
		public bool ServicioHabitacion { get; set; }

		public bool CompraExitosa { get; set; }

		public bool ErrorCheckIn { get; set; }

		public IActionResult OnPostLogout()
        {

            LoginModel.usuarioGlobal = null;
            LoginModel.Exitoso = false;

            return RedirectToPage("Login");

        }

        public IActionResult OnPostComprarServicio()
		{

			if (LoginModel.usuarioGlobal.CheckedIN)
			{
				int nroPlanchar = int.Parse(Planchar);
				int nroLavar = int.Parse(Lavar);
				bool servicio = ServicioHabitacion ? true : false;

				LoginModel.usuarioGlobal.Solicitar_Servicio(nroLavar, nroPlanchar, servicio);
				CompraExitosa = true;
			}
			else
			{
				ErrorCheckIn = true;
			}

			return Page();

		}

		public void OnGet()
        {
        }
    }
}
