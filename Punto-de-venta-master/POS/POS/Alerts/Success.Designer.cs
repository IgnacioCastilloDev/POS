﻿namespace POS.Alerts
{
    partial class Success
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Success));
            this.lblImage = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblImage
            // 
            this.lblImage.Image = ((System.Drawing.Image)(resources.GetObject("lblImage.Image")));
            this.lblImage.Location = new System.Drawing.Point(29, 25);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(148, 163);
            this.lblImage.TabIndex = 2;
            // 
            // lblContenido
            // 
            this.lblContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenido.Location = new System.Drawing.Point(183, 25);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(375, 115);
            this.lblContenido.TabIndex = 3;
            this.lblContenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(347, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(116, 33);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Success
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 212);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblContenido);
            this.Controls.Add(this.lblImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Success";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Success";
            this.Load += new System.EventHandler(this.Success_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Button btnOk;
    }
}