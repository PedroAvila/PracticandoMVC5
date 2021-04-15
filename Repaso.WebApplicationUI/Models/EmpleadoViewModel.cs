using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repaso.WebApplicationUI.Models
{
    public class EmpleadoViewModel
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}