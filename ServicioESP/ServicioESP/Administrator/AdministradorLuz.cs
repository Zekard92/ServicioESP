using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioESP.Administrator
{
	public class AdministradorLuz
	{
		public List<Luz> Obtener()
		{
			try
			{
				using (ServicioESP_DBEntities db = new ServicioESP_DBEntities ())
				{
					return db.Luz.ToList ();
				}
			}
			catch (Exception ex)
			{
				//throw new Exception ("Ha ocurrido un error al intentar obtener la lista de luces");
				throw new Exception (ex.Message);
			}
		}

		public Luz Obtener(int id)
		{
			try
			{
				using (ServicioESP_DBEntities db = new ServicioESP_DBEntities ())
				{
					return db.Luz.FirstOrDefault (x => x.Id == id);
				}
			}
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar obtener la información de la lampara");
			}
		}

		public void Agregar(Luz lampara)
		{
			try
			{
				using (ServicioESP_DBEntities db = new ServicioESP_DBEntities ())
				{
					db.Luz.Add (lampara);
					db.SaveChanges ();
				}
			}
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar agregar una nueva lampara.");
			}
		}

		public void Modificar(Luz lampara)
		{
			try
			{
				using (ServicioESP_DBEntities db = new ServicioESP_DBEntities ())
				{
					db.Entry (lampara).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges ();
				}
			}
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar modificar la información de la lampara");
			}
		}

		public void Eliminar(int id)
		{
			try
			{
				using (ServicioESP_DBEntities db = new ServicioESP_DBEntities ())
				{
					db.Entry (db.Luz.FirstOrDefault (x => x.Id == id)).State = System.Data.Entity.EntityState.Deleted;
					db.SaveChanges ();
				}
			}
			catch (Exception)
			{
				throw new Exception ("Ha ocurrido un error al intentar eliminar la lampara.");
			}
		}
	}
}