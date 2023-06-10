using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Club
{
    public partial class frmajanda : Form
    {
        public frmajanda()
        {
            InitializeComponent();
        }

        private void frmajanda_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet3.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter1.Fill(this.futbol_BilgiDataSet3.Resources);
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet4.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.futbol_BilgiDataSet4.Resources);
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet4.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.futbol_BilgiDataSet4.Appointments);
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet.Futbolcular' table. You can move, or remove it, as needed.
            //this.futbolcularTableAdapter.Fill(this.futbol_BilgiDataSet.Futbolcular);

        }
    }
}
