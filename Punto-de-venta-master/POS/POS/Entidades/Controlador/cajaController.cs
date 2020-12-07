using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades.Controlador
{
    class cajaController
    {

        public respuesta listarCajasXNombre()
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.CAJA.OrderBy(n => n.nombre).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "CAJAS OBTENIDAS", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "CAJAS NO ENCONTRADAS");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER CAJAS", e.Message.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;
        }

        public respuesta traerCajaActiva()
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.CAJA.Where(n => n.estado == "1").FirstOrDefault();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "EXISTE UNA CAJA ABIERTA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "LA CAJA NO ESTA ABIERTA");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER CAJAS", e.Message.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;
        }



        public respuesta Editar(int _id,string _estado)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        CAJA obj = db.CAJA.Find(_id);
                        obj.estado = _estado ;
                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        int afected = db.SaveChanges();

                        if (obj != null)
                        {
                            r = new respuesta(true, "CAJA ENCONTRADA", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "CAJA NO ENCONTRADA");
                        }


                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL TRAER CAJA", ex.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;

        }

   

        public respuesta buscarXId(int _id)
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.CAJA.Find(_id);

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "CAJA ENCONTRADA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "CAJA NO ENCONTRADA");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER CAJA", e.Message.ToString());
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
