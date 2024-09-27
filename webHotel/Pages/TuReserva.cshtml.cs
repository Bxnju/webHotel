using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace webHotel.Pages
{
    public class TuReservaModel : PageModel
    {

		public TuReservaModel() 
		{
		
			this.hotel = Hotel.Obtener_Instancia_Hotel();

			foreach (var reserva in hotel.oficinaHotel.L_reservas)
			{

				if (LoginModel.usuarioGlobal == reserva.UsuarioReserva)
				{
					reservaActual = reserva;
				}

			}

			RefrescarAtributos();

		}

		public void RefrescarAtributos()
		{

			data = hotel.oficinaHotel.RecepcionHotel.Check_Out(reservaActual);

			NroDesayunos = data["nroDesayunos"];
			NroAlmuerzos = data["nroAlmuerzos"];
			NroCenas = data["nroCenas"];
			NroPlanchadas = data["nroPlanchadas"];
			NroLavadas = data["nroLavadas"];
			NroGaseosas = data["nroGaseosas"];
			NroKits = data["nroKitAseo"];
			NroBatas = data["nroBatas"];
			NroLicores = data["nroLicores"];
			NroVinos = data["nroVinos"];
			NroAguas = data["nroAguas"];
			NroServicios = data["nroServicioCuarto"];
			ValorRestaurante = data["valorRestaurante"];
			ValorLavanderia = data["valorLavanderia"];
			ValorTienda = data["valorTienda"];
			ValorIVA = data["valorIVA"];
			ValorEstadia = data["valorEstadia"];
			ValorSeguro = data["valorSeguroHotelero"];
			ValorDescuento = data["valorDescuento"];
			ValorServicios = data["valorServiciosCuarto"];
			TipoHabitacion = data["tipoCuarto"];
			TotalReserva = data["TOTAL"];


		}

        public IActionResult OnPostLogout()
        {

            LoginModel.usuarioGlobal = null;
            LoginModel.Exitoso = false;

            return RedirectToPage("Login");

        }

        public readonly Hotel hotel;

		public Dictionary<string, string> data;

		public Reserva reservaActual { get; set; }

        public string NroDesayunos { get; set; }

		public string NroAlmuerzos { get; set; }

		public string NroCenas { get; set; }

		public string NroPlanchadas { get; set; }

		public string NroLavadas { get; set; }

		public string NroGaseosas { get; set; }

		public string NroKits { get; set; }

		public string NroBatas { get; set; }

		public string NroLicores { get; set; }

		public string NroVinos { get; set; }

		public string NroAguas { get; set; }

		public string NroServicios { get; set; }


		public string ValorRestaurante { get; set; }

		public string ValorLavanderia { get; set; }

		public string ValorTienda { get; set; }

		public string ValorIVA { get; set; }

		public string ValorEstadia { get; set; }

		public string ValorSeguro { get; set; }

		public string ValorDescuento { get; set; }

		public string ValorServicios { get; set; }

		public string TipoHabitacion { get; set; }

		public string TotalReserva { get; set; }

		public static string precioAPagar { get; set; }

		public bool ExitoCheckIn { get; set; }

		public bool ErrorCheckIn { get; set; }


		public IActionResult OnPostCheckOut()
		{

			LoginModel.usuarioGlobal.Check_Out();
			LoginModel.usuarioGlobal.TieneReserva = false;

			precioAPagar = TotalReserva;
			return RedirectToPage("/Pagar");
		}

		public IActionResult OnPostCheckIn()
		{

			try
			{
				LoginModel.usuarioGlobal.Check_In();
				ExitoCheckIn = true;
			}
			catch (Exception)
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
