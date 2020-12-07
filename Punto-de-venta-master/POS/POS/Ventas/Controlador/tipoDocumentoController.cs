using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Ventas.Controlador
{
    class tipoDocumentoController
    {
        public respuesta listarCategoriasXNombre()
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.TIPO_DOCUMENTO.OrderBy(n => n.nombre).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "TIPO DOCUMENTOS OBTENIDAS", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "TIPO DOCUMENTOS NO ENCONTRADAS");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER TIPO DOCUMENTOS", e.Message.ToString());
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
