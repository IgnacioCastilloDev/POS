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
    public partial class Success : Form
    {
        public string contenido;
        public Success(string _contenido)
        {
            contenido = _contenido;
            InitializeComponent();
        }

        private void Success_Load(object sender, EventArgs e)
        {
            lblContenido.Text = contenido;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
