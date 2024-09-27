using b_Hotel.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHotel.Pages
{
    public class RegistroModel : PageModel
    {

		public readonly Hotel hotel;

		public RegistroModel() 
		{ 
		
			this.hotel = Hotel.Obtener_Instancia_Hotel();
		
		}

        [BindProperty]
        public string Nombre { get; set; }

		[BindProperty]
		public long Telefono { get; set; }

		[BindProperty]
		public string TipoDocumento { get; set; }

		[BindProperty]
		public long NroDocumento { get; set; }

		[BindProperty]
		public string Nacionalidad { get; set; }

		[BindProperty]
		public string Usuario { get; set; }

		[BindProperty]
		public string Contrasenia { get; set; }

		public Usuario.e_tipoID eTipoDocumento { get; set; }

		public Usuario.e_Nacionalidad eNacionalidad { get; set; }

		public bool ExitoRegistro { get; set; }
		public bool ErrorRegistro { get; set; }


		public IActionResult OnPostRegistrar()
		{

			try
			{

				switch (TipoDocumento)
				{
					case "cc": eTipoDocumento = b_Hotel.Clases.Usuario.e_tipoID.CC; break;
					case "ce": eTipoDocumento = b_Hotel.Clases.Usuario.e_tipoID.CE; break;
					case "pa": eTipoDocumento = b_Hotel.Clases.Usuario.e_tipoID.PA; break;
					case "ti": eTipoDocumento = b_Hotel.Clases.Usuario.e_tipoID.TI; break;
					default: break;
				}

				switch (Nacionalidad)
				{
					case "colombiana": eNacionalidad = b_Hotel.Clases.Usuario.e_Nacionalidad.Colombiano; break;
					case "otra": eNacionalidad = b_Hotel.Clases.Usuario.e_Nacionalidad.Otro; break;
					default: break;
				}

				hotel.l_usuarios.Add(new Huesped(Nombre, eTipoDocumento, NroDocumento, Telefono, Usuario, Contrasenia, eNacionalidad));

				ExitoRegistro = true;
				return Page();

			}
			catch (Exception)
			{
				ErrorRegistro = true;
				return Page();
			}

		}


		public void OnGet()
        {
        }
    }
}
