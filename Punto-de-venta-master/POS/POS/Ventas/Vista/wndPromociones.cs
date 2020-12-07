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
    public partial class wndPromociones : Form
    {
        public wndPromociones()
        {
            InitializeComponent();
        }

        private void wndPromociones_Load(object sender, EventArgs e)
        {
            refrescarGrilla();
        }

        void refrescarGrilla()
        {
            respuesta rPromocion;
            promocionController pc = new promocionController();
            rPromocion = pc.listarPromocionesXDescripcion();

            if (rPromocion.status)
            {

                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = rPromocion.Data;

            }
            cbCategoria.SelectedIndex = 1;
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.Utils.solonumeros(e);
        }

        private void txtCondicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.Utils.solonumeros(e);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow.Index != -1)
            {
                lblId.Text = dgvData.CurrentRow.Cells["id"].Value.ToString();
                txtDescripcion.Text = dgvData.CurrentRow.Cells["descripcion"].Value.ToString();
                numericDesde.Value = Convert.ToInt32(dgvData.CurrentRow.Cells["condicion"].Value);
                numericDescuento.Value = Convert.ToInt32(dgvData.CurrentRow.Cells["descuento"].Value);
                cbCategoria.SelectedIndex = Convert.ToInt32(dgvData.CurrentRow.Cells["estado"].Value);

            }
        }
        void reset()
        {
            txtDescripcion.Text = "";
            numericDescuento.Value = 1;
            numericDesde.Value = 1;
            cbCategoria.Refresh();
            lblId.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            string estado = Convert.ToString(cbCategoria.SelectedItem);
            string estadoCrud = null;
            if(estado.Equals("0 - Inactiva"))
            {
                estadoCrud = "0";
            }
            else
            {
                estadoCrud = "1";
            }
            respuesta r;
            promocionController pc = new promocionController();
            if (lblId.Text == "")
            {
               
                r = pc.agregar(Convert.ToInt32(numericDesde.Value), Convert.ToInt32(numericDescuento.Value), estadoCrud, txtDescripcion.Text);
                if (r.status)
                {
                    refrescarGrilla();
                    reset();
                }
            }
            else
            {
                r = pc.Editar(Convert.ToInt32(lblId.Text),Convert.ToInt32(numericDesde.Value), Convert.ToInt32(numericDescuento.Value), estadoCrud, txtDescripcion.Text);
                if (r.status)
                {
                    refrescarGrilla();
                    reset();
                }
            }
        }
    }
}
