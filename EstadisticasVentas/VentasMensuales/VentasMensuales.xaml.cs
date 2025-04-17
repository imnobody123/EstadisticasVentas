using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstadisticasVentas.VentasMensuales
{
    /// <summary>
    /// Lógica de interacción para VentasMensuales.xaml
    /// </summary>
    public partial class VentasMensuales : UserControl
    {
        ProcesaDatosEstadisticas estadisticas = new ProcesaDatosEstadisticas();
        public VentasMensuales()
        {
            InitializeComponent();
        }

        private void btnProcesa_Click(object sender, RoutedEventArgs e)
        {
            DateTime FechaInicio = Convert.ToDateTime(dateFechaInicio.SelectedDate);
            DateTime FechaFin = Convert.ToDateTime(dateFechaFin.SelectedDate);
            System.Diagnostics.Debug.WriteLine("La fecha es " + FechaInicio);
            System.Diagnostics.Debug.WriteLine("La fecha es " + FechaFin);
            dgvVentasMensuales.ItemsSource = estadisticas.VentasMensualkes(FechaInicio, FechaFin).DefaultView;
        }

        private void DatePickerMes1_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker dp && dp.Template.FindName("PART_TextBox", dp) is DatePickerTextBox textBox)
            {
                textBox.SetValue(TextBox.TextProperty, dp.SelectedDate?.ToString("yyyy-MM") ?? "");
            }
        }

        private void DatePickerMes1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker dp && dp.Template.FindName("PART_TextBox", dp) is DatePickerTextBox textBox)
            {
                textBox.SetValue(TextBox.TextProperty, dp.SelectedDate?.ToString("yyyy-MM") ?? "");
            }
        }

        private void DatePickerMes2_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker dp && dp.Template.FindName("PART_TextBox", dp) is DatePickerTextBox textBox)
            {
                textBox.SetValue(TextBox.TextProperty, dp.SelectedDate?.ToString("yyyy-MM") ?? "");
            }
        }

        private void DatePickerMes2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker dp && dp.Template.FindName("PART_TextBox", dp) is DatePickerTextBox textBox)
            {
                textBox.SetValue(TextBox.TextProperty, dp.SelectedDate?.ToString("yyyy-MM") ?? "");
            }
        }
    }
}
