namespace ProjecteFinal
{
    partial class frmFactures
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNFactura = new System.Windows.Forms.TextBox();
            this.txtNAlbara = new System.Windows.Forms.TextBox();
            this.txtDataFactura = new System.Windows.Forms.TextBox();
            this.txtDataAlbara = new System.Windows.Forms.TextBox();
            this.txtCodiClient = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.txtDireccio = new System.Windows.Forms.TextBox();
            this.txtPoblacio = new System.Windows.Forms.TextBox();
            this.dgvLiniesFactura = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEliminarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniesFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data albara";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Número albarà";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nom";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Codi client";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "NIF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Direcció";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Població";
            // 
            // txtNFactura
            // 
            this.txtNFactura.Location = new System.Drawing.Point(132, 58);
            this.txtNFactura.Name = "txtNFactura";
            this.txtNFactura.Size = new System.Drawing.Size(100, 20);
            this.txtNFactura.TabIndex = 9;
            // 
            // txtNAlbara
            // 
            this.txtNAlbara.Location = new System.Drawing.Point(132, 141);
            this.txtNAlbara.Name = "txtNAlbara";
            this.txtNAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtNAlbara.TabIndex = 10;
            // 
            // txtDataFactura
            // 
            this.txtDataFactura.Location = new System.Drawing.Point(132, 99);
            this.txtDataFactura.Name = "txtDataFactura";
            this.txtDataFactura.Size = new System.Drawing.Size(100, 20);
            this.txtDataFactura.TabIndex = 10;
            // 
            // txtDataAlbara
            // 
            this.txtDataAlbara.Location = new System.Drawing.Point(132, 183);
            this.txtDataAlbara.Name = "txtDataAlbara";
            this.txtDataAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtDataAlbara.TabIndex = 11;
            // 
            // txtCodiClient
            // 
            this.txtCodiClient.Location = new System.Drawing.Point(132, 225);
            this.txtCodiClient.Name = "txtCodiClient";
            this.txtCodiClient.Size = new System.Drawing.Size(100, 20);
            this.txtCodiClient.TabIndex = 12;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(132, 303);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 13;
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(132, 264);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(100, 20);
            this.txtNIF.TabIndex = 13;
            // 
            // txtDireccio
            // 
            this.txtDireccio.Location = new System.Drawing.Point(132, 340);
            this.txtDireccio.Name = "txtDireccio";
            this.txtDireccio.Size = new System.Drawing.Size(100, 20);
            this.txtDireccio.TabIndex = 14;
            // 
            // txtPoblacio
            // 
            this.txtPoblacio.Location = new System.Drawing.Point(132, 377);
            this.txtPoblacio.Name = "txtPoblacio";
            this.txtPoblacio.Size = new System.Drawing.Size(100, 20);
            this.txtPoblacio.TabIndex = 15;
            // 
            // dgvLiniesFactura
            // 
            this.dgvLiniesFactura.AllowUserToAddRows = false;
            this.dgvLiniesFactura.AllowUserToDeleteRows = false;
            this.dgvLiniesFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiniesFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvLiniesFactura.Location = new System.Drawing.Point(273, 106);
            this.dgvLiniesFactura.Name = "dgvLiniesFactura";
            this.dgvLiniesFactura.ReadOnly = true;
            this.dgvLiniesFactura.Size = new System.Drawing.Size(543, 178);
            this.dgvLiniesFactura.TabIndex = 16;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Codi article";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripció";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quantitat venuda";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Preu venda";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Descompte";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // txtEliminarFactura
            // 
            this.txtEliminarFactura.Location = new System.Drawing.Point(405, 329);
            this.txtEliminarFactura.Name = "txtEliminarFactura";
            this.txtEliminarFactura.Size = new System.Drawing.Size(116, 41);
            this.txtEliminarFactura.TabIndex = 17;
            this.txtEliminarFactura.Text = "Eliminar Factura";
            this.txtEliminarFactura.UseVisualStyleBackColor = true;
            this.txtEliminarFactura.Click += new System.EventHandler(this.txtEliminarFactura_Click);
            // 
            // frmFactures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 457);
            this.Controls.Add(this.txtEliminarFactura);
            this.Controls.Add(this.dgvLiniesFactura);
            this.Controls.Add(this.txtPoblacio);
            this.Controls.Add(this.txtDireccio);
            this.Controls.Add(this.txtNIF);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtCodiClient);
            this.Controls.Add(this.txtDataAlbara);
            this.Controls.Add(this.txtDataFactura);
            this.Controls.Add(this.txtNAlbara);
            this.Controls.Add(this.txtNFactura);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFactures";
            this.Text = "frmFactures";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFactures_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtNFactura, 0);
            this.Controls.SetChildIndex(this.txtNAlbara, 0);
            this.Controls.SetChildIndex(this.txtDataFactura, 0);
            this.Controls.SetChildIndex(this.txtDataAlbara, 0);
            this.Controls.SetChildIndex(this.txtCodiClient, 0);
            this.Controls.SetChildIndex(this.txtNom, 0);
            this.Controls.SetChildIndex(this.txtNIF, 0);
            this.Controls.SetChildIndex(this.txtDireccio, 0);
            this.Controls.SetChildIndex(this.txtPoblacio, 0);
            this.Controls.SetChildIndex(this.dgvLiniesFactura, 0);
            this.Controls.SetChildIndex(this.txtEliminarFactura, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniesFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNFactura;
        private System.Windows.Forms.TextBox txtNAlbara;
        private System.Windows.Forms.TextBox txtDataFactura;
        private System.Windows.Forms.TextBox txtDataAlbara;
        private System.Windows.Forms.TextBox txtCodiClient;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.TextBox txtDireccio;
        private System.Windows.Forms.TextBox txtPoblacio;
        private System.Windows.Forms.DataGridView dgvLiniesFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button txtEliminarFactura;
    }
}