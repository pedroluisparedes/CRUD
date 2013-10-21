using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Capa_Datos
{
    class Acceso
    {
        SqlConnection _Conexion;
        string Cadena = string.Empty;

        public Acceso()
        {
             Cadena = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            _Conexion = new SqlConnection(Cadena);
        }

        public SqlConnection ObtenerConexion()
        {
            return _Conexion;
        }
    }
}
