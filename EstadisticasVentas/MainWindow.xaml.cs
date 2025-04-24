using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WPF;
using BLL;
using System.Data;
using System.Windows.Controls.Primitives;


namespace EstadisticasVentas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void miComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnProcesa_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboVentana.SelectedIndex == 0)
            {
                VentasMensuales.VentasMensuales ventanaVentas = new VentasMensuales.VentasMensuales();
                ContenedorVistas.Content = ventanaVentas;
            }
            else if(comboVentana.SelectedIndex == 1)
            {
                MasVendidos.Top10 ventanaTop10 = new MasVendidos.Top10();
                ContenedorVistas.Content = ventanaTop10;
            }
            else if(comboVentana.SelectedIndex == 2)
            {
                UtilidadPorProducto.UtilidadPorProducto ventanaUtilidad = new UtilidadPorProducto.UtilidadPorProducto();
                ContenedorVistas.Content = ventanaUtilidad;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}