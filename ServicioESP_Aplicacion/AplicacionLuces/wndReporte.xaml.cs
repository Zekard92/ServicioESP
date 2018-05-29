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
using System.Windows.Shapes;

namespace AplicacionLuces
{
	/// <summary>
	/// Interaction logic for wndReporte.xaml
	/// </summary>
	public partial class wndReporte : Window
	{
		public wndReporte()
		{
			InitializeComponent ();
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			AdministradorReporte reporte = new AdministradorReporte ();
			await reporte.CargarReporte (reportViewer.LocalReport);
			reportViewer.SetDisplayMode (Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
			reportViewer.RefreshReport ();
		}
	}
}