using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjecteFinal
{
    public partial class frmAlbarans : frmPare
    {
        OracleDataSet dsDades;
        OracleConnection cnOracle;
        OracleDataSetTableAdapters.CABALBARATableAdapter caTa;
        OracleDataSetTableAdapters.TableAdapterManager tamDades;

        DataRow dr;
        public frmAlbarans(OracleDataSet dsDades, OracleConnection cnOracle, OracleDataSetTableAdapters.TableAdapterManager tamDades)
        {
            InitializeComponent();

            this.dsDades = dsDades;
            this.cnOracle = cnOracle;
            this.tamDades = tamDades;
            caTa = new OracleDataSetTableAdapters.CABALBARATableAdapter();

            cnOracle.Open();

            // Ordenem els albarans pel seu número
            dsDades.CABALBARA.DefaultView.Sort = "NALBARA ASC";

            Origen.DataSource = dsDades.CABALBARA;
            Origen.MoveFirst();
            BtnGuardarCanvis.Hide();
            BtnCancelarCanvis.Hide();

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();
            MostrarLiniaAlbara(dr["nalbara"].ToString());

            // Esdeveniment que saltarà quan canviem de registre actual
            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        public override void EliminarRegistreActual()
        {
            // NO XUTA
            Origen.RemoveCurrent();

            try
            {
                caTa.Update(dsDades);
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        public override void GuardarCanvis()
        {
            try
            {
                dr = ((DataRowView)Origen.Current).Row;

                dr.BeginEdit();
                dr[1] = txtDataAlbara.Text;

                if (ClientExisteix())
                {
                    dr[2] = txtCodiClient.Text;
                }
                else
                {
                    txtCodiClient.Text = dr["codiclient"].ToString();
                }

                dr[3] = txtNIF.Text;
                dr[4] = txtNom.Text;
                dr[5] = txtDireccio.Text;
                dr[6] = txtPoblacio.Text;
                dr.EndEdit();

                caTa.Update(dsDades);
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
            }
        }

        public override void ActivarModeEdicio()
        {
            txtDataAlbara.ReadOnly = false;
            txtCodiClient.ReadOnly = false;
            txtNIF.ReadOnly = false;
            txtNom.ReadOnly = false;
            txtDireccio.ReadOnly = false;
            txtPoblacio.ReadOnly = false;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            // S'encarrega de mostrar les dades del registre actual, si no hi ha més dades, les posa totes a buit
            dgvLiniaAlbara.Rows.Clear();

            if (Origen.Count > 0)
            {
                dr = ((DataRowView)Origen.Current).Row;
                EmplenarDades();
                MostrarLiniaAlbara(dr["nalbara"].ToString());
            }
            else
            {
                MostrarBuits();
            }
        }

        public override void MostrarBuits()
        {
            txtNAlbara.Text = "";
            txtDataAlbara.Text = "";
            txtCodiClient.Text = "";
            txtNIF.Text = "";
            txtNom.Text = "";
            txtDireccio.Text = "";
            txtPoblacio.Text = "";
        }

        public override void EmplenarDades()
        {
            txtNAlbara.Text = dr["nalbara"].ToString();
            txtDataAlbara.Text = dr["dataalbara"].ToString();
            txtCodiClient.Text = dr["codiclient"].ToString();
            txtNIF.Text = dr["nif"].ToString();
            txtNom.Text = dr["nom"].ToString();
            txtDireccio.Text = dr["direccio"].ToString();
            txtPoblacio.Text = dr["poblacio"].ToString();
        }

        public override void ModeNavegacio()
        {
            txtDataAlbara.ReadOnly = true;
            txtCodiClient.ReadOnly = true;
            txtNIF.ReadOnly = true;
            txtNom.ReadOnly = true;
            txtDireccio.ReadOnly = true;
            txtPoblacio.ReadOnly = true;
        }

        /// <summary>
        /// Funció que mostra al DataGridView les linies de l'albarà que estem situats
        /// </summary>
        /// <param name="nAlbara"></param>
        private void MostrarLiniaAlbara(string nAlbara)
        {
            OracleCommand cmd = new OracleCommand();
            cmd = cnOracle.CreateCommand();
            cmd.CommandText = "SELECT * FROM lineasalbara WHERE nalbara = " + nAlbara;
            OracleDataReader reader = cmd.ExecuteReader();

            if (dgvLiniaAlbara.Columns.Count != 0)
            {
                while (reader.Read())
                {
                    dgvLiniaAlbara.Rows.Add(reader.GetOracleString(1), reader.GetOracleString(2), reader.GetOracleValue(3), reader.GetOracleDecimal(4));
                }
            }

            reader.Dispose();
            reader.Close();
        }

        private void btnFacturarAlbara_Click(object sender, EventArgs e)
        {
            // Obrirà el formulari que ens pregunta quin tipus de Facturació volem, manual o automàtica
            FrmModus frmModus = new FrmModus();
            frmModus.ShowDialog();
            bool modusManual = frmModus.ModusManual;
            bool modusAutomatic = frmModus.ModusAutomatic;

            if (modusManual)
            {
                FrmManual frmManual = new FrmManual();
                frmManual.ShowDialog();
                string nFactura = Convert.ToString(frmManual.NFactura);
                DateTime data = frmManual.DtData;

                // Comprova si el número de factura que ens han entrat existeix
                if (!ExisteixFactura(Convert.ToInt32(nFactura)))
                {
                    // Generarà la factura
                    FacturarAlbara(dr["nalbara"].ToString(), nFactura, data);
                }
                else
                {
                    MessageBox.Show("Aquest número de factura ja existeix, hauràs d'entrar un altre");
                }

                
            }
            else if (modusAutomatic)
            {
                OracleCommand cmd = cnOracle.CreateCommand();
                bool existeix = false;
                OracleDataReader reader;
                string nFactura = "";

                while (!existeix)
                {
                    cmd.CommandText = "SELECT TO_CHAR(projectefinal.seq_factura.NEXTVAL, 'TM9') FROM DUAL";
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    OracleCommand command = cnOracle.CreateCommand();

                    command.CommandText = "SELECT * FROM cabfacturas WHERE nfactura = " + reader[0];
                    OracleDataReader readerFactura = command.ExecuteReader();
                    if (!readerFactura.HasRows)
                    {
                        existeix = true;
                        nFactura = reader[0].ToString();
                    }
                }

                // Generarà la factura
                FacturarAlbara(dr["nalbara"].ToString(), nFactura, DateTime.Today);
            }
        }

        /// <summary>
        /// Funció que ens dirà si el número de la factura que hem entrat existeix
        /// </summary>
        /// <param name="nFactura"></param>
        /// <returns></returns>
        private bool ExisteixFactura(int nFactura)
        {
            OracleCommand cmd = cnOracle.CreateCommand();

            cmd.CommandText = "SELECT * FROM cabfacturas WHERE nfactura = " + nFactura;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Funció que farà tota la facturació cridant al procediment emmagatzemat
        /// </summary>
        /// <param name="nAlbara"></param>
        /// <param name="nFactura"></param>
        /// <param name="data"></param>
        private void FacturarAlbara(string nAlbara, string nFactura, DateTime data)
        {
            OracleCommand command = new OracleCommand();

            command.Connection = cnOracle;
            command.CommandText = "projectefinal.generarFactura";
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.Clear();
            command.Parameters.Add(new OracleParameter("nAlbara", OracleDbType.Int32)).Value = nAlbara;
            command.Parameters.Add(new OracleParameter("nFactura", OracleDbType.Int32)).Value = nFactura;
            command.Parameters.Add(new OracleParameter("dataFactura", OracleDbType.Date)).Value = data;

            command.ExecuteNonQuery();

            command.Dispose();

            tamDades.CABALBARATableAdapter.Fill(dsDades.CABALBARA);
            tamDades.CABFACTURASTableAdapter.Fill(dsDades.CABFACTURAS);
            tamDades.LINEASALBARATableAdapter.Fill(dsDades.LINEASALBARA);
            tamDades.LINEASFACTURATableAdapter.Fill(dsDades.LINEASFACTURA);
            tamDades.ARTICLESTableAdapter.Fill(dsDades.ARTICLES);
        }

        private void frmAlbarans_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnOracle.Close();
        }

        private bool ClientExisteix()
        {
            OracleCommand cmd = cnOracle.CreateCommand();
            OracleDataReader reader;

            cmd.CommandText = "SELECT * FROM CLIENTS WHERE CODI = '" + txtCodiClient.Text + "'";
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}