using POS.Alerts;
using POS.DBModel;
using POS.Entidades.Controlador;
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
    public partial class wndCierreDeCaja : Form
    {
        public string _id;
        public Boolean cerro  = false;
        public wndCierreDeCaja(string _idApertura)
        {
            _id  = _idApertura;

            InitializeComponent();
            txtAperturaId.Text = _id;
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
            txtFecha.Text = DateTime.Now.ToString();
        }
        private void wndCierreDeCaja_Load(object sender, EventArgs e)
        {

            respuesta r;
            cajaController cc = new cajaController();
            r = cc.listarCajasXNombre();
            cbCaja.DataSource = r.Data;
            cbCaja.DisplayMember = "nombre";
            cbCaja.ValueMember = "id";

            StartTimer();
        }

        private void txtMontoFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.Utils.solonumeros(e);
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (txtMontoFinal.Text != "")
            {
     
            if (MessageBox.Show("Se va Cerrar la caja ¿Esta seguro?", "Cierre", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                respuesta respuestaApertura;
                respuesta rCaja;
                aperturaController ac = new aperturaController();
                cajaController cc = new cajaController();
                respuestaApertura = ac.buscarXId(Convert.ToInt32(txtAperturaId.Text));
            if (respuestaApertura.status) {

                APERTURA apertura = (APERTURA)respuestaApertura.Data;

                rCaja = cc.Editar(Convert.ToInt32(apertura.fk_id_caja), "0");
                        if (rCaja.status)
                        {

                            respuestaApertura = ac.updateEstado(Convert.ToInt32(apertura.id));
                            if (respuestaApertura.status)
                            {
                                cerro = true;
                                this.Close();
                            }
                            
                           
                        }
                
            }
            }
            }

        }

        
    }
}
