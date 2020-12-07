namespace POS.Alerts
{
    partial class Default
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default));
            this.lblContenido = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblContenido
            // 
            this.lblContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenido.Location = new System.Drawing.Point(183, 25);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(375, 115);
            this.lblContenido.TabIndex = 0;
            this.lblContenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContenido.Click += new System.EventHandler(this.lblContenido_Click);
            // 
            // lblImage
            // 
            this.lblImage.Image = ((System.Drawing.Image)(resources.GetObject("lblImage.Image")));
            this.lblImage.Location = new System.Drawing.Point(29, 25);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(148, 163);
            this.lblImage.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(347, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(116, 33);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 212);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Deactivate += new System.EventHandler(this.Default_Deactivate);
            this.Load += new System.EventHandler(this.Default_Load);
            this.Leave += new System.EventHandler(this.Default_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnOk;
    }
}