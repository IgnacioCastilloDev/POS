namespace POS.Ventas.Vista
{
    partial class wndConfirmarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wndConfirmarVenta));
            this.lblContenido = new System.Windows.Forms.Label();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblContenido
            // 
            this.lblContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenido.Location = new System.Drawing.Point(80, 27);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(375, 115);
            this.lblContenido.TabIndex = 1;
            this.lblContenido.Text = "Esta a punto de cerrar la venta, Desea continuar?";
            this.lblContenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSi
            // 
            this.btnSi.Image = ((System.Drawing.Image)(resources.GetObject("btnSi.Image")));
            this.btnSi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSi.Location = new System.Drawing.Point(135, 166);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(93, 75);
            this.btnSi.TabIndex = 24;
            this.btnSi.UseVisualStyleBackColor = true;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnNo
            // 
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNo.Location = new System.Drawing.Point(294, 166);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(93, 75);
            this.btnNo.TabIndex = 23;
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // wndConfirmarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(528, 281);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.lblContenido);
            this.Name = "wndConfirmarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirmar venta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnNo;
    }
}