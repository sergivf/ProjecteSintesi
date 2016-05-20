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
    public partial class frmFactures : frmPare
    {
        OracleDataSet dsDades;
        OracleConnection cnOracle;
        OracleDataSetTableAdapters.TableAdapterManager tamDades;
        DataRow dr;
        public frmFactures(OracleDataSet dsDades, OracleConnection cnOracle, OracleDataSetTableAdapters.TableAdapterManager tamDades)
        {
            InitializeComponent();

            this.dsDades = dsDades;
            this.cnOracle = cnOracle;
            this.tamDades = tamDades;

            cnOracle.Open();

            Origen.DataSource = dsDades.CABFACTURAS;
            Origen.MoveFirst();
            /*btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();*/

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();
            MostrarLiniaFactura(dr["nfactura"].ToString());

            Origen.CurrentChanged += Origen_CurrentChanged; ;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            dgvLiniesFactura.Rows.Clear();

            if (Origen.Count > 0)
            {
                dr = ((DataRowView)Origen.Current).Row;
                EmplenarDades();
                MostrarLiniaFactura(dr["nfactura"].ToString());
            }
            else
            {
                MostrarBuits();
            }
        }

        private void MostrarBuits()
        {
            txtNFactura.Text = "";
            txtDataFactura.Text = "";
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
            txtNFactura.Text = dr["nfactura"].ToString();
            txtDataFactura.Text = dr["datafactura"].ToString();
            txtNAlbara.Text = dr["nalbara"].ToString();
            txtDataAlbara.Text = dr["dataalbara"].ToString();
            txtCodiClient.Text = dr["codiclient"].ToString();
            txtNIF.Text = dr["nif"].ToString();
            txtNom.Text = dr["nom"].ToString();
            txtDireccio.Text = dr["direccio"].ToString();
            txtPoblacio.Text = dr["poblacio"].ToString();
        }

        private void MostrarLiniaFactura(string nFactura)
        {
            OracleCommand cmd = new OracleCommand();
            cmd = cnOracle.CreateCommand();
            cmd.CommandText = "SELECT * FROM lineasfactura WHERE nfactura = " + nFactura;
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dgvLiniesFactura.Rows.Add(reader.GetOracleString(1), reader.GetOracleString(2), reader.GetOracleValue(3), reader.GetOracleDecimal(4), reader.GetOracleValue(5));
            }
        }

        private void frmFactures_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnOracle.Close();
        }

        private void txtEliminarFactura_Click(object sender, EventArgs e)
        {
            OracleCommand command = new OracleCommand();

            command.Connection = cnOracle;
            command.CommandText = "projectefinal.eliminarFactura";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Clear();
            command.Parameters.Add(new OracleParameter("nAlbara", OracleDbType.Int32)).Value = dr[0].ToString();

            command.ExecuteNonQuery();

            command.Dispose();

            tamDades.CABALBARATableAdapter.Fill(dsDades.CABALBARA);
            tamDades.CABFACTURASTableAdapter.Fill(dsDades.CABFACTURAS);
            tamDades.LINEASALBARATableAdapter.Fill(dsDades.LINEASALBARA);
            tamDades.LINEASFACTURATableAdapter.Fill(dsDades.LINEASFACTURA);
            tamDades.ARTICLESTableAdapter.Fill(dsDades.ARTICLES);
        }
    }
}