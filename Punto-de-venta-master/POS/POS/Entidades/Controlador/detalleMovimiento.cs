using POS.DBModel;
using POS.Entidades.Modelo;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades.Controlador
{
    class detalleMovimiento
    {
        public respuesta agregar(int _idMovimiento,int _idApertura,DateTime _fecha,int _monto,string _motivo)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        DETALLE_MOVIMIENTO obj = new  DETALLE_MOVIMIENTO();
                        obj.fk_id_movimiento = _idMovimiento;
                        obj.fk_id_apertura = _idApertura;
                        obj.fecha = _fecha;
                        obj.monto = _monto;
                        obj.motivo = _motivo;

                        db.DETALLE_MOVIMIENTO.Add(obj);
                        int afected = db.SaveChanges();
                        DETALLE_MOVIMIENTO DETALLE_MOVIMIENTO = (DETALLE_MOVIMIENTO)obj;
                        if (afected == 1)
                        {
                            r = new respuesta(true, "DETALLE_MOVIMIENTO GUARDADO CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO GUARDAR EL DETALLE_MOVIMIENTO");
                        }
                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL GUARDAR DETALLE_MOVIMIENTO", e.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }
            return r;
        }


        public respuesta Editar(int _id,int _idMovimiento, int _idApertura, DateTime _fecha, int _monto, string _motivo)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        DETALLE_MOVIMIENTO obj = db.DETALLE_MOVIMIENTO.Find(_id);
                        obj.fk_id_movimiento = _idMovimiento;
                        obj.fk_id_apertura = _idApertura;
                        obj.fecha = _fecha;
                        obj.monto = _monto;
                        obj.motivo = _motivo;
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

        public respuesta traerMovimientosDiarios(DateTime _desde,DateTime _hasta,int _idMov)
        {
            respuesta r;
            detalleMovimientoModel dmm = new detalleMovimientoModel();
            r = dmm.traerMovimientosDiarios(_desde,_hasta,_idMov);
            return r;

           
        }
    }
}
