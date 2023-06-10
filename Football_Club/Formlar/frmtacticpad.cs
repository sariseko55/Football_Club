using DevExpress.XtraBars;
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

namespace Football_Club.Formlar
{
    public partial class frmtacticpad : Form
    {
        public frmtacticpad()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmtacticpad_Load(object sender, EventArgs e)
        {
            //SqlConnection baglan1 = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            //baglan1.Open();
            //SqlDataAdapter da = new SqlDataAdapter("Select * from Taktik", baglan1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
            //baglan1.Close();

            //COMBOBAXLARA pERSONELLER VERİTABANINDA BULUNAN ANTRENÖR GEİTRME;
            SqlConnection baglan5 = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan5.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select Adi,Soyadi from Personeller where Gorevi ='ANTRENÖR' order by Adi asc";
            komut.Connection = baglan5;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbteknikdirektor.Items.Add(dr["Adi"].ToString() + " " + dr["Soyadi"].ToString());
                cmbantrenor.Items.Add(dr["Adi"].ToString() + " " + dr["Soyadi"].ToString());
                cmbkaleciantrenoru.Items.Add(dr["Adi"].ToString() + " " + dr["Soyadi"].ToString());

            }
            baglan5.Close();

            //COMBOBAXLARA pERSONELLER VERİTABANINDA BULUNAN YÖNETİCİ GEİTRME;
            SqlConnection baglan12 = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan12.Open();
            SqlCommand komut12 = new SqlCommand();
            komut.CommandText = "Select Adi,Soyadi from Personeller where Gorevi ='İDARECİ' order by Adi asc";
            komut.Connection = baglan12;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr12;
            dr12 = komut.ExecuteReader();
            while (dr12.Read())
            {
                cmbyonetici.Items.Add(dr12["Adi"].ToString() + " " + dr12["Soyadi"].ToString());

            }
            baglan12.Close();



            //COMBOBAXLARA FUTBOLCULAR VERİTABANINDA BULUNAN "KALECİ" SÜTUNUNDAKİ KALECİLERİ GEİTRME;
            SqlConnection baglan = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            SqlCommand komut1 = new SqlCommand();
            komut1.CommandText = "Select Adi,Soyadi from Futbolcular where Mevki='Kaleci' order by Adi asc";
            komut1.Connection = baglan;
            komut1.CommandType = CommandType.Text;
            SqlDataReader dr1;
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbkaleci.Items.Add(dr1["Adi"].ToString() + " " + dr1["Soyadi"].ToString());
                cmbyedekkaleci.Items.Add(dr1["Adi"].ToString() + " " + dr1["Soyadi"].ToString());

            }
            baglan.Close();

            //COMBOBAXLARA FUTBOLCULAR TABLOSUNDA BULUNAN MEVKİLER SÜTUNUNDAKİLERİ GETİRME;
            baglan.Open();
            SqlCommand kom2 = new SqlCommand();
            kom2.CommandText = "Select Adi,Soyadi from Futbolcular where Mevki='KALECİ'or Mevki='SAĞ BEK' or Mevki='SOL BEK' or Mevki='SOL STOPER' or Mevki='SAĞ STOPER' or Mevki='LİBERO' or Mevki='ORTASAHA MERKEZ' or Mevki='ORTASAHA SAĞ' or Mevki='ORTASAHA SOL' or Mevki='ÖNLİBERO' or Mevki='SAĞ FORVET' or Mevki='SOL FORVET' or Mevki='FORVET' or Mevki='10 NUMARA' order by Adi asc";
            kom2.Connection = baglan;
            kom2.CommandType = CommandType.Text;
            SqlDataReader dr2;
            dr2 = kom2.ExecuteReader();
            while (dr2.Read())
            {
                cmbkaptan.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb2.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb3.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb4.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb5.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb6.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb7.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb8.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb9.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb10.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb11.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb13.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb14.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb15.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb16.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb17.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
                cmb18.Items.Add(dr2["Adi"].ToString() + " " + dr2["Soyadi"].ToString());
            }
            baglan.Close();

