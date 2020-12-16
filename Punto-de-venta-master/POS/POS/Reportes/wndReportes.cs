using POS.Utilidades;
using POS.Ventas.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Reportes
{
    public partial class wndReportes : Form
    {
        public int metodoPago;
        public wndReportes()
        {
            InitializeComponent();
        }

        private void wndReportes_Load(object sender, EventArgs e)
        {
            refrescarComboMetodoPago();
        }

        public void  checkRadioButton()
        {
            if (rbCredito.Checked == true)
            {
                metodoPago = 3;
            }
            if (rbDebito.Checked == true)
            {
                metodoPago = 2;
            }
            if (rbEfectivo.Checked == true)
            {
                metodoPago = 1;
            }
        }
        void refrescarComboMetodoPago()
        {
            respuesta r;
            tipoDocumentoController tdc = new tipoDocumentoController();

            r = tdc.listarCategoriasXNombre();

            cbTipoDocumento.DataSource = r.Data;
            cbTipoDocumento.DisplayMember = "nombre";
            cbTipoDocumento.ValueMember = "id";

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            checkRadioButton();
            respuesta rVenta;
            ventaController vc = new ventaController();

            rVenta = vc.traerVentasXperiodo(dtpDesde.Value,dtpHasta.Value,Convert.ToInt32(cbTipoDocumento.SelectedValue),metodoPago);
            if (rVenta.status)
            {

                MessageBox.Show("ssd");
            }
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
          
;        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
