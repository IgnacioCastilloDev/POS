using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace POS.Ventas.Controlador
{
    class detalleVentaController
    {
        public respuesta Agregar(long _idProducto,int _cantidad,int _subtotal,long _idVenta)
        {
            respuesta r;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        DETALLE_VENTA obj = new DETALLE_VENTA();
                        obj.fk_producto = _idProducto;
                        obj.cantidad = _cantidad;
                        obj.subtotal = _subtotal;
                        obj.fk_venta = _idVenta;
                        db.DETALLE_VENTA.Add(obj);
                        int afected = db.SaveChanges();
                        DETALLE_VENTA detalle_venta = (DETALLE_VENTA)obj;
                        if (afected == 1)
                            r = new respuesta(true, "VENTA GUARDADA CORRECTAMENTE", obj);
                        else
                            r = new respuesta(false, "NO SE PUDO GUARDAR LA VENTA");
                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL CREAR VENTA", ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                r = new respuesta(false, "CONEXION CON LA DB RECHAZADA", ex.Message.ToString());
            }
            return r;
        }
    }
}
