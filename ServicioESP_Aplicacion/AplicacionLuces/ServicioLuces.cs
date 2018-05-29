using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionLuces
{
	public class ServicioLuces
	{
		private const string uri = "http://localhost:56196/api/Luces/";

		public async Task<List<Luz>> Obtener()
		{
			try
			{
				using (HttpClient client = new HttpClient ())
				{
					var response = await client.GetAsync (uri);
					await VerificarRespuesta (response);
					var responseString = await response.Content.ReadAsStringAsync ();
					return JsonConvert.DeserializeObject<List<Luz>> (responseString);
				}
			}
			catch (ArgumentException) { throw; }
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar obtener la lista de luces");
			}
		}

		public async Task<Luz> Obtener(int id)
		{
			try
			{
				using (HttpClient client = new HttpClient ())
				{
					var response = await client.GetAsync (string.Format ("{0}/{1}", uri, id));
					await VerificarRespuesta (response);
					var responseString = await response.Content.ReadAsStringAsync ();
					return JsonConvert.DeserializeObject<Luz> (responseString);
				}
			}
			catch (ArgumentException) { throw; }
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar obtener la información de la lampara");
			}
		}

		public async void Agregar(Luz lampara)
		{
			try
			{
				using (HttpClient client = new HttpClient ())
				{
					var json = JsonConvert.SerializeObject (lampara);
					var stringContent = new StringContent (json, UnicodeEncoding.UTF8, "application/json");
					var response = await client.PostAsync (uri, stringContent);
					await VerificarRespuesta (response);
				}
			}
			catch (ArgumentException) { throw; }
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar agregar la lampara");
			}
		}

		public async void Modificar(Luz lampara)
		{
			try
			{
				using (HttpClient client = new HttpClient ())
				{
					var json = JsonConvert.SerializeObject (lampara);
					var stringContent = new StringContent (json, UnicodeEncoding.UTF8, "application/json");
					var response = await client.PutAsync (uri, stringContent);
					await VerificarRespuesta (response);
				}
			}
			catch (ArgumentException) { throw; }
			catch (Exception ex)
			{
				throw new Exception ("Ha ocurrido un error al intentar modificar la lampara");
			}
		}

		public async void Eliminar(int id)
		{
			try
			{
				using (HttpClient client = new HttpClient ())
				{
					var response = await client.DeleteAsync (string.Format ("{0}/{1}", uri, id));
					await VerificarRespuesta (response);
				}
			}
			catch (ArgumentException) { throw; }
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar eliminar la lampara");
			}
		}

		private static async Task VerificarRespuesta(HttpResponseMessage response)
		{
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
			{
				var mensaje = await response.Content.ReadAsStringAsync ();
				var excepcion = JsonConvert.DeserializeObject<string> (mensaje);
				throw new ArgumentException (excepcion);
			}
		}
	}
}