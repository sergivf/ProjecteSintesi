namespace ProjecteFinal
{
    partial class frmAlbarans
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
            this.lblNAlbara = new System.Windows.Forms.Label();
            this.lblDataAlbara = new System.Windows.Forms.Label();
            this.lblCodiClient = new System.Windows.Forms.Label();
            this.lblNIF = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNAlbara = new System.Windows.Forms.TextBox();
            this.txtDataAlbara = new System.Windows.Forms.TextBox();
            this.txtCodiClient = new System.Windows.Forms.TextBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.dgvLiniaAlbara = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPoblacio = new System.Windows.Forms.Label();
            this.Direccio = new System.Windows.Forms.Label();
            this.txtPoblacio = new System.Windows.Forms.TextBox();
            this.txtDireccio = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFacturarAlbara = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOrdenacio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniaAlbara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNAlbara
            // 
            this.lblNAlbara.AutoSize = true;
            this.lblNAlbara.Location = new System.Drawing.Point(23, 108);
            this.lblNAlbara.Name = "lblNAlbara";
            this.lblNAlbara.Size = new System.Drawing.Size(77, 13);
            this.lblNAlbara.TabIndex = 1;
            this.lblNAlbara.Text = "Número Albarà";
            this.lblNAlbara.Click += new System.EventHandler(this.lblNAlbara_Click);
            // 
            // lblDataAlbara
            // 
            this.lblDataAlbara.AutoSize = true;
            this.lblDataAlbara.Location = new System.Drawing.Point(23, 148);
            this.lblDataAlbara.Name = "lblDataAlbara";
            this.lblDataAlbara.Size = new System.Drawing.Size(63, 13);
            this.lblDataAlbara.TabIndex = 2;
            this.lblDataAlbara.Text = "Data Albarà";
            this.lblDataAlbara.Click += new System.EventHandler(this.lblDataAlbara_Click);
            // 
            // lblCodiClient
            // 
            this.lblCodiClient.AutoSize = true;
            this.lblCodiClient.Location = new System.Drawing.Point(23, 188);
            this.lblCodiClient.Name = "lblCodiClient";
            this.lblCodiClient.Size = new System.Drawing.Size(57, 13);
            this.lblCodiClient.TabIndex = 3;
            this.lblCodiClient.Text = "Codi Client";
            this.lblCodiClient.Click += new System.EventHandler(this.lblCodiClient_Click);
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.Location = new System.Drawing.Point(23, 229);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(24, 13);
            this.lblNIF.TabIndex = 4;
            this.lblNIF.Text = "NIF";
            this.lblNIF.Click += new System.EventHandler(this.lblNIF_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(23, 270);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 5;
            this.lblNom.Text = "Nom";
            this.lblNom.Click += new System.EventHandler(this.lblNom_Click);
            // 
            // txtNAlbara
            // 
            this.txtNAlbara.Location = new System.Drawing.Point(142, 101);
            this.txtNAlbara.Name = "txtNAlbara";
            this.txtNAlbara.ReadOnly = true;
            this.txtNAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtNAlbara.TabIndex = 6;
            // 
            // txtDataAlbara
            // 
            this.txtDataAlbara.Location = new System.Drawing.Point(142, 141);
            this.txtDataAlbara.Name = "txtDataAlbara";
            this.txtDataAlbara.ReadOnly = true;
            this.txtDataAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtDataAlbara.TabIndex = 7;
            // 
            // txtCodiClient
            // 
            this.txtCodiClient.Location = new System.Drawing.Point(142, 181);
            this.txtCodiClient.Name = "txtCodiClient";
            this.txtCodiClient.ReadOnly = true;
            this.txtCodiClient.Size = new System.Drawing.Size(100, 20);
            this.txtCodiClient.TabIndex = 8;
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(142, 222);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.ReadOnly = true;
            this.txtNIF.Size = new System.Drawing.Size(100, 20);
            this.txtNIF.TabIndex = 9;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(142, 263);
            this.txtNom.Name = "txtNom";
            this.txtNom.ReadOnly = true;
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 10;
            // 
            // dgvLiniaAlbara
            // 
            this.dgvLiniaAlbara.AllowUserToAddRows = false;
            this.dgvLiniaAlbara.AllowUserToDeleteRows = false;
            this.dgvLiniaAlbara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiniaAlbara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvLiniaAlbara.Location = new System.Drawing.Point(402, 34);
            this.dgvLiniaAlbara.Name = "dgvLiniaAlbara";
            this.dgvLiniaAlbara.ReadOnly = true;
            this.dgvLiniaAlbara.Size = new System.Drawing.Size(448, 127);
            this.dgvLiniaAlbara.TabIndex = 11;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Codi article";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Descripció";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantitat venuda";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Preu venda";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // lblPoblacio
            // 
            this.lblPoblacio.AutoSize = true;
            this.lblPoblacio.Location = new System.Drawing.Point(23, 346);
            this.lblPoblacio.Name = "lblPoblacio";
            this.lblPoblacio.Size = new System.Drawing.Size(48, 13);
            this.lblPoblacio.TabIndex = 12;
            this.lblPoblacio.Text = "Població";
            this.lblPoblacio.Click += new System.EventHandler(this.lblPoblacio_Click);
            // 
            // Direccio
            // 
            this.Direccio.AutoSize = true;
            this.Direccio.Location = new System.Drawing.Point(23, 309);
            this.Direccio.Name = "Direccio";
            this.Direccio.Size = new System.Drawing.Size(46, 13);
            this.Direccio.TabIndex = 13;
            this.Direccio.Text = "Direcció";
            this.Direccio.Click += new System.EventHandler(this.Direccio_Click);
            // 
            // txtPoblacio
            // 
            this.txtPoblacio.Location = new System.Drawing.Point(142, 339);
            this.txtPoblacio.Name = "txtPoblacio";
            this.txtPoblacio.ReadOnly = true;
            this.txtPoblacio.Size = new System.Drawing.Size(100, 20);
            this.txtPoblacio.TabIndex = 14;
            // 
            // txtDireccio
            // 
            this.txtDireccio.Location = new System.Drawing.Point(142, 302);
            this.txtDireccio.Name = "txtDireccio";
            this.txtDireccio.ReadOnly = true;
            this.txtDireccio.Size = new System.Drawing.Size(100, 20);
            this.txtDireccio.TabIndex = 15;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgv.Location = new System.Drawing.Point(402, 167);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(448, 135);
            this.dgv.TabIndex = 16;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Total brut";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Total net";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Total IVA";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Total albarà";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // btnFacturarAlbara
            // 
            this.btnFacturarAlbara.Location = new System.Drawing.Point(511, 339);
            this.btnFacturarAlbara.Name = "btnFacturarAlbara";
            this.btnFacturarAlbara.Size = new System.Drawing.Size(117, 39);
            this.btnFacturarAlbara.TabIndex = 17;
            this.btnFacturarAlbara.Text = "Facturar l\'albarà";
            this.btnFacturarAlbara.UseVisualStyleBackColor = true;
            this.btnFacturarAlbara.Click += new System.EventHandler(this.btnFacturarAlbara_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 18);
            this.label9.TabIndex = 30;
            this.label9.Text = "Ordenat: ";
            // 
            // lblOrdenacio
            // 
            this.lblOrdenacio.AutoSize = true;
            this.lblOrdenacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenacio.Location = new System.Drawing.Point(130, 34);
            this.lblOrdenacio.Name = "lblOrdenacio";
            this.lblOrdenacio.Size = new System.Drawing.Size(203, 18);
            this.lblOrdenacio.TabIndex = 31;
            this.lblOrdenacio.Text = "NÚMERO D\'ALBARÀ ASC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 18);
            this.label8.TabIndex = 32;
            this.label8.Text = "Premer els Labels per ordenar";
            // 
            // frmAlbarans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 413);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOrdenacio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnFacturarAlbara);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtDireccio);
            this.Controls.Add(this.txtPoblacio);
            this.Controls.Add(this.Direccio);
            this.Controls.Add(this.lblPoblacio);
            this.Controls.Add(this.dgvLiniaAlbara);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtNIF);
            this.Controls.Add(this.txtCodiClient);
            this.Controls.Add(this.txtDataAlbara);
            this.Controls.Add(this.txtNAlbara);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblNIF);
            this.Controls.Add(this.lblCodiClient);
            this.Controls.Add(this.lblDataAlbara);
            this.Controls.Add(this.lblNAlbara);
            this.Name = "frmAlbarans";
            this.Text = "frmAlbarans";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAlbarans_FormClosing);
            this.Controls.SetChildIndex(this.lblNAlbara, 0);
            this.Controls.SetChildIndex(this.lblDataAlbara, 0);
            this.Controls.SetChildIndex(this.lblCodiClient, 0);
            this.Controls.SetChildIndex(this.lblNIF, 0);
            this.Controls.SetChildIndex(this.lblNom, 0);
            this.Controls.SetChildIndex(this.txtNAlbara, 0);
            this.Controls.SetChildIndex(this.txtDataAlbara, 0);
            this.Controls.SetChildIndex(this.txtCodiClient, 0);
            this.Controls.SetChildIndex(this.txtNIF, 0);
            this.Controls.SetChildIndex(this.txtNom, 0);
            this.Controls.SetChildIndex(this.dgvLiniaAlbara, 0);
            this.Controls.SetChildIndex(this.lblPoblacio, 0);
            this.Controls.SetChildIndex(this.Direccio, 0);
            this.Controls.SetChildIndex(this.txtPoblacio, 0);
            this.Controls.SetChildIndex(this.txtDireccio, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.btnFacturarAlbara, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblOrdenacio, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniaAlbara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNAlbara;
        private System.Windows.Forms.Label lblDataAlbara;
        private System.Windows.Forms.Label lblCodiClient;
        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNAlbara;
        private System.Windows.Forms.TextBox txtDataAlbara;
        private System.Windows.Forms.TextBox txtCodiClient;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DataGridView dgvLiniaAlbara;
        private System.Windows.Forms.Label lblPoblacio;
        private System.Windows.Forms.Label Direccio;
        private System.Windows.Forms.TextBox txtPoblacio;
        private System.Windows.Forms.TextBox txtDireccio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnFacturarAlbara;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOrdenacio;
        private System.Windows.Forms.Label label8;
    }
}