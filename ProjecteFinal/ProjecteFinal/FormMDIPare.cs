using System;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Collections.Generic;

namespace ProjecteFinal
{
    public partial class frmMDIPare : Form
    {
        static OracleConnection cnOracle;
        DataSet dsXML;
        bool obtencioFeta = false;
        public frmMDIPare(OracleConnection connection)
        {
            InitializeComponent();
            cnOracle = connection;
        }

        private void tsmObtenirDades_Click(object sender, EventArgs e)
        {
            dsXML = new DataSet();
            DataSet dsLlegir;

            #region Punt 1 - DataSet Oracle
            this.aRTICLESTableAdapter.Fill(this.oracleDataSet.ARTICLES);
            this.pROVINCIESTableAdapter.Fill(this.oracleDataSet.PROVINCIES);
            this.mUNICIPISTableAdapter.Fill(this.oracleDataSet.MUNICIPIS);
            this.cLIENTSTableAdapter.Fill(this.oracleDataSet.CLIENTS);
            this.cABALBARATableAdapter.Fill(this.oracleDataSet.CABALBARA);
            this.cABFACTURASTableAdapter.Fill(this.oracleDataSet.CABFACTURAS);
            this.lINEASALBARATableAdapter.Fill(this.oracleDataSet.LINEASALBARA);
            this.lINEASFACTURATableAdapter.Fill(this.oracleDataSet.LINEASFACTURA);
            #endregion

            DialogResult dialgoRes = MessageBox.Show("Vols carregar dades del eXistDB?", "Carrega eXistDB", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialgoRes == DialogResult.Yes)
            {

                #region Punt 2 - JAR
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c java.exe -jar transformacions.jar";
                p.Start();
                p.WaitForExit(1000);
                #endregion

                #region Punt 3 - Validacions XML
                p.Close();
                ValidacioXML("clients.xml", "clients.xsd");
                ValidacioXML("productes.xml", "productes.xsd");
                ValidacioXML("municipis.xml", "municipis.xsd");
                ValidacioXML("provincies.xml", "provincies.xsd");
                #endregion

                #region Punt 4 - Modificar DataSet
                dsLlegir = new DataSet();
                dsLlegir.ReadXml("clients.xml");

                dsXML.Merge(dsLlegir);

                dsLlegir = new DataSet();
                dsLlegir.ReadXml("productes.xml");

                dsXML.Merge(dsLlegir);

                dsLlegir = new DataSet();
                dsLlegir.ReadXml("municipis.xml");

                dsXML.Merge(dsLlegir);

                dsLlegir = new DataSet();
                dsLlegir.ReadXml("provincies.xml");

                dsXML.Merge(dsLlegir);
                #endregion

                #region Punt 5 - Dades Persistents
                InserirMunicipis();
                InserirProvincies();
                InserirArticles();
                InserirClients();
                #endregion
            }

            MessageBox.Show("Obtenció de dades finalitzat");

            obtencioFeta = true;
        }

