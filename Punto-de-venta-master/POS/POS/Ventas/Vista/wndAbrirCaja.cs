using POS.DBModel;
using POS.Entidades.Controlador;
using POS.Entidades.Modelo;
using POS.Login.Controlador;
using POS.Utilidades;
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
    public partial class wndAbrirCaja : Form
    {
       
        public Boolean abrio = false;
        public string idCajaAbierta = null;
       
        public wndAbrirCaja()
        {
            InitializeComponent();
           
            
            
        }


        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            txtFechaApertura.Text = DateTime.Now.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void wndAbrirCaja_Load(object sender, EventArgs e)
        {
            StartTimer();
            comprobarEstadoCaja(); //-- Inicia combo Box

        }

        public void comprobarCajaAbierta()
        {
            


        }
        public void comprobarEstadoCaja()
        {
            respuesta r;      
            cajaController cc = new cajaController();
            r = cc.listarCajasXNombre();          
            cbCaja.DataSource = r.Data;
            cbCaja.DisplayMember = "nombre";
            cbCaja.ValueMember = "id";     
            txtCajero.Text = sesion.nombreUsuario;
            
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (txtMontoInicial.Text != "" && Convert.ToInt32(txtMontoInicial.Text) >0)
            {
                respuesta rApertura;
                respuesta rCaja;
                aperturaController ac = new aperturaController();
                cajaController cc = new cajaController();
                //Consultar ID CAJA PARA EVITAR ERROR
                rApertura = ac.agregar(Convert.ToDateTime(txtFechaApertura.Text), Convert.ToInt64(txtMontoInicial.Text), "1", sesion.idUsuario, 1);
                if (rApertura.status)
                {

                    APERTURA apertura = (APERTURA)rApertura.Data;
                    rCaja = cc.Editar(1,"1");

                    if (rCaja.status)
                    {
                        abrio = true;
                        idCajaAbierta = Convert.ToString(apertura.id);
                        this.Close();
                        
                    }
                }
            }
            else
            {
            }
           

        }

        private void wndAbrirCaja_Shown(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
