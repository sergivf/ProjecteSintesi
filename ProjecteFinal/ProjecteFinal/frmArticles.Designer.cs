namespace ProjecteFinal
{
    partial class frmArticles
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
            this.txtCodi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescripcio = new System.Windows.Forms.TextBox();
            this.txtQuantitatStock = new System.Windows.Forms.TextBox();
            this.txtPCost = new System.Windows.Forms.TextBox();
            this.txtPVenda = new System.Windows.Forms.TextBox();
            this.txtDescompte = new System.Windows.Forms.TextBox();
            this.btnCancelarCanvis = new System.Windows.Forms.Button();
            this.btnGuardarCanvis = new System.Windows.Forms.Button();
            this.btnModeEdicio = new System.Windows.Forms.Button();
            this.dtpDataInici = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.btnCercarArticles = new System.Windows.Forms.Button();
            this.dgvAlbarans = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbarans)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codi";
            // 
            // txtCodi
            // 
            this.txtCodi.Location = new System.Drawing.Point(139, 36);
            this.txtCodi.Name = "txtCodi";
            this.txtCodi.ReadOnly = true;
            this.txtCodi.Size = new System.Drawing.Size(100, 20);
            this.txtCodi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripció";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantitat Stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Preu Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Preu Venda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Descompte";
            // 
            // txtDescripcio
            // 
            this.txtDescripcio.Location = new System.Drawing.Point(139, 75);
            this.txtDescripcio.Name = "txtDescripcio";
            this.txtDescripcio.ReadOnly = true;
            this.txtDescripcio.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcio.TabIndex = 8;
            // 
            // txtQuantitatStock
            // 
            this.txtQuantitatStock.Location = new System.Drawing.Point(139, 113);
            this.txtQuantitatStock.Name = "txtQuantitatStock";
            this.txtQuantitatStock.ReadOnly = true;
            this.txtQuantitatStock.Size = new System.Drawing.Size(100, 20);
            this.txtQuantitatStock.TabIndex = 9;
            // 
            // txtPCost
            // 
            this.txtPCost.Location = new System.Drawing.Point(139, 152);
            this.txtPCost.Name = "txtPCost";
            this.txtPCost.ReadOnly = true;
            this.txtPCost.Size = new System.Drawing.Size(100, 20);
            this.txtPCost.TabIndex = 10;
            // 
            // txtPVenda
            // 
            this.txtPVenda.Location = new System.Drawing.Point(139, 195);
            this.txtPVenda.Name = "txtPVenda";
            this.txtPVenda.ReadOnly = true;
            this.txtPVenda.Size = new System.Drawing.Size(100, 20);
            this.txtPVenda.TabIndex = 11;
            // 
            // txtDescompte
            // 
            this.txtDescompte.Location = new System.Drawing.Point(139, 236);
            this.txtDescompte.Name = "txtDescompte";
            this.txtDescompte.ReadOnly = true;
            this.txtDescompte.Size = new System.Drawing.Size(100, 20);
            this.txtDescompte.TabIndex = 12;
            // 
            // btnCancelarCanvis
            // 
            this.btnCancelarCanvis.Location = new System.Drawing.Point(282, 162);
            this.btnCancelarCanvis.Name = "btnCancelarCanvis";
            this.btnCancelarCanvis.Size = new System.Drawing.Size(75, 51);
            this.btnCancelarCanvis.TabIndex = 25;
            this.btnCancelarCanvis.Text = "Cancel·lar Canvis";
            this.btnCancelarCanvis.UseVisualStyleBackColor = true;
            this.btnCancelarCanvis.Click += new System.EventHandler(this.btnCancelarCanvis_Click);
            // 
            // btnGuardarCanvis
            // 
            this.btnGuardarCanvis.Location = new System.Drawing.Point(282, 100);
            this.btnGuardarCanvis.Name = "btnGuardarCanvis";
            this.btnGuardarCanvis.Size = new System.Drawing.Size(75, 53);
            this.btnGuardarCanvis.TabIndex = 24;
            this.btnGuardarCanvis.Text = "Guardar Canvis";
            this.btnGuardarCanvis.UseVisualStyleBackColor = true;
            this.btnGuardarCanvis.Click += new System.EventHandler(this.btnGuardarCanvis_Click);
            // 
            // btnModeEdicio
            // 
            this.btnModeEdicio.Location = new System.Drawing.Point(282, 52);
            this.btnModeEdicio.Name = "btnModeEdicio";
            this.btnModeEdicio.Size = new System.Drawing.Size(75, 23);
            this.btnModeEdicio.TabIndex = 23;
            this.btnModeEdicio.Text = "Mode Edició";
            this.btnModeEdicio.UseVisualStyleBackColor = true;
            this.btnModeEdicio.Click += new System.EventHandler(this.btnModeEdicio_Click);
            // 
            // dtpDataInici
            // 
            this.dtpDataInici.Location = new System.Drawing.Point(502, 55);
            this.dtpDataInici.Name = "dtpDataInici";
            this.dtpDataInici.Size = new System.Drawing.Size(200, 20);
            this.dtpDataInici.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Data Inici";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Data Final";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Location = new System.Drawing.Point(502, 93);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(200, 20);
            this.dtpDataFinal.TabIndex = 29;
            // 
            // btnCercarArticles
            // 
            this.btnCercarArticles.Location = new System.Drawing.Point(742, 64);
            this.btnCercarArticles.Name = "btnCercarArticles";
            this.btnCercarArticles.Size = new System.Drawing.Size(97, 41);
            this.btnCercarArticles.TabIndex = 30;
            this.btnCercarArticles.Text = "Cercar articles entre dates";
            this.btnCercarArticles.UseVisualStyleBackColor = true;
            this.btnCercarArticles.Click += new System.EventHandler(this.btnCercarArticles_Click);
            // 
            // dgvAlbarans
            // 
            this.dgvAlbarans.AllowUserToAddRows = false;
            this.dgvAlbarans.AllowUserToDeleteRows = false;
            this.dgvAlbarans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbarans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvAlbarans.Location = new System.Drawing.Point(439, 159);
            this.dgvAlbarans.Name = "dgvAlbarans";
            this.dgvAlbarans.ReadOnly = true;
            this.dgvAlbarans.Size = new System.Drawing.Size(446, 130);
            this.dgvAlbarans.TabIndex = 31;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Número d\'albarà";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data albarà";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nom client";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantitat";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // frmArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 517);
            this.Controls.Add(this.dgvAlbarans);
            this.Controls.Add(this.btnCercarArticles);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDataInici);
            this.Controls.Add(this.btnCancelarCanvis);
            this.Controls.Add(this.btnGuardarCanvis);
            this.Controls.Add(this.btnModeEdicio);
            this.Controls.Add(this.txtDescompte);
            this.Controls.Add(this.txtPVenda);
            this.Controls.Add(this.txtPCost);
            this.Controls.Add(this.txtQuantitatStock);
            this.Controls.Add(this.txtDescripcio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodi);
            this.Controls.Add(this.label1);
            this.Name = "frmArticles";
            this.Text = "frmArticles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArticles_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCodi, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDescripcio, 0);
            this.Controls.SetChildIndex(this.txtQuantitatStock, 0);
            this.Controls.SetChildIndex(this.txtPCost, 0);
            this.Controls.SetChildIndex(this.txtPVenda, 0);
            this.Controls.SetChildIndex(this.txtDescompte, 0);
            this.Controls.SetChildIndex(this.btnModeEdicio, 0);
            this.Controls.SetChildIndex(this.btnGuardarCanvis, 0);
            this.Controls.SetChildIndex(this.btnCancelarCanvis, 0);
            this.Controls.SetChildIndex(this.dtpDataInici, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dtpDataFinal, 0);
            this.Controls.SetChildIndex(this.btnCercarArticles, 0);
            this.Controls.SetChildIndex(this.dgvAlbarans, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbarans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescripcio;
        private System.Windows.Forms.TextBox txtQuantitatStock;
        private System.Windows.Forms.TextBox txtPCost;
        private System.Windows.Forms.TextBox txtPVenda;
        private System.Windows.Forms.TextBox txtDescompte;
        private System.Windows.Forms.Button btnCancelarCanvis;
        private System.Windows.Forms.Button btnGuardarCanvis;
        private System.Windows.Forms.Button btnModeEdicio;
        private System.Windows.Forms.DateTimePicker dtpDataInici;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.Button btnCercarArticles;
        private System.Windows.Forms.DataGridView dgvAlbarans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}