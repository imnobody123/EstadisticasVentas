using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPL;

namespace BLL
{
    public class ProcesaDatosEstadisticas
    {
        dProductosMasVendidos MasVendidos = new dProductosMasVendidos();
        public void TraerMasVendidos(ref List<string> Productos, ref List<int> PiezasVendidas)
        {
            DataTable TablaTop10 = MasVendidos.Top10();
            foreach (DataRow fila in TablaTop10.Rows)
            {
                Productos.Add((string)fila["descripcion"]);
                PiezasVendidas.Add((int)fila["vendidos"]);
            }
        }

        public DataTable VentasMensualkes(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                /* 
                Agrega un mes y quita un día para dejarlo
                en el último día del mes seleccionado
                */
                FechaFin = FechaFin.AddMonths(1).AddDays(-1);
                return MasVendidos.VentasMensuales(FechaInicio, FechaFin);
            }
            catch(Exception error)
            {
                throw new Exception("Ocurrió un error al procesar las ventas mensuales", error);
            }
        }

        public DataTable UtilidadesProductos()
        {
            try
            {
                return MasVendidos.VistaUtilidadProductos();
            }
            catch(Exception error)
            {
                throw new Exception("Hubo un problema al procesar la información", error);
            }
        }
    }
}
