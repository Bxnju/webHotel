using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace webHotel.Pages
{
    public class ReservarModel : PageModel
    {

        public ReservarModel()
        {
            this.hotel = Hotel.Obtener_Instancia_Hotel();
            this.Habitaciones = new List<Habitacion>();
        }

        public IActionResult OnPostLogout()
        {

            LoginModel.usuarioGlobal = null;
            LoginModel.Exitoso = false;

            return RedirectToPage("Login");

        }

        public readonly Hotel hotel;

        public List<Habitacion> Habitaciones { get; set; }

        [BindProperty]
        public DateTime FechaEntrada { get; set; }

        [BindProperty]
        public DateTime FechaSalida { get; set; }

        [BindProperty]
        public short IdHabitacionSeleccionada { get; set; }

        public bool ErrorReserva { get; set; }


        public async Task<IActionResult> OnPostBuscarHabitacionesAsync()
        {
            // Obtener las fechas de los inputs
            string fechaEntradaStr = Request.Form["FechaEntrada"];
            string fechaSalidaStr = Request.Form["FechaSalida"];

            // Convertir las fechas al formato "dd/MM/yyyy"
            DateTime fechaEntrada = DateTime.ParseExact(fechaEntradaStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime fechaSalida = DateTime.ParseExact(fechaSalidaStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Convertir las fechas al formato "dd/MM/yyyy"
            string fechaEntradaFormatted = fechaEntrada.ToString("dd/MM/yyyy");
            string fechaSalidaFormatted = fechaSalida.ToString("dd/MM/yyyy");

            // Llamar a la función para buscar habitaciones disponibles
            List<Habitacion> habitacionesDisponibles = hotel.oficinaHotel.Buscar_Habitaciones_Disponibles(fechaEntradaFormatted, fechaSalidaFormatted);

            // Asignar la lista de habitaciones al atributo Habitaciones del modelo
            Habitaciones = new List<Habitacion>();
            Habitaciones = habitacionesDisponibles;

            // Redirigir a la página actualizada
            return Page();
        }

        public IActionResult Ingresar()
        {
            return RedirectToPage("IndexIngresado");
        }

        public async Task<IActionResult> OnPostReservarHabitacionAsync()
        {
            // Obtener las fechas de los inputs
            string fechaEntradaStr = Request.Form["FechaEntrada"];
            string fechaSalidaStr = Request.Form["FechaSalida"];

            // Convertir las fechas al formato "dd/MM/yyyy"
            DateTime fechaEntrada = DateTime.ParseExact(fechaEntradaStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime fechaSalida = DateTime.ParseExact(fechaSalidaStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Convertir las fechas al formato "dd/MM/yyyy"
            string fechaEntradaFormatted = fechaEntrada.ToString("dd/MM/yyyy");
            string fechaSalidaFormatted = fechaSalida.ToString("dd/MM/yyyy");

            short hab_select = short.Parse(Request.Form["IdHabitacionSeleccionada"]);

            // Llamar a la función para buscar habitaciones disponibles


            try
            {

                LoginModel.usuarioGlobal.Crear_Reserva(hab_select, fechaEntradaFormatted, fechaSalidaFormatted);
                LoginModel.usuarioGlobal.TieneReserva = true;

            }
            catch (Exception)
            {

                ErrorReserva = true;
                return Page();
            }


            IsPostBack = true;

            // Redirigir a la página actualizada
            return Ingresar();
        }

        public bool IsPostBack { get; set; }

        public void OnGet()
        {

        }

    }
}
