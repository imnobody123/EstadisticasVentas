using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
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
using BLL;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WPF;
using LiveChartsCore.Kernel.Sketches;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting;

namespace EstadisticasVentas.MasVendidos
{
    /// <summary>
    /// Lógica de interacción para Top10.xaml
    /// </summary>
    public partial class Top10 : UserControl
    {
        ProcesaDatosEstadisticas estadisticas = new ProcesaDatosEstadisticas();
        public ISeries[] Series { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }
        public Top10()
        {
            InitializeComponent();
        }

        private void miGrafica_Loaded(object sender, RoutedEventArgs e)
        {
            CreaModelo();
        }

        private void CreaModelo()
        {
            List<string> Productos = new List<string>();
            List<int> CantVend = new List<int>();

            estadisticas.TraerMasVendidos(ref Productos, ref CantVend);

            // Configurar los datos
            miGrafica.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Ventas",
                    Values =  CantVend,
                    XToolTipLabelFormatter = point => $"{Productos[point.Index]}"
                }
            };

            miGrafica.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = Enumerable.Range(1, CantVend.Count).Select(x => x.ToString()).ToArray(),
                    Name = "Ranking",
                    LabelsRotation = 0,
                    UnitWidth = 1,
                    MinStep = 1,
                    LabelsPaint = new SolidColorPaint(SKColors.Black)
                }
            };

            miGrafica.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Ventas"
                }
            };
        }
    }
}
