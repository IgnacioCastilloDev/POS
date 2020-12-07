using POS.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace POS.Utilidades
{
    public class Utils
    {

        public static Form abrirAlertaDefault(string _mensaje)
        {

            Default alert = new Default(_mensaje);
            return alert;
           
        }
       public static void solonumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                       if (Char.IsControl(e.KeyChar)) //permitir teclas de control 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas (no numéricas ni de control) pulsadas se desactivan
                e.Handled = true;
            }
         
        }


        public static int ajusteSencillo(int subtotal)
        {
            int resultadoAjuste = 0;
            int ajuste = subtotal % 10;
            if (ajuste >= 5)
            {
                resultadoAjuste = subtotal - ajuste + 10;
            }
            else
            {
                resultadoAjuste = subtotal - ajuste;
            }

            return resultadoAjuste;
        }


        public static void reproducirBeep()
        {
            WindowsMediaPlayer myplayer = new WindowsMediaPlayer();
            myplayer.URL = @"C:\Users\Oskr_\Desktop\Nueva carpeta\beep.mp3";
            myplayer.controls.play();
        }
    }
}
