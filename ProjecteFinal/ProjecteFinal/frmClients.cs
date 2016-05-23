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
        DataRow dr;
        public frmClients(OracleDataSet dsDades, OracleConnection cnOracle) 
        {
            InitializeComponent();
            this.dsDades = dsDades;
            this.cnOracle = cnOracle;

            cnOracle.Open();

            dsDades.CLIENTS.DefaultView.Sort = "CODI ASC";

            Origen.DataSource = dsDades.CLIENTS;
            Origen.MoveFirst();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();
            MostrarAlbarans(dr["codi"].ToString());

            // Esdeveniment que saltarà quan canviem de registre actual
            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            // S'encarrega de mostrar les dades del registre actual, si no hi ha més dades, les posa totes a buit
            dgvLinies.Rows.Clear();
            dgvAlbarans.Rows.Clear();

            if (Origen.Count > 0)
            {
                dr = ((DataRowView)Origen.Current).Row;
                EmplenarDades();
                MostrarAlbarans(dr["codi"].ToString());
            }
            else
            {
                MostrarBuits();
            }
        }

        /// <summary>
        /// Quan no hi ha més dades mostra els textbox buits
        /// </summary>
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

        /// <summary>
        /// Emplena les dades amb el registre actual
        /// </summary>
        /// <param name="dr"></param>
        private void EmplenarDades()
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

        /// <summary>
        /// Funció que s'encarrega de mostrar tots els albarans del client actual
        /// </summary>
        /// <param name="codiClient"></param>
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

            // While -> Recorre el reader que conte el número d'albarà i la data del client actual
            while (reader.Read())
            {
                cmdTotal.CommandText = "SELECT quantitatvenuda, preuvenda FROM lineasalbara WHERE nalbara = " + reader.GetOracleValue(0);

                OracleDataReader readerTotal = cmdTotal.ExecuteReader();

                // While -> Recorre el reader que conté la quantitat venuda i preuvenda de l'albarà
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

        /// <summary>
        /// Funció que entra en el mode edició
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Funció que ens canvia a mode navegació
        /// </summary>
        private void ModeConsulta()
        {
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
        }

        /// <summary>
        /// Cancel·la tots els canvis i surt del mode edició
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarCanvis_Click(object sender, EventArgs e)
        {
            ModeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            ModeConsulta();

            EmplenarDades();
        }

        /// <summary>
        /// Guarda tots els canvis i surt del mode edició
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarCanvis_Click(object sender, EventArgs e)
        {
            int sortida = 0;
            ModeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();
            ModeConsulta();

            try
            {
                cTa = new OracleDataSetTableAdapters.CLIENTSTableAdapter();

                dr = ((DataRowView)Origen.Current).Row;

                dr.BeginEdit();
                dr[1] = txtNIF.Text;
                dr[2] = txtNom.Text;
                dr[3] = txtAdreça.Text;

                if (ProvinciaExisteix())
                {
                    dr[4] = txtCodiProvincia.Text;
                }
                else
                {
                    txtCodiProvincia.Text = dr["codiprovincia"].ToString();
                }

                if (MunicipiExisteix())
                {
                    dr[5] = txtCodiMunicipi.Text;
                }
                else
                {
                    txtCodiMunicipi.Text = dr["codimunicipi"].ToString();
                }

                if (!int.TryParse(txtTelefon.Text, out sortida))
                {
                    txtTelefon.Text = dr["telefon"].ToString();
                }
                else
                {
                    dr[6] = txtTelefon.Text;
                }

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

        private bool ProvinciaExisteix()
        {
            OracleCommand cmd = cnOracle.CreateCommand();
            OracleDataReader reader;
            int sortida = 0;

            if (!int.TryParse(txtCodiProvincia.Text, out sortida))
            {
                return false;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM PROVINCIES WHERE codi = '" + sortida + "'";
                reader = cmd.ExecuteReader();

                if (reader.HasRows) return true;
                else return false;
            }
        }

        private bool MunicipiExisteix()
        {
            OracleCommand cmd = cnOracle.CreateCommand();
            OracleDataReader reader;
            int sortida = 0;

            if (!int.TryParse(txtCodiMunicipi.Text, out sortida))
            {
                return false;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM MUNICIPIS WHERE codi = '" + sortida + "'";
                reader = cmd.ExecuteReader();

                if (reader.HasRows) return true;
                else return false;
            }
        }

        /// <summary>
        /// Quan es fa doble clic a un albarà, mostra les seves línies d'albarà
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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