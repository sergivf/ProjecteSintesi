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
    public partial class FrmManual : Form
    {
        int nFactura;
        DateTime dtData;

        public DateTime DtData
        {
            get { return dtData; }
            set { dtData = value; }
        }

        public int NFactura
        {
            get { return nFactura; }
            set { nFactura = value; }
        }

        public FrmManual()
        {
            InitializeComponent();
            dtpDada.Value = DateTime.Today;
        }

        private void tbnFacturar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNFactura.Text, out nFactura))
            {
                MessageBox.Show("El número de factura ha de ser un número");
                return;
            }
            else
            {
                NFactura = Convert.ToInt32(txtNFactura.Text);
                dtData = dtpDada.Value;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
