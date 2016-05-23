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
    // Tots els altres formularis (clients, articles, etc) hereten d'aquest formulari, tindràn un bindingsource i el KeyDown
    public partial class frmPare : Form
    {
        BindingSource origen;
        bool modeEdicio = false;

        public frmPare()
        {
            InitializeComponent();

            origen = new BindingSource();
            this.MouseWheel += FrmPare_MouseWheel;
        }

        private void FrmPare_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && !modeEdicio)
            {
                origen.MoveNext();
            }
            else if (e.Delta < 0 && !modeEdicio)
            {
                origen.MovePrevious();
            }
        }

        public BindingSource Origen
        {
            get { return origen; }
            set { origen = value; }
        }

        public bool ModeEdicio
        {
            get { return modeEdicio; }
            set { modeEdicio = value; }
        }

        public Button BtnModeEdicio
        {
            get { return btnModeEdicio; }
            set { btnModeEdicio = value; }
        }

        public Button BtnGuardarCanvis
        {
            get { return btnGuardarCanvis; }
            set { btnGuardarCanvis = value; }
        }

        public Button BtnCancelarCanvis
        {
            get { return btnCancelarCanvis; }
            set { btnCancelarCanvis = value; }
        }

        private void frmPare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                if (!modeEdicio) origen.MovePrevious();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                if (!modeEdicio) origen.MoveNext();
            }
            else if (e.KeyCode == Keys.Home && e.Modifiers == Keys.Control)
            {
                if (!modeEdicio) origen.MoveFirst();
            }
            else if (e.KeyCode == Keys.End && e.Modifiers == Keys.Control)
            {
                if (!modeEdicio) origen.MoveLast();
            }
            else if (e.KeyCode == Keys.Insert && e.Modifiers == Keys.Control)
            {
                this.Text = "Ctrl + Insert";
                if (!modeEdicio)
                {
                    // origen.Insert();
                }
            }
            else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (!modeEdicio && origen.Count > 0)
                {
                    EliminarRegistreActual();
                }
            }
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                if (!modeEdicio)
                {
                    modeEdicio = true;
                    btnModeEdicio.Hide();
                    btnGuardarCanvis.Show();
                    btnCancelarCanvis.Show();
                    ActivarModeEdicio();
                }
            }
            else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                if (modeEdicio)
                {
                    modeEdicio = false;

                    btnModeEdicio.Show();
                    btnGuardarCanvis.Hide();
                    btnCancelarCanvis.Hide();

                    ModeNavegacio();

                    EmplenarDades();
                }
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                if (modeEdicio)
                {
                    modeEdicio = false;

                    btnModeEdicio.Show();
                    btnGuardarCanvis.Hide();
                    btnCancelarCanvis.Hide();

                    ModeNavegacio();

                    GuardarCanvis();
                }
            }
        }
        
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            origen.MoveLast();
        }

        private void btnModeEdicio_Click(object sender, EventArgs e)
        {
            modeEdicio = true;
            btnModeEdicio.Hide();
            btnGuardarCanvis.Show();
            btnCancelarCanvis.Show();

            ActivarModeEdicio();
        }

        public virtual void ActivarModeEdicio()
        {

        }

        private void btnGuardarCanvis_Click(object sender, EventArgs e)
        {
            if (modeEdicio)
            {
                modeEdicio = false;

                btnModeEdicio.Show();
                btnGuardarCanvis.Hide();
                btnCancelarCanvis.Hide();

                ModeNavegacio();

                GuardarCanvis();
            }
        }

        public virtual void GuardarCanvis()
        {
            
        }

        public virtual void ModeNavegacio()
        {

        }

        private void btnCancelarCanvis_Click(object sender, EventArgs e)
        {
            modeEdicio = false;

            btnModeEdicio.Show();
            btnGuardarCanvis.Hide();
            btnCancelarCanvis.Hide();

            ModeNavegacio();

            EmplenarDades();
        }

        public virtual void EmplenarDades()
        {

        }

        public virtual void EliminarRegistreActual()
        {

        }

        public virtual void MostrarBuits()
        {

        }
    }
}