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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPoblacio = new System.Windows.Forms.TextBox();
            this.txtDireccio = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFacturarAlbara = new System.Windows.Forms.Button();
            this.btnCancelarCanvis = new System.Windows.Forms.Button();
            this.btnGuardarCanvis = new System.Windows.Forms.Button();
            this.btnModeEdicio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniaAlbara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número Albarà";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Albarà";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codi Client";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "NIF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nom";
            // 
            // txtNAlbara
            // 
            this.txtNAlbara.Location = new System.Drawing.Point(144, 39);
            this.txtNAlbara.Name = "txtNAlbara";
            this.txtNAlbara.ReadOnly = true;
            this.txtNAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtNAlbara.TabIndex = 6;
            // 
            // txtDataAlbara
            // 
            this.txtDataAlbara.Location = new System.Drawing.Point(144, 79);
            this.txtDataAlbara.Name = "txtDataAlbara";
            this.txtDataAlbara.ReadOnly = true;
            this.txtDataAlbara.Size = new System.Drawing.Size(100, 20);
            this.txtDataAlbara.TabIndex = 7;
            // 
            // txtCodiClient
            // 
            this.txtCodiClient.Location = new System.Drawing.Point(144, 119);
            this.txtCodiClient.Name = "txtCodiClient";
            this.txtCodiClient.ReadOnly = true;
            this.txtCodiClient.Size = new System.Drawing.Size(100, 20);
            this.txtCodiClient.TabIndex = 8;
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(144, 160);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.ReadOnly = true;
            this.txtNIF.Size = new System.Drawing.Size(100, 20);
            this.txtNIF.TabIndex = 9;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(144, 201);
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
            this.dgvLiniaAlbara.Location = new System.Drawing.Point(371, 34);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Població";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Direcció";
            // 
            // txtPoblacio
            // 
            this.txtPoblacio.Location = new System.Drawing.Point(144, 277);
            this.txtPoblacio.Name = "txtPoblacio";
            this.txtPoblacio.ReadOnly = true;
            this.txtPoblacio.Size = new System.Drawing.Size(100, 20);
            this.txtPoblacio.TabIndex = 14;
            // 
            // txtDireccio
            // 
            this.txtDireccio.Location = new System.Drawing.Point(144, 240);
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
            this.dgv.Location = new System.Drawing.Point(371, 167);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(548, 135);
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
            this.btnFacturarAlbara.Location = new System.Drawing.Point(480, 339);
            this.btnFacturarAlbara.Name = "btnFacturarAlbara";
            this.btnFacturarAlbara.Size = new System.Drawing.Size(117, 39);
            this.btnFacturarAlbara.TabIndex = 17;
            this.btnFacturarAlbara.Text = "Facturar l\'albarà";
            this.btnFacturarAlbara.UseVisualStyleBackColor = true;
            this.btnFacturarAlbara.Click += new System.EventHandler(this.btnFacturarAlbara_Click);
            // 
            // btnCancelarCanvis
            // 
            this.btnCancelarCanvis.Location = new System.Drawing.Point(265, 176);
            this.btnCancelarCanvis.Name = "btnCancelarCanvis";
            this.btnCancelarCanvis.Size = new System.Drawing.Size(75, 51);
            this.btnCancelarCanvis.TabIndex = 25;
            this.btnCancelarCanvis.Text = "Cancel·lar Canvis";
            this.btnCancelarCanvis.UseVisualStyleBackColor = true;
            this.btnCancelarCanvis.Click += new System.EventHandler(this.btnCancelarCanvis_Click);
            // 
            // btnGuardarCanvis
            // 
            this.btnGuardarCanvis.Location = new System.Drawing.Point(265, 114);
            this.btnGuardarCanvis.Name = "btnGuardarCanvis";
            this.btnGuardarCanvis.Size = new System.Drawing.Size(75, 53);
            this.btnGuardarCanvis.TabIndex = 24;
            this.btnGuardarCanvis.Text = "Guardar Canvis";
            this.btnGuardarCanvis.UseVisualStyleBackColor = true;
            this.btnGuardarCanvis.Click += new System.EventHandler(this.btnGuardarCanvis_Click);
            // 
            // btnModeEdicio
            // 
            this.btnModeEdicio.Location = new System.Drawing.Point(265, 66);
            this.btnModeEdicio.Name = "btnModeEdicio";
            this.btnModeEdicio.Size = new System.Drawing.Size(75, 23);
            this.btnModeEdicio.TabIndex = 23;
            this.btnModeEdicio.Text = "Mode Edició";
            this.btnModeEdicio.UseVisualStyleBackColor = true;
            this.btnModeEdicio.Click += new System.EventHandler(this.btnModeEdicio_Click);
            // 
            // frmAlbarans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 413);
            this.Controls.Add(this.btnCancelarCanvis);
            this.Controls.Add(this.btnGuardarCanvis);
            this.Controls.Add(this.btnModeEdicio);
            this.Controls.Add(this.btnFacturarAlbara);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtDireccio);
            this.Controls.Add(this.txtPoblacio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvLiniaAlbara);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtNIF);
            this.Controls.Add(this.txtCodiClient);
            this.Controls.Add(this.txtDataAlbara);
            this.Controls.Add(this.txtNAlbara);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAlbarans";
            this.Text = "frmAlbarans";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAlbarans_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNAlbara, 0);
            this.Controls.SetChildIndex(this.txtDataAlbara, 0);
            this.Controls.SetChildIndex(this.txtCodiClient, 0);
            this.Controls.SetChildIndex(this.txtNIF, 0);
            this.Controls.SetChildIndex(this.txtNom, 0);
            this.Controls.SetChildIndex(this.dgvLiniaAlbara, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtPoblacio, 0);
            this.Controls.SetChildIndex(this.txtDireccio, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.btnFacturarAlbara, 0);
            this.Controls.SetChildIndex(this.btnModeEdicio, 0);
            this.Controls.SetChildIndex(this.btnGuardarCanvis, 0);
            this.Controls.SetChildIndex(this.btnCancelarCanvis, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiniaAlbara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNAlbara;
        private System.Windows.Forms.TextBox txtDataAlbara;
        private System.Windows.Forms.TextBox txtCodiClient;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DataGridView dgvLiniaAlbara;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Button btnCancelarCanvis;
        private System.Windows.Forms.Button btnGuardarCanvis;
        private System.Windows.Forms.Button btnModeEdicio;
    }
}