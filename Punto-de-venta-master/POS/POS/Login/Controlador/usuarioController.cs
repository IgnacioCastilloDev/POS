using POS.DBModel;
using POS.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Login.Controlador
{
    class usuarioController
    {

        public respuesta validarUsuario(string _usuario,string _password)
        {
            respuesta r;
            USUARIO objDatos;

            try
            {

                using (POS.DBModel.negocioEntities db = new POS.DBModel.negocioEntities())
                {
                    try
                    {
                        objDatos = db.USUARIO.Where(x => x.usuario1 == _usuario ).First();

                        if (objDatos.password == _password)
                        {
                            r = new respuesta(true, "Bienvenido", objDatos);
                        }
                        else
                        {
                            r = new respuesta(false, "CONTRASEÑA INCORRECTA");
                        }
                    }
                    catch (Exception e)
                    {
                        r = new respuesta(false, "EL USUARIO NO EXISTE EN LA BD", e.Message.ToString());
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
