using POS.DBModel;
using POS.Login.Controlador;
using POS.Utilidades;
using POS.Ventas.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Login.Vista
{
    public partial class wndLogin : Form
    {
        public wndLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            validarIngreso();

        }

        public void validarIngreso()
        {
            respuesta r;
            usuarioController uc = new usuarioController();
            r = uc.validarUsuario(txtUsuario.Text,txtPassword.Text);


            if (r.status)
            {
                wndVentas wventas = new wndVentas();
                USUARIO usuariologged = (USUARIO)r.Data;
                sesion.nombreUsuario = usuariologged.nombre;
                sesion.idUsuario = usuariologged.id;

                wventas.ShowDialog();
               
                
                this.Close();
    
            }
            else
            {
                MessageBox.Show(r.mensajeUsuario);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
