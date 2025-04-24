using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPL
{
    public  class dProductosMasVendidos : Conexion
    {
        public DataTable Top10()
        {
            try
            {
                using (SqlConnection Conexion = CreaConexion())
                {
                    Conexion.Open();
                    using (SqlCommand Comando = new SqlCommand())
                    {
                        DataTable TablaTop10 = new DataTable();
                        Comando.Connection = Conexion;
                        Comando.CommandText = "SELECT TOP 10 P.descripcion, SUM(VD.cantidad) AS vendidos " +
                            "FROM ventaDetalle VD " +
                            "INNER JOIN productos P ON P.idProducto = VD.idProducto " +
                            "GROUP BY P.descripcion\r\nORDER BY vendidos DESC ";
                        Comando.CommandType = CommandType.Text;
                        SqlDataReader reader = Comando.ExecuteReader();
                        TablaTop10.Load(reader);
                        return TablaTop10;
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable VentasMensuales(DateTime FechaInicio, DateTime FechaFIn)
        {
            try
            {
                using (SqlConnection Conexion = CreaConexion())
                {
                    Conexion.Open();
                    using (SqlCommand Comando = new SqlCommand("EstadisticaVentasMes", Conexion))
                    {
                        Comando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                        Comando.Parameters.AddWithValue("@FechaFin", FechaFIn);
                        Comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = Comando.ExecuteReader())
                        {
                            DataTable TablaVentas = new DataTable();
                            TablaVentas.Load(reader);
                            return TablaVentas;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al conectar a la base de datos", ex);
            }
        }

        public DataTable VistaUtilidadProductos()
        {
            try
            {
                using (SqlConnection Conexion = CreaConexion())
                {
                    Conexion.Open();
                    using (SqlCommand Comando = new SqlCommand("SELECT * FROM UtilidadesPorProducto ORDER BY [Utilidad P Mayoreo] DESC", Conexion))
                    {
                        Comando.CommandType = CommandType.Text;
                        using (SqlDataReader Reader = Comando.ExecuteReader())
                        {
                            DataTable TablaUtilidad = new DataTable();
                            TablaUtilidad.Load(Reader);
                            return TablaUtilidad;
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Error técnico en base de datos...", ex);
            }
        }
    }
}
