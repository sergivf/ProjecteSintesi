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
    public partial class frmInformes : Form
    {
        OracleConnection cnOracle;
        OracleDataSet oracleDataSet;
        bool albara;
        bool factura;

        public bool Albara
        {
            get { return albara; }
            set { albara = value; }
        }

        public bool Factura
        {
            get { return factura; }
            set { factura = value; }
        }

        public TextBox TxtFinsA
        {
            get { return txtFinsA; }
            set { txtFinsA = value; }
        }

        public Label LblFinsA
        {
            get { return lblFinsA; }
            set { lblFinsA = value; }
        }

        public frmInformes(OracleConnection cnOracle, OracleDataSet oracleDataSet)
        {
            InitializeComponent();

            this.cnOracle = cnOracle;
            this.oracleDataSet = oracleDataSet;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (albara)
            {
                if (txtFinsA.Enabled)
                {
                    LlistarEntreAlbarans();
                }
                else
                {
                    LlistarUnAlbara();
                }
            }
            else
            {
                LlistarUnaFactura();
            }   
        }

        private void LlistarEntreAlbarans()
        {
            int valorInici = 0;
            int valorFinal = 0;

            if (int.TryParse(txtNumero.Text, out valorInici))
            {
                if (int.TryParse(txtFinsA.Text, out valorFinal))
                {
                    if (!Llistar.LlistarEntreAlbarans(oracleDataSet, cnOracle, valorInici, valorFinal))
                        MessageBox.Show("No existeix cap albarà entre els números " + valorInici + " - " + valorFinal);
                }
                else
                {
                    MessageBox.Show("Has d'entrar un número");
                }
            }
            else
            {
                MessageBox.Show("Has d'entrar un número");
            }
        }

        private void LlistarUnAlbara()
        {
            int numero = 0;

            if (int.TryParse(txtNumero.Text, out numero))
            {
                if (!Llistar.LlistarUnAlbara(oracleDataSet, cnOracle, numero))
                    MessageBox.Show("El número d'albarà no existeix");
            }
            else
            {
                MessageBox.Show("Has d'entrar un número");
            }
        }

        private void LlistarUnaFactura()
        {
            int numero = 0;

            if (int.TryParse(txtNumero.Text, out numero))
            {
                if (!Llistar.LlistarUnaFactura(oracleDataSet, cnOracle, numero))
                    MessageBox.Show("El número de factura no existeix");
            }
            else
            {
                MessageBox.Show("Has d'entrar un número");
            }
        }
    }
}
