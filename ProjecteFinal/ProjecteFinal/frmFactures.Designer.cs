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
            this.lblNFactura = new System.Windows.Forms.Label();
            this.lblDataAlbara = new System.Windows.Forms.Label();
            this.lblNAlbara = new System.Windows.Forms.Label();
            this.lblDataFactura = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblCodiClient = new System.Windows.Forms.Label();
            this.lblNIF = new System.Windows.Forms.Label();
            this.lblDireccio = new System.Windows.Forms.Label();
            this.lblPoblacio = new System.Windows.Forms.Label();
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
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.lblOrdenat = new System.Windows.Forms.Label();
            this.lblOrdenacio = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniesFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNFactura
            // 
            this.lblNFactura.AutoSize = true;
            this.lblNFactura.Location = new System.Drawing.Point(27, 106);
            this.lblNFactura.Name = "lblNFactura";
            this.lblNFactura.Size = new System.Drawing.Size(80, 13);
            this.lblNFactura.TabIndex = 1;
            this.lblNFactura.Text = "Número factura";
            this.lblNFactura.Click += new System.EventHandler(this.lblNFactura_Click);
            // 
            // lblDataAlbara
            // 
            this.lblDataAlbara.AutoSize = true;
            this.lblDataAlbara.Location = new System.Drawing.Point(27, 231);
            this.lblDataAlbara.Name = "lblDataAlbara";
            this.lblDataAlbara.Size = new System.Drawing.Size(62, 13);
            this.lblDataAlbara.TabIndex = 2;
            this.lblDataAlbara.Text = "Data albara";
            this.lblDataAlbara.Click += new System.EventHandler(this.lblDataAlbara_Click);
            // 
            // lblNAlbara
            // 
            this.lblNAlbara.AutoSize = true;
            this.lblNAlbara.Location = new System.Drawing.Point(27, 191);
            this.lblNAlbara.Name = "lblNAlbara";
            this.lblNAlbara.Size = new System.Drawing.Size(76, 13);
            this.lblNAlbara.TabIndex = 3;
            this.lblNAlbara.Text = "Número albarà";
            this.lblNAlbara.Click += new System.EventHandler(this.lblNAlbara_Click);
            // 
            // lblDataFactura
            // 
            this.lblDataFactura.AutoSize = true;
            this.lblDataFactura.Location = new System.Drawing.Point(27, 147);
            this.lblDataFactura.Name = "lblDataFactura";
            this.lblDataFactura.Size = new System.Drawing.Size(66, 13);
            this.lblDataFactura.TabIndex = 4;
            this.lblDataFactura.Text = "Data factura";
            this.lblDataFactura.Click += new System.EventHandler(this.lblDataFactura_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(27, 351);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 5;
            this.lblNom.Text = "Nom";
            this.lblNom.Click += new System.EventHandler(this.lblNom_Click);
            // 
            // lblCodiClient
            // 
            this.lblCodiClient.AutoSize = true;
            this.lblCodiClient.Location = new System.Drawing.Point(27, 273);
            this.lblCodiClient.Name = "lblCodiClient";
            this.lblCodiClient.Size = new System.Drawing.Size(56, 13);
            this.lblCodiClient.TabIndex = 5;
            this.lblCodiClient.Text = "Codi client";
            this.lblCodiClient.Click += new System.EventHandler(this.lblCodiClient_Click);
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.Location = new System.Drawing.Point(27, 312);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(24, 13);
            this.lblNIF.TabIndex = 6;
            this.lblNIF.Text = "NIF";
            this.lblNIF.Click += new System.EventHandler(this.lblNIF_Click);
            // 
            // lblDireccio
            // 
            this.lblDireccio.AutoSize = true;
            this.lblDireccio.Location = new System.Drawing.Point(27, 388);
            this.lblDireccio.Name = "lblDireccio";
            this.lblDireccio.Size = new System.Drawing.Size(46, 13);
            this.lblDireccio.TabIndex = 7;
            this.lblDireccio.Text = "Direcció";
            this.lblDireccio.Click += new System.EventHandler(this.lblDireccio_Click);
            // 
            // lblPoblacio
            // 
            this.lblPoblacio.AutoSize = true;
            this.lblPoblacio.Location = new System.Drawing.Point(27, 421);
            this.lblPoblacio.Name = "lblPoblacio";
            this.lblPoblacio.Size = new System.Drawing.Size(48, 13);
            this.lblPoblacio.TabIndex = 8;
            this.lblPoblacio.Text = "Població";
            this.lblPoblacio.Click += new System.EventHandler(this.lblPoblacio_Click);
            // 
            // txtNFactura
            // 
            this.txtNFactura.Location = new System.Drawing.Point(132, 99);
            this.txtNFactura.Name = "txtNFactura";
            this.txtNFactura.ReadOnly = true;
            this.txtNFactura.Size = new System.Drawing.Size(100, 20);
            this.txtNFactura.TabIndex = 9;
            // 
            // txtNAlbara
            // 
            this.txtNAlbara.Location = new System.Drawing.Point(132, 184);
            this.txtNAlbara.Name = "txtNAlbara";
            this.txtNAlbara.ReadOnly = true;
            this.txtNAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtNAlbara.TabIndex = 10;
            // 
            // txtDataFactura
            // 
            this.txtDataFactura.Location = new System.Drawing.Point(132, 140);
            this.txtDataFactura.Name = "txtDataFactura";
            this.txtDataFactura.ReadOnly = true;
            this.txtDataFactura.Size = new System.Drawing.Size(100, 20);
            this.txtDataFactura.TabIndex = 10;
            // 
            // txtDataAlbara
            // 
            this.txtDataAlbara.Location = new System.Drawing.Point(132, 224);
            this.txtDataAlbara.Name = "txtDataAlbara";
            this.txtDataAlbara.ReadOnly = true;
            this.txtDataAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtDataAlbara.TabIndex = 11;
            // 
            // txtCodiClient
            // 
            this.txtCodiClient.Location = new System.Drawing.Point(132, 266);
            this.txtCodiClient.Name = "txtCodiClient";
            this.txtCodiClient.ReadOnly = true;
            this.txtCodiClient.Size = new System.Drawing.Size(100, 20);
            this.txtCodiClient.TabIndex = 12;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(132, 344);
            this.txtNom.Name = "txtNom";
            this.txtNom.ReadOnly = true;
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 13;
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(132, 305);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.ReadOnly = true;
            this.txtNIF.Size = new System.Drawing.Size(100, 20);
            this.txtNIF.TabIndex = 13;
            // 
            // txtDireccio
            // 
            this.txtDireccio.Location = new System.Drawing.Point(132, 381);
            this.txtDireccio.Name = "txtDireccio";
            this.txtDireccio.ReadOnly = true;
            this.txtDireccio.Size = new System.Drawing.Size(100, 20);
            this.txtDireccio.TabIndex = 14;
            // 
            // txtPoblacio
            // 
            this.txtPoblacio.Location = new System.Drawing.Point(132, 414);
            this.txtPoblacio.Name = "txtPoblacio";
            this.txtPoblacio.ReadOnly = true;
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
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.Location = new System.Drawing.Point(405, 329);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(116, 41);
            this.btnEliminarFactura.TabIndex = 17;
            this.btnEliminarFactura.Text = "Eliminar Factura";
            this.btnEliminarFactura.UseVisualStyleBackColor = true;
            this.btnEliminarFactura.Click += new System.EventHandler(this.btnEliminarFactura_Click);
            // 
            // lblOrdenat
            // 
            this.lblOrdenat.AutoSize = true;
            this.lblOrdenat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenat.Location = new System.Drawing.Point(15, 34);
            this.lblOrdenat.Name = "lblOrdenat";
            this.lblOrdenat.Size = new System.Drawing.Size(78, 18);
            this.lblOrdenat.TabIndex = 30;
            this.lblOrdenat.Text = "Ordenat: ";
            // 
            // lblOrdenacio
            // 
            this.lblOrdenacio.AutoSize = true;
            this.lblOrdenacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenacio.Location = new System.Drawing.Point(99, 34);
            this.lblOrdenacio.Name = "lblOrdenacio";
            this.lblOrdenacio.Size = new System.Drawing.Size(201, 18);
            this.lblOrdenacio.TabIndex = 31;
            this.lblOrdenacio.Text = "NÚMERO FACTURA ASC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 18);
            this.label10.TabIndex = 32;
            this.label10.Text = "Premer els Labels per ordenar";
            // 
            // frmFactures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 457);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblOrdenacio);
            this.Controls.Add(this.lblOrdenat);
            this.Controls.Add(this.btnEliminarFactura);
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
            this.Controls.Add(this.lblPoblacio);
            this.Controls.Add(this.lblDireccio);
            this.Controls.Add(this.lblNIF);
            this.Controls.Add(this.lblCodiClient);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblDataFactura);
            this.Controls.Add(this.lblNAlbara);
            this.Controls.Add(this.lblDataAlbara);
            this.Controls.Add(this.lblNFactura);
            this.Name = "frmFactures";
            this.Text = "frmFactures";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFactures_FormClosing);
            this.Controls.SetChildIndex(this.lblNFactura, 0);
            this.Controls.SetChildIndex(this.lblDataAlbara, 0);
            this.Controls.SetChildIndex(this.lblNAlbara, 0);
            this.Controls.SetChildIndex(this.lblDataFactura, 0);
            this.Controls.SetChildIndex(this.lblNom, 0);
            this.Controls.SetChildIndex(this.lblCodiClient, 0);
            this.Controls.SetChildIndex(this.lblNIF, 0);
            this.Controls.SetChildIndex(this.lblDireccio, 0);
            this.Controls.SetChildIndex(this.lblPoblacio, 0);
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
            this.Controls.SetChildIndex(this.btnEliminarFactura, 0);
            this.Controls.SetChildIndex(this.lblOrdenat, 0);
            this.Controls.SetChildIndex(this.lblOrdenacio, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniesFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.Label lblDireccio;
        private System.Windows.Forms.Label lblPoblacio;
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
        private System.Windows.Forms.Label lblCodiClient;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblDataFactura;
        private System.Windows.Forms.Label lblNAlbara;
        private System.Windows.Forms.Label lblDataAlbara;
        private System.Windows.Forms.Label lblNFactura;
        private System.Windows.Forms.Button btnEliminarFactura;
        private System.Windows.Forms.Label lblOrdenat;
        private System.Windows.Forms.Label lblOrdenacio;
        private System.Windows.Forms.Label label10;
    }
}