            //VERİ TABANINDAKİ TAKTİKLERİ COMBOBOXA ÇEKME İŞLEMİ;
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("Select Taktik from TaktikSekli", baglan);
            SqlDataReader dr3 = komut2.ExecuteReader();
            while (dr3.Read())
            {
                comboBox19.Items.Add(dr3["Taktik"].ToString());
            }

            baglan.Close();

            // Comboxlara takımları çekme
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("select TakimAdi from Takimlar ORDER BY TakimAdi ASC", baglan);
            SqlDataReader droku = komut3.ExecuteReader();
            while (droku.Read())
            {
                comboBox20.Items.Add(droku["TakimAdi"].ToString());
                comboBox21.Items.Add(droku["TakimAdi"].ToString());
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        //private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        //{    //SEÇİLNE TAKTİĞE GÖRE SAHADAKİ DİZİLİŞİN DEĞİŞMESİ
        //    SqlConnection baglan = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
        //    baglan.Open();
        //    //SqlCommand komut2 = new SqlCommand("Select Taktik from TaktikSekli", baglan);
        //    //SqlDataReader dr3 = komut2.ExecuteReader();
        //    //while (dr3.Read())
        //    //{
        //    //    comboBox19.Items.Add(dr3["Taktik"].ToString());
        //    //}

        //    baglan.Close();

        //    if (comboBox19.Text.ToString() == "4-2-3-1")
        //    {
        //        lbl2.Location = new Point(542, 203);
        //        lbl1.Location = new Point(990, 110);
        //        lbl3.Location = new Point(1156, 105);

        //        lbl5.Location = new Point(945, 193);
        //        lbl4.Location = new Point(750, 193);
        //        lbl7.Location = new Point(542, 439);

        //        lbl6.Location = new Point(962, 309);
        //        lbl8.Location = new Point(737, 309);
        //        lbl9.Location = new Point(855, 529);

        //        lbl10.Location = new Point(846, 408);
        //        lbl11.Location = new Point(1136, 250);

        //        //PİCTUREBOXLARIN DAĞILIMI İÇİN;
        //        kaleci.Location = new Point(81, 111);
        //        ply2.Location = new Point(565, 145);
        //        ply3.Location = new Point(1169, 120);
        //        ply4.Location = new Point(771, 135);
        //        ply5.Location = new Point(965, 135);
        //        ply6.Location = new Point(979, 252);
        //        ply7.Location = new Point(556, 381);
        //        ply8.Location = new Point(753, 252);
        //        ply9.Location = new Point(873, 471);
        //        ply10.Location = new Point(864, 350);
        //        ply11.Location = new Point(1159, 380);               

        //    }


        //    if (comboBox19.Text.ToString() == "4-4-2")
        //    {
        //        lbl2.Location = new Point(542, 203);
        //        lbl1.Location = new Point(856, 93);
        //        lbl3.Location = new Point(1156, 203);
        //        lbl5.Location = new Point(945, 193);
        //        lbl4.Location = new Point(750, 193);
        //        lbl7.Location = new Point(542, 439);
        //        lbl6.Location = new Point(978, 339);

        //        lbl8.Location = new Point(753, 339);
        //        lbl9.Location = new Point(978, 529);

        //        lbl10.Location = new Point(785, 529);
        //        lbl11.Location = new Point(1136, 440);

        //        kaleci.Location = new Point(81, 111);
        //        ply2.Location = new Point(565, 145);
        //        ply3.Location = new Point(1169, 145);
        //        ply4.Location = new Point(771, 135);
        //        ply5.Location = new Point(965, 135);
        //        ply6.Location = new Point(995, 282);
        //        ply7.Location = new Point(556, 381);
        //        ply8.Location = new Point(769, 282);
        //        ply9.Location = new Point(996, 471);
        //        ply10.Location = new Point(803, 471);
        //        ply11.Location = new Point(1159, 380);
        //    }


        //    if (comboBox19.Text.ToString() == "3-5-2")
        //    {
        //        lbl2.Location = new Point(641, 212);
        //        lbl1.Location = new Point(856, 93);
        //        lbl3.Location = new Point(1169, 445);
        //        lbl5.Location = new Point(1037, 212);
        //        lbl4.Location = new Point(841,197);
        //        lbl7.Location = new Point(542, 448);
        //        lbl6.Location = new Point(980, 338);

        //        lbl8.Location = new Point(715, 338);
        //        lbl9.Location = new Point(979, 519);

        //        lbl10.Location = new Point(733, 519);
        //        lbl11.Location = new Point(839, 429);

        //        kaleci.Location = new Point(81, 111);
        //        ply2.Location = new Point(664, 154);
        //        ply3.Location = new Point(1182, 387);
        //        ply4.Location = new Point(862, 139);
        //        ply5.Location = new Point(1057, 154);
        //        ply6.Location = new Point(997, 281);
        //        ply7.Location = new Point(556, 390);
        //        ply8.Location = new Point(731, 281);
        //        ply9.Location = new Point(997, 461);
        //        ply10.Location = new Point(751, 461);
        //        ply11.Location = new Point(862, 369);
        //    }


        //    if (comboBox19.Text.ToString() == "4-1-3-2")
        //    {
        //        lbl2.Location = new Point(536, 255);
        //        lbl1.Location = new Point(856, 93);
        //        lbl3.Location = new Point(1151, 255);
        //        lbl5.Location = new Point(951, 212);
        //        lbl4.Location = new Point(730, 212);
        //        lbl7.Location = new Point(595, 438);
        //        lbl6.Location = new Point(847, 336);

        //        lbl8.Location = new Point(848, 439);
        //        lbl9.Location = new Point(979, 526);

        //        lbl10.Location = new Point(733, 526);
        //        lbl11.Location = new Point(1094, 434);

        //        kaleci.Location = new Point(81, 111); 
        //        ply2.Location = new Point(559, 197);
        //        ply3.Location = new Point(1164, 197);
        //        ply4.Location = new Point(751, 154);
        //        ply5.Location = new Point(971, 154);
        //        ply6.Location = new Point(864, 279);
        //        ply7.Location = new Point(609, 380);
        //        ply8.Location = new Point(864, 382);
        //        ply9.Location = new Point(997, 468);
        //        ply10.Location = new Point(751, 468);
        //        ply11.Location = new Point(1117, 374);
        //    }

        //    if (comboBox19.Text.ToString() == "4-1-4-1")
        //    {
        //        lbl2.Location = new Point(536, 255);
        //        lbl1.Location = new Point(856, 93);
        //        lbl3.Location = new Point(1151, 255);
        //        lbl5.Location = new Point(951, 212);
        //        lbl4.Location = new Point(730, 212);
        //        lbl7.Location = new Point(562, 438);
        //        lbl6.Location = new Point(847, 336);

        //        lbl8.Location = new Point(952, 447);
        //        lbl9.Location = new Point(846, 540);

        //        lbl10.Location = new Point(745, 448);
        //        lbl11.Location = new Point(1131, 434);

        //        kaleci.Location = new Point(81, 111);
        //        ply2.Location = new Point(559, 197);
        //        ply3.Location = new Point(1164, 197);
        //        ply4.Location = new Point(751, 154);
        //        ply5.Location = new Point(971, 154);
        //        ply6.Location = new Point(864, 279);
        //        ply7.Location = new Point(576, 380);
        //        ply8.Location = new Point(968, 390);
        //        ply9.Location = new Point(864, 482);
        //        ply10.Location = new Point(763, 390);
        //        ply11.Location = new Point(1154, 374);
        //    }

        //    if (comboBox19.Text.ToString() == "3-4-3")
        //    {
        //        lbl2.Location = new Point(635, 415);
        //        lbl1.Location = new Point(856, 93);
        //        lbl3.Location = new Point(1055, 243);
        //        lbl5.Location = new Point(844, 212);
        //        lbl4.Location = new Point(639, 243);
        //        lbl7.Location = new Point(559, 523);
        //        lbl6.Location = new Point(766, 339);

        //        lbl8.Location = new Point(942, 339);
        //        lbl9.Location = new Point(848, 523);
        //        lbl10.Location = new Point(1150, 512);
        //        lbl11.Location = new Point(1068, 412);


        //        kaleci.Location = new Point(81, 111);
        //        ply2.Location = new Point(658, 357);
        //        ply3.Location = new Point(1068, 185);
        //        ply4.Location = new Point(660, 185);
        //        ply5.Location = new Point(864, 154);
        //        ply6.Location = new Point(783, 282);
        //        ply7.Location = new Point(573, 465);
        //        ply8.Location = new Point(958, 282);
        //        ply9.Location = new Point(866, 465);
        //        ply10.Location = new Point(1168, 454);
        //        ply11.Location = new Point(1091, 352);
        //    }
        //}

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            lbl1.Text = cmbkaleci.Text;
            lbl2.Text = cmb2.Text;
            lbl3.Text = cmb3.Text;
            lbl4.Text = cmb4.Text;
            lbl5.Text = cmb5.Text;
            lbl6.Text = cmb6.Text;
            lbl7.Text = cmb7.Text;
            lbl8.Text = cmb8.Text;
            lbl9.Text = cmb9.Text;
            lbl10.Text = cmb10.Text;
            lbl11.Text = cmb11.Text;
            label30.Text = "12" + " " + cmbyedekkaleci.Text;
            label31.Text = "13" + " " + cmb13.Text;
            label32.Text = "14" + " " + cmb14.Text;
            label35.Text = "15" + " " + cmb15.Text;
            label34.Text = "16" + " " + cmb16.Text;
            label33.Text = "17" + " " + cmb17.Text;
            label36.Text = "18" + " " + cmb18.Text;

        }

