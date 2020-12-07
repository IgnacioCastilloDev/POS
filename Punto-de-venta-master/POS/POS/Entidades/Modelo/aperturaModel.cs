using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entidades.Modelo
{
    class aperturaModel : APERTURA
    {
        public string nombre { get; set; }
        public respuesta BUSCAR_POR_ID_Y_ESTADO(int _idCaja)
        {
            respuesta r;
            Object objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {

                    try
                    {

                        string sql = "SELECT A.id,A.hora_apertura,A.monto,A.estado,a.fk_id_usuario,a.fk_id_caja,U.nombre FROM APERTURA A" +
                                     " INNER JOIN CAJA C on C.id = A.fk_id_caja" +
                                     " INNER JOIN USUARIO U on U.id = A.fk_id_usuario " +
                                     "where a.estado = 1 and A.fk_id_caja = @idCaja";

                        SqlParameter sqlIdCaja = new SqlParameter("@idCaja", System.Data.SqlDbType.Int);
                        sqlIdCaja.Value = _idCaja;
                        

                        SqlParameter[] parametros = new SqlParameter[1] { sqlIdCaja };


                        objDatos = db.Database.SqlQuery<aperturaModel>(sql, parametros).FirstOrDefault();

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

    }

}
