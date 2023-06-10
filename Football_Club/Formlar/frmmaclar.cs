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
    public partial class frmmaclar : Form
    {
        public frmmaclar()
        {
            InitializeComponent();
        }

        public void listelemaclar()
        {
            //SqlConnection baglan = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            //baglan.Open();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Select ID,Tarih,Hafta,EvSahibi,Deplasman,Sezon from Maclar order by ID desc", baglan);
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
        }

        void maclistele()
        {
            SqlConnection baglan = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,Tarih,Hafta,EvSahibi,Deplasman,Skor,Sezon,MacNotu from Maclar order by ID desc", baglan);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            GOLLER.Items.Clear();
            SARIKART.Items.Clear();
            KIRMIZIKART.Items.Clear();
            DEGİSİKLİKLER.Items.Clear();
            cmbevsahibi.Text = ""; cmbdeplasman.Text = "";
            comboBox6.Text = "";
            comboBox9.Text = "";
            comboBox7.Text = "";
            comboBox10.Text = "";
            comboBox8.Text = ""; mskdegisik2.Text = ""; mskdegisik1.Text = ""; cmbtur.Text = "";
            comboBox11.Text = "";
            mskdepskor.Text = ""; mskevskor.Text = ""; cmbhafta.Text = ""; cmbsezon.Text = ""; mskdegisik3.Text = "";
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        private void frmmaclar_Load(object sender, EventArgs e)
        {

            SqlConnection baglan = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,Tarih,Hafta,EvSahibi,Deplasman,Skor,Sezon from Maclar order by ID desc", baglan);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            maclistele();
            baglan.Close();

            //dikkat
            //DataTable skordatatbl = new DataTable();
            //SqlDataAdapter skoradap = new SqlDataAdapter("select Gol1+ '-'+Gol2  as Skor from Maclar", baglan);
            //skoradap.Fill(skordatatbl);
            //txtskornet.Text = skordatatbl.Columns["Skor"].ToString();
            baglan.Open();
            SqlCommand gollist = new SqlCommand();
            gollist.CommandText = "select Gol1+ '-'+Gol2  as Skor from Maclar";
            gollist.Connection = baglan;
            gollist.CommandType = CommandType.Text;
            SqlDataReader oku;
            oku = gollist.ExecuteReader();
            while (oku.Read())
            {
                txtskornet.Text = oku["Skor"].ToString();
            }
            baglan.Close();

            baglan.Open();
            // AYARLAR MENÜSÜNDEKİ FORMA EKLENEN TAKIMLARI BAŞKA FORMDA COMBOXTA GÖSTERME
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select TakimAdi from Takimlar order by TakimAdi asc";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbevsahibi.Items.Add(dr["TakimAdi"]);
                cmbdeplasman.Items.Add(dr["TakimAdi"]);

            }

            baglan.Close();

            baglan.Open();
            SqlCommand komut2 = new SqlCommand();
            komut.CommandText = "Select Adi,Soyadi from Futbolcular order by Adi asc";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;
            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {   //FUTBOLCULAR TABLOSUNDA AYRI SÜTÜNLARDA BULUNAN AD VE SOYADLARI COMBOBAXTA GÖSTERME
                comboBox3.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                comboBox4.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                comboBox5.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
            }
            baglan.Close();

            baglan.Open();
            SqlCommand komut3 = new SqlCommand();
            komut.CommandText = "Select Adi,Soyadi from Futbolcular order by Adi asc";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr3;
            dr3 = komut.ExecuteReader();
            while (dr3.Read())
            {   //FUTBOLCULAR TABLOSUNDA AYRI SÜTÜNLARDA BULUNAN AD VE SOYADLARI COMBOBAXTA GÖSTERME
                comboBox6.Items.Add(dr3["Adi"].ToString() + " " + dr3["Soyadi"].ToString());
                comboBox7.Items.Add(dr3["Adi"].ToString() + " " + dr3["Soyadi"].ToString());
                comboBox8.Items.Add(dr3["Adi"].ToString() + " " + dr3["Soyadi"].ToString());
                comboBox9.Items.Add(dr3["Adi"].ToString() + " " + dr3["Soyadi"].ToString());
                comboBox10.Items.Add(dr3["Adi"].ToString() + " " + dr3["Soyadi"].ToString());
                comboBox11.Items.Add(dr3["Adi"].ToString() + " " + dr3["Soyadi"].ToString());
            }
            baglan.Close();



        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglan = new SqlConnection("Server=. ; Database=Futbol_Bilgi; integrated security=true");
                baglan.Open();
                SqlCommand kaydet = new SqlCommand("insert into Maclar (Tarih, Hafta, EvSahibi,Gol1,Deplasman,Gol2,GolAtan,SariKart,KirmiziKart,Degisiklikler,Sezon,Skor,MacNotu,Tur) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", baglan);

                kaydet.Parameters.AddWithValue("@p1", datetimetarih.Value);
                kaydet.Parameters.AddWithValue("@p2", cmbhafta.Text.ToString());
                kaydet.Parameters.AddWithValue("@p3", cmbevsahibi.Text.ToString());
                kaydet.Parameters.AddWithValue("@p4", mskevskor.Text.ToString());
                kaydet.Parameters.AddWithValue("@p5", cmbdeplasman.Text.ToString());
                kaydet.Parameters.AddWithValue("@p6", mskdepskor.Text.ToString());



                string goller = string.Empty; //GOLLERİ LİSTBOXA EKLENDİKTEN SONRA SQLDE TEK HÜCREYE SIĞDIRMAK İÇİN
                for (int i = 0; i < GOLLER.Items.Count; i++)
                {
                    if (i == (GOLLER.Items.Count - 1))
                    {
                        goller += GOLLER.Items[i].ToString();
                    }
                    else
                    {
                        goller += GOLLER.Items[i].ToString() + " -- ";
                    }
                }
                kaydet.Parameters.AddWithValue("@p7", goller);


                string sarikart = string.Empty; //SARIKARTLARI LİSTBOXA EKLENDİKTEN SONRA SQLDE TEK HÜCREYE SIĞDIRMAK İÇİN
                for (int s = 0; s < SARIKART.Items.Count; s++)
                {
                    if (s == (SARIKART.Items.Count - 1))
                    {
                        sarikart += SARIKART.Items[s].ToString();
                    }
                    else
                    {
                        sarikart += SARIKART.Items[s].ToString() + " -- ";
                    }
                }
                kaydet.Parameters.AddWithValue("@p8", sarikart);

                string kirmizik = string.Empty; //KIRMIZI KARTLARI LİSTBOXA EKLENDİKTEN SONRA SQLDE TEK HÜCREYE SIĞDIRMAK İÇİN
                for (int k = 0; k < KIRMIZIKART.Items.Count; k++)
                {
                    if (k == (KIRMIZIKART.Items.Count - 1))
                    {
                        kirmizik += KIRMIZIKART.Items[k].ToString();
                    }
                    else
                    {
                        kirmizik += KIRMIZIKART.Items[k].ToString() + " -- ";
                    }
                }
                kaydet.Parameters.AddWithValue("@p9", kirmizik);

                string degisik = string.Empty; //DEĞİŞİKLİKLERİ LİSTBOXA EKLENDİKTEN SONRA SQLDE TEK HÜCREYE SIĞDIRMAK İÇİN
                for (int d = 0; d < DEGİSİKLİKLER.Items.Count; d++)
                {
                    if (d == (DEGİSİKLİKLER.Items.Count - 1))
                    {
                        degisik += DEGİSİKLİKLER.Items[d].ToString();
                    }
                    else
                    {
                        degisik += DEGİSİKLİKLER.Items[d].ToString() + " -- ";
                    }
                }
                kaydet.Parameters.AddWithValue("@p10", degisik.ToString());
                kaydet.Parameters.AddWithValue("@p11", cmbsezon.Text.ToString());
                kaydet.Parameters.AddWithValue("@p12", txtskornet.Text.ToString());
                kaydet.Parameters.AddWithValue("@p13", richmacnot.Text);
                kaydet.Parameters.AddWithValue("@p14", cmbtur.Text);


                if (kaydet.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Müsabaka Bilgileri Başarıyla Eklendi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GOLLER.Items.Clear();
                    SARIKART.Items.Clear();
                    KIRMIZIKART.Items.Clear();
                    DEGİSİKLİKLER.Items.Clear();
                    cmbevsahibi.Text = ""; cmbdeplasman.Text = "";
                    comboBox6.Text = "";
                    comboBox9.Text = "";
                    comboBox7.Text = "";
                    comboBox10.Text = "";
                    comboBox8.Text = ""; mskdegisik2.Text = ""; mskdegisik1.Text = ""; cmbtur.Text = "";
                    comboBox11.Text = "";
                    mskdepskor.Text = ""; mskevskor.Text = ""; cmbhafta.Text = ""; cmbsezon.Text = ""; mskdegisik3.Text = "";

                }

                //baglan.Open();
                SqlCommand gollist = new SqlCommand();
                gollist.CommandText = "select Gol1+ '-'+Gol2  as Skor from Maclar ";
                gollist.Connection = baglan;
                gollist.CommandType = CommandType.Text;
                SqlDataReader oku;
                oku = gollist.ExecuteReader();
                while (oku.Read())
                {
                    txtskornet.Text = oku["Skor"].ToString();
                }
                baglan.Close();




            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }

            maclistele();

            //listelemaclar();
        }

        private void btngolekle_Click(object sender, EventArgs e)
        {
            if (mskgoldk.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Lütfen Gol Atan Oyuncuyu veya Gol Dakikasını boş bırakmayınız!", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GOLLER.Items.Add("Dk:" + " " + mskgoldk.Text.ToString() + " " + comboBox3.Text.ToString());
                MessageBox.Show("GOL eklendi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskgoldk.Text = ""; comboBox3.Text = "";
            }
        }

        private void btnsarikart_Click(object sender, EventArgs e)
        {
            if (msksariekle.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Lütfen Sarı Kart Gören Oyuncuyu veya Kartın Dakikasını boş bırakmayınız!", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SARIKART.Items.Add("Dk:" + " " + msksariekle.Text.ToString() + " " + comboBox4.Text.ToString());
                MessageBox.Show("Sarı Kart eklendi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msksariekle.Text = ""; comboBox4.Text = "";
            }
        }

        private void btnkirmizikart_Click(object sender, EventArgs e)
        {
            if (mskkirmiziekle.Text == "" || comboBox5.Text == "")
            {
                MessageBox.Show("Lütfen Kırmızı Kart Gören Oyuncuyu veya Kartın Dakikasını boş bırakmayınız!", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                KIRMIZIKART.Items.Add("Dk:" + " " + mskkirmiziekle.Text.ToString() + " " + comboBox5.Text.ToString());
                MessageBox.Show("Kırmızı Kart eklendi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskkirmiziekle.Text = ""; comboBox5.Text = "";
            }


        }

        private void btndegisiklikkaydet_Click(object sender, EventArgs e)
        {
            if (mskdegisik1.Text == "" || comboBox9.Text == "" || comboBox6.Text == "")
            {
                MessageBox.Show("Lütfen Oyuncu Değişikliklerini ve Dakikasını boş bırakmadan doldurunuz", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DEGİSİKLİKLER.Items.Add("Dk:" + " " + mskdegisik1.Text.ToString() + " " + comboBox9.Text.ToString() + " çıktı ve yerine " + comboBox6.Text.ToString() + " girdi");
            }
            comboBox6.Text = ""; comboBox7.Text = ""; comboBox8.Text = ""; comboBox9.Text = ""; comboBox10.Text = ""; comboBox11.Text = "";
        }

        private void btndegisiklikkaydet2_Click(object sender, EventArgs e)
        {
            //Oyuncu değişiklikleri kutusunun boş kalması durumunda hata mesajı
            if (mskdegisik2.Text == "" || comboBox10.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Lütfen Oyuncu Değişikliklerini ve Dakikasını boş bırakmadan doldurunuz", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DEGİSİKLİKLER.Items.Add("Dk:" + " " + mskdegisik2.Text.ToString() + " " + comboBox10.Text.ToString() + " çıktı ve yerine " + comboBox7.Text.ToString() + " girdi");
            }
        }

        private void btndegisiklikkaydet3_Click(object sender, EventArgs e)
        {
            if (mskdegisik3.Text == "" || comboBox11.Text == "" || comboBox8.Text == "")
            {
                MessageBox.Show("Lütfen Oyuncu Değişikliklerini ve Dakikasını boş bırakmadan doldurunuz", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DEGİSİKLİKLER.Items.Add("Dk:" + " " + mskdegisik3.Text.ToString() + " " + comboBox11.Text.ToString() + " çıktı ve yerine " + comboBox8.Text.ToString() + " girdi");
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlConnection bgl = new SqlConnection("Server=.;Database=Futbol_Bilgi;integrated security=true");
            bgl.Open();
            DialogResult dia = new DialogResult();

            dia = MessageBox.Show("Seçilen maçı listeden silmek istiyor musunuz?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from Maclar where ID=@id", bgl);
                sil.Parameters.AddWithValue("@id", txtid.Text.ToString());
                if (sil.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Seçilen maç listeden silindi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                maclistele();
            }

        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtid.Enabled = true;
                cmbevsahibi.Text = dr["EvSahibi"].ToString();
                cmbdeplasman.Text = dr["Deplasman"].ToString();
                //cmbtur.Text=dr["Tur"].ToString();
                cmbhafta.Text = dr["Hafta"].ToString();

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmmacdetay mac = new frmmacdetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                mac.ad = dr["ID"].ToString();
                mac.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Sezon,Tarih,Hafta,EvSahibi,Deplasman,Skor,MacNotu from Maclar where Hafta='Turnuva' order by ID desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