        private void comboBox19_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //SEÇİLNE TAKTİĞE GÖRE SAHADAKİ DİZİLİŞİN DEĞİŞMESİ
            SqlConnection baglan = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            //SqlCommand komut2 = new SqlCommand("Select Taktik from TaktikSekli", baglan);
            //SqlDataReader dr3 = komut2.ExecuteReader();
            //while (dr3.Read())
            //{
            //    comboBox19.Items.Add(dr3["Taktik"].ToString());
            //}

            baglan.Close();

            if (comboBox19.Text.ToString() == "4-2-3-1")
            {
                lbl1.Location = new Point(727, 86);
                lbl2.Location = new Point(485, 244);
                lbl3.Location = new Point(944, 237);
                lbl4.Location = new Point(635, 195);
                lbl5.Location = new Point(779, 198);
                lbl6.Location = new Point(635, 342);
                lbl7.Location = new Point(494, 483);
                lbl8.Location = new Point(831, 340);
                lbl9.Location = new Point(736, 526);
                lbl10.Location = new Point(728, 432);
                lbl11.Location = new Point(964, 479);





                //PİCTUREBOXLARIN DAĞILIMI İÇİN;
                kaleci.Location = new Point(743, 28);
                ply2.Location = new Point(502, 179);
                ply3.Location = new Point(988, 179);
                ply4.Location = new Point(670, 143);
                ply5.Location = new Point(827, 141);
                ply6.Location = new Point(649, 279);
                ply7.Location = new Point(509, 425);
                ply8.Location = new Point(843, 277);
                ply9.Location = new Point(746, 469);
                ply10.Location = new Point(746, 370);
                ply11.Location = new Point(979, 422);

            }


