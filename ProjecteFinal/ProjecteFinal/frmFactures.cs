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
    public partial class frmFactures : frmPare
    {
        OracleDataSet.CABFACTURASDataTable dsCabFactures;
        OracleDataSet.LINEASFACTURADataTable dsLiniaFactures;

        public frmFactures(OracleDataSet.CABFACTURASDataTable dsCabFactures, OracleDataSet.LINEASFACTURADataTable dsLiniaFactures)
        {
            InitializeComponent();

            this.dsCabFactures = dsCabFactures;
            this.dsLiniaFactures = dsLiniaFactures;
        }
    }
}