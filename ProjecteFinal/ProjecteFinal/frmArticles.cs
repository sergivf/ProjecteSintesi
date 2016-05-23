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

        public frmArticles(OracleDataSet dsDades, OracleConnection cnOracle)
        {
            InitializeComponent();
            this.dsDades = dsDades;
            this.cnOracle = cnOracle;

            cnOracle.Open();

            dsDades.ARTICLES.DefaultView.Sort = "CODI ASC";

            Origen.DataSource = dsDades.ARTICLES;
            Origen.MoveFirst();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            dr = ((DataRowView)Origen.Current).Row;

            EmplenarDades();

            // Esdeveniment que saltarà quan canviem de registre actual
            Origen.CurrentChanged += Origen_CurrentChanged;
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
        private void MostrarBuits()
        {
            txtCodi.Text = "";
            txtDescripcio.Text = "";
            txtQuantitatStock.Text = "";
            txtPCost.Text = "";
            txtPVenda.Text = "";
            txtDescompte.Text = "";
        }

        /// <summary>
        /// Emplena les dades amb el registre actual
        /// </summary>
        /// <param name="dr"></param>
        private void EmplenarDades()
        {
            txtCodi.Text = dr["codi"].ToString();
            txtDescripcio.Text = dr["descripcio"].ToString();
            txtQuantitatStock.Text = dr["quantitatstock"].ToString();
            txtPCost.Text = dr["pcost"].ToString();
            txtPVenda.Text = dr["pvenda"].ToString();
            txtDescompte.Text = dr["descompte"].ToString();
        }

        /// <summary>
        /// Canvia a mode edició
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModeEdicio_Click(object sender, EventArgs e)
        {
            ModeEdicio = true;
            txtDescripcio.ReadOnly = false;
            txtQuantitatStock.ReadOnly = false;
            txtPCost.ReadOnly = false;
            txtPVenda.ReadOnly = false;
            txtDescompte.ReadOnly = false;

            btnModeEdicio.Hide();
            btnGuardarCanvis.Show();
            btnCancelarCanvis.Show();
        }

        /// <summary>
        /// Cancel·larà tots els canvis i treurà el mode edició
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarCanvis_Click(object sender, EventArgs e)
        {
            ModeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            txtDescripcio.ReadOnly = true;
            txtQuantitatStock.ReadOnly = true;
            txtPCost.ReadOnly = true;
            txtPVenda.ReadOnly = true;
            txtDescompte.ReadOnly = true;

            EmplenarDades();
        }

        /// <summary>
        /// Guardarà tots els canvis i treurà el mode edició
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarCanvis_Click(object sender, EventArgs e)
        {
            double valorDecimal = 0;
            int valorEnter = 0;
            ModeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();
            ModeConsulta();

            try
            {
                aTa = new OracleDataSetTableAdapters.ARTICLESTableAdapter();

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

        private void ModeConsulta()
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
    }
}
