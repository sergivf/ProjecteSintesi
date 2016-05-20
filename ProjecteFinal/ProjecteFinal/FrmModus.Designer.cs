namespace ProjecteFinal
{
    partial class FrmModus
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnAutomatica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quin tipus de facturació vols fer?";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(184, 92);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancel·lar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(22, 92);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAutomatica
            // 
            this.btnAutomatica.Location = new System.Drawing.Point(103, 92);
            this.btnAutomatica.Name = "btnAutomatica";
            this.btnAutomatica.Size = new System.Drawing.Size(75, 23);
            this.btnAutomatica.TabIndex = 2;
            this.btnAutomatica.Text = "Automàtica";
            this.btnAutomatica.UseVisualStyleBackColor = true;
            this.btnAutomatica.Click += new System.EventHandler(this.btnAutomatica_Click);
            // 
            // FrmModus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 150);
            this.Controls.Add(this.btnAutomatica);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Name = "FrmModus";
            this.Text = "FrmModus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnAutomatica;
    }
}