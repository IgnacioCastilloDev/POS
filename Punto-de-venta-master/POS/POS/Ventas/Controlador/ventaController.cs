using POS.DBModel;
using POS.Reportes.Modelo;
using POS.Utilidades;
using POS.Ventas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace POS.Ventas.Controlador
{
    class ventaController
    {

        public respuesta agregar(DateTime _fecha, int _apertura,int? _totalVenta,int _fk_idMetodoDePago, int _fk_idTipoDocumento)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        VENTA obj = new VENTA();
                        obj.fecha = _fecha;
                        obj.fk_id_apertura =_apertura;
                        obj.fk_id_metodoPago = _fk_idMetodoDePago;
                        obj.total_venta = _totalVenta;
                        obj.fk_id_tipo_documento = _fk_idTipoDocumento;
                      
                        db.VENTA.Add(obj);
                        int afected = db.SaveChanges();
                        VENTA VENTA = (VENTA)obj;
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


        public respuesta TRAER_MAX_ID_VENTA()
        {

            respuesta r;
            ventaModel mVenta = new ventaModel();
            r = mVenta.TRAER_MAX_ID_VENTA();
            return r;

        }



        public respuesta traerVentasXperiodo(DateTime _desde,DateTime _hasta, int _tipoDocumento, int _metodoPago)
        {
            respuesta r;
            ventasXperiodo ventasXperiodo = new ventasXperiodo();
            r = ventasXperiodo.traerVentasXperiodo(_desde,_hasta,_tipoDocumento,_metodoPago);
            return r;
        }

        public respuesta traerTotalXperiodo(DateTime _desde, DateTime _hasta, int _tipoDocumento, int _metodoPago)
        {
            respuesta r;
            ventasXperiodo ventasXperiodo = new ventasXperiodo();
            r = ventasXperiodo.traerTotalXperiodo(_desde, _hasta, _tipoDocumento, _metodoPago);
            return r;
        }
    }
}
