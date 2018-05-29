using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionLuces
{
	public class AdministradorReporte
	{
		public async void CargarReporteArtista(LocalReport reporte, int artistaId)
		{
			reporte.ReportPath = @"..\ReporteLuces\rptLuces.rdlc";

			reporte.EnableExternalImages = true;

			ServicioLuces servLuces = new ServicioLuces ();

			var luces = await servLuces.Obtener ();

			reporte.DataSources.Add (new ReportDataSource ("Luces", luces));
		}
	}
}