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
    public partial class wndMontoCredito : Form
    {
        public string creditoCancelado = "0";
        public wndMontoCredito()
        {
            InitializeComponent();
        }

        public void ingresarMonto()
        {
            if (txtCredito.Text == "")
            {
                creditoCancelado = "0";
                this.Close();
            }
            else
            {
                creditoCancelado = txtCredito.Text;
                this.Close();
            }

        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == (char)Keys.Enter))
            {
                ingresarMonto();
            }
        }

        private void wndMontoCredito_Load(object sender, EventArgs e)
        {

        }
    }
}
