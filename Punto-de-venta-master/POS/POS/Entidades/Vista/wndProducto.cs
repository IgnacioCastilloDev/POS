using POS.Alerts;
using POS.Entidades.Controlador;
using POS.Entidades.Modelo;
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

namespace POS.Entidades.Vista
{
    public partial class wndProducto : Form
    {
        public int condicion = 0;
        public int descuento = 0;
        public wndProducto()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void refrescarGrilla()
        {
            respuesta r;
            productoModel pm = new productoModel();
            r = pm.listarProductos();

            if (r.status)
            {
                dgvData.DataSource = r.Data;
            }
            pintarQuiebres();

            if (dgvData.Rows.Count > 0)
            {
                dgvData.Rows[0].Selected = false;
            }
           


        }

        void refrescarComboCat()
        {
            respuesta r;
            categoriaController cc = new categoriaController();
            r = cc.listarCategoriasXNombre();
            cbCategoria.DataSource = r.Data;
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.ValueMember = "id";

       


        }

        private void wndProducto_Load(object sender, EventArgs e)
        {


           
            refrescarGrilla();
            refrescarComboCat();
           
            rbNo.Checked = true;
          
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

       
            if (dgvData.CurrentRow.Index !=  -1)
            {
    
                lblId.Text = dgvData.CurrentRow.Cells["id"].Value.ToString();
                txtDescripcion.Text = dgvData.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dgvData.CurrentRow.Cells["precio"].Value.ToString();
                txtStock.Text = dgvData.CurrentRow.Cells["stock"].Value.ToString();
                cbCategoria.SelectedValue = dgvData.CurrentRow.Cells["idCategoria"].Value;

                if(Convert.ToInt32(dgvData.CurrentRow.Cells["condicionp"].Value) > 0 || Convert.ToInt32(dgvData.CurrentRow.Cells["descuentop"].Value) > 0)
                {
                    gbPromo.Visible = true;

                    int descuento = Convert.ToInt32(dgvData.CurrentRow.Cells["descuentop"].Value);
                    int desde = Convert.ToInt32(dgvData.CurrentRow.Cells["condicionp"].Value);

                    numericDescuento.Value = descuento;
                    numericDesde.Value = desde;

                    rbSi.Checked = true;
                    refrescarFixNumeric();
                }
                else
                {
                    rbNo.Checked = true;
                    gbPromo.Visible = false;
                }
                //>= 0 && stock <
                txtCodigoBarra.Text = dgvData.CurrentRow.Cells["codigoBarra"].Value.ToString();
                pintarQuiebres();

            }
            
        }

        void refrescarFixNumeric()
        {
            if (dgvData.CurrentRow.Index != -1)
            {

                lblId.Text = dgvData.CurrentRow.Cells["id"].Value.ToString();
                txtDescripcion.Text = dgvData.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dgvData.CurrentRow.Cells["precio"].Value.ToString();
                txtStock.Text = dgvData.CurrentRow.Cells["stock"].Value.ToString();
                cbCategoria.SelectedValue = dgvData.CurrentRow.Cells["idCategoria"].Value;

                if (Convert.ToInt32(dgvData.CurrentRow.Cells["condicionp"].Value) > 0 || Convert.ToInt32(dgvData.CurrentRow.Cells["descuentop"].Value) > 0)
                {
                    gbPromo.Visible = true;

                    int descuento = Convert.ToInt32(dgvData.CurrentRow.Cells["descuentop"].Value);
                    int desde = Convert.ToInt32(dgvData.CurrentRow.Cells["condicionp"].Value);

                    numericDescuento.Value = descuento;
                    numericDesde.Value = desde;

                    rbSi.Checked = true;
                }
                else
                {
                    rbNo.Checked = true;
                    gbPromo.Visible = false;
                }
                //>= 0 && stock <
                txtCodigoBarra.Text = dgvData.CurrentRow.Cells["codigoBarra"].Value.ToString();
                pintarQuiebres();

            }
        }
     

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            reset();        

        }
        void reset()
        {
            lblId.Text = "";
            txtCodigoBarra.Text = "";
            txtDescripcion.Text = "";
            txtFiltroBusqueda.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";
            gbPromo.Visible = false;
            numericDesde.Value = 0;
            numericDescuento.Value = 0;
            descuento = 0;
            condicion = 0;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(lblId.Text != "")
            {
                respuesta rProducto;
                productoController pc = new productoController();
                rProducto = pc.Eliminar(Convert.ToInt32(lblId.Text));

                if (rProducto.status)
                {
                    Success success = new Success("Producto Eliminado correctamente");
                    success.ShowDialog();
                    reset();
                    refrescarGrilla();
                }
            }
            else
            {
                Default def = new Default("Seleccione un producto");
                def.ShowDialog();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            productoController pc = new productoController();
            respuesta rProducto;

            if (txtCodigoBarra.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "" && txtStock.Text != "")
            {

                if (rbSi.Checked)
                {
                    descuento = Convert.ToInt32(numericDescuento.Value);
                    condicion = Convert.ToInt32(numericDesde.Value);
                }
                if (lblId.Text == "")
            {


                    //int precioConDescuento = precio - Convert.ToInt32(precio * descuento )/100;

                    //Preguntar si el producto existe

                 respuesta rExisteCodigoBarra;
                    rExisteCodigoBarra = pc.buscarXCodigoDeBarra(txtCodigoBarra.Text.Replace(" ", ""));
                    if (rExisteCodigoBarra.status)
                    {
                        Default def = new Default("El codigo de barra ingresado ya existe");
                        def.ShowDialog();
                    }
                    else
                    {

                    
                rProducto = pc.agregar(txtCodigoBarra.Text.Replace(" ", ""), Convert.ToInt32(txtStock.Text), txtDescripcion.Text , Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(cbCategoria.SelectedValue),condicion,descuento);
                if (rProducto.status)
                {
                    Success success = new Success("Producto Guardado correctamente");
                    success.ShowDialog();
                    reset();
                    refrescarGrilla();
                }
                
                else
                {
                    Default def = new Default("Error al guardar producto");
                    def.ShowDialog();
                }
                    }

                }
            else
            {
                rProducto = pc.Editar(Convert.ToInt32(lblId.Text), txtCodigoBarra.Text, Convert.ToInt32(txtStock.Text), txtDescripcion.Text, Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(cbCategoria.SelectedValue), condicion, descuento);

                if (rProducto.status)
                {
                    Success success = new Success("Producto modificado correctamente");
                    success.ShowDialog();
                    reset();
                    refrescarGrilla();
                }
            }
            }
            else
            {
                Default def = new Default("Faltan datos por rellenar");
                def.ShowDialog();
            }
        }
        void pintarQuiebres()
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {

                int stock = Convert.ToInt32(dgvData.Rows[i].Cells["stock"].Value);
                if (stock >= 0 && stock <= 15)
                {
             
                 row.Cells[2].Style.BackColor = Color.Red;

                }

                if (stock >= 16 && stock <= 20)
                {
                    row.Cells[2].Style.BackColor = Color.Khaki;
                }

                if (stock >= 21)
                {
                    row.Cells[2].Style.BackColor = Color.LightSeaGreen;
                }
                i++;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refrescarGrilla();
        }

        void solonumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                       if (Char.IsControl(e.KeyChar)) //permitir teclas de control 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas (no numéricas ni de control) pulsadas se desactivan
                e.Handled = true;
            }
            if ((e.KeyChar == (char)Keys.Enter))
            {
                cbCategoria.Focus();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumeros(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

            solonumeros(e);
        }

        private void wndProducto_Shown(object sender, EventArgs e)
        {

            pintarQuiebres();
        }

        private void cbPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            gbPromo.Visible = true;
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            gbPromo.Visible = false;
            numericDesde.Value = 0;
            numericDescuento.Value = 0;
            descuento = 0;
            condicion = 0;
        }
    }
}
