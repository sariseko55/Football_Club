using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using Football_Club.Raporlar;
using Football_Club.Formlar;


namespace Football_Club
{
    public partial class frmanamodul : Form
    {
        public frmanamodul() => InitializeComponent();
        [STAThread]
        private static void Main(string[] args)
        {
            Application.Run(new frmanamodul());
        }

        private void panelControl1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }



        private void btnkadro_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement14_Click(object sender, EventArgs e)
        {

        }


        //frmsporcukayit frsavesoccer;
        //private void accordionControlElement3_Click(object sender, EventArgs e)
        //{
        //    if (frsavesoccer == null || frsavesoccer.IsDisposed)
        //    {
        //        frsavesoccer = new frmsporcukayit();
        //        frsavesoccer.MdiParent = this;
        //        frsavesoccer.Show();
        //    }




        private void accordionControl1_Click_1(object sender, EventArgs e)
        {

        }


        private void accordionControlElement11_Click(object sender, EventArgs e)
        {

            //frmraporgoruntule rapor = new frmraporgoruntule();
            //rapor.Show();

        }

        private void accordionControlElement18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        frmmaclar maclar;
        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (maclar == null || maclar.IsDisposed)
            {
                maclar = new frmmaclar();
                maclar.MdiParent = this;
                maclar.Show();
            }
        }



        frmantrenman frant;
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            //if (frant==null || frant.IsDisposed)
            //{
            //    frant = new frmantrenman();
            //    frant.MdiParent = this;
            //    frant.Show();
            //}
        }

        frmajanda ajandam;
        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            //if (ajandam==null||ajandam.IsDisposed)
            //{
            //    ajandam = new frmajanda();
            //    ajandam.MdiParent = this;
            //    ajandam.Show();
            //}
        }

        frmtakimekle takimekle;
        private void accordionControlElement32_Click(object sender, EventArgs e)
        {
            if (takimekle == null || takimekle.IsDisposed)
            {
                takimekle = new frmtakimekle();
                //takimekle.MdiParent = this;
                takimekle.Show();
            }
        }



        //frmraporgoruntule goruntule;
        private void accordionControlElement34_Click(object sender, EventArgs e)
        {
            //if (goruntule == null || goruntule.IsDisposed)
            //{
            //    goruntule = new frmraporgoruntule();
            //    goruntule.Show();
            //}
        }

        private void accordionControlElement34_Click_1(object sender, EventArgs e)
        {
            raporformu fr = new raporformu();
            fr.Show();
            //XtraReport1 rapor = new XtraReport1();
            //rapor.RequestParameters = false;
            //rapor.ExportToPdf("Report");
        }



        private void accordionControlElement33_Click(object sender, EventArgs e)
        {
            // DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport(); // XtraReport nesnemize oluşturduğumuz Report bileşenimizin adını veriyoruz.


            //DevExpress.XtraReports.UI.ReportPrintTool print = new DevExpress.XtraReports.UI.ReportPrintTool(report);
            //print.ShowPreview(); // PDF önizlemesini gösteriyoruz.   
            //Football_Club.Raporlar.frmYazdir frmraporum = new Football_Club.Raporlar.frmYazdir();
            //frmraporum.ShowPreviewDialog();



        }

        //frmtacticpad tactical;
        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            //if (tactical==null || tactical.IsDisposed)
            //{
            //    tactical = new frmtacticpad();
            //    tactical.MdiParent = this;
            //    tactical.Show();

            //}
        }
        frmanasayfa fr;
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new frmanasayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        frmsporcukayit frsavesoccer;
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (frsavesoccer == null || frsavesoccer.IsDisposed)
            {
                frsavesoccer = new frmsporcukayit();
                frsavesoccer.MdiParent = this;
                frsavesoccer.Show();
            }
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }
        frmkadro fr2;
        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {

            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new frmkadro();
                fr2.MdiParent = this;
                fr2.Show();
            }

        }

        //frmmaclar maclar;
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            if (maclar == null || maclar.IsDisposed)
            {
                maclar = new frmmaclar();
                maclar.MdiParent = this;
                maclar.Show();
            }
        }
        //frmantrenman frant;
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (frant == null || frant.IsDisposed)
            {
                frant = new frmantrenman();
                frant.MdiParent = this;
                frant.Show();
            }
        }

        frmtacticpad tactical;
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (tactical == null || tactical.IsDisposed)
            {
                tactical = new frmtacticpad();
                tactical.MdiParent = this;
                tactical.Show();

            }
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {

        }

        frmraporsayfası raporum;
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            if (raporum == null || raporum.IsDisposed)
            {
                raporum = new frmraporsayfası();
                raporum.Show();

            }

        }
        //frmajanda ajandam;
        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            if (ajandam == null || ajandam.IsDisposed)
            {
                ajandam = new frmajanda();
                ajandam.MdiParent = this;
                ajandam.Show();
            }
        }
        frmayarlar frayar;
        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            if (frayar == null || frayar.IsDisposed)
            {
                frayar = new frmayarlar();
                frayar.Show();
            }
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //frmBireysel bireysel;
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            //if (bireysel == null || bireysel.IsDisposed)
            //{
            //    bireysel = new frmBireysel();
            //    bireysel.MdiParent = this;
            //    bireysel.Show();

            //}
        }

        frmpersoneller personel;
        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (personel == null || personel.IsDisposed)
            {
                personel = new frmpersoneller();
                personel.MdiParent = this;
                personel.Show();
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }






        //}
        //frmraporgoruntule goruntule;
        //private void accordionControlElement17_Click(object sender, EventArgs e);
        //{
        //    goruntule = new frmraporgoruntule();
        //    goruntule.Show();
        //}


        //public object tactical { get; set; }
    }
}