            if (comboBox19.Text.ToString() == "4-4-2")
            {
                lbl1.Location = new Point(727, 86);
                lbl2.Location = new Point(485, 244);
                lbl3.Location = new Point(944, 237);
                lbl4.Location = new Point(635, 195);
                lbl5.Location = new Point(779, 198);
                lbl7.Location = new Point(475, 375);
                lbl6.Location = new Point(635, 342);

                lbl8.Location = new Point(831, 340);
                lbl9.Location = new Point(848, 525);

                lbl10.Location = new Point(643, 530);
                lbl11.Location = new Point(973, 374);

                kaleci.Location = new Point(743, 28);
                ply2.Location = new Point(502, 179);
                ply3.Location = new Point(988, 179);
                ply4.Location = new Point(670, 143);
                ply5.Location = new Point(827, 141);

                ply6.Location = new Point(649, 279);
                ply7.Location = new Point(490, 317);
                ply8.Location = new Point(843, 277);
                ply9.Location = new Point(858, 468);
                ply10.Location = new Point(661, 468);
                ply11.Location = new Point(988, 317);
            }


            //if (comboBox19.Text.ToString() == "3-5-2")
            //{
            //    lbl2.Location = new Point(641, 212);
            //    lbl1.Location = new Point(856, 93);
            //    lbl3.Location = new Point(1169, 445);
            //    lbl5.Location = new Point(1037, 212);
            //    lbl4.Location = new Point(841, 197);
            //    lbl7.Location = new Point(542, 448);
            //    lbl6.Location = new Point(980, 338);

            //    lbl8.Location = new Point(715, 338);
            //    lbl9.Location = new Point(979, 519);

            //    lbl10.Location = new Point(733, 519);
            //    lbl11.Location = new Point(839, 429);

            //    kaleci.Location = new Point(859, 35);
            //    ply2.Location = new Point(664, 154);
            //    ply3.Location = new Point(1182, 387);
            //    ply4.Location = new Point(862, 139);
            //    ply5.Location = new Point(1057, 154);
            //    ply6.Location = new Point(997, 281);
            //    ply7.Location = new Point(556, 390);
            //    ply8.Location = new Point(731, 281);
            //    ply9.Location = new Point(997, 461);
            //    ply10.Location = new Point(751, 461);
            //    ply11.Location = new Point(862, 369);
            //}


            //if (comboBox19.Text.ToString() == "4-1-3-2")
            //{
            //    lbl2.Location = new Point(536, 255);
            //    lbl1.Location = new Point(856, 93);
            //    lbl3.Location = new Point(1151, 255);
            //    lbl5.Location = new Point(951, 212);
            //    lbl4.Location = new Point(730, 212);
            //    lbl7.Location = new Point(595, 438);
            //    lbl6.Location = new Point(847, 336);

            //    lbl8.Location = new Point(848, 439);
            //    lbl9.Location = new Point(979, 526);

            //    lbl10.Location = new Point(733, 526);
            //    lbl11.Location = new Point(1094, 434);

            //    kaleci.Location = new Point(859, 35);
            //    ply2.Location = new Point(559, 197);
            //    ply3.Location = new Point(1317, 220);
            //    ply4.Location = new Point(751, 154);
            //    ply5.Location = new Point(971, 154);
            //    ply6.Location = new Point(864, 279);
            //    ply7.Location = new Point(609, 380);
            //    ply8.Location = new Point(864, 382);
            //    ply9.Location = new Point(997, 468);
            //    ply10.Location = new Point(751, 468);
            //    ply11.Location = new Point(1117, 374);
            //}

            //if (comboBox19.Text.ToString() == "4-1-4-1")
            //{
            //    lbl2.Location = new Point(536, 255);
            //    lbl1.Location = new Point(856, 93);
            //    lbl3.Location = new Point(1151, 255);
            //    lbl5.Location = new Point(951, 212);
            //    lbl4.Location = new Point(730, 212);
            //    lbl7.Location = new Point(562, 438);
            //    lbl6.Location = new Point(847, 336);

            //    lbl8.Location = new Point(952, 447);
            //    lbl9.Location = new Point(846, 540);

            //    lbl10.Location = new Point(745, 448);
            //    lbl11.Location = new Point(1131, 434);

            //    kaleci.Location = new Point(859, 35);
            //    ply2.Location = new Point(559, 197);
            //    ply3.Location = new Point(1317, 220);
            //    ply4.Location = new Point(751, 154);
            //    ply5.Location = new Point(971, 154);
            //    ply6.Location = new Point(864, 279);
            //    ply7.Location = new Point(576, 380);
            //    ply8.Location = new Point(968, 390);
            //    ply9.Location = new Point(864, 482);
            //    ply10.Location = new Point(763, 390);
            //    ply11.Location = new Point(1154, 374);
            //}

