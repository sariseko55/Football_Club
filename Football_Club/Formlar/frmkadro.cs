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
    public partial class frmkadro : Form
    {
        public frmkadro()
        {
            InitializeComponent();
        }

        #region Futbolcu Listele
        void futbolculistele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Adi,Soyadi,DogumTarihi,Telefon,Mevki,Boy,Kilo,Mail,Notlar,VeliAd,VeliTel from Futbolcular order by Adi asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        #endregion



        void kalecilistele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Adi,Soyadi,DogumTarihi,Mevki,Boy,Kilo,VeliAd,VeliTel from Futbolcular where Mevki like '%" + "Kaleci" + "%' order by Adi asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void defanslistele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlDataAdapter adap2 = new SqlDataAdapter("Select Adi,Soyadi,DogumTarihi,Mevki,Boy,Kilo,VeliAd,VeliTel from Futbolcular where Mevki ='STOPER' OR Mevki='SOL STOPER' OR Mevki='SAĞ STOPER'OR Mevki='SAĞ BEK'OR Mevki='SOL BEK' order by Adi asc", bgl.baglanti());
            DataTable dt2 = new DataTable();
            adap2.Fill(dt2);
            gridControl1.DataSource = dt2;
            bgl.baglanti().Close();
        }
        void ortasahalistele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Adi,Soyadi,DogumTarihi,Mevki,Boy,Kilo,VeliAd,VeliTel from Futbolcular where Mevki='ORTASAHA MERKEZ' OR Mevki='ORTASAHA SAĞ' or Mevki='ORTASAHA SOL' or Mevki='10 NUMARA' or Mevki='SAĞ FORVET' or Mevki='SOL FORVET' or Mevki='10 NUMARA' order by Adi asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void forvetlistele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Adi,Soyadi,DogumTarihi,Mevki,Boy,Kilo,VeliAd,VeliTel from Futbolcular where Mevki ='FORVET' or Mevki='SOL FORVET' OR Mevki='SAĞ FORVET' order by Adi asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void toplamsporcu()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }


        private void frmkadro_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'Futbol_BilgiDataSet5.Futbolcular' table. You can move, or remove it, as needed.
            this.FutbolcularTableAdapter.Fill(this.Futbol_BilgiDataSet5.Futbolcular);
            futbolculistele();
            kalecilistele();
            defanslistele();
            ortasahalistele();
            forvetlistele();
            toplamsporcu();
            var kolon = gridView1.Columns.Add();
            kolon.FieldName = "Sıra No";
            kolon.Visible = true;
            kolon.Width = 50;
            kolon.VisibleIndex = 0; //ilk sıraya ekler.
            kolon.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            kolon.OptionsColumn.AllowEdit = false;
            kolon.OptionsColumn.AllowFocus = false;
            radiotumsporcular.Checked = true;

            this.reportViewer1.RefreshReport();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }


        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmrapor frrap = new frmrapor();
            //frrap.Show();


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radiotumsporcular.Checked == true)
            {

                radiotumsporcular.BackColor = Color.Red;
                futbolculistele();
            }
            else
            {
                radiotumsporcular.BackColor = Color.Transparent;
            }
        }

        private void radiodefans_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioforvet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from Futbolcular where Grup='A' order by Adi asc", bgl.baglanti());
            adapt.Fill(table);
            gridControl1.DataSource = table;
            bgl.baglanti().Close();
            lblgrupadi.Text = btnA.Text;

            //sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular WHERE Grup='A'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();

        }

        private void btnB_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bglB = new sqlbaglantisi();
            DataTable tablea = new DataTable();
            SqlDataAdapter adapta = new SqlDataAdapter("Select * from Futbolcular where Grup='B' order by Adi asc", bglB.baglanti());
            adapta.Fill(tablea);
            gridControl1.DataSource = tablea;
            bglB.baglanti().Close();
            lblgrupadi.Text = btnB.Text;

            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Grup='B'", bglB.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bglB.baglanti().Close();
        }





        private void btnC_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bglC = new sqlbaglantisi();
            DataTable tablec = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from Futbolcular where Grup='C' order by Adi asc", bglC.baglanti());
            adapt.Fill(tablec);
            gridControl1.DataSource = tablec;
            lblgrupadi.Text = btnC.Text;
            bglC.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Grup='C'", bglC.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bglC.baglanti().Close();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgld = new sqlbaglantisi();
            DataTable tabled = new DataTable();
            SqlDataAdapter adaptd = new SqlDataAdapter("Select * from Futbolcular where Grup='D' order by Adi asc", bgld.baglanti());
            adaptd.Fill(tabled);
            gridControl1.DataSource = tabled;
            lblgrupadi.Text = btnD.Text;
            bgld.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Grup='D'", bgld.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgld.baglanti().Close();
        }




        sqlbaglantisi bgl = new sqlbaglantisi();
        private void radiotumsporcular_CheckedChanged(object sender, EventArgs e)
        {
            futbolculistele();
            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular ", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void radiokaleci_CheckedChanged(object sender, EventArgs e)
        {
            if (radiokaleci.Checked == true)
            {
                radiokaleci.BackColor = Color.Red;
                kalecilistele();
            }
            else
            {
                radiokaleci.BackColor = Color.Transparent;
            }
            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Mevki='Kaleci'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void radiodefans_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radiodefans.Checked == true)
            {
                radiodefans.BackColor = Color.Red;
                defanslistele();
            }
            else
            {
                radiodefans.BackColor = Color.Transparent;
            }

            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Mevki ='STOPER' OR Mevki='SOL STOPER' OR Mevki='SAĞ STOPER' OR Mevki='SAĞ BEK' OR Mevki='SOL BEK'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void radioortasaha_CheckedChanged(object sender, EventArgs e)
        {
            if (radioortasaha.Checked == true)
            {
                radioortasaha.BackColor = Color.Red;
                ortasahalistele();
            }
            else
            {
                radioortasaha.BackColor = Color.Transparent;
            }
            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Mevki='ORTASAHA MERKEZ' OR Mevki='ORTASAHA SAĞ' or Mevki='ORTASAHA SOL' or Mevki='10 NUMARA' or Mevki='SAĞ FORVET' or Mevki='SOL FORVET' or Mevki='10 NUMARA'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();

        }

        private void radioforvet_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioforvet.Checked == true)
            {
                radioforvet.BackColor = Color.Red;
                forvetlistele();
            }
            else
            {
                radioforvet.BackColor = Color.Transparent;
            }

            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Mevki ='FORVET' or Mevki='SOL FORVET' OR Mevki='SAĞ FORVET' ", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnyso_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgld = new sqlbaglantisi();
            DataTable tabled = new DataTable();
            SqlDataAdapter adaptd = new SqlDataAdapter("Select * from Futbolcular where Grup='Yaz Spor Okulları' order by Adi asc", bgld.baglanti());
            adaptd.Fill(tabled);
            gridControl1.DataSource = tabled;
            lblgrupadi.Text = btnyso.Text;
            bgld.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select Count(id) As 'Toplam Sayi' from Futbolcular where Grup='Yaz Spor Okulları'", bgld.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl2.Text = oku[0].ToString();
            }
            bgld.baglanti().Close();
        }
    }
}
