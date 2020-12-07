using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Entidades.Controlador
{
    class productoController
    {



        public respuesta agregar(string _codigoBarra,int _stock,string _descripcion,int _precio,int _idCategoria,int _condicion,int _descuento)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        PRODUCTO obj = new PRODUCTO();
                        obj.codigobarra = _codigoBarra;
                        obj.stock = _stock;
                        obj.descripcion = _descripcion;
                        obj.precio = _precio;
                        obj.fk_id_categoria = _idCategoria;
                        obj.estado = "1";
                        obj.condicion = _condicion;
                        obj.descuento = _descuento;
                        db.PRODUCTO.Add(obj);
                        int afected = db.SaveChanges();
                        PRODUCTO PRODUCTO = (PRODUCTO)obj;
                        if (afected == 1)
                        {
                            r = new respuesta(true, "PRODUCTO GUARDADO CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO GUARDAR EL PRODUCTO");
                        }
                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL GUARDAR PRODUCTO", e.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }
            return r;
        }

        public respuesta Eliminar(int _id)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        PRODUCTO obj = db.PRODUCTO.Find(_id);
                        obj.estado = "0";
                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        int afected = db.SaveChanges();

                        if (obj != null)
                        {
                            r = new respuesta(true, "PRODUCTO ELIMINADO CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO ELIMINAR EL PRODUCTO");
                        }


                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL ELIMINAR PRODUCTO", ex.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;

        }
        public respuesta updateStock(int _id,int _cantidad)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        PRODUCTO obj = db.PRODUCTO.Find(_id);
                       
                        obj.stock = obj.stock - _cantidad;
                  
                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        int afected = db.SaveChanges();

                        if (obj != null)
                        {
                            r = new respuesta(true, "PRODUCTO MODIFICADO CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO MODIFICAR EL PRODUCTO");
                        }


                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL TRAER PRODUCTO", ex.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;

        }



        public respuesta Editar(int _id, string _codigoBarra, int _stock, string _descripcion, int _precio, int _idCategoria, int _condicion, int _descuento)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        PRODUCTO obj = db.PRODUCTO.Find(_id);
                        obj.codigobarra = _codigoBarra;
                        obj.stock = _stock;
                        obj.descripcion = _descripcion;
                        obj.precio = _precio;
                        obj.fk_id_categoria = _idCategoria;
                        obj.condicion = _condicion;
                        obj.descuento = _descuento;
                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        int afected = db.SaveChanges();

                        if (obj != null)
                        {
                            r = new respuesta(true, "PRODUCTO MODIFICADO CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO MODIFICAR EL PRODUCTO");
                        }


                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL TRAER PRODUCTO", ex.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;

        }
        public respuesta buscarXCodigoDeBarra(string _codigoBarra)
        {
            respuesta r;
            Object objDatos;

                try
                {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                    objDatos = db.PRODUCTO.Where(x=> x.codigobarra == _codigoBarra && x.estado =="1").FirstOrDefault();

                    if (objDatos != null)
                    {
                        r = new respuesta(true, "PRODUCTO ENCONTRADO",objDatos);
                    }
                    else
                    {
                        r = new respuesta(false, "PRODUCTO NO ENCONTRADO");
                    }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER PRODUCTO", e.Message.ToString());
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
    

