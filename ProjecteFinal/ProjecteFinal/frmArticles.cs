using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ProjecteFinal
{
    public partial class frmArticles : frmPare
    {
        OracleDataSet dsDades;
        OracleDataSetTableAdapters.ARTICLESTableAdapter aTa;
        OracleConnection cnOracle;

        public frmArticles(OracleDataSet dsDades, OracleConnection cnOracle)
        {
            InitializeComponent();
            this.dsDades = dsDades;
            this.cnOracle = cnOracle;

            cnOracle.Open();

            Origen.DataSource = dsDades.ARTICLES;
            Origen.MoveFirst();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            DataRow dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades(dr);
            
            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            if (Origen.Count > 0)
            {
                DataRow dr = ((DataRowView)Origen.Current).Row;
                EmplenarDades(dr);
            }
            else
            {
                MostrarBuits();
            }
        }

        private void MostrarBuits()
        {
            txtCodi.Text = "";
            txtDescripcio.Text = "";
            txtQuantitatStock.Text = "";
            txtPCost.Text = "";
            txtPVenda.Text = "";
            txtDescompte.Text = "";
        }

        private void EmplenarDades(DataRow dr)
        {
            txtCodi.Text = dr["codi"].ToString();
            txtDescripcio.Text = dr["descripcio"].ToString();
            txtQuantitatStock.Text = dr["quantitatstock"].ToString();
            txtPCost.Text = dr["pcost"].ToString();
            txtPVenda.Text = dr["pvenda"].ToString();
            txtDescompte.Text = dr["descompte"].ToString();
        }

        private void btnModeEdicio_Click(object sender, EventArgs e)
        {
            ModeEdicio = true;
            txtDescripcio.ReadOnly = false;
            txtQuantitatStock.ReadOnly = false;
            txtPCost.ReadOnly = false;
            txtPVenda.ReadOnly = false;
            txtDescompte.ReadOnly = false;

            btnModeEdicio.Hide();
            btnGuardarCanvis.Show();
            btnCancelarCanvis.Show();
        }

        private void btnCancelarCanvis_Click(object sender, EventArgs e)
        {
            ModeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            txtDescripcio.ReadOnly = true;
            txtQuantitatStock.ReadOnly = true;
            txtPCost.ReadOnly = true;
            txtPVenda.ReadOnly = true;
            txtDescompte.ReadOnly = true;

            EmplenarDades(((DataRowView)Origen.Current).Row);
        }

        private void btnGuardarCanvis_Click(object sender, EventArgs e)
        {
            ModeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            try
            {
                aTa = new OracleDataSetTableAdapters.ARTICLESTableAdapter();
                // Guardar els canvis en el dataset

                DataRow dr = ((DataRowView)Origen.Current).Row;

                dr.BeginEdit();
                dr[1] = txtDescripcio.Text;
                dr[2] = txtQuantitatStock.Text;
                dr[3] = txtPCost.Text;
                dr[4] = txtPVenda.Text;
                dr[5] = txtDescompte.Text;
                dr.EndEdit();

                aTa.Update(dsDades);
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
            }
        }

        private void frmArticles_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnOracle.Close();
        }
    }
}
