using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BunifuAnimatorNS;
using Football_Club.Formlar;
//using System.Drawing;


namespace Football_Club
{
    public partial class frmanasayfa : Form
    {
        public frmanasayfa()
        {
            InitializeComponent();
        }

        private void frmanasayfa_Load(object sender, EventArgs e)
        {



            //boy ortalamalarını listeleme.
            sqlbaglantisi bgl = new sqlbaglantisi();
            //bgl.baglanti().Open();
            SqlCommand komutportalamaboy = new SqlCommand("select AVG(Boy) AS 'Ortalama Boy' from Futbolcular ", bgl.baglanti());
            SqlDataReader drortalamaboy = komutportalamaboy.ExecuteReader();
            while (drortalamaboy.Read())
            {
                lblboy.Text = drortalamaboy[0].ToString();
            }
            bgl.baglanti().Close();

            //takımdaki toplam oyuncu sayısını futbolcular tablosundan Count ile alma,
            //bgl.baglanti().Open();
            SqlCommand toplamfutbolcu = new SqlCommand("select Count(id) AS 'Toplam Sayi' from Futbolcular ", bgl.baglanti());
            SqlDataReader drtoplamfutbolcu = toplamfutbolcu.ExecuteReader();
            while (drtoplamfutbolcu.Read())
            {
                lbltoplamoyuncu.Text = drtoplamfutbolcu[0].ToString();
            }

            bgl.baglanti().Close();

            // kilo ortalamasını alma
            //bgl.baglanti().Open();
            SqlCommand komkilo = new SqlCommand("select AVG(Kilo) AS 'Ortalama Kilo'  from Futbolcular ", bgl.baglanti());
            SqlDataReader drkilo = komkilo.ExecuteReader();
            while (drkilo.Read())
            {
                labelControl14.Text = drkilo[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam kaleci sayısını alma
            //bgl.baglanti().Open();
            SqlCommand toplamkaleci = new SqlCommand("select count (id) from Futbolcular where Mevki='Kaleci' ", bgl.baglanti());
            SqlDataReader drtoplamkaleci = toplamkaleci.ExecuteReader();
            while (drtoplamkaleci.Read())
            {
                lbltoplkale.Text = drtoplamkaleci[0].ToString();
            }

            bgl.baglanti().Close();

            //Defans sayısını alma;
            //bgl.baglanti().Open();
            SqlCommand toplamdefans = new SqlCommand("select count (id) from Futbolcular where Mevki='STOPER' or Mevki='SOL STOPER' or Mevki='SAĞ STOPER' or Mevki='SOL BEK' or Mevki='SAĞ BEK' ", bgl.baglanti());
            SqlDataReader drtoplamdefans = toplamdefans.ExecuteReader();
            while (drtoplamdefans.Read())
            {
                lbldefans.Text = drtoplamdefans[0].ToString();
            }

            bgl.baglanti().Close();

            //toplam ortasahalar
            //bgl.baglanti().Open();
            SqlCommand toplamortasaha = new SqlCommand("select count (id) from Futbolcular where Mevki='ORTASAHA MERKEZ' or Mevki='ORTASAHA SAĞ' or Mevki='ORTASAHA SOL' or Mevki='10 NUMARA' or Mevki='SAĞ FORVET' or Mevki='SOL FORVET'", bgl.baglanti());
            SqlDataReader toplamortasaha2 = toplamortasaha.ExecuteReader();
            while (toplamortasaha2.Read())
            {
                lblortasaha.Text = toplamortasaha2[0].ToString();
            }

            bgl.baglanti().Close();

            //bgl.baglanti().Open();
            SqlCommand toplamforvet = new SqlCommand("select count (id) from Futbolcular where Mevki='FORVET'", bgl.baglanti());
            SqlDataReader toplamforvet2 = toplamforvet.ExecuteReader();
            while (toplamforvet2.Read())
            {
                lblforvet.Text = toplamforvet2[0].ToString();
            }

            bgl.baglanti().Close();

            //baglanti1.Open();
            //DataTable dt= new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Select Adi,Soyadi, DogumTarihi from Futbolcular order by DogumTarihi desc",baglanti1);
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
                                    //SqlCommand com = new SqlCommand(); 
            // com.CommandText = "SELECT Adi,Soyadi,DogumTarihi FROM Futbolcular WHERE DAY(dtarih) = DAY(GETDATE()) AND MONTH(dtarih) = MONTH(GETDATE())";
            // SqlDataReader dr = com.ExecuteReader(); 

            //DataSet ds;

            //DateTime tarih = DateTime.Now;
            //DateTime dogumgunu = new DateTime();
            //TimeSpan fark = tarih - dogumgunu;
            //lblzaman.Text = tarih.ToLongDateString();
            //labelControl4.Text = dr["DogumGunu"].ToString();

        }







        public Control bunifuCards1 { get; set; }
        public Control bunifuCircleProgress { get; set; }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }
    }

}