            //if (comboBox19.Text.ToString() == "3-4-3")
            //{
            //    lbl2.Location = new Point(635, 415);
            //    lbl1.Location = new Point(856, 93);
            //    lbl3.Location = new Point(1055, 243);
            //    lbl5.Location = new Point(844, 212);
            //    lbl4.Location = new Point(639, 243);
            //    lbl7.Location = new Point(559, 523);
            //    lbl6.Location = new Point(766, 339);

            //    lbl8.Location = new Point(942, 339);
            //    lbl9.Location = new Point(848, 523);
            //    lbl10.Location = new Point(1150, 512);
            //    lbl11.Location = new Point(1068, 412);


            //    kaleci.Location = new Point(859, 35);
            //    ply2.Location = new Point(658, 357);
            //    ply3.Location = new Point(1068, 185);
            //    ply4.Location = new Point(660, 185);
            //    ply5.Location = new Point(864, 154);
            //    ply6.Location = new Point(783, 282);
            //    ply7.Location = new Point(573, 465);
            //    ply8.Location = new Point(958, 282);
            //    ply9.Location = new Point(866, 465);
            //    ply10.Location = new Point(1168, 454);
            //    ply11.Location = new Point(1091, 352);
            //}
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {

            SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security= true");
            baglan.Open();
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show(dateTimePicker1.Value.ToString("d MMMM yyyy dddd ") + " GÜNÜ OYNANACAK OLAN  " + comboBox20.Text + " - " + comboBox21.Text + " MAÇI İÇİN KADRO AŞAĞIDA BELİRTİLEN ŞEKİLDE OLACAK ONAYLIYOR MUSUNUZ? " + "\n" + "\n" + "1)" + cmbkaleci.Text.ToString() + "\n" + "2)" + cmb2.Text.ToString() + "\n" + "3)" + cmb3.Text.ToString() + "\n" + "4)" + cmb4.Text.ToString() + "\n" + "5)" + cmb5.Text.ToString() + "\n" + "6)" + cmb6.Text.ToString() + "\n" + "7)" + cmb7.Text.ToString() + "\n" + "8)" + cmb8.Text.ToString() + "\n" + "9)" + cmb9.Text.ToString() + "\n" + "10)" + cmb10.Text.ToString() + "\n" + "11)" + cmb11.Text.ToString() + "\n" + "12)" + cmbyedekkaleci.Text.ToString() + "\n" + "13)" + cmb13.Text.ToString() + "\n" + "14)" + cmb14.Text.ToString() + "\n" + "15)" + cmb15.Text.ToString() + "\n" + "16)" + cmb16.Text.ToString() + "\n" + "17)" + cmb17.Text.ToString() + "\n" + "18)" + cmb18.Text.ToString() + "\n" + "\n" + "Teknik Direktör -" + cmbteknikdirektor.Text.ToString() + "\n" + "Takım Kaptanı -" + cmbkaptan.Text.ToString() + "\n" + "Yönetici -" + cmbyonetici.Text.ToString() + "\n" + "Antrenör -" + cmbantrenor.Text.ToString() + "\n" + "Kaleci Antrenörü -" + cmbkaleciantrenoru.Text.ToString() + "\n" + "Masör -" + cmbmasor.Text.ToString() + "\n" + "Doktor -" + cmbdoktor.Text.ToString(), "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialog == DialogResult.Yes)
            {
                SqlCommand kaydet = new SqlCommand("insert into Taktik(Kaleci,Oyuncu2,Oyuncu3,Oyuncu4,Oyuncu5,Oyuncu6,Oyuncu7,Oyuncu8,Oyuncu9,Oyuncu10,Oyuncu11,Oyuncu12,Oyuncu13,Oyuncu14,Oyuncu15,Oyuncu16,Oyuncu17,Oyuncu18,EvSahibi,Deplasman,Taktik,Tarih,Yonetici,Antrenor,KaleciAntrenoru,Masor,Doktor,Kaptan,TeknikDirektor) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@P29)", baglan);
                kaydet.Parameters.AddWithValue("@p1", cmbkaleci.Text);
                kaydet.Parameters.AddWithValue("@p2", cmb2.Text);
                kaydet.Parameters.AddWithValue("@p3", cmb3.Text);
                kaydet.Parameters.AddWithValue("@p4", cmb4.Text);
                kaydet.Parameters.AddWithValue("@p5", cmb5.Text);
                kaydet.Parameters.AddWithValue("@p6", cmb6.Text);
                kaydet.Parameters.AddWithValue("@p7", cmb7.Text);
                kaydet.Parameters.AddWithValue("@p8", cmb8.Text);
                kaydet.Parameters.AddWithValue("@p9", cmb9.Text);
                kaydet.Parameters.AddWithValue("@p10", cmb10.Text);
                kaydet.Parameters.AddWithValue("@p11", cmb11.Text);
                kaydet.Parameters.AddWithValue("@p12", cmbyedekkaleci.Text);
                kaydet.Parameters.AddWithValue("@p13", cmb13.Text);
                kaydet.Parameters.AddWithValue("@p14", cmb14.Text);
                kaydet.Parameters.AddWithValue("@p15", cmb15.Text);
                kaydet.Parameters.AddWithValue("@p16", cmb16.Text);
                kaydet.Parameters.AddWithValue("@p17", cmb17.Text);
                kaydet.Parameters.AddWithValue("@p18", cmb18.Text);
                kaydet.Parameters.AddWithValue("@p19", comboBox20.Text);
                kaydet.Parameters.AddWithValue("@p20", comboBox21.Text);
                kaydet.Parameters.AddWithValue("@p21", comboBox19.Text);
                kaydet.Parameters.AddWithValue("@p22", Convert.ToDateTime(dateTimePicker1.Value));
                kaydet.Parameters.AddWithValue("@p23", cmbyonetici.Text);
                kaydet.Parameters.AddWithValue("@p24", cmbantrenor.Text);
                kaydet.Parameters.AddWithValue("@p25", cmbkaleciantrenoru.Text);
                kaydet.Parameters.AddWithValue("@p26", cmbmasor.Text);
                kaydet.Parameters.AddWithValue("@p27", cmbdoktor.Text);
                kaydet.Parameters.AddWithValue("@p28", cmbkaptan.Text);
                kaydet.Parameters.AddWithValue("@p29", cmbteknikdirektor.Text);
                if (kaydet.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Maç kadrosu kaydedilmiştir!", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbkaleci.Text = ""; cmb2.Text = "";
                    cmb3.Text = ""; comboBox20.Text = "";
                    cmb4.Text = ""; comboBox21.Text = "";
                    cmb5.Text = ""; cmb13.Text = "";
                    cmb14.Text = ""; comboBox19.Text = "";
                    cmb15.Text = ""; cmb6.Text = "";
                    cmb16.Text = ""; cmb7.Text = "";
                    cmb17.Text = ""; cmb8.Text = "";
                    cmb18.Text = ""; cmb11.Text = "";
                    cmbyedekkaleci.Text = ""; cmb9.Text = "";
                    cmb10.Text = ""; comboBox19.Text = "";
                    comboBox20.Text = ""; comboBox21.Text = "";
                    cmbteknikdirektor.Text = ""; cmbyonetici.Text = "";
                    cmbyedekkaleci.Text = ""; cmbmasor.Text = ""; cmbkaptan.Text = ""; cmbkaleciantrenoru.Text = ""; cmbkaleci.Text = ""; cmbdoktor.Text = "";
                    cmbantrenor.Text = "";

                }
                baglan.Close();

                baglan.Open();
                SqlCommand tarihgetir = new SqlCommand();
                tarihgetir.CommandText = "Select Tarih from Taktik order by Tarih desc";
                tarihgetir.Connection = baglan;
                tarihgetir.CommandType = CommandType.Text;
                SqlDataReader dr;
                dr = tarihgetir.ExecuteReader();
                while (dr.Read())
                {
                    dateTimePicker1.Value.ToString(dr["Tarih"].ToString());
                }

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmb9.Visible = true; label9.Visible = true;
            cmb10.Visible = false; label10.Visible = false;
            cmb11.Visible = false; label11.Visible = false;
            ply6.Visible = true; lbl6.Visible = true;
            ply7.Visible = true; lbl7.Visible = true;
            ply9.Visible = true; lbl9.Visible = true;
            ply10.Visible = false; lbl10.Visible = false;
            ply11.Visible = false; lbl11.Visible = false;

            ply7.Location = new Point(880, 392); lbl7.Location = new Point(874, 450);

            radio9.BackColor = Color.Red;
            radio8.BackColor = Color.Transparent;
            radio11.BackColor = Color.Transparent;

            ply5.Location = new Point(889, 149);
            lbl5.Location = new Point(885, 212);

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmb9.Visible = true; label9.Visible = true;
            cmb10.Visible = true; label10.Visible = true;
            cmb11.Visible = true; label11.Visible = true;
            ply7.Visible = true; ply11.Visible = true;
            ply10.Visible = true; lbl10.Visible = true;
            lbl11.Visible = true; lbl7.Visible = true;
            ply6.Visible = true; lbl6.Visible = true;
            radio11.BackColor = Color.Red;
            radio8.BackColor = Color.Transparent;
            radio9.BackColor = Color.Transparent;
            lbl2.Location = new Point(542, 203);
            lbl1.Location = new Point(856, 93);
            lbl3.Location = new Point(1156, 203);

            lbl5.Location = new Point(945, 193);
            lbl4.Location = new Point(750, 193);
            lbl7.Location = new Point(542, 439);

            lbl6.Location = new Point(962, 309);
            lbl8.Location = new Point(737, 309);
            lbl9.Location = new Point(855, 529);

            lbl10.Location = new Point(846, 408);
            lbl11.Location = new Point(1136, 440);

            //PİCTUREBOXLARIN DAĞILIMI İÇİN;
            kaleci.Location = new Point(859, 35);
            ply2.Location = new Point(565, 145);
            ply3.Location = new Point(1169, 145);
            ply4.Location = new Point(771, 135);
            ply5.Location = new Point(965, 135);
            ply6.Location = new Point(979, 252);
            ply7.Location = new Point(556, 381);
            ply8.Location = new Point(753, 252);
            ply9.Location = new Point(873, 471);
            ply10.Location = new Point(864, 350);
            ply11.Location = new Point(1159, 380);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cmb9.Visible = false; label9.Visible = false;
            cmb10.Visible = false; label10.Visible = false;
            cmb11.Visible = false; label11.Visible = false;

            lbl6.Visible = true; ply6.Visible = true;
            lbl7.Visible = true; ply7.Visible = true;
            lbl8.Visible = true; ply8.Visible = true;
            lbl9.Visible = false; ply9.Visible = false;
            lbl10.Visible = false; ply10.Visible = false;
            lbl11.Visible = false; ply11.Visible = false;

            ply7.Location = new Point(907, 484);
            lbl7.Location = new Point(899, 542);

            ply2.Location = new Point(707, 313);
            lbl2.Location = new Point(703, 371);

            ply6.Location = new Point(879, 285);
            lbl6.Location = new Point(874, 340);

            ply8.Location = new Point(1048, 313);
            lbl8.Location = new Point(1044, 369);

            ply4.Location = new Point(659, 177);
            lbl4.Location = new Point(655, 235);

            ply5.Location = new Point(889, 149);
            lbl5.Location = new Point(885, 212);

            ply3.Location = new Point(1096, 177);
            lbl3.Location = new Point(1092, 235);


            radio8.BackColor = Color.Red;
            radio11.BackColor = Color.Transparent;
            radio9.BackColor = Color.Transparent;
        }


        frmesamerapor esameraporum;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (esameraporum == null || esameraporum.IsDisposed)
            {
                esameraporum = new frmesamerapor();
                esameraporum.Show();

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }
    }



}

