using POS.DBModel;
using POS.Utilidades;
using POS.Ventas.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Ventas.Vista
{
    public partial class wndConfirmarVenta : Form
    {

        public Boolean confirmo = false;

       
        public wndConfirmarVenta()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            confirmo = true;
            this.Close();
         

        }
    }
}
