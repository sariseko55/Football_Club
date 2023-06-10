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

namespace Football_Club
{
    public partial class frmmacdetay : Form
    {
        public frmmacdetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string ad;

        private void frmmacdetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Futbol_BilgiDataSet1.Maclar' table. You can move, or remove it, as needed.
            // this.MaclarTableAdapter.Fill(this.Futbol_BilgiDataSet1.Maclar);
            // TODO: This line of code loads data into the 'Futbol_BilgiDataSet.Futbolcular' table. You can move, or remove it, as needed.
            //this.FutbolcularTableAdapter.Fill(this.Futbol_BilgiDataSet.Futbolcular);

            SqlDataAdapter da = new SqlDataAdapter("Select * from Maclar where Id='" + ad + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            vGridControl1.DataSource = dt;
            bgl.baglanti().Close();




        }
        //frmmacraporual frmacrapor;
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    if (frmacrapor==null||frmacrapor.IsDisposed)
        //    {
        //        frmacrapor = new frmmacraporual();
        //        frmacrapor.Show();
            //}
            
      
     }
}

