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
        DataRow dr;
        bool asc = false;
        bool desc = false;

        public frmArticles(OracleDataSet dsDades, OracleConnection cnOracle)
        {
            InitializeComponent();
            this.dsDades = dsDades;
            this.cnOracle = cnOracle;
            aTa = new OracleDataSetTableAdapters.ARTICLESTableAdapter();

            cnOracle.Open();

            dsDades.ARTICLES.DefaultView.Sort = "CODI ASC";
            asc = true;

            Origen.DataSource = dsDades.ARTICLES;
            Origen.MoveFirst();
            BtnGuardarCanvis.Hide();
            BtnCancelarCanvis.Hide();

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();

            // Esdeveniment que saltarà quan canviem de registre actual
            Origen.CurrentChanged += Origen_CurrentChanged;
        }

        public override void EliminarRegistreActual()
        {
            // NO XUTA
            Origen.RemoveCurrent();

            try
            {
                aTa.Update(dsDades);
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        public override void GuardarCanvis()
        {
            double valorDecimal = 0;
            int valorEnter = 0;

            try
            {
                DataRow dr = ((DataRowView)Origen.Current).Row;

                dr.BeginEdit();
                dr[1] = txtDescripcio.Text;

                if (!int.TryParse(txtQuantitatStock.Text, out valorEnter))
                {
                    txtQuantitatStock.Text = dr["quantitatstock"].ToString();
                }
                else
                {
                    dr[2] = txtQuantitatStock.Text;
                }

                if (!double.TryParse(txtPCost.Text, out valorDecimal))
                {
                    txtPCost.Text = dr["pcost"].ToString();
                }
                else
                {
                    dr[3] = txtPCost.Text.Replace('.', ',');
                }

                if (!double.TryParse(txtPVenda.Text, out valorDecimal))
                {
                    txtPVenda.Text = dr["pvenda"].ToString();
                }
                else
                {
                    dr[4] = txtPVenda.Text.Replace('.', ',');
                }

                if (!int.TryParse(txtDescompte.Text, out valorEnter))
                {
                    txtDescompte.Text = dr["descompte"].ToString();
                }
                else
                {
                    dr[5] = txtDescompte.Text;
                }
                dr.EndEdit();

                aTa.Update(dsDades);
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
            }
        }

        public override void ActivarModeEdicio()
        {
            txtDescripcio.ReadOnly = false;
            txtQuantitatStock.ReadOnly = false;
            txtPCost.ReadOnly = false;
            txtPVenda.ReadOnly = false;
            txtDescompte.ReadOnly = false;
        }

        private void Origen_CurrentChanged(object sender, EventArgs e)
        {
            // S'encarrega de mostrar les dades del registre actual, si no hi ha més dades, les posa totes a buit
            dgvAlbarans.Rows.Clear();

            if (Origen.Count > 0)
            {
                dr = ((DataRowView)Origen.Current).Row;
                EmplenarDades();
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
            txtCodi.Text = "";
            txtDescripcio.Text = "";
            txtQuantitatStock.Text = "";
            txtPCost.Text = "";
            txtPVenda.Text = "";
            txtDescompte.Text = "";
        }

        public override void EmplenarDades()
        {
            txtCodi.Text = dr["codi"].ToString();
            txtDescripcio.Text = dr["descripcio"].ToString();
            txtQuantitatStock.Text = dr["quantitatstock"].ToString();
            txtPCost.Text = dr["pcost"].ToString();
            txtPVenda.Text = dr["pvenda"].ToString();
            txtDescompte.Text = dr["descompte"].ToString();
        }

        public override void ModeNavegacio()
        {
            txtDescripcio.ReadOnly = true;
            txtQuantitatStock.ReadOnly = true;
            txtPCost.ReadOnly = true;
            txtPVenda.ReadOnly = true;
            txtDescompte.ReadOnly = true;
        }

        private void frmArticles_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnOracle.Close();
        }

        /// <summary>
        /// Ens permetrà fer que ens mostri a quins albarans han demanat l'article actual i que estigui comprès entre les dues dates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCercarArticles_Click(object sender, EventArgs e)
        {
            // Comprova si la data inici és posterior a la data final
            if (dtpDataFinal.Value < dtpDataInici.Value)
            {
                MessageBox.Show("La data final és anterior a la data inici...!");
                dgvAlbarans.Rows.Clear();
            }
            else
            {
                DataRow dr = ((DataRowView)Origen.Current).Row;
                string dataInici = "";
                string dataFinal = "";

                dgvAlbarans.Rows.Clear();
                OracleCommand cmd = new OracleCommand();
                cmd = cnOracle.CreateCommand();
                cmd.CommandText = "SELECT nalbara, quantitatvenuda FROM lineasalbara WHERE codiarticle = '" + dr[0] + "'";
                OracleDataReader reader = cmd.ExecuteReader();

                OracleCommand cmdCab = new OracleCommand();
                cmdCab = cnOracle.CreateCommand();

                // While -> Recorre el reader on tenim el número albarà i la quantitat venuda dels albarans que contenen l'article actual
                while (reader.Read())
                {
                    // Si no guardem les dates d'aquesta manera no ens les agafava bé a la clausula (WHERE)
                    dataInici = dtpDataInici.Value.Day + "/" + dtpDataInici.Value.Month + "/" + dtpDataInici.Value.Year;
                    dataFinal = dtpDataFinal.Value.Day + "/" + dtpDataFinal.Value.Month + "/" + dtpDataFinal.Value.Year;
                    cmdCab.CommandText = "SELECT nom, dataalbara FROM cabalbara WHERE nalbara = " + reader.GetOracleValue(0) + " AND dataalbara BETWEEN TO_DATE('" + dataInici + "', 'dd/mm/yyyy') AND TO_DATE('" + dataFinal + "', 'dd/mm/yyyy')";

                    OracleDataReader readerCab = cmdCab.ExecuteReader();

                    // While -> Recorre el reader on tenim el nom del client i la data de l'albarà dels albarans que contenen l'article actual
                    while (readerCab.Read())
                    {
                        dgvAlbarans.Rows.Add(reader.GetOracleValue(0), readerCab.GetOracleDate(1), readerCab.GetOracleString(0), reader.GetOracleValue(1));
                    }

                    readerCab.Dispose();
                    readerCab.Close();
                }

                cmdCab.Dispose();
                reader.Dispose();
                reader.Close();
                cmd.Dispose();
            }
        }

        private void lblCodi_Click(object sender, EventArgs e)
        {
            if (asc)
            {
                dsDades.ARTICLES.DefaultView.Sort = "CODI DESC";
                asc = false;
                desc = true;
                lblOrdenacio.Text = "CODI DESC";
            }
            else
            {
                dsDades.ARTICLES.DefaultView.Sort = "CODI ASC";
                asc = true;
                desc = false;
                lblOrdenacio.Text = "CODI ASC";
            }
        }

        private void lblDescripcio_Click(object sender, EventArgs e)
        {
            if (asc)
            {
                dsDades.ARTICLES.DefaultView.Sort = "DESCRIPCIO DESC";
                asc = false;
                desc = true;
                lblOrdenacio.Text = "DESCRIPCIÓ DESC";
            }
            else
            {
                dsDades.ARTICLES.DefaultView.Sort = "DESCRIPCIO ASC";
                asc = true;
                desc = false;
                lblOrdenacio.Text = "DESCRIPCIÓ ASC";
            }
        }

        private void lblQuantitatStock_Click(object sender, EventArgs e)
        {
            if (asc)
            {
                dsDades.ARTICLES.DefaultView.Sort = "QUANTITATSTOCK DESC";
                asc = false;
                desc = true;
                lblOrdenacio.Text = "QUANTITAT STOCK DESC";
            }
            else
            {
                dsDades.ARTICLES.DefaultView.Sort = "QUANTITATSTOCK ASC";
                asc = true;
                desc = false;
                lblOrdenacio.Text = "QUANTITAT STOCK ASC";
            }
        }

        private void lblPreuCost_Click(object sender, EventArgs e)
        {
            if (asc)
            {
                dsDades.ARTICLES.DefaultView.Sort = "PCOST DESC";
                asc = false;
                desc = true;
                lblOrdenacio.Text = "PREU COST DESC";
            }
            else
            {
                dsDades.ARTICLES.DefaultView.Sort = "PCOST ASC";
                asc = true;
                desc = false;
                lblOrdenacio.Text = "PREU COST ASC";
            }
        }

        private void lblPreuVenda_Click(object sender, EventArgs e)
        {
            if (asc)
            {
                dsDades.ARTICLES.DefaultView.Sort = "PVENDA DESC";
                asc = false;
                desc = true;
                lblOrdenacio.Text = "PREU VENDA DESC";
            }
            else
            {
                dsDades.ARTICLES.DefaultView.Sort = "PVENDA ASC";
                asc = true;
                desc = false;
                lblOrdenacio.Text = "PREU VENDA ASC";
            }
        }

        private void lblDescompte_Click(object sender, EventArgs e)
        {
            if (asc)
            {
                dsDades.ARTICLES.DefaultView.Sort = "DESCOMPTE DESC";
                asc = false;
                desc = true;
                lblOrdenacio.Text = "DESCOMPTE DESC";
            }
            else
            {
                dsDades.ARTICLES.DefaultView.Sort = "DESCOMPTE ASC";
                asc = true;
                desc = false;
                lblOrdenacio.Text = "DESCOMPTE ASC";
            }
        }
    }
}