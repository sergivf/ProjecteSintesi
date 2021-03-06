﻿using System;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Collections.Generic;
using System.Xml.Xsl;

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

            // Carregarà sobre el dataset totes les dades de l'Oracle amb el (Fill)
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

            // Ens pregunta si volem carregar les dades de la base de dades (eXist)
            DialogResult dialgoRes = MessageBox.Show("Vols carregar dades del eXistDB?", "Carrega eXistDB", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialgoRes == DialogResult.Yes)
            {
                // Execució del JAR mitjançant un procés
                #region Punt 2 - JAR
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c java.exe -jar transformacions.jar";
                p.Start();
                p.WaitForExit(1000);
                #endregion

                // Validació dels fitxers XML amb l'XSD
                #region Punt 3 - Validacions XML
                p.Close();
                ValidacioXML("clients.xml", "clients.xsd");
                ValidacioXML("productes.xml", "productes.xsd");
                ValidacioXML("municipis.xml", "municipis.xsd");
                ValidacioXML("provincies.xml", "provincies.xsd");
                #endregion

                // El codi d'aquesta region s'encarrega de llegir tots els xml i afegir-los a un sol dataset
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

                // S'encarrega de fer persistents les dades, és a dir, de fer els inserts a les taules de la base de dades Oracle
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
                try
                {
                    cnOracle.Open();
                    int nombreClients = Convert.ToInt32(Math.Round(oracleDataSet.CLIENTS.Rows.Count * 0.6, 0));
                    Random r = new Random();
                    OracleCommand cmd;
                    OracleDataReader reader;
                    OracleDataSetTableAdapters.CABALBARATableAdapter caTa = new OracleDataSetTableAdapters.CABALBARATableAdapter();
                    OracleDataSetTableAdapters.LINEASALBARATableAdapter laTa = new OracleDataSetTableAdapters.LINEASALBARATableAdapter();

                    // Creació array ens crearà un array amb números aleatoris, indicant de quins clients seran els albarans que creem
                    int[] clients = CreacioArray(oracleDataSet.CLIENTS.Rows.Count);

                    // El codi d'aquesta region s'encarrega de generar els albarans, tant la capçalera com les línies
                    #region Generació Albarà
                    DataRow dr;

                    // For -> nombre d'albarans que crearem
                    for (int i = 0; i < nombreClients; i++)
                    {
                        int vegades = r.Next(1, 6);
                        string poblacio = "";

                        // D'aquesta select treurem la població per després inserir-la a la CABALBARA
                        cmd = cnOracle.CreateCommand();
                        cmd.CommandText = "SELECT nom FROM municipis WHERE codi = " + oracleDataSet.CLIENTS.Rows[clients[i]]["codimunicipi"];
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        poblacio = reader[0].ToString();

                        reader.Dispose();
                        reader.Close();

                        // For -> número d'albarans que tindrà el client
                        for (int j = 0; j < vegades; j++)
                        {
                            // Agafarà el següent número de la seqüència
                            cmd.CommandText = "SELECT TO_CHAR(projectefinal.seq_albara.NEXTVAL, 'TM9') FROM DUAL";
                            reader = cmd.ExecuteReader();
                            dr = oracleDataSet.CABALBARA.NewRow();

                            reader.Read();

                            // Insereix totes les dades en el DataRow
                            dr[0] = reader[0];

                            reader.Dispose();
                            reader.Close();

                            dr[1] = DateTime.Today;
                            dr[2] = oracleDataSet.CLIENTS.Rows[clients[i]]["codi"];
                            dr[3] = oracleDataSet.CLIENTS.Rows[clients[i]]["nif"];
                            dr[4] = oracleDataSet.CLIENTS.Rows[clients[i]]["nom"];
                            dr[5] = oracleDataSet.CLIENTS.Rows[clients[i]]["adreça"];

                            dr[6] = poblacio;

                            // Afegeix la fila que hem creat a l'OracleDataSet
                            oracleDataSet.CABALBARA.Rows.Add(dr);
                            // Update de la base de dades oracle, passant-li el DataRow
                            caTa.Update(dr);

                            // Ens crearà les línies de l'albarà
                            CreacioLineaAlbara(laTa, dr[0].ToString());

                            reader.Dispose();
                            reader.Close();
                        }
                        cmd.Dispose();
                    }
                    #endregion

                    #region Generació Factura
                    int nombreAlbarans = Convert.ToInt32(Math.Round(oracleDataSet.CABALBARA.Rows.Count * 0.66, 0));

                    // Array que hi haurà els albarans que haurem de passar a factura
                    int[] albarans = CreacioArray(oracleDataSet.CABALBARA.Rows.Count);

                    OracleCommand command = new OracleCommand();
                    cmd = cnOracle.CreateCommand();

                    // For -> Nombre d'albarans que es passaran a factura
                    for (int i = 0; i < nombreAlbarans; i++)
                    {
                        // PROCEDIMENT ENMAGATZEMAT que ens farà tota la generació d'una factura, restar stock, eliminar l'albarà i crear la factura
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
                    this.aRTICLESTableAdapter.Fill(this.oracleDataSet.ARTICLES);

                    MessageBox.Show("Generació de dades finalitzat");
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Primer has de obtenir les dades");
        }
        
        /// <summary>
        /// Funció que ens crearà les línies d'albarà i les guardarà tant a l'OracleDataSet com a la base de dades Oracle
        /// </summary>
        /// <param name="laTa"></param>
        /// <param name="nAlbara"></param>
        private void CreacioLineaAlbara(OracleDataSetTableAdapters.LINEASALBARATableAdapter laTa, string nAlbara)
        {
            Random r = new Random();
            DataRow producte;
            DataRow dr;
            int nProducte;
            int quantitatVenuda;
            int nLinies = r.Next(3, 21);
            List<int> productesAgafats = new List<int>();

            // Número de línies d'albarà que crearà per l'albarà
            for (int i = 0; i < nLinies; i++)
            {
                nProducte = r.Next(0, oracleDataSet.ARTICLES.Rows.Count);
                // Mentres coincideixin els productes agafarà de nous
                // While fet per no fer que un albarà tingui dos productes repetits
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

                // Updates
                oracleDataSet.LINEASALBARA.Rows.Add(dr);
                laTa.Update(dr);
            }
        }

        /// <summary>
        /// Funció que s'encarrega de crear un array i barrejar els números
        /// Farà els aleatoris de clients i albarans
        /// </summary>
        /// <param name="llargada"></param>
        /// <returns></returns>
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

        private void tsmClients_Click(object sender, EventArgs e)
        {
            if (obtencioFeta)
            {
                Form f = new frmClients(oracleDataSet, cnOracle);
                f.Show();
                f.MdiParent = this;
            }
            else MessageBox.Show("Primer has d'obtenir les dades");
        }

        private void tsmArticles_Click(object sender, EventArgs e)
        {
            if (obtencioFeta)
            {
                Form f = new frmArticles(oracleDataSet, cnOracle);
                f.Show();
                f.MdiParent = this;
            }
            else MessageBox.Show("Primer has d'obtenir les dades");
        }

        private void tsmAlbarans_Click(object sender, EventArgs e)
        {
            if (obtencioFeta)
            {
                Form f = new frmAlbarans(oracleDataSet, cnOracle, tableAdapterManager);
                f.Show();
                f.MdiParent = this;
            }
            else MessageBox.Show("Primer has d'obtenir les dades");
        }

        private void tsmFactures_Click(object sender, EventArgs e)
        {
            if (obtencioFeta)
            {
                Form f = new frmFactures(oracleDataSet, cnOracle, tableAdapterManager);
                f.Show();
                f.MdiParent = this;
            }
            else MessageBox.Show("Primer has d'obtenir les dades");
        }

        /// <summary>
        /// Inserirà els municipis del DataSet (que té les dades del fitxer XML de municipis) cap a la base de dades d'Oracle
        /// </summary>
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

        /// <summary>
        /// Inserirà les províncies del DataSet (que té les dades del fitxer XML de províncies) cap a la base de dades d'Oracle
        /// </summary>
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

        /// <summary>
        /// Inserirà els articles del DataSet (que té les dades del fitxer XML d'articles) cap a la base de dades d'Oracle
        /// </summary>
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

        /// <summary>
        /// Inserirà els clients del DataSet (que té les dades del fitxer XML de clients) cap a la base de dades d'Oracle
        /// </summary>
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

        /// <summary>
        /// Funció que s'encarregarà de validar els XML
        /// </summary>
        /// <param name="xmlFile">Indica quin és el nom del fitxer xml</param>
        /// <param name="xsdFile">Indica quin és el nom del fitxer xsd</param>
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
            }
            catch (Exception e)
            {
                MessageBox.Show(xmlFile + " NO ÉS VÀLID" + "\n" + e.Message);
            }
        }

        private void eliminarDadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnOracle.Open();
            DialogResult dialgoRes = MessageBox.Show("Estàs segur que vols eliminar les dades de la base de dades d'Oracle", "Eliminar Oracle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialgoRes == DialogResult.Yes)
            {
                try
                {
                    OracleCommand command = new OracleCommand();

                    command.Connection = cnOracle;
                    command.CommandText = "projectefinal.eliminarDades";
                    command.CommandType = CommandType.StoredProcedure;

                    command.ExecuteNonQuery();

                    cnOracle.Close();

                    obtencioFeta = false;

                    MessageBox.Show("S'han esborrat les dades");
                }
                catch (Exception ez)
                {
                    MessageBox.Show(ez.Message);
                }
            }
        }

        private void llistarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void unAlbaràToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformes f = new frmInformes(cnOracle, oracleDataSet);

            f.TxtFinsA.Hide();
            f.TxtFinsA.Enabled = false;
            f.LblFinsA.Hide();
            f.Albara = true;
            f.Factura = false;
            f.Show();
            f.MdiParent = this;
        }

        private void facturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformes f = new frmInformes(cnOracle, oracleDataSet);

            f.TxtFinsA.Hide();
            f.TxtFinsA.Enabled = false;
            f.LblFinsA.Hide();
            f.Factura = true;
            f.Albara = false;
            f.Show();
            f.MdiParent = this;
        }

        private void entreNúmerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformes f = new frmInformes(cnOracle, oracleDataSet);

            f.TxtFinsA.Show();
            f.TxtFinsA.Enabled = true;
            f.LblFinsA.Show();
            f.Albara = true;
            f.Factura = false;
            f.Show();
            f.MdiParent = this;
        }
    }
}