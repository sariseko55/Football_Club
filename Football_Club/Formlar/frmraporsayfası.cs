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
    public partial class frmraporsayfası : Form
    {
        public frmraporsayfası()
        {
            InitializeComponent();
        }

       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           XtraReport1 report1 = new XtraReport1();
            report1.ShowPreview();
            
        }

        private void frmraporsayfası_Load(object sender, EventArgs e)
        {

        }

        
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
           EsameListesi esamem = new EsameListesi();
            esamem.ShowPreview();

            
        }
    }
}
