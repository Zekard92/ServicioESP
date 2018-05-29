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

namespace AplicacionLuces
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ServicioLuces servicio = new ServicioLuces ();

		public MainWindow()
		{
			InitializeComponent ();
		}

		private async void Activar(object sender, RoutedEventArgs ev)
		{
			var a = await servicio.Obtener (1);
			a.State = !a.State;
			servicio.Modificar (a);
			Actualizar ();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Actualizar ();
		}

		private async void Actualizar()
		{
			try
			{
				var a = (Luz)await servicio.Obtener (1);
				if (a.State == true)
				{
					lblName.Content = "Encendido";
					btnActivar.Content = "Apagar";
				}
				if (a.State == false)
				{
					lblName.Content = "Apagado";
					btnActivar.Content = "Encender";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message);
			}
		}
	}
}