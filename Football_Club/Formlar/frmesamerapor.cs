using DevExpress.XtraReports.UI;
using Football_Club.Raporlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Club.Formlar
{
    public partial class frmesamerapor : Form
    {
        public frmesamerapor()
        {
            InitializeComponent();
        }

        private void frmesamerapor_Load(object sender, EventArgs e)
        {
            EsameListesi rapor = new EsameListesi();
            //rapor.RequestParameters = false;
            rapor.ShowPreview();
            ////rapor.ExportToPdf("Report");
        }
    }
}
