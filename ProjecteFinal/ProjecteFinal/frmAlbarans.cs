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
        OracleDataSetTableAdapters.TableAdapterManager tamDades;
        DataRow dr;
        public frmAlbarans(OracleDataSet dsDades, OracleConnection cnOracle, OracleDataSetTableAdapters.TableAdapterManager tamDades)
        {
            InitializeComponent();

            this.dsDades = dsDades;
            this.cnOracle = cnOracle;
            this.tamDades = tamDades;

            cnOracle.Open();

            dsDades.CABALBARA.DefaultView.Sort = "NALBARA ASC";

            Origen.DataSource = dsDades.CABALBARA;
            Origen.MoveFirst();
            /*btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();*/

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();
            MostrarLiniaAlbara(dr["nalbara"].ToString());

            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
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

        private void MostrarBuits()
        {
            txtNAlbara.Text = "";
            txtDataAlbara.Text = "";
            txtCodiClient.Text = "";
            txtNIF.Text = "";
            txtNom.Text = "";
            txtDireccio.Text = "";
            txtPoblacio.Text = "";

            /*btnModeEdicio.Hide();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();*/
        }

        private void EmplenarDades()
        {
            txtNAlbara.Text = dr["nalbara"].ToString();
            txtDataAlbara.Text = dr["dataalbara"].ToString();
            txtCodiClient.Text = dr["codiclient"].ToString();
            txtNIF.Text = dr["nif"].ToString();
            txtNom.Text = dr["nom"].ToString();
            txtDireccio.Text = dr["direccio"].ToString();
            txtPoblacio.Text = dr["poblacio"].ToString();
        }

        private void MostrarLiniaAlbara(string nAlbara)
        {
            OracleCommand cmd = new OracleCommand();
            cmd = cnOracle.CreateCommand();
            cmd.CommandText = "SELECT * FROM lineasalbara WHERE nalbara = " + nAlbara;
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dgvLiniaAlbara.Rows.Add(reader.GetOracleString(1), reader.GetOracleString(2), reader.GetOracleValue(3), reader.GetOracleDecimal(4));
            }
        }

        private void btnFacturarAlbara_Click(object sender, EventArgs e)
        {
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

                FacturarAlbara(dr["nalbara"].ToString(), nFactura, data);
            }
            else if (modusAutomatic)
            {
                OracleCommand cmd = cnOracle.CreateCommand();

                cmd.CommandText = "SELECT TO_CHAR(projectefinal.seq_factura.NEXTVAL, 'TM9') FROM DUAL";
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();

                FacturarAlbara(dr["nalbara"].ToString(), reader[0].ToString(), DateTime.Today);
            }
        }

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
    }
}