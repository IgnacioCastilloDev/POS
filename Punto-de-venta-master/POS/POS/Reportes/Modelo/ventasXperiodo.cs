using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Reportes.Modelo
{
    class ventasXperiodo
    {

        public long VID { get; set; }
        public int AID { get; set; }
        public DateTime  fecha { get; set; }
        public int total_venta { get; set; }
        public string metodopago { get; set; }
        public string documento { get; set; }
        public string nombrecaja { get; set; }
        public string nombrecajero { get; set; }
        public int totalEntrePeriodo { get; set; }
     




        public respuesta traerVentasXperiodo(DateTime _desde,DateTime _hasta,int _tipoDocumento,int _metodoPago)
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        string sql = "SELECT V.ID AS VID,A.id AS AID,V.fecha,V.total_venta,mp.nombre " +
                                    "as metodopago,TD.nombre as documento,C.nombre as nombrecaja,U.nombre as nombrecajero " +              
                                    "FROM VENTA V INNER JOIN METODO_PAGO MP ON MP.ID = V.fk_id_metodoPago " +
                                    "INNER JOIN APERTURA A ON A.id =V.fk_id_apertura " +
                                    "INNER JOIN USUARIO U ON U.id = a.fk_id_usuario " +
                                    "INNER JOIN TIPO_DOCUMENTO TD ON TD.id = V.fk_id_tipo_documento " +
                                    "INNER JOIN CAJA C ON C.ID = A.fk_id_caja " +
                                    "where v.fecha >=@Desde and  v.fecha <=@Hasta and TD.id = @TipoDoc and MP.id = @MetoPago";

                       
                        SqlParameter sqlDesde = new SqlParameter("@Desde", System.Data.SqlDbType.Date);
                        sqlDesde.Value = _desde.Date;
                        SqlParameter sqlHasta = new SqlParameter("@Hasta", System.Data.SqlDbType.Date);
                        sqlHasta.Value = _hasta.Date;
                        SqlParameter sqlTipoDocumento = new SqlParameter("@TipoDoc", System.Data.SqlDbType.Int);
                        sqlTipoDocumento.Value = _tipoDocumento;
                        SqlParameter sqlMetodoPago = new SqlParameter("MetoPago", System.Data.SqlDbType.Int);
                        sqlMetodoPago.Value = _metodoPago;




                        SqlParameter[] parametros = new SqlParameter[4] {sqlDesde,sqlHasta,sqlTipoDocumento,sqlMetodoPago };


                        objDatos = db.Database.SqlQuery<ventasXperiodo>(sql, parametros).ToList();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "APERTURA ENCONTRADA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "APERTURA NO ENCONTRADO");
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



        public respuesta traerTotalXperiodo(DateTime _desde,DateTime _hasta, int _tipoDocumento, int _metodoPago)
        {

            respuesta r;
            Object objDatos;
            try
            {
                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {


                    try
                    {
                        string sql = "select SUM(V.total_venta) as totalEntrePeriodo from VENTA V  INNER JOIN TIPO_DOCUMENTO TD ON TD.id = V.fk_id_tipo_documento " +
                                      "INNER JOIN METODO_PAGO MP ON MP.ID = V.fk_id_metodoPago where v.fecha >= @Desde and v.fecha <= @Hasta and TD.id = @TipoDoc and MP.id = @MetoPago";

                        SqlParameter sqlDesde = new SqlParameter("@Desde", System.Data.SqlDbType.DateTime);
                        sqlDesde.Value = _desde.Date;
                        SqlParameter sqlHasta = new SqlParameter("@Hasta", System.Data.SqlDbType.DateTime);
                        sqlHasta.Value = _hasta.Date;
                        SqlParameter sqlTipoDoc = new SqlParameter("@TipoDoc", System.Data.SqlDbType.Int);
                        sqlTipoDoc.Value = _tipoDocumento;
                        SqlParameter sqlMetoPago = new SqlParameter("@MetoPago", System.Data.SqlDbType.Int);
                        sqlMetoPago.Value = _metodoPago;


                        SqlParameter[] parametros = new SqlParameter[4] { sqlDesde,sqlHasta,sqlTipoDoc,sqlMetoPago};

                        objDatos = db.Database.SqlQuery<ventasXperiodo>(sql, parametros).FirstOrDefault();

                        if (objDatos != null)
                        {
                            r = new respuesta(true, "APERTURA ENCONTRADA", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "APERTURA NO ENCONTRADO");
                        }
                    }
                    catch (Exception ex)
                    {
                        r = new respuesta(false, "ERROR AL TRAER APERTURA", ex.Message.ToString());
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
