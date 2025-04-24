using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DPL
{
    public class Conexion
    {
        protected SqlConnection CreaConexion()
        {
            string Cadena = string.Empty;
            Cadena = @"Server=tcp:SERVIDORHP\HERBAL,49500; DataBase= herbal; user id=AppHerbalV2; Password= Admin*12;TrustServerCertificate=True;";
            //Cadena = @"Server=localhost; DataBase=herbal;user id=AppHerbalV2;Password=Admin*12;TrustServerCertificate=True;";
            return new SqlConnection(Cadena);
        }
    }
}
