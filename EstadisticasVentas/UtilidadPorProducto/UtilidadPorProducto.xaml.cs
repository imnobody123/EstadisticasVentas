using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstadisticasVentas.UtilidadPorProducto
{
    /// <summary>
    /// Lógica de interacción para UtilidadPorProducto.xaml
    /// </summary>
    public partial class UtilidadPorProducto : UserControl
    {
        ProcesaDatosEstadisticas estadisticas = new ProcesaDatosEstadisticas();

        public UtilidadPorProducto()
        {
            InitializeComponent();
        }

        public void UtilidadPorProducto_Loaded(object sender, RoutedEventArgs e)
        {
            dgvUtilidadPorProducto.ItemsSource = estadisticas.UtilidadesProductos().DefaultView;
            var fila = (DataRowView)dgvUtilidadPorProducto.Items[0]; // fila 4 (índice 3)
            System.Diagnostics.Debug.WriteLine("El valor es " + fila["Utilidad P Mayoreo"].ToString());
        }
    }
}
