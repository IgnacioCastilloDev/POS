using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Ventas.Modelo
{
    class ventaModel
    {
        public long maxVenta { get; set; }
        public respuesta TRAER_MAX_ID_VENTA()
        {
            respuesta r;
            Object objDatos;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        string sql = "SELECT COALESCE(MAX(id), 0)+1 as maxVenta FROM VENTA";
                 
                        objDatos = db.Database.SqlQuery<ventaModel>(sql).FirstOrDefault();

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
