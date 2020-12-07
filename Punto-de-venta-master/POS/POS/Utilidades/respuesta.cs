using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Utilidades
{
    public class respuesta
    {

        public Boolean status = false;
        public String mensajeUsuario;
        public Object Data;
        public String mensajeDB;


        public respuesta(Boolean _status, string _mensajeUsuario)
        {

            status = _status;
            mensajeUsuario = _mensajeUsuario;
          
        }
        public respuesta (Boolean _status, string _mensajeUsuario, object _queryData)
        {

            status = _status;
            mensajeUsuario = _mensajeUsuario;
            Data = _queryData;

        }

        public respuesta(Boolean _status, string _mensajeUsuario, string _mensajeDB)
        {

            status = _status;
            mensajeUsuario = _mensajeUsuario;
            mensajeDB = _mensajeDB;
        }



    }
}
