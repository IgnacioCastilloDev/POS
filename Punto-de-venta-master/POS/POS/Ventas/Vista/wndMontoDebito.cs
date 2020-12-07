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
    public partial class wndMontoDebito : Form
    {
        public string debitoCancelado = "0";
        public wndMontoDebito()
        {
            InitializeComponent();
        }

        private void wndMontoDebito_Load(object sender, EventArgs e)
        {

        }

        public void ingresarMonto()
        {
            if (txtDebito.Text == "")
            {
                debitoCancelado = "0";
                this.Close();
            }
            else
            {
                debitoCancelado = txtDebito.Text;
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
    }
}
