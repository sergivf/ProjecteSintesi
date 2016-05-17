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

namespace ProjecteFinal
{
    public partial class frmClients : frmPare
    {
        OracleDataSet dsDades;
        OracleDataSetTableAdapters.CLIENTSTableAdapter cTa;
        OracleConnection cnOracle;
        public frmClients(OracleDataSet dsDades, OracleConnection cnOracle)
        {
            InitializeComponent();
            this.dsDades = dsDades;
            this.cnOracle = cnOracle;

            cnOracle.Open();

            Origen.DataSource = dsDades.CLIENTS;
            Origen.MoveFirst();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            DataRow dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades(dr);
            MostrarAlbarans(dr["codi"].ToString());
            
            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            dgvLinies.Rows.Clear();
            dgvAlbarans.Rows.Clear();

            if (Origen.Count > 0)
            {
                DataRow dr = ((DataRowView)Origen.Current).Row;
                EmplenarDades(dr);
                MostrarAlbarans(dr["codi"].ToString());
            }
            else
            {
                MostrarBuits();
            }
        }

        private void MostrarBuits()
        {
            txtCodi.Text = "";
            txtNIF.Text = "";
            txtNom.Text = "";
            txtAdreça.Text = "";
            txtCodiProvincia.Text = "";
            txtCodiMunicipi.Text = "";
            txtTelefon.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtBancCC.Text = "";
            txtFormaPagament.Text = "";

            btnModeEdicio.Hide();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();
        }

        private void EmplenarDades(DataRow dr)
        {
            txtCodi.Text = dr["codi"].ToString();
            txtNIF.Text = dr["nif"].ToString();
            txtNom.Text = dr["nom"].ToString();
            txtAdreça.Text = dr["adreça"].ToString();
            txtCodiProvincia.Text = dr["codiprovincia"].ToString();
            txtCodiMunicipi.Text = dr["codimunicipi"].ToString();
            txtTelefon.Text = dr["telefon"].ToString();
            txtFax.Text = dr["fax"].ToString();
            txtEmail.Text = dr["email"].ToString();
            txtBancCC.Text = dr["banccc"].ToString();
            txtFormaPagament.Text = dr["formadepagament"].ToString();
        }

        private void MostrarAlbarans(string codiClient)
        {
            double total = 0;
            int quant = 0;
            double preu = 0;
            OracleCommand cmd = new OracleCommand();
            cmd = cnOracle.CreateCommand();
            cmd.CommandText = "SELECT nalbara, dataalbara FROM cabalbara WHERE codiclient = '" + codiClient + "'";
            OracleDataReader reader = cmd.ExecuteReader();

            OracleCommand cmdTotal = new OracleCommand();
            cmdTotal = cnOracle.CreateCommand();

            while (reader.Read())
            {
                cmdTotal.CommandText = "SELECT quantitatvenuda, preuvenda FROM lineasalbara WHERE nalbara = " + reader.GetOracleValue(0);

                OracleDataReader readerTotal = cmdTotal.ExecuteReader();

                while (readerTotal.Read())
                {
                    quant = Convert.ToInt32(readerTotal.GetOracleValue(0).ToString());
                    string preuString = readerTotal.GetOracleValue(1).ToString().Replace('.', ',');
                    preu = Convert.ToDouble(preuString);
                    total += quant * preu;
                }

                dgvAlbarans.Rows.Add(reader.GetOracleValue(0), reader.GetDateTime(1), total);
                total = 0;
            }
        }

        private void btnModeEdicio_Click(object sender, EventArgs e)
        {
            ModeEdicio = true;
            txtNIF.ReadOnly = false;
            txtNom.ReadOnly = false;
            txtAdreça.ReadOnly = false;
            txtCodiProvincia.ReadOnly = false;
            txtCodiMunicipi.ReadOnly = false;
            txtTelefon.ReadOnly = false;
            txtFax.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtBancCC.ReadOnly = false;
            txtFormaPagament.ReadOnly = false;

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

            txtNIF.ReadOnly = true;
            txtNom.ReadOnly = true;
            txtAdreça.ReadOnly = true;
            txtCodiProvincia.ReadOnly = true;
            txtCodiMunicipi.ReadOnly = true;
            txtTelefon.ReadOnly = true;
            txtFax.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtBancCC.ReadOnly = true;
            txtFormaPagament.ReadOnly = true;

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
                cTa = new OracleDataSetTableAdapters.CLIENTSTableAdapter();
                // Guardar els canvis en el dataset

                DataRow dr = ((DataRowView)Origen.Current).Row;

                dr.BeginEdit();
                dr[1] = txtNIF.Text;
                dr[2] = txtNom.Text;
                dr[3] = txtAdreça.Text;
                dr[4] = txtCodiProvincia.Text;
                dr[5] = txtCodiMunicipi.Text;
                dr[6] = txtTelefon.Text;
                dr[7] = txtFax.Text;
                dr[8] = txtEmail.Text;
                dr[9] = txtBancCC.Text;
                dr[10] = txtFormaPagament.Text;
                dr.EndEdit();

                cTa.Update(dsDades);
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
            }
        }

        private void dgvAlbarans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAlbarans.SelectedCells.Count > 0)
            {
                int index = dgvAlbarans.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvAlbarans.Rows[index];

                string nAlbaraString = selectedRow.Cells["nalbara"].Value.ToString();
                int nAlbara = Convert.ToInt32(nAlbaraString);

                dgvLinies.Rows.Clear();
                OracleCommand cmd = new OracleCommand();
                cmd = cnOracle.CreateCommand();
                cmd.CommandText = "SELECT codiarticle, descripcio, quantitatvenuda, preuvenda FROM lineasalbara WHERE nalbara = " + nAlbara;
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvLinies.Rows.Add(reader.GetOracleString(0), reader.GetOracleString(1), reader.GetOracleValue(2), reader.GetOracleValue(3));
                }
            }
        }

        private void frmClients_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnOracle.Close();
        }
    }
}