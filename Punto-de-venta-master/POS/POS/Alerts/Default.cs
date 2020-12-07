using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Alerts
{
    public partial class Default : Form
    {

        public string contenido;
        public Default(string _contenido)
        {
            contenido = _contenido;
            InitializeComponent();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            lblContenido.Text = contenido;
        }

        private void Default_Leave(object sender, EventArgs e)
        {
            
        }

        private void Default_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblContenido_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
