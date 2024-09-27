using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class RestauranteModel : PageModel
    {

		public RestauranteModel()
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
        public string Desayunos { get; set; }

		[BindProperty]
		public string Almuerzos { get; set; }

		[BindProperty]
		public string Cenas { get; set; }

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

        public IActionResult OnPostComprarRestaurante()
		{

			if (LoginModel.usuarioGlobal.CheckedIN)
			{

				int nroDesayunos = int.Parse(Desayunos);
				int nroAlmuerzos = int.Parse(Almuerzos);
				int nroCenas = int.Parse(Cenas);
				bool servicio = ServicioHabitacion ? true : false;

				LoginModel.usuarioGlobal.Comprar_Comida(nroDesayunos, nroAlmuerzos, nroCenas, ServicioHabitacion);
				CompraExitosa = true;

			}
			else{

				ErrorCheckIn = true;
			}

			return Page();

		}

		public void OnGet()
        {
        }
    }
}
