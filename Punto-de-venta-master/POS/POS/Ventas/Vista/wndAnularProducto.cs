using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Ventas.Vista
{
    public partial class wndAnularProducto : Form
    {
        public wndAnularProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            traspasarCodigoYCantidad();
        }

        void traspasarCodigoYCantidad()
        {
            wndVentas.anularProducto(txtCodigoDeBarra.Text, Convert.ToString(numericCantidad.Value));
            this.Close();
        }

        private void txtCodigoDeBarra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar == (char)Keys.Enter))
            {
                traspasarCodigoYCantidad();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericCantidad_Enter(object sender, EventArgs e)
        {

            ActiveControl = txtCodigoDeBarra;
        }
    }
}
