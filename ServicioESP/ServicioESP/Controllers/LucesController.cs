using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioESP.Controllers
{
	public class LucesController : ApiController
	{
		private Administrator.AdministradorLuz admin = new Administrator.AdministradorLuz ();
		public HttpResponseMessage Get()
		{
			try
			{
				return Request.CreateResponse (HttpStatusCode.OK, admin.Obtener ());
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse (HttpStatusCode.BadRequest, ex.Message);
			}
		}
		public HttpResponseMessage Get(int id)
		{
			try
			{
				return Request.CreateResponse (HttpStatusCode.OK, admin.Obtener (id));
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse (HttpStatusCode.BadRequest, ex.Message);
			}
		}
		public HttpResponseMessage Post([FromBody]Luz lampara)
		{
			try
			{
				admin.Agregar (lampara);
				return Request.CreateResponse (HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse (HttpStatusCode.BadRequest, ex.Message);
			}
		}
		public HttpResponseMessage Put([FromBody] Luz lampara)
		{
			try
			{
				admin.Modificar (lampara);
				return Request.CreateResponse (HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse (HttpStatusCode.BadRequest, ex.Message);
			}
		}
		public HttpResponseMessage Delete(int id)
		{
			try
			{
				admin.Eliminar (id);
				return Request.CreateResponse (HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse (HttpStatusCode.BadRequest, ex.Message);
			}
		}
	}
}