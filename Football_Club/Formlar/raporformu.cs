using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DocumentView;
using DevExpress.XtraReports;
using Football_Club.Raporlar;
using DevExpress.XtraReports.UI;
using System.IO;

namespace Football_Club.Formlar
{
    public partial class raporformu : Form
    {
        public raporformu()
        {
            InitializeComponent();
        }

        private void raporformu_Load(object sender, EventArgs e)
        {

            XtraReport1 rapor = new XtraReport1();
            //rapor.RequestParameters = false;
            rapor.ShowPreview();
            ////rapor.ExportToPdf("Report");
        }
    }
}
