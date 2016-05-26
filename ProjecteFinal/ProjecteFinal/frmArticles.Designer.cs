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
            this.lblCodi = new System.Windows.Forms.Label();
            this.txtCodi = new System.Windows.Forms.TextBox();
            this.lblDescripcio = new System.Windows.Forms.Label();
            this.lblQuantitatStock = new System.Windows.Forms.Label();
            this.lblPreuCost = new System.Windows.Forms.Label();
            this.lblPreuVenda = new System.Windows.Forms.Label();
            this.lblDescompte = new System.Windows.Forms.Label();
            this.txtDescripcio = new System.Windows.Forms.TextBox();
            this.txtQuantitatStock = new System.Windows.Forms.TextBox();
            this.txtPCost = new System.Windows.Forms.TextBox();
            this.txtPVenda = new System.Windows.Forms.TextBox();
            this.txtDescompte = new System.Windows.Forms.TextBox();
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
            this.label9 = new System.Windows.Forms.Label();
            this.lblOrdenacio = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbarans)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodi
            // 
            this.lblCodi.AutoSize = true;
            this.lblCodi.Location = new System.Drawing.Point(31, 134);
            this.lblCodi.Name = "lblCodi";
            this.lblCodi.Size = new System.Drawing.Size(28, 13);
            this.lblCodi.TabIndex = 1;
            this.lblCodi.Text = "Codi";
            this.lblCodi.Click += new System.EventHandler(this.lblCodi_Click);
            // 
            // txtCodi
            // 
            this.txtCodi.Location = new System.Drawing.Point(138, 127);
            this.txtCodi.Name = "txtCodi";
            this.txtCodi.ReadOnly = true;
            this.txtCodi.Size = new System.Drawing.Size(100, 20);
            this.txtCodi.TabIndex = 2;
            // 
            // lblDescripcio
            // 
            this.lblDescripcio.AutoSize = true;
            this.lblDescripcio.Location = new System.Drawing.Point(31, 173);
            this.lblDescripcio.Name = "lblDescripcio";
            this.lblDescripcio.Size = new System.Drawing.Size(57, 13);
            this.lblDescripcio.TabIndex = 3;
            this.lblDescripcio.Text = "Descripció";
            this.lblDescripcio.Click += new System.EventHandler(this.lblDescripcio_Click);
            // 
            // lblQuantitatStock
            // 
            this.lblQuantitatStock.AutoSize = true;
            this.lblQuantitatStock.Location = new System.Drawing.Point(31, 211);
            this.lblQuantitatStock.Name = "lblQuantitatStock";
            this.lblQuantitatStock.Size = new System.Drawing.Size(81, 13);
            this.lblQuantitatStock.TabIndex = 4;
            this.lblQuantitatStock.Text = "Quantitat Stock";
            this.lblQuantitatStock.Click += new System.EventHandler(this.lblQuantitatStock_Click);
            // 
            // lblPreuCost
            // 
            this.lblPreuCost.AutoSize = true;
            this.lblPreuCost.Location = new System.Drawing.Point(31, 250);
            this.lblPreuCost.Name = "lblPreuCost";
            this.lblPreuCost.Size = new System.Drawing.Size(53, 13);
            this.lblPreuCost.TabIndex = 5;
            this.lblPreuCost.Text = "Preu Cost";
            this.lblPreuCost.Click += new System.EventHandler(this.lblPreuCost_Click);
            // 
            // lblPreuVenda
            // 
            this.lblPreuVenda.AutoSize = true;
            this.lblPreuVenda.Location = new System.Drawing.Point(31, 293);
            this.lblPreuVenda.Name = "lblPreuVenda";
            this.lblPreuVenda.Size = new System.Drawing.Size(63, 13);
            this.lblPreuVenda.TabIndex = 6;
            this.lblPreuVenda.Text = "Preu Venda";
            this.lblPreuVenda.Click += new System.EventHandler(this.lblPreuVenda_Click);
            // 
            // lblDescompte
            // 
            this.lblDescompte.AutoSize = true;
            this.lblDescompte.Location = new System.Drawing.Point(31, 334);
            this.lblDescompte.Name = "lblDescompte";
            this.lblDescompte.Size = new System.Drawing.Size(61, 13);
            this.lblDescompte.TabIndex = 7;
            this.lblDescompte.Text = "Descompte";
            this.lblDescompte.Click += new System.EventHandler(this.lblDescompte_Click);
            // 
            // txtDescripcio
            // 
            this.txtDescripcio.Location = new System.Drawing.Point(138, 166);
            this.txtDescripcio.Name = "txtDescripcio";
            this.txtDescripcio.ReadOnly = true;
            this.txtDescripcio.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcio.TabIndex = 8;
            // 
            // txtQuantitatStock
            // 
            this.txtQuantitatStock.Location = new System.Drawing.Point(138, 204);
            this.txtQuantitatStock.Name = "txtQuantitatStock";
            this.txtQuantitatStock.ReadOnly = true;
            this.txtQuantitatStock.Size = new System.Drawing.Size(100, 20);
            this.txtQuantitatStock.TabIndex = 9;
            // 
            // txtPCost
            // 
            this.txtPCost.Location = new System.Drawing.Point(138, 243);
            this.txtPCost.Name = "txtPCost";
            this.txtPCost.ReadOnly = true;
            this.txtPCost.Size = new System.Drawing.Size(100, 20);
            this.txtPCost.TabIndex = 10;
            // 
            // txtPVenda
            // 
            this.txtPVenda.Location = new System.Drawing.Point(138, 286);
            this.txtPVenda.Name = "txtPVenda";
            this.txtPVenda.ReadOnly = true;
            this.txtPVenda.Size = new System.Drawing.Size(100, 20);
            this.txtPVenda.TabIndex = 11;
            // 
            // txtDescompte
            // 
            this.txtDescompte.Location = new System.Drawing.Point(138, 327);
            this.txtDescompte.Name = "txtDescompte";
            this.txtDescompte.ReadOnly = true;
            this.txtDescompte.Size = new System.Drawing.Size(100, 20);
            this.txtDescompte.TabIndex = 12;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 18);
            this.label9.TabIndex = 32;
            this.label9.Text = "Ordenat: ";
            // 
            // lblOrdenacio
            // 
            this.lblOrdenacio.AutoSize = true;
            this.lblOrdenacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenacio.Location = new System.Drawing.Point(105, 33);
            this.lblOrdenacio.Name = "lblOrdenacio";
            this.lblOrdenacio.Size = new System.Drawing.Size(87, 18);
            this.lblOrdenacio.TabIndex = 33;
            this.lblOrdenacio.Text = "CODI ASC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 18);
            this.label10.TabIndex = 34;
            this.label10.Text = "Premer els Labels per ordenar";
            // 
            // frmArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 517);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblOrdenacio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvAlbarans);
            this.Controls.Add(this.btnCercarArticles);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDataInici);
            this.Controls.Add(this.txtDescompte);
            this.Controls.Add(this.txtPVenda);
            this.Controls.Add(this.txtPCost);
            this.Controls.Add(this.txtQuantitatStock);
            this.Controls.Add(this.txtDescripcio);
            this.Controls.Add(this.lblDescompte);
            this.Controls.Add(this.lblPreuVenda);
            this.Controls.Add(this.lblPreuCost);
            this.Controls.Add(this.lblQuantitatStock);
            this.Controls.Add(this.lblDescripcio);
            this.Controls.Add(this.txtCodi);
            this.Controls.Add(this.lblCodi);
            this.Name = "frmArticles";
            this.Text = "frmArticles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArticles_FormClosing);
            this.Controls.SetChildIndex(this.lblCodi, 0);
            this.Controls.SetChildIndex(this.txtCodi, 0);
            this.Controls.SetChildIndex(this.lblDescripcio, 0);
            this.Controls.SetChildIndex(this.lblQuantitatStock, 0);
            this.Controls.SetChildIndex(this.lblPreuCost, 0);
            this.Controls.SetChildIndex(this.lblPreuVenda, 0);
            this.Controls.SetChildIndex(this.lblDescompte, 0);
            this.Controls.SetChildIndex(this.txtDescripcio, 0);
            this.Controls.SetChildIndex(this.txtQuantitatStock, 0);
            this.Controls.SetChildIndex(this.txtPCost, 0);
            this.Controls.SetChildIndex(this.txtPVenda, 0);
            this.Controls.SetChildIndex(this.txtDescompte, 0);
            this.Controls.SetChildIndex(this.dtpDataInici, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dtpDataFinal, 0);
            this.Controls.SetChildIndex(this.btnCercarArticles, 0);
            this.Controls.SetChildIndex(this.dgvAlbarans, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblOrdenacio, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbarans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodi;
        private System.Windows.Forms.TextBox txtCodi;
        private System.Windows.Forms.Label lblDescripcio;
        private System.Windows.Forms.Label lblQuantitatStock;
        private System.Windows.Forms.Label lblPreuCost;
        private System.Windows.Forms.Label lblPreuVenda;
        private System.Windows.Forms.Label lblDescompte;
        private System.Windows.Forms.TextBox txtDescripcio;
        private System.Windows.Forms.TextBox txtQuantitatStock;
        private System.Windows.Forms.TextBox txtPCost;
        private System.Windows.Forms.TextBox txtPVenda;
        private System.Windows.Forms.TextBox txtDescompte;
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOrdenacio;
        private System.Windows.Forms.Label label10;
    }
}