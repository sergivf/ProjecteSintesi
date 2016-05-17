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
    public partial class frmPare : Form
    {
        BindingSource origen;
        bool modeEdicio = false;

        public frmPare()
        {
            InitializeComponent();

            origen = new BindingSource();
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
                    origen.RemoveCurrent();
                }
            }
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                this.Text = "Ctrl + E";
                // Posarà el registre en mode d’edició.
                // TODO TOT
            }
            else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                this.Text = "Ctrl + A";
                // Cancel·larà els canvis fets en el registre que estem modificant.
                // TODO TOT
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                this.Text = "Ctrl + G";
                // Gravarà a l’origen de dades, els canvis fets en el registre que estem modificant
                // TODO TOT
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            origen.MoveLast();
        }
    }
}