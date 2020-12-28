using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades.Modelo
{
    class detalleMovimientoModel
    {
        public string fecha { get; set; }
        public int id { get; set; }
        public int monto { get; set; }
        public string motivo { get; set; }
        public string nombreMov { get; set; }
        public string nombreCajero { get; set; }
        public string nombreCaja { get; set; }

        public respuesta traerMovimientosDiarios(DateTime _desde,DateTime _hasta,int _idMov)
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        string sql = "SELECT FORMAT(fecha,'dd/MM/yyyy hh:mm') as fecha,DM.id,DM.monto,DM.motivo,M.nombre nombreMov,U.nombre as nombreCajero,c.nombre as nombreCaja " +
                                      "FROM DETALLE_MOVIMIENTO DM INNER JOIN MOVIMIENTO M ON M.id = DM.fk_id_movimiento " +
                                      "INNER JOIN APERTURA A ON A.id = DM.fk_id_apertura " +
                                      "INNER JOIN USUARIO U ON U.id= A.fk_id_usuario " +
                                      "INNER JOIN CAJA C ON C.ID = A.fk_id_caja  " +
                                      "where CONVERT(DATE,DM.fecha) >= @Desde and CONVERT(DATE,DM.fecha) <= @Hasta and DM.fk_id_movimiento=@idMov ";

                        SqlParameter sqlDesde = new SqlParameter("@Desde", System.Data.SqlDbType.Date);
                        sqlDesde.Value = _desde.Date;
                        SqlParameter sqlHasta = new SqlParameter("@Hasta", System.Data.SqlDbType.Date);
                        sqlHasta.Value = _hasta.Date;
                        SqlParameter sqlIdMov = new SqlParameter("@idMov", System.Data.SqlDbType.Int);
                        sqlIdMov.Value = _idMov;


                        SqlParameter[] parametros = new SqlParameter[3] { sqlDesde,sqlHasta,sqlIdMov };


                        objDatos = db.Database.SqlQuery<detalleMovimientoModel>(sql, parametros).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "Movimientos encontrados", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "Movimientos NO ENCONTRADO");
                        }

                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "ERROR AL TRAER Movimientos", e.Message.ToString());
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
