using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades
{
    class movimientoController
    {
        public respuesta listarMovimientoXNombre()
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.MOVIMIENTO.OrderBy(n => n.nombre).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "Movimientos OBTENIDOS", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "MOVIMIENTOS NO ENCONTRADAS");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER MOVIMIENTOS", e.Message.ToString());
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
