using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class IndexModel : PageModel
    {

        public readonly Hotel hotel;

        public bool Importado { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.hotel = Hotel.Obtener_Instancia_Hotel();

            if (Importado)
            {

            }
            else
            {

                try
                {

					hotel.l_usuarios.Add(new Huesped("Andres", Usuario.e_tipoID.TI, 1027802021, 3023344972, "Benjumea123", "1027802021An", Usuario.e_Nacionalidad.Colombiano));

				}
                catch (Exception)
                {

					Importado = true;

				}

				
			}

        }

        public void OnGet()
        {
			
		}
    }
}