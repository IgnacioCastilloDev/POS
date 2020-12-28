﻿using POS.Entidades;
using POS.Entidades.Controlador;
using POS.Reportes.Modelo;
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
        public int tMetodoPago;
        public wndReportes()
        {
            InitializeComponent();
        }

        void combo()
        {
            respuesta r;
            movimientoController mc = new movimientoController();
            r = mc.listarMovimientoXNombre();
            cbTipoMovimiento.DataSource = r.Data;
            cbTipoMovimiento.DisplayMember = "nombre";
            cbTipoMovimiento.ValueMember = "id";

        }
        private void wndReportes_Load(object sender, EventArgs e)
        {
            refrescarComboMetodoPago();
            combo();


        }

        public void  checkRadioButton()
        {
            if (rbCredito.Checked == true)
            {
                tMetodoPago = 3;
            }
            if (rbDebito.Checked == true)
            {
                tMetodoPago = 2;
            }
            if (rbEfectivo.Checked == true)
            {
                tMetodoPago = 1;
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
            respuesta rTotalVenta;
            ventaController vc = new ventaController();

           


            rVenta = vc.traerVentasXperiodo(dtpDesde.Value,dtpHasta.Value,Convert.ToInt32(cbTipoDocumento.SelectedValue),tMetodoPago);
            if (rVenta.status)
            {
                if (((List<ventasXperiodo>)rVenta.Data).Count == 0 )
                {
                    MessageBox.Show("No se encontraron registros");
                    txtTotalRecaudado.Text = "";
                    dgvData.DataSource = null;

                }
                else
                {
                    rTotalVenta = vc.traerTotalXperiodo(dtpDesde.Value, dtpHasta.Value, Convert.ToInt32(cbTipoDocumento.SelectedValue), tMetodoPago);
                    if (rTotalVenta.status)
                    {
                        ventasXperiodo totalVenta;

                        totalVenta = (ventasXperiodo)rTotalVenta.Data;
                        txtTotalRecaudado.Text = Convert.ToString(totalVenta.totalEntrePeriodo);
                    }
                    dgvData.AutoGenerateColumns = false;
                    dgvData.DataSource = rVenta.Data;
                   
                }

            }
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
          
;        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {


            respuesta rMovimientos;
            detalleMovimiento dm = new detalleMovimiento();
            rMovimientos = dm.traerMovimientosDiarios(dtpDesde.Value, dtpHasta.Value, Convert.ToInt32(cbTipoMovimiento.SelectedValue));
            if (rMovimientos.status)
            {
                dgvDataMovimientos.AutoGenerateColumns = false;
                dgvDataMovimientos.DataSource = rMovimientos.Data;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
