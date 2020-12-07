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
    public partial class wndMetodoDePago : Form
    {


        public int metodoDePago;
        public wndMetodoDePago()
        {
            InitializeComponent();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void wndMetodoDePago_Load(object sender, EventArgs e)
        {

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            metodoDePago = 1;
            this.Close();
        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            metodoDePago = 2;
            this.Close();
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            metodoDePago = 3;
            this.Close();
        }
    }
}
