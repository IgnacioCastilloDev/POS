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
    class aperturaController
    {
        public respuesta agregar(DateTime _horaApertura, long _monto, string _estado, int _idUsuario, int _idCaja)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        APERTURA obj = new APERTURA();
                        obj.hora_apertura = _horaApertura;
                        obj.monto = _monto;
                        obj.estado = _estado;
                        obj.fk_id_usuario = _idUsuario;
                        obj.fk_id_caja = _idCaja;
                        db.APERTURA.Add(obj);
                        int afected = db.SaveChanges();
                        APERTURA APERTURA = (APERTURA)obj;
                        if (afected == 1)
                        {
                            r = new respuesta(true, "VENTA GUARDADA CORRECTAMENTE", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "NO SE PUDO GUARDAR LA VENTA");
                        }
                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL CREAR VENTA", e.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }
            return r;
        }

        public respuesta updateMonto(int _id, int _monto,int _idMovimiento)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        APERTURA obj = db.APERTURA.Find(_id);

                        switch (_idMovimiento)
                        {
                            case 1:
                                obj.monto = obj.monto + _monto;
                                break;

                            case 2:
                                obj.monto = obj.monto - _monto;
                                break;
                        }
                        
                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        int afected = db.SaveChanges();

                        if (obj != null)
                        {
                            r = new respuesta(true, "MOVIMIENTO REALIZADO", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "ERROR AL HACER MOVIMIENTO");
                        }


                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL HACER MOVIMIENTO", ex.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;

        }

        public respuesta updateEstado(int _id)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        APERTURA obj = db.APERTURA.Find(_id);


                        obj.estado = "0";

                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        int afected = db.SaveChanges();

                        if (obj != null)
                        {
                            r = new respuesta(true, "MOVIMIENTO REALIZADO", obj);
                        }
                        else
                        {
                            r = new respuesta(false, "ERROR AL HACER MOVIMIENTO");
                        }


                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL HACER MOVIMIENTO", ex.Message.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", e.Message.ToString());
            }

            return r;

        }

        public respuesta traerApertura(int _idCaja)
        {

            respuesta r;
            aperturaModel mApertura = new aperturaModel();
            r = mApertura.BUSCAR_POR_ID_Y_ESTADO(_idCaja);
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

                        objDatos = db.APERTURA.Find(_id);

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "APERTURA ENCONTRADA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "APERTURA NO ENCONTRADA");
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
