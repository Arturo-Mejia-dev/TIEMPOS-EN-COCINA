using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace TIEMPOS_RW
{
    class Conexion
    {
        //Conexion SQL
        public SqlConnection crearConexion()
        {

            //SqlConnection conexion = new SqlConnection("Data Source=192.168.1.3;Initial Catalog=UAQUERETARO;User Id=sa;Password=masterkey");

            SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["conexion"]);

            //SqlConnection conexion = new SqlConnection("Data Source=APLLAP;Initial Catalog=UAQUERETARO;User Id=sa;Password=masterkey");
            return conexion;
        }
    }
}