        private void tsmGenerarDades_Click(object sender, EventArgs e)
        {
            if (obtencioFeta)
            {
                cnOracle.Open();
                int nombreClients = Convert.ToInt32(Math.Round(oracleDataSet.CLIENTS.Rows.Count * 0.6, 0));
                Random r = new Random();
                OracleCommand cmd;
                OracleDataReader reader;
                OracleDataSetTableAdapters.CABALBARATableAdapter caTa = new OracleDataSetTableAdapters.CABALBARATableAdapter();
                OracleDataSetTableAdapters.LINEASALBARATableAdapter laTa = new OracleDataSetTableAdapters.LINEASALBARATableAdapter();

                int [] clients = CreacioArray(oracleDataSet.CLIENTS.Rows.Count);

                #region Generació Albarà
                for (int i = 0; i < nombreClients; i++)
                {
                    DataRow dr;
                    dr = oracleDataSet.CABALBARA.NewRow();
                    int vegades = r.Next(1, 6);
                    string poblacio = "";

                    cmd = cnOracle.CreateCommand();
                    cmd.CommandText = "SELECT nom FROM municipis WHERE codi = " + oracleDataSet.CLIENTS.Rows[clients[i]]["codimunicipi"];
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    poblacio = reader[0].ToString();

                    reader.Dispose();
                    reader.Close();

                    for (int j = 0; j < vegades; j++)
                    {
                        dr = oracleDataSet.CABALBARA.NewRow();
                        cmd.CommandText = "SELECT TO_CHAR(projectefinal.seq_albara.NEXTVAL, 'TM9') FROM DUAL";
                        reader = cmd.ExecuteReader();

                        reader.Read();

                        dr[0] = reader[0];

                        reader.Dispose();
                        reader.Close();

                        dr[1] = DateTime.Today;
                        dr[2] = oracleDataSet.CLIENTS.Rows[clients[i]]["codi"];
                        dr[3] = oracleDataSet.CLIENTS.Rows[clients[i]]["nif"];
                        dr[4] = oracleDataSet.CLIENTS.Rows[clients[i]]["nom"];
                        dr[5] = oracleDataSet.CLIENTS.Rows[clients[i]]["adreça"];

                        dr[6] = poblacio;

                        oracleDataSet.CABALBARA.Rows.Add(dr);
                        caTa.Update(dr);

                        CreacioLineaAlbara(laTa, dr[0].ToString());

                        reader.Dispose();
                        reader.Close();
                    }
                    cmd.Dispose();
                }
                #endregion

                #region Generació Factura
                int nombreAlbarans = Convert.ToInt32(Math.Round(oracleDataSet.CABALBARA.Rows.Count * 0.66, 0));

                int[] albarans = CreacioArray(oracleDataSet.CABALBARA.Rows.Count);

                OracleCommand command = new OracleCommand();
                cmd = cnOracle.CreateCommand();

                for (int i = 0; i < nombreAlbarans; i++)
                {
                    command.Connection = cnOracle;
                    command.CommandText = "projectefinal.generarFactura";
                    command.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SELECT TO_CHAR(projectefinal.seq_factura.NEXTVAL, 'TM9') FROM DUAL";
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    command.Parameters.Clear();
                    command.Parameters.Add(new OracleParameter("nAlbara", OracleDbType.Int32)).Value = oracleDataSet.CABALBARA.Rows[albarans[i]]["nalbara"];
                    command.Parameters.Add(new OracleParameter("nFactura", OracleDbType.Int32)).Value = reader[0];
                    command.Parameters.Add(new OracleParameter("dataFactura", OracleDbType.Date)).Value = DateTime.Today;

                    command.ExecuteNonQuery();

                    reader.Dispose();
                    reader.Close();
                }
                cmd.Dispose();
                command.Dispose();
                cnOracle.Close();

                this.cABALBARATableAdapter.Fill(this.oracleDataSet.CABALBARA);
                this.cABFACTURASTableAdapter.Fill(this.oracleDataSet.CABFACTURAS);
                this.lINEASALBARATableAdapter.Fill(this.oracleDataSet.LINEASALBARA);
                this.lINEASFACTURATableAdapter.Fill(this.oracleDataSet.LINEASFACTURA);

                MessageBox.Show("Generació de dades finalitzat");
                #endregion
            }
            else MessageBox.Show("Primer has de obtenir les dades");
        }
        
        private void CreacioLineaAlbara(OracleDataSetTableAdapters.LINEASALBARATableAdapter laTa, string nAlbara)
        {
            Random r = new Random();
            DataRow producte;
            DataRow dr;
            int nProducte;
            int quantitatVenuda;
            int nLinies = r.Next(3, 21);
            List<int> productesAgafats = new List<int>();

            for (int i = 0; i < nLinies; i++)
            {
                nProducte = r.Next(0, oracleDataSet.ARTICLES.Rows.Count);
                while (productesAgafats.Contains(nProducte))
                {
                    nProducte = r.Next(0, oracleDataSet.ARTICLES.Rows.Count);
                }
                productesAgafats.Add(nProducte);
                dr = oracleDataSet.LINEASALBARA.NewRow();
                producte = oracleDataSet.ARTICLES.Rows[nProducte];
                quantitatVenuda = r.Next(1, 21);

                dr[0] = Convert.ToInt32(nAlbara);
                dr[1] = producte["codi"];
                dr[2] = producte["descripcio"];
                dr[3] = quantitatVenuda;
                dr[4] = producte["pvenda"];

                oracleDataSet.LINEASALBARA.Rows.Add(dr);
                laTa.Update(dr);
            }
        }

        private int[] CreacioArray(int llargada)
        {
            int[] taula = new int[llargada];
            Random r = new Random();
            int valorAux = 0;
            int posicio = 0;

            for (int i = 0; i < llargada; i++)
            {
                taula[i] = i;
            }

            int posArray = 0;
            for (int i = 0; i < (int)Math.Pow(llargada, 2); i++)
            {
                if (posArray > llargada - 1) posArray = 0;
                valorAux = taula[posArray];
                posicio = r.Next(0, llargada - 1);
                taula[posArray] = taula[posicio];
                taula[posicio] = valorAux;
                posArray++;
            }

            return taula;
        }

