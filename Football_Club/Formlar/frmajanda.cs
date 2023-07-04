using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Windows.Forms;

namespace Football_Club.Formlar
{
    public partial class frmajanda : Form
    {
        private object schedulerTestDataSet;
        private object schedulerTestDataset;

        public frmajanda()
        {
            InitializeComponent();
        }

        private void frmajanda_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet8.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.futbol_BilgiDataSet8.Resources);
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet8.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter1.Fill(this.futbol_BilgiDataSet8.Appointments);
            // TODO: This line of code loads data into the 'futbol_BilgiDataSet7.Appointments' table. You can move, or remove it, as needed.
            //this.appointmentsTableAdapter.Fill(this.futbol_BilgiDataSet7.Appointments);

        }

        private void appointmentsBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void appointmentsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void schedulerDataStorage1_AppointmentChanging(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            
        }

        private void schedulerDataStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter1.Update(futbol_BilgiDataSet8);
            futbol_BilgiDataSet8.AcceptChanges();
        }
    }
}
