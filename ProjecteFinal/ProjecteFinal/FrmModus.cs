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
    public partial class FrmModus : Form
    {
        bool modusManual;
        bool modusAutomatic;

        public bool ModusManual
        {
            get { return modusManual; }
            set { modusManual = value; }
        }

        public bool ModusAutomatic
        {
            get { return modusAutomatic; }
            set { modusAutomatic = value; }
        }

        public FrmModus()
        {
            InitializeComponent();
            ModusManual = false;
            ModusAutomatic = false;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            ModusManual = true;
            this.Close();
        }

        private void btnAutomatica_Click(object sender, EventArgs e)
        {
            modusAutomatic = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
