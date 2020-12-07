using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades.Modelo
{
    class productoModel
    {
        public long id { get; set; }
        public string codigoBarra { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int idCategoria { get; set; }
        public int descuento { get; set; }
        public int condicion { get; set; }

        public string nombreCat { get; set; }
      


        public respuesta listarProductos()
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        string sql = "SELECT p.descuento,p.condicion,P.id,p.codigobarra,p.stock,p.descripcion,p.precio,p.fk_id_categoria as idCategoria, c.nombre as nombreCat " +
                                     "FROM PRODUCTO P INNER JOIN CATEGORIA C on c.id = P.fk_id_categoria where p.estado = 1 order by stock DESC";



                        objDatos = db.Database.SqlQuery<productoModel>(sql).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "APERTURA ENCONTRADA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "APERTURA NO ENCONTRADO");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER APERTURA", e.Message.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;
        }


       
    }
}
