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
        public ISeries[] Series { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }

        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void miComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CreaModelo()
        {
            List<string> Productos = new List<string>();
            List<int> CantVend = new List<int>();

            //estadisticas.TraerMasVendidos(ref Productos, ref CantVend);

            // Configurar los datos
            Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Ventas",
                    Values =  CantVend,
                    XToolTipLabelFormatter = point => $"{Productos[point.Index]}"
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = Productos,
                    LabelsRotation = 15
                }
            };

            YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Cantidad"
                }
            };
        }

        private void CargarGrafica(int opcion)
        {
            
        }

        private void btnProcesa_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VentasMensuales.VentasMensuales ventanaVentas = new VentasMensuales.VentasMensuales();
            ContenedorVistas.Content = ventanaVentas;
        }
    }
}