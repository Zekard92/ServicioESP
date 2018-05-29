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
	/// Interaction logic for wndAgregarLuz.xaml
	/// </summary>
	public partial class wndAgregarLuz : Window
	{
		public ServicioLuces Servicio { get; set; }
		private bool esEditar = false;

		public wndAgregarLuz()
		{
			InitializeComponent ();
			DataContext = new Luz ();
		}

		public wndAgregarLuz(Luz lampara)
		{
			InitializeComponent ();
			DataContext = new Luz ()
			{
				Id = lampara.Id,
				Name = lampara.Name,
				State = lampara.State
			};
			esEditar = true;
		}

		public void Aceptar(object sender, RoutedEventArgs ev)
		{
			try
			{
				if (esEditar)
					Servicio.Modificar ((Luz)DataContext);
				else
					Servicio.Agregar ((Luz)DataContext);
				Close ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message);
			}
		}

		public void Cancelar(object sender, RoutedEventArgs ev)
		{
			Close ();
		}
	}
}