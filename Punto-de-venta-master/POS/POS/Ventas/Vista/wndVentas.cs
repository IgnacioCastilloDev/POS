using POS.Alerts;
using POS.DBModel;
using POS.Entidades.Controlador;
using POS.Entidades.Modelo;
using POS.Entidades.Vista;
using POS.Login.Controlador;
using POS.Utilidades;
using POS.Ventas.Controlador;
using POS.Ventas.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace POS.Ventas.Vista
{
    public partial class wndVentas : Form
    {
        public static string _cantidadAnular =null;
        public static string _codigoBarraAnular =null;
        public  string _efectivoCancelado = null;
        public string _idCajaAsignada = null;
        public int metodoDePago ;
        
      
        public wndVentas()
        {
            InitializeComponent();

                 
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            traerXCodigoDeBarra();
        }

        public int  ajusteSencillo(int subtotal)
        {
            int resultadoAjuste = 0;
            int ajuste = subtotal % 10;
            if(ajuste >= 5)
            {
                resultadoAjuste =  subtotal - ajuste+10;
            }
            else
            {
                 resultadoAjuste = subtotal - ajuste ;
            }

            return resultadoAjuste;
        }

        public int calcularDescuento(int cantidad,int condicion, int descuento,int subtotal,int precio,int NumericCantidad)
        {
            int subtotalConDescuento = 0;
            int totalCorregido = 0;
            if(cantidad >= condicion)
            {

                int resultadoSinDescuento =  precio * cantidad;
                int resultadoDescuento = (resultadoSinDescuento * descuento) / 100;
                 subtotalConDescuento = resultadoSinDescuento - resultadoDescuento;
                totalCorregido = ajusteSencillo(subtotalConDescuento);
    
            }
                //int resultadoSinDescuento = Convert.ToInt32(dgvData.Rows[rowIndex].Cells["subtotal"].Value) + (Convert.ToInt32(producto.precio)
                //                            * Convert.ToInt32(numericCantidad.Value));
                //int resultadoDescuento = Convert.ToInt32(resultadoSinDescuento * descuento) / 100;
                //int subtotalConDescuento = resultadoSinDescuento - resultadoDescuento;
                //dgvData.Rows[rowIndex].Cells["subtotal"].Value = subtotalConDescuento;
    
            return totalCorregido;
        }


        void traerXCodigoDeBarra()
        {
            if (lblId.Text != "") { 
            productoController pc = new productoController();
            PRODUCTO producto;
            respuesta r;
            r = pc.buscarXCodigoDeBarra(txtCodigoBarra.Text.Replace(" ",""));
            if (r.status)
            {
                dgvData.AutoGenerateColumns = false;
                producto = (PRODUCTO)r.Data;
                ArrayList listCodigos = new ArrayList();
                Boolean existe = false;
             
                    //Consultar promocion
                             
                    int? condicion = producto.condicion;                   
                    int?  descuento = producto.descuento;

                    //if (rPromocion.status)
                    //{
                    //    PROMOCION promocion = (PROMOCION)rPromocion.Data;
                    //    condicion = Convert.ToInt32(promocion.condicion);
                    //    descuento = promocion.descuento;
                    //}
                    //else
                    //{
                    //    condicion = 0;
                    //    descuento = 0;

                    //}

                    int rowIndex = -1;
                    if (dgvData.RowCount > 0)
                {
                    for (int row = 0; row < dgvData.Rows.Count; row++)
                    {
                        listCodigos.Add(dgvData.Rows[row].Cells["id"].Value.ToString());
                    }
                    for (int i = 0; i < listCodigos.Count; i++)
                    {
                        if (Convert.ToInt32(listCodigos[i]) == Convert.ToInt32(producto.id))
                        {

                            existe = true;
                            string repetido = Convert.ToString(listCodigos[i]);
                            
                            foreach (DataGridViewRow row in dgvData.Rows)
                            {
                                if (row.Cells[0].Value.ToString().Equals(repetido))
                                {
                                    rowIndex = row.Index;
                                      
                                    dgvData.Rows[rowIndex].Cells["cantidad"].Value = Convert.ToInt32(dgvData.Rows[rowIndex].Cells["cantidad"].Value) + numericCantidad.Value;
                                        if (Convert.ToInt32(dgvData.Rows[rowIndex].Cells["cantidad"].Value) >=condicion)
                                        {

                                            dgvData.Rows[rowIndex].Cells["subtotal"].Value = ajusteSencillo(calcularDescuento(Convert.ToInt32(dgvData.Rows[rowIndex].Cells["cantidad"].Value), Convert.ToInt32(condicion), Convert.ToInt32(descuento),
                                                Convert.ToInt32(dgvData.Rows[rowIndex].Cells["subtotal"].Value), Convert.ToInt32(producto.precio), Convert.ToInt32(numericCantidad.Value)));
                                            
                                        }
                                        else
                                        {
                                            dgvData.Rows[rowIndex].Cells["subtotal"].Value = ajusteSencillo(Convert.ToInt32(dgvData.Rows[rowIndex].Cells["subtotal"].Value) + (Convert.ToInt32(producto.precio)
                                                                                             * Convert.ToInt32(numericCantidad.Value)));                              
                                        }                    
                                        break;
                                }
                            }
                        }
                    }
                    if (existe != true)
                    {
                          if(numericCantidad.Value >=condicion)
                            {
                                int subtotal = Convert.ToInt32(producto.precio * numericCantidad.Value);
                                int descuentoAlSubTotal = Convert.ToInt32(subtotal * descuento) / 100;
                                int subtotalConDescuento = subtotal - descuentoAlSubTotal;
                                dgvData.Rows.Add(producto.id, producto.codigobarra, producto.descripcion, producto.stock, producto.precio, numericCantidad.Value, ajusteSencillo(subtotalConDescuento));


                            }
                            else
                            {
                              
                                dgvData.Rows.Add(producto.id, producto.codigobarra, producto.descripcion, producto.stock, producto.precio, numericCantidad.Value, ajusteSencillo((Convert.ToInt32(producto.precio) * Convert.ToInt32(numericCantidad.Value))));
                            }                         
                        //Utils.reproducirBeep();
                    }
                }
                else
                {
                        if (numericCantidad.Value >= condicion)
                        {
                            int subtotal = Convert.ToInt32(producto.precio * numericCantidad.Value);
                            int descuentoAlSubTotal = Convert.ToInt32(subtotal * descuento) / 100;
                            int subtotalConDescuento = subtotal - descuentoAlSubTotal;
                            dgvData.Rows.Add(producto.id, producto.codigobarra, producto.descripcion, producto.stock, producto.precio, numericCantidad.Value, ajusteSencillo(subtotalConDescuento));
                            seleccionarMetodoPago();
                        }
                        else 
                        {
                            
                            dgvData.Rows.Add(producto.id, producto.codigobarra, producto.descripcion, producto.stock, producto.precio, numericCantidad.Value, ajusteSencillo((Convert.ToInt32(producto.precio) * Convert.ToInt32(numericCantidad.Value))));
                        }
                        
                    //Utils.reproducirBeep();
                }
                    dgvData.Rows[0].Selected = false;

                }
            else
            {
                Default alerta = new Default("Codigo de barra no encontrado");
                alerta.ShowDialog();
            }
            reset();
            }
            else
            {
                Default alerta = new Default("Debe abrir una caja para poder hacer ventas");
                alerta.ShowDialog();
            }
            

        }


        void seleccionarMetodoPago()
        {
            MessageBox.Show("Seleccione el metodo de pago");
            wndMetodoDePago wnd = new wndMetodoDePago();
            wnd.ShowDialog();

            switch (wnd.metodoDePago)
            {
                case 1:
                    lblMetodoDePago.Text = "Efectivo";
                    btnEfectivo.Visible = true;
                    lblEfectivo.Visible = true;
                    metodoDePago = wnd.metodoDePago;
                    lblMetodoDePago.Refresh();
                    break;
                case 2:
                    lblMetodoDePago.Text = "Tarjeta Debito";
                    btnDebito.Visible = true;
                    lblDebito.Visible = true;
                    metodoDePago = wnd.metodoDePago;
                    lblMetodoDePago.Refresh();
                    break;
                case 3:
                    lblMetodoDePago.Text = "Tarjeta Credito";
                    lblCredito.Visible = true;
                    metodoDePago = wnd.metodoDePago;
                    btnCredito.Visible = true;
                    lblMetodoDePago.Refresh();
                    break;

            }
        }

        void resetMetodoPago()
        {
            btnEfectivo.Visible = false;
            lblEfectivo.Visible = false;
            btnDebito.Visible = false;
            lblDebito.Visible = false;
            lblCredito.Visible = false;
            btnCredito.Visible = false;
            lblMetodoDePago.Text = "--Ninguno--";

        }
        void reset()
        {
            numericCantidad.Value = 1;
            txtCodigoBarra.Text = "";
            

        }
     
        public void actualizarCabeceraVenta()
        {
            respuesta rVenta;
            ventaController vc = new ventaController();
            rVenta = vc.TRAER_MAX_ID_VENTA();

            if (rVenta.status)
            {
                ventaModel idMaxDeVenta = (ventaModel)rVenta.Data;
                lblVentaActual.Text = Convert.ToString(idMaxDeVenta.maxVenta);

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
            lblTime.Text = DateTime.Now.ToString();
        }



        void  ButtonsMetodoPago()
        {

        }
        private void wndVentas_Load(object sender, EventArgs e)
        {

            StartTimer();
            btnConfirmarVenta.Enabled = false;
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnDebito.Enabled = true;
            lblCajero.Text = sesion.nombreUsuario;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            actualizarCabeceraVenta();

            ///Preguntar si hay alguna caja activa para restaurarla
            ///

            verificarCaja();
        }

        public  void verificarCaja()
        {
            respuesta rExisteCajaActiva;
            respuesta rApertura;
            cajaController cc = new cajaController();
            aperturaModel am = new aperturaModel();
            rExisteCajaActiva = cc.traerCajaActiva();

            if (rExisteCajaActiva.status)
            {
                CAJA cajaActiva = (CAJA)rExisteCajaActiva.Data;

                rApertura = am.BUSCAR_POR_ID_Y_ESTADO(cajaActiva.id);

                if (rApertura.status)
                {
                    aperturaModel aperturaActiva = (aperturaModel)rApertura.Data;
                    lblId.Text = Convert.ToString(aperturaActiva.id);
                    _idCajaAsignada = Convert.ToString(aperturaActiva.id);
                    lblCajero.Text = Convert.ToString(aperturaActiva.nombre);
                    lblEstadoCaja.Text = "Caja Abierta";
                    lblEstadoCaja.ForeColor = Color.Green;
                    lblNombreCaja.Text = "1";
                }
            }
            else
            {
                lblEstadoCaja.Text = "Caja Cerrada";
                lblEstadoCaja.ForeColor = Color.Red;
                lblId.Text = "";
                lblNombreCaja.Text = "";
            }
        }





        public void cambiar()
        {
            lblMontoCancelado.Text = "1";
        }

      

    private void wndVentas_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


        private void button7_Click(object sender, EventArgs e)
        {
            wndAnularProducto wap = new wndAnularProducto();
            wap.ShowDialog();

            if (_codigoBarraAnular =="")
            {      
            }
            else
            {
                for (int row = 0; row < dgvData.Rows.Count; row++)
                {
                    int codigoRepetido;
                    foreach (DataGridViewRow rows in dgvData.Rows)
                    {
                        if (rows.Cells[1].Value.ToString().Equals(_codigoBarraAnular))
                        {
                            codigoRepetido = rows.Index;
                            int cantidad = Convert.ToInt32(dgvData.Rows[codigoRepetido].Cells["cantidad"].Value);                       
                            if (Convert.ToInt32(_cantidadAnular) >  cantidad)
                            {

                                int subtotalDelAnulado = Convert.ToInt32(dgvData.Rows[codigoRepetido].Cells["subtotal"].Value);
                                int totalActualizado = ajusteSencillo(Convert.ToInt32(lblTotal.Text.Replace(".", "")) - subtotalDelAnulado);
                                lblTotal.Text = totalActualizado.ToString("#,##0").Replace(",", ".");
                                dgvData.Rows.RemoveAt(codigoRepetido);                      
                            }
                            else
                            {
                                dgvData.Rows[codigoRepetido].Cells["cantidad"].Value = cantidad - Convert.ToInt32(_cantidadAnular);
                                dgvData.Rows[codigoRepetido].Cells["subtotal"].Value = ajusteSencillo(Convert.ToInt32(dgvData.Rows[codigoRepetido].Cells["precio"].Value) * Convert.ToInt32(dgvData.Rows[codigoRepetido].Cells["cantidad"].Value));
                            }
                            if(Convert.ToInt32(_cantidadAnular) == cantidad)
                            {
                                dgvData.Rows.RemoveAt(codigoRepetido);
                            }
                            break;
                            //Hasta aqui estoy captando el dato codigo de barra que voy a eliminar 
                        }              
                    }             
                    _cantidadAnular = null;
                    _codigoBarraAnular = null;
                }      
            }
            txtCodigoBarra.Focus();
        }
        public static void anularProducto(string _codigo,string _cantidad) {

            _codigoBarraAnular = _codigo;
            _cantidadAnular = _cantidad;
           
        }

        void calcularTotal()
        {
            int suma = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                suma += (int)row.Cells["subtotal"].Value;
            }
            lblTotal.Text = Convert.ToString(suma.ToString("#,##0").Replace(",", "."));

        }

        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calcularTotal();
           
        }
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calcularTotal();

            if (dgvData.Rows.Count > 0)
            {
                resetMetodoPago();
            }
        }
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           

          int resultado = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["precio"].Value) * Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["cantidad"].Value);
          dgvData.Rows[e.RowIndex].Cells["subtotal"].Value = resultado;



        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCodigoBarra_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                traerXCodigoDeBarra();
            }
        }
        
      
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            
            
            wndMontoEfectivo wnde = new wndMontoEfectivo();
            wnde.ShowDialog();

            if (_efectivoCancelado == null)
            {
                _efectivoCancelado = wnde.efectivoCancelado;
                lblMontoCancelado.Text = Convert.ToInt32(wnde.efectivoCancelado).ToString("#,##0").Replace(",", ".");
                _efectivoCancelado = null;
            }
            txtCodigoBarra.Focus();
            
            //else
            //{
            //    int totalMontoCancelado = Convert.ToInt32(lblMontoCancelado.Text) + Convert.ToInt32(wnde.efectivoCancelado);
            //    lblMontoCancelado.Text = Convert.ToString(totalMontoCancelado);
            //}

        }

        private void wndVentas_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString("Bienvenido " + sesion.nombreUsuario));
   
        }

     

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            
        }

        private void lblMontoCancelado_TextChanged(object sender, EventArgs e)
        {

            ///AQUI HAY UN ERROR
            
            if (Convert.ToInt32(lblMontoCancelado.Text.Replace(".", "")) > Convert.ToInt32(lblTotal.Text.Replace(".", "")))
            {
                int vuelto = Convert.ToInt32(lblMontoCancelado.Text.Replace(".", "")) - Convert.ToInt32(lblTotal.Text.Replace(".", ""));
                lblVuelto.Text = vuelto.ToString("#,##0").Replace(",", ".");
            }
            else
            {
                lblVuelto.Text = "0";
              
            }
            if (Convert.ToInt32(lblMontoCancelado.Text.Replace(".", "")) >= Convert.ToInt32(lblTotal.Text.Replace(".", "")))
            {
               
                btnConfirmarVenta.Enabled = true;
            }
            else
            {
                btnConfirmarVenta.Enabled = false;
            }
            
        }

        private void lblVuelto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
             

            if (Convert.ToInt32(lblTotal.Text.Replace(".", "")) > 0)
            {
                btnEfectivo.Enabled = true;
            }
            else
            {
                btnEfectivo.Enabled = false;
            }
            if (Convert.ToInt32(lblTotal.Text.Replace(".", "")) > Convert.ToInt32(lblMontoCancelado.Text.Replace(".", "")))
            {
                lblVuelto.Text = "0";
            }
            else
            {
                lblVuelto.Text = Convert.ToString(Convert.ToInt32(lblMontoCancelado.Text.Replace(".", "")) - Convert.ToInt32(lblTotal.Text.Replace(".", "")));
            }
            if (Convert.ToInt32(lblMontoCancelado.Text.Replace(".", "")) >= Convert.ToInt32(lblTotal.Text.Replace(".", "")))
            {
                btnConfirmarVenta.Enabled = true;
            }
            else
            {
                btnConfirmarVenta.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "0";
            lblMontoCancelado.Text = "0";
            lblVuelto.Text = "0";
            dgvData.Rows.Clear();
            resetMetodoPago();
        }

        private void numericCantidad_Enter(object sender, EventArgs e)
        {
            ActiveControl = txtCodigoBarra;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            

            ///FALTA MANDAR EL METODO DE PAGO OBLIGATORIO
            if(dgvData.Rows.Count >0)
            {
            wndConfirmarVenta wConfirmarVenta = new wndConfirmarVenta();
            wConfirmarVenta.ShowDialog();
            if (wConfirmarVenta.confirmo)
            {
            respuesta rDetalleVenta;
            respuesta rVenta;
            ventaController vc = new ventaController();
            Boolean ventaStatus = false;
            detalleVentaController dvc = new detalleVentaController();
            rVenta = vc.agregar(DateTime.Now,Convert.ToInt32(lblId.Text),0,0,Convert.ToInt32(lblTotal.Text.Replace(".", "")),metodoDePago);
            if (rVenta.status)
            {
                VENTA ventaHecha = (VENTA)rVenta.Data;
                int i = 0;
                foreach (DataGridViewRow rows in dgvData.Rows)
                {
                  long idProducto =  Convert.ToInt64(dgvData.Rows[i].Cells["id"].Value);
                  int cantidad = Convert.ToInt32(dgvData.Rows[i].Cells["cantidad"].Value);
                  int subtotal = Convert.ToInt32(dgvData.Rows[i].Cells["subtotal"].Value);
                  rDetalleVenta = dvc.Agregar(idProducto,cantidad,subtotal,Convert.ToInt64(ventaHecha.id));
                        if (rDetalleVenta.status)
                        {

                            productoController pc = new productoController();
                            pc.updateStock(Convert.ToInt32(idProducto),cantidad);


                            ventaStatus = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error");
                        }
                        i++;
                    }
                    if (ventaStatus)
                    {
                        dgvData.Rows.Clear();
                        dgvData.Refresh();
                        Success success = new Success("La venta se realizo correctamente");
                        success.ShowDialog();
                    }
                    actualizarCabeceraVenta();
                    //Capturar excepcion de el detalleVenta -- RESPUESTA
            }
                wConfirmarVenta.confirmo = false;
            }
            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wndAbrirCaja wndAbrirCaja = new wndAbrirCaja();
            if (lblId.Text == "")
            {
                wndAbrirCaja.ShowDialog();
                if (wndAbrirCaja.abrio)
                {
                    Success success = new Success("La caja ha sido Abierta con exito");
                    success.ShowDialog();
                    lblId.Text = wndAbrirCaja.idCajaAbierta;
                    lblEstadoCaja.Text = "Caja Abierta";
                    lblEstadoCaja.ForeColor = Color.Green;
                    lblNombreCaja.Text = "1";
                    //verificarCaja();

                }

            }
            else
            {
                Default def = new Default("La caja ya se encuentra abierta");
                def.ShowDialog();
            }

        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wndCierreDeCaja cdc = new wndCierreDeCaja(lblId.Text);
            if(lblId.Text != "")
            {
                cdc.ShowDialog();
                if (cdc.cerro)
                {
                    Success success = new Success("La caja ha sido cerrada con exito");
                    success.ShowDialog();
                    verificarCaja();
                }
               
            }
            else
            {
                Default def = new Default("No hay una caja abierta");
                def.ShowDialog();
            }
           
        }

        private void mantenedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wndProducto wProducto = new wndProducto();
            wProducto.ShowDialog();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wndPromociones wpromo = new wndPromociones();
            wpromo.ShowDialog();
        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {


            wndOperaciones wOperaciones = new wndOperaciones(lblId.Text);
            if (lblId.Text != "")
            {
                wOperaciones.ShowDialog();
                if (wOperaciones.movimiento)
                {
                    Success success = new Success("Movimiento realizado con exito");
                    success.ShowDialog();
                    verificarCaja();
                }

            }
            else
            {
                Default def = new Default("No hay una caja abierta");
                def.ShowDialog();
            }
            
            
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
