using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjecteFinal
{
    public partial class frmValidacio : Form
    {
        public frmValidacio()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            EstablirConnection();
        }

        private void EstablirConnection()
        {
            try
            {
                string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=projectefinal;Password=123456;";
                //string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=" + txtUser.Text + ";Password=" + txtPassword.Text + ";";
                OracleConnection cnOracle = new OracleConnection(connectionString);
                cnOracle.Open();

                cnOracle.Close();
                this.Hide();
                frmMDIPare mdiPare = new frmMDIPare(cnOracle);
                mdiPare.ShowDialog();
                this.Close();
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
                //MessageBox.Show("Invalid username/password\nTorna-ho a provar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmValidacio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EstablirConnection();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}