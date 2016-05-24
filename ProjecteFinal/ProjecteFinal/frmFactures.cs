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

            // Ordenem els albarans per número de Factura
            dsDades.CABFACTURAS.DefaultView.Sort = "NFACTURA ASC";

            Origen.DataSource = dsDades.CABFACTURAS;
            Origen.MoveFirst();

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();
            MostrarLiniaFactura(dr["nfactura"].ToString());

            BtnCancelarCanvis.Hide();
            BtnModeEdicio.Hide();
            BtnGuardarCanvis.Hide();

            // Esdeveniment que saltarà quan canviem de registre actual
            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            // S'encarrega de mostrar les dades del registre actual, si no hi ha més dades, les posa totes a buit
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

        /// <summary>
        /// Quan no hi ha més dades mostra els textbox buits
        /// </summary>
        public override void MostrarBuits()
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
        }

        /// <summary>
        /// Emplena les dades amb el registre actual
        /// </summary>
        public override void EmplenarDades()
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

        /// <summary>
        /// Funció que mostrarà les línies de factura
        /// Executarà la funció sempre que canvii el registre actual
        /// </summary>
        /// <param name="nFactura"></param>
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

        /// <summary>
        /// S'encarrega de cridat el procediment emmagatzemat que recuperarà l'stock, l'albarà i eliminarà la factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarFactura_Click(object sender, EventArgs e)
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