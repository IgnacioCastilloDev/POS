using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Ventas.Vista
{
    public partial class wndMontoEfectivo : Form
    {
       

        public string efectivoCancelado = "0";
        public wndMontoEfectivo()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ingresarMonto();
        }

        public void ingresarMonto()
        {
            if (txtEfectivo.Text == "")
            {
                efectivoCancelado = "0";
                this.Close();
            }
            else
            {
                efectivoCancelado = txtEfectivo.Text;
                this.Close();
            }

        }

        private void wndMontoEfectivo_Load(object sender, EventArgs e)
        {

        }

        void solonumeros(KeyPressEventArgs e)
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

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumeros(e);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == (char)Keys.Enter))
            {
                ingresarMonto();
            }
        }

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {

            
        }
    }
}
