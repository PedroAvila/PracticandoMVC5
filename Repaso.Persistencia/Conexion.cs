using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Repaso.Persistencia
{
    public class Conexion
    {
        public static SqlConnection Connect(string con)
        {
            try
            {
                var cadenaConexion = ConfigurationManager.ConnectionStrings["default"].ToString();
                SqlConnection cn = new SqlConnection(cadenaConexion);
                return cn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error de conexión", ex);
            }
        }

    }
}
