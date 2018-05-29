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
		public async Task<int> CargarReporte(LocalReport reporte)
		{
			reporte.ReportPath = @".\rptLuces.rdlc";

			ServicioLuces servLuces = new ServicioLuces ();

			var luces = await servLuces.Obtener ();

			reporte.DataSources.Add (new ReportDataSource ("LucesData", luces));

			return 0;
		}
	}
}