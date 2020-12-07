using POS.Alerts;
using POS.DBModel;
using POS.Entidades;
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
    public partial class wndOperaciones : Form
    {
        public Boolean movimiento = false;
        public string _id;
        public int _montoEnCaja;
        public wndOperaciones( string _idCaja)
        {

            _id = _idCaja;
            InitializeComponent();
            if (_idCaja != "")
            {
                lblId.Text = _id;
            }
            
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

        void combo()
        {

            respuesta r;
            movimientoController mc = new movimientoController();
            r = mc.listarMovimientoXNombre();
            cbTipoOperacion.DataSource = r.Data;
            cbTipoOperacion.DisplayMember = "nombre";
            cbTipoOperacion.ValueMember = "id";

        }

        private void wndOperaciones_Load(object sender, EventArgs e)
        {
            combo();
            StartTimer();

            respuesta rApertura;
            aperturaController ac = new aperturaController();
            rApertura = ac.buscarXId(Convert.ToInt32(lblId.Text));
            if (rApertura.status)
            {
                APERTURA apertura = (APERTURA)rApertura.Data;
                _montoEnCaja = Convert.ToInt32(apertura.monto);
            }
            txtMontoEnCaja.Text = Convert.ToString(_montoEnCaja.ToString("#,##0").Replace(",", "."));

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.Utils.solonumeros(e);
        }

        public void operacion()
        {
            respuesta rApertura;
            respuesta rDetalleMovimiento;
            detalleMovimiento dm = new detalleMovimiento();
            aperturaController ac = new aperturaController();

            rDetalleMovimiento = dm.agregar(Convert.ToInt32(cbTipoOperacion.SelectedValue),
                                 Convert.ToInt32(lblId.Text), Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(txtMonto.Text), txtMotivo.Text);
            if (rDetalleMovimiento.status)
            {

                rApertura = ac.updateMonto(Convert.ToInt32(lblId.Text), Convert.ToInt32(txtMonto.Text), Convert.ToInt32(cbTipoOperacion.SelectedValue));
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text != "")
            {

                string selected = cbTipoOperacion.Text;
                if (selected.Equals("Egreso"))
                {
                    if(Convert.ToInt32(txtMonto.Text) == _montoEnCaja)
                    {
                        if (MessageBox.Show("Va a retirar la totalidad del dinero en caja ¿Esta Seguro?", "Movimientos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            operacion();
                            this.Close();
                            movimiento = true;
                        }
                    }
                    if(Convert.ToInt32(txtMonto.Text) > _montoEnCaja)
                    {
                        
                           MessageBox.Show(" El Monto ingresado es superior al monto en caja , vuelta a intentar con menos");
                    }

                    if (Convert.ToInt32(txtMonto.Text) < _montoEnCaja)
                    {

                        if (MessageBox.Show("Va a retirar la cantidad de $ "+txtMonto.Text+" ¿Esta Seguro?", "Movimientos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            operacion();
                            this.Close();
                            movimiento = true;
                        }
                       
                    }
                }
                else
                {
                    if (MessageBox.Show("Va a hacer un ingreso  con una  cantidad de $ " + txtMonto.Text + " ¿Esta Seguro?", "Movimientos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        operacion();
                        this.Close();
                        movimiento = true;
                    }
                    
                }                   
            }
        }
    }
}
