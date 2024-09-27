using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class TiendaModel : PageModel
    {


		public TiendaModel()
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

        public IActionResult OnPostLogout()
        {

            LoginModel.usuarioGlobal = null;
            LoginModel.Exitoso = false;

            return RedirectToPage("Login");

        }


        public readonly Hotel hotel;
		public Reserva reservaActual { get; set; }

		[BindProperty]
		public string Vinos { get; set; }

		[BindProperty]
		public string Licores { get; set; }

		[BindProperty]
		public string Aguas { get; set; }

		[BindProperty]
		public string Gaseosas { get; set; }

		[BindProperty]
		public string Kits { get; set; }

		[BindProperty]
		public string Batas { get; set; }

		[BindProperty]
		public bool ServicioHabitacion { get; set; }

		public bool CompraExitosa { get; set; }

		public bool ErrorCheckIn { get; set; }


		public IActionResult OnPostComprarTienda()
		{

			if (LoginModel.usuarioGlobal.CheckedIN)
			{
				int nroVinos = int.Parse(Vinos);
				int nroLicores = int.Parse(Licores);
				int nroAguas = int.Parse(Aguas);
				int nroGaseosas = int.Parse(Gaseosas);
				int nroKits = int.Parse(Kits);
				int nroBatas = int.Parse(Batas);
				bool servicio = ServicioHabitacion ? true : false;

				LoginModel.usuarioGlobal.Comprar_Productos(nroGaseosas, nroAguas, nroVinos, nroLicores, nroBatas, nroKits, servicio);
				CompraExitosa = true;

				return Page();
			}
			else
			{
				ErrorCheckIn = true;
				return Page();
			}

		}

		public void OnGet()
        {
        }
    }
}
