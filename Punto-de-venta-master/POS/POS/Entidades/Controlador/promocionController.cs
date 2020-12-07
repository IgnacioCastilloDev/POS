using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades.Controlador
{
    class promocionController
    {
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

                        objDatos = db.PROMOCION.Where(x => x.id ==_id && x.estado == "1").FirstOrDefault();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "PROMOCION ENCONTRADA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "PROMOCION NO ENCONTRADA");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER PROMOCION", e.Message.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;
        }
        public respuesta listarPromocionesXDescripcion()
        {
            respuesta r;
            Object objDatos;
           

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.PROMOCION.OrderBy(n => n.descripcion ).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "PROMOCIONES OBTENIDAS", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "PROMOCIONES NO ENCONTRADAS");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER PROMOCIONES", e.Message.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;
        }

        public respuesta listarPromocionesXDescripcion2()
        {
            respuesta r;
            Object objDatos;


            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        objDatos = db.PROMOCION.Where(n => n.estado =="1").ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "PROMOCIONES OBTENIDAS", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "PROMOCIONES NO ENCONTRADAS");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER PROMOCIONES", e.Message.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;
        }

        public respuesta agregar(int _condicion,int _descuento,string _estado,string _descripcion)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        PROMOCION obj = new PROMOCION();
                        obj.condicion = _condicion;
                        obj.descuento = _descuento;
                        obj.estado = _estado;
                        obj.descripcion = _descripcion;
                        db.PROMOCION.Add(obj);
                        int afected = db.SaveChanges();
                        PROMOCION PROMOCION = (PROMOCION)obj;
                        if (afected == 1)
                        {
                            r = new respuesta(true, "PROMOCION GUARDADO CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO GUARDAR EL PROMOCION");
                        }
                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL GUARDAR PROMOCION", e.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }
            return r;
        }

        public respuesta Editar(int _id, int _condicion, int _descuento, string _estado, string _descripcion)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        PROMOCION obj = db.PROMOCION.Find(_id);
                        obj.condicion = _condicion;
                        obj.descuento = _descuento;
                        obj.estado = _estado;
                        obj.descripcion = _descripcion;
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
    }
}