        private void tsmSortir_Click(object sender, EventArgs e)
        {
            // PRIMER COMPROVA SI HI HA HAGUT CANVIS.

            // NO HI HA CANVIS SURT DE L'APLICACIÓ.

            // SI HI HA CANVIS:
            DialogResult resultat = MessageBox.Show("Vols guardar els canvis?", "Tancar el formulari", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch(resultat)
            {
                case DialogResult.Yes:
                    // Guarda canvis i surt de l'aplicació
                    this.Close();
                    break;
                case DialogResult.No:
                    // Fet
                    this.Close();
                    break;
            }
        }

        private void tsmClients_Click(object sender, EventArgs e)
        {
            Form f = new frmClients(oracleDataSet, cnOracle);
            f.Show();
            f.MdiParent = this;

            // TODO TOT
        }

        private void tsmArticles_Click(object sender, EventArgs e)
        {
            Form f = new frmArticles(oracleDataSet, cnOracle);
            f.Show();
            f.MdiParent = this;

            // TODO TOT
        }

        private void tsmAlbarans_Click(object sender, EventArgs e)
        {
            Form f = new frmAlbarans(oracleDataSet.CABALBARA, oracleDataSet.LINEASALBARA);
            f.Show();
            f.MdiParent = this;

            // TODO TOT
        }

        private void tsmFactures_Click(object sender, EventArgs e)
        {
            Form f = new frmFactures(oracleDataSet.CABFACTURAS, oracleDataSet.LINEASFACTURA);
            f.Show();
            f.MdiParent = this;

            // TODO TOT
        }

        private void tsmInformes_Click(object sender, EventArgs e)
        {
            Form f = new frmInformes();
            f.Show();
            f.MdiParent = this;

            // TODO TOT
        }

        private void InserirMunicipis()
        {
            OracleDataSetTableAdapters.MUNICIPISTableAdapter mTa = new OracleDataSetTableAdapters.MUNICIPISTableAdapter();
            int codiDB;
            int codiXML;

            foreach (DataRow r in dsXML.Tables[2].Rows)
            {
                int i = 0;
                bool existeix = false;
                codiXML = Convert.ToInt32(r["codimunicipi"]);

                while (i < oracleDataSet.MUNICIPIS.Rows.Count && !existeix)
                {
                    codiDB = Convert.ToInt32(oracleDataSet.MUNICIPIS.Rows[i]["codi"]);

                    existeix = codiDB == codiXML;

                    if (!existeix)
                        i++;
                }

                if (existeix)
                {
                    DataRow dr = oracleDataSet.MUNICIPIS.Rows[i];
                    dr.BeginEdit();
                    dr[1] = r["nommunicipi"];
                    if (r["abrev"] == DBNull.Value) dr[2] = "";
                    else dr[2] = r["abrev"];
                    dr.EndEdit();

                    try
                    {
                        mTa.Update(dr);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                }
                else
                {
                    DataRow dr;
                    dr = oracleDataSet.MUNICIPIS.NewRow();

                    dr[0] = r["codimunicipi"];
                    dr[1] = r["nommunicipi"];
                    if (r["abrev"] == DBNull.Value) dr[2] = "";
                    else dr[2] = r["abrev"];

                    oracleDataSet.MUNICIPIS.Rows.Add(dr);
                    mTa.Update(dr);
                }
            }
        }

        private void InserirProvincies()
        {
            OracleDataSetTableAdapters.PROVINCIESTableAdapter pTa = new OracleDataSetTableAdapters.PROVINCIESTableAdapter();
            int codiDB;
            int codiXML;

            foreach (DataRow r in dsXML.Tables[3].Rows)
            {
                int i = 0;
                bool existeix = false;
                codiXML = Convert.ToInt32(r["codi"]);

                while (i < oracleDataSet.PROVINCIES.Rows.Count && !existeix)
                {
                    codiDB = Convert.ToInt32(oracleDataSet.PROVINCIES.Rows[i]["codi"]);
                    existeix = codiDB == codiXML;

                    if (!existeix)
                        i++;
                }

                if (existeix)
                {
                    DataRow dr = oracleDataSet.PROVINCIES.Rows[i];
                    dr.BeginEdit();
                    dr[1] = r["nom"];
                    dr.EndEdit();
                    pTa.Update(dr);
                }
                else
                {
                    DataRow dr;
                    dr = oracleDataSet.PROVINCIES.NewRow();

                    dr[0] = r["codi"];
                    dr[1] = r["nom"];

                    oracleDataSet.PROVINCIES.Rows.Add(dr);
                    pTa.Update(dr);
                }
            }
        }

        private void InserirArticles()
        {
            String codiDB;
            String codiXML;
            OracleDataSetTableAdapters.ARTICLESTableAdapter aTa = new OracleDataSetTableAdapters.ARTICLESTableAdapter();

            foreach (DataRow r in dsXML.Tables[1].Rows)
            {
                int i = 0;
                bool existeix = false;

                codiXML = Convert.ToString(r["idProducte"]);


                while (i < oracleDataSet.ARTICLES.Rows.Count && !existeix)
                {
                    codiDB = Convert.ToString(oracleDataSet.ARTICLES.Rows[i]["codi"]);
                    existeix = codiDB == codiXML;

                    if (!existeix)
                        i++;
                }

                if (existeix)
                {
                    string aux = "";
                    double pcost = 0;
                    double pvenda = 0;
                    DataRow dr = oracleDataSet.ARTICLES.Rows[i];
                    dr.BeginEdit();

                    dr[1] = r["descripcio"];
                    dr[2] = r["quantitatstock"];

                    aux = r["pcost"].ToString();
                    pcost = double.Parse(aux, System.Globalization.CultureInfo.InvariantCulture);
                    dr[3] = Math.Round(pcost, 2);

                    aux = r["pvenda"].ToString();
                    pvenda = double.Parse(aux, System.Globalization.CultureInfo.InvariantCulture);
                    dr[4] = Math.Round(pvenda, 2);
                    
                    dr[5] = 0;

                    dr.EndEdit();
                    aTa.Update(dr);
                }
                else
                {
                    DataRow dr;
                    string aux = "";
                    double pcost = 0;
                    double pvenda = 0;
                    dr = oracleDataSet.ARTICLES.NewRow();

                    dr[0] = r["idProducte"];
                    dr[1] = r["descripcio"];
                    dr[2] = r["quantitatstock"];

                    aux = r["pcost"].ToString();
                    pcost = double.Parse(aux, System.Globalization.CultureInfo.InvariantCulture);
                    dr[3] = Math.Round(pcost, 2);

                    aux = r["pvenda"].ToString();
                    pvenda = double.Parse(aux, System.Globalization.CultureInfo.InvariantCulture);
                    dr[4] = Math.Round(pvenda, 2);

                    dr[5] = 0;

                    oracleDataSet.ARTICLES.Rows.Add(dr);
                    aTa.Update(dr);
                }
            }
        }

        private void InserirClients()
        {
            OracleDataSetTableAdapters.CLIENTSTableAdapter cTa = new OracleDataSetTableAdapters.CLIENTSTableAdapter();
            string codiXML;
            string codiBD;

            foreach (DataRow r in dsXML.Tables[0].Rows)
            {
                int i = 0;
                bool existeix = false;
                codiXML = r["codi"].ToString();

                while (i < oracleDataSet.CLIENTS.Rows.Count && !existeix)
                {
                    codiBD = oracleDataSet.CLIENTS.Rows[i]["codi"].ToString();
                    existeix = (codiBD == codiXML);

                    if (!existeix) i++;
                }

                if (existeix)
                {
                    DataRow dr = oracleDataSet.CLIENTS.Rows[i];
                    dr.BeginEdit();

                    dr[1] = r["NIF"];
                    dr[2] = r["nom"];
                    dr[3] = r["adreca"];
                    dr[4] = Convert.ToInt32(r["codipostal"].ToString().Substring(0, 2));
                    dr[5] = r["municipi"];

                    if (r["telefon"] == DBNull.Value) dr[6] = 0;
                    else dr[6] = r["telefon"];

                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";

                    dr.EndEdit();
                    cTa.Update(dr);
                }
                else
                {
                    DataRow dr;
                    dr = oracleDataSet.CLIENTS.NewRow();

                    dr[0] = r["codi"];
                    dr[1] = r["NIF"];
                    dr[2] = r["nom"];
                    dr[3] = r["adreca"];
                    dr[4] = Convert.ToInt32(r["codipostal"].ToString().Substring(0, 2));
                    dr[5] = r["municipi"];

                    if (r["telefon"] == DBNull.Value) dr[6] = 0;
                    else dr[6] = r["telefon"];

                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";

                    oracleDataSet.CLIENTS.Rows.Add(dr);
                    cTa.Update(dr);
                }
            }
        }

        private void ValidacioXML(string xmlFile, string xsdFile)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsdFile);
                settings.ValidationType = ValidationType.Schema;
                XmlDocument document = new XmlDocument();
                document.Load(xmlFile);
                XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);
                while (rdr.Read()) { }

                // MessageBox.Show(xmlFile + " ÉS VÀLID");
            }
            catch (Exception e)
            {
                MessageBox.Show(xmlFile + " NO ÉS VÀLID" + "\n" + e.Message);
            }
        }
        }
}