using DevExpress.Diagram.Core.Native.Ribbon;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Football_Club
{
    public partial class frmsporcukayit : Form
    {
        public frmsporcukayit()
        {
            InitializeComponent();
        }

        //bool durum;

        //void mukerrer()
        //{
        //    sqlbaglantisi bgl = new sqlbaglantisi();
        //    SqlCommand komut1 = new SqlCommand("Select * from Futbolcular where TC=@p1", bgl.baglanti());
        //    komut1.Parameters.AddWithValue("@p1", msktc.Text);
        //    SqlDataReader dr = komut1.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        durum = false;
        //    }
        //    else
        //    {
        //        durum = true;
        //    }
        //}

        void futbolculistele()
        {
            sqlbaglantisi bgl5 = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("Select * from Futbolcular order by Adi asc ", bgl5.baglanti());
            adap.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void temizle()
        {
            txtadi.Text = "";
            txtid.Text = "";
            // textEdit3.Text = "";
            txtsoyadi.Text = "";
            txtmail.Text = "";
            mskdogum.Text = "";
            msktelefon.Text = "";
            mskboy.Text = "";
            mskkilo.Text = "";
            richnot.Text = "";
            cmbmevki.Text = "";
            msktc.Text = "";
            txtveliad.Text = "";
            mskvelitel.Text = "";
            txtokul.Text = "";
            txtokulno.Text = ""; txtara.Text = "";
            txtsinif.Text = "";
            msklisansno.Text = ""; txtanneadi.Text = "";
            txtannebabamail.Text = ""; txtanneisadres.Text = ""; txtannemeslek.Text = ""; txtbabaisadres.Text = ""; txtbabameslek.Text = "";
            txtdogumyeri.Text = ""; txtresimyolu.Text = "";
            checkBox1.Checked = false;
            circlePic1.Image = Image.FromFile("S:\\CSHARP DENEMELERİM\\icon\\istockphoto-1209654046-612x612.jpg");

        }
        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void textEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        //void baglan()
        //{
        //    SqlConnection baglanti = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
        //}


        private void frmsporcukayit_Load(object sender, EventArgs e)
        {
            //SELECT * FROM TABLO_ISMI WITH(NOLOCK)
            cmbgrup.SelectedItem = lblgrup.Text;
           
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand toplamfutbolcu = new SqlCommand("select Count(id) AS 'Toplam Sayi' from Futbolcular  with(NOLOCK) ", bgl.baglanti());
            SqlDataReader drtoplamfutbolcu = toplamfutbolcu.ExecuteReader();
            while (drtoplamfutbolcu.Read())
            {
                lbltoplamoyuncu.Text = drtoplamfutbolcu[0].ToString();

            }

            txtara.CharacterCasing = CharacterCasing.Upper;
            btnmukerrer.BackColor = Color.Lime;
            futbolculistele();
            temizle();
            sqlbaglantisi bgl2 = new sqlbaglantisi();

            cmbmevki.Properties.CharacterCasing = CharacterCasing.Upper;
            // comboboxa verileri çekme
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select Mevki from Mevkiler with(NOLOCK) ";
            komut.Connection = bgl2.baglanti();
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbmevki.Properties.Items.Add(dr["Mevki"]);
            }
            bgl.baglanti().Close();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            lblgrup.Text = cmbgrup.Text;

            try
            {
                FileStream filestream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                BinaryReader binaryreader = new BinaryReader(filestream);
                byte[] resim = binaryreader.ReadBytes((int)filestream.Length);
                binaryreader.Close();
                filestream.Close();
                if (resim != null)
                {
                    object val = resim;

                    if (val == DBNull.Value || val == null)
                    {
                        Resim = new byte[0];
                        circlePic2.ImageLocation = "S:\\CSHARP DENEMELERİM\\icon\\istockphoto-1209654046-612x612.jpeg";

                    }
                    else
                    {
                        DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                        byte[] resim2;
                        resim2 = (byte[])dr["Resim"];
                        MemoryStream memorystream = new MemoryStream(resim);
                        circlePic2.Image = Image.FromStream(memorystream);

                    }

                    sqlbaglantisi bgl = new sqlbaglantisi();
                    SqlCommand kaydet = new SqlCommand("insert into Futbolcular(Adi,Soyadi,DogumTarihi,Mevki,Boy,Kilo,Notlar,Telefon,Mail,VeliAd,VeliTel,LisansNo,Okul,Sinif,OkulNo,Resimyolu,Resim,TC,Dogumyeri,Babameslek,Babaisadresi,Annemeslek,Anneisadresi,AnneBabaMail,AnneTel,Grup,AnneAdi) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27)", bgl.baglanti());

                    kaydet.Parameters.AddWithValue("@p1", txtadi.Text);
                    kaydet.Parameters.AddWithValue("@p2", txtsoyadi.Text);
                    kaydet.Parameters.AddWithValue("@p3", Convert.ToDateTime(mskdogum.Text.ToString()));
                    kaydet.Parameters.AddWithValue("@p4", cmbmevki.Text);
                    kaydet.Parameters.AddWithValue("@p5", mskboy.Text.ToString());
                    kaydet.Parameters.AddWithValue("@p6", mskkilo.Text.ToString());
                    kaydet.Parameters.AddWithValue("@p7", richnot.Text);
                    kaydet.Parameters.AddWithValue("@p8", msktelefon.Text); ;
                    kaydet.Parameters.AddWithValue("@p9", txtmail.Text);
                    kaydet.Parameters.AddWithValue("@p10", txtveliad.Text);
                    kaydet.Parameters.AddWithValue("@p11", mskvelitel.Text);
                    kaydet.Parameters.AddWithValue("@p12", msklisansno.Text.ToString());
                    kaydet.Parameters.AddWithValue("@p13", txtokul.Text);
                    kaydet.Parameters.AddWithValue("@p14", txtsinif.Text);
                    kaydet.Parameters.AddWithValue("@p15", txtokulno.Text);
                    kaydet.Parameters.AddWithValue("@p16", txtresimyolu.Text);
                    kaydet.Parameters.AddWithValue("@p17", SqlDbType.Image).Value = resim;
                    kaydet.Parameters.AddWithValue("@p18", msktc.Text.ToString());
                    kaydet.Parameters.AddWithValue("@p19", txtdogumyeri.Text);
                    kaydet.Parameters.AddWithValue("@p20", txtbabameslek.Text);
                    kaydet.Parameters.AddWithValue("@p21", txtbabaisadres.Text);
                    kaydet.Parameters.AddWithValue("@p22", txtannemeslek.Text);
                    kaydet.Parameters.AddWithValue("@p23", txtanneisadres.Text);
                    kaydet.Parameters.AddWithValue("@p24", txtannebabamail.Text);
                    kaydet.Parameters.AddWithValue("@p25", mskannetel.Text);
                    kaydet.Parameters.AddWithValue("@p26", lblgrup.Text);
                    kaydet.Parameters.AddWithValue("@p27", txtanneadi.Text);


                    if (kaydet.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show(msktc.Text + " TC nolu " + "\n" + txtadi.Text + " " + txtsoyadi.Text + "\n" + lblgrup.Text + " Grubuna" + " \n" + "Oyuncu eklemesi yapıldı ve listeye eklendi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        temizle();
                        txtadi.Focus();
                        futbolculistele();
                        bgl.baglanti().Close();
                    }
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());

            }

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            temizle();
        }





        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //SEÇİLEN KİŞİNİN GRİDVİEW ÜZERİNDEKİ BİLGİLERİ BOXLARA TAŞIMA

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["id"].ToString();
                txtadi.Text = dr["Adi"].ToString();
                txtsoyadi.Text = dr["Soyadi"].ToString();
                mskdogum.Text = dr["DogumTarihi"].ToString();
                cmbmevki.Text = dr["Mevki"].ToString();
                msktelefon.Text = dr["Telefon"].ToString();
                txtmail.Text = dr["Mail"].ToString();
                mskboy.Text = dr["Boy"].ToString();
                mskkilo.Text = dr["Kilo"].ToString();
                richnot.Text = dr["Notlar"].ToString();
                //pictureBox2.ImageLocation = dr["Resimyolu"].ToString();
                txtveliad.Text = dr["VeliAd"].ToString();
                mskvelitel.Text = dr["VeliTel"].ToString();
                txtokulno.Text = dr["OkulNo"].ToString();
                txtsinif.Text = dr["Sinif"].ToString();
                txtokul.Text = dr["Okul"].ToString();
                msktc.Text = dr["TC"].ToString();
                msklisansno.Text = dr["LisansNo"].ToString();
                txtresimyolu.Text = dr["Resimyolu"].ToString();
                txtanneadi.Text = dr["AnneAdi"].ToString();
                txtannemeslek.Text = dr["Annemeslek"].ToString();
                txtanneisadres.Text = dr["Anneisadresi"].ToString();
                txtannebabamail.Text = dr["AnneBabaMail"].ToString();
                lblgrup.Text = dr["Grup"].ToString();
                txtdogumyeri.Text = dr["Dogumyeri"].ToString();
                txtbabameslek.Text = dr["Babameslek"].ToString();
                mskannetel.Text = dr["Annetel"].ToString();
                txtbabaisadres.Text = dr["Babaisadresi"].ToString();
                cmbgrup.Text = dr["Grup"].ToString();


                if (dr["Resim"] != null)
                {
                    object val = dr["Resim"];

                    if (val == DBNull.Value || val == null)
                    {
                        Resim = new byte[0];
                        circlePic2.ImageLocation = "S:\\CSHARP DENEMELERİM\\icon\\istockphoto-1209654046-612x612.jpeg";

                    }
                    else
                    {
                        byte[] resim;
                        resim = (byte[])dr["Resim"];
                        MemoryStream memorystream = new MemoryStream(resim);
                        circlePic2.Image = Image.FromStream(memorystream);

                    }


                }


            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            try
            {
                string imagepath = txtresimyolu.Text;
                FileStream filestream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                BinaryReader binaryreader = new BinaryReader(filestream);
                byte[] resim = binaryreader.ReadBytes((int)filestream.Length);
                binaryreader.Close();
                filestream.Close();

                SqlCommand guncelle = new SqlCommand("update Futbolcular set Adi=@p1, Soyadi=@p2, DogumTarihi=@p3, Mevki=@p4, Boy=@p5, Kilo=@p6, Notlar=@p7,Telefon=@p8,Mail=@p9,VeliAd=@p10 ,VeliTel=@p11,LisansNo=@p12,Okul=@p13,Sinif=@p14,OkulNo=@p15,Resimyolu=@p16,Resim=@p17, TC=@p18 ,BabaMeslek=@p20,Babaisadresi=@p21,Annemeslek=@p22,Anneisadresi=@p23,AnneBabaMail=@p24,AnneTel=@p25,Grup=@p26,AnneAdi=@p27, Dogumyeri=@p28 where id=@p19", bgl.baglanti());

                guncelle.Parameters.AddWithValue("@p1", txtadi.Text);
                guncelle.Parameters.AddWithValue("@p2", txtsoyadi.Text);
                guncelle.Parameters.AddWithValue("@p3", Convert.ToDateTime(mskdogum.Text));
                guncelle.Parameters.AddWithValue("@p4", cmbmevki.Text);
                guncelle.Parameters.AddWithValue("@p5", mskboy.Text.ToString());
                guncelle.Parameters.AddWithValue("@p6", mskkilo.Text.ToString());
                guncelle.Parameters.AddWithValue("@p7", richnot.Text.ToString());
                guncelle.Parameters.AddWithValue("@p8", msktelefon.Text.ToString()); ;
                guncelle.Parameters.AddWithValue("@p9", txtmail.Text);
                guncelle.Parameters.AddWithValue("@p10", txtveliad.Text);
                guncelle.Parameters.AddWithValue("@p11", mskvelitel.Text.ToString());
                guncelle.Parameters.AddWithValue("@p12", msklisansno.Text.ToString());
                guncelle.Parameters.AddWithValue("@p13", txtokul.Text);
                guncelle.Parameters.AddWithValue("@p14", txtsinif.Text.ToString());
                guncelle.Parameters.AddWithValue("@p15", txtokulno.Text.ToString());
                guncelle.Parameters.AddWithValue("@p16", txtresimyolu.Text);
                guncelle.Parameters.AddWithValue("@p17", SqlDbType.Image).Value = resim;
                guncelle.Parameters.AddWithValue("@p18", msktc.Text.ToString());
                guncelle.Parameters.AddWithValue("@p20", txtbabameslek.Text);
                guncelle.Parameters.AddWithValue("@p21", txtbabaisadres.Text);
                guncelle.Parameters.AddWithValue("@p22", txtannemeslek.Text);
                guncelle.Parameters.AddWithValue("@p23", txtanneisadres.Text);
                guncelle.Parameters.AddWithValue("@p24", txtannebabamail.Text);
                guncelle.Parameters.AddWithValue("@p25", mskannetel.Text.ToString());
                guncelle.Parameters.AddWithValue("@p26", lblgrup.Text);
                guncelle.Parameters.AddWithValue("@p27", txtanneadi.Text);
                guncelle.Parameters.AddWithValue("@p28", txtdogumyeri.Text);
                guncelle.Parameters.AddWithValue("@p19", txtid.Text.ToString());


                if (guncelle.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Oyuncu güncellemesi yapıldı", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    futbolculistele();
                    temizle();

                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }

        }

        private bool RotateImage(Image img)
        {
            throw new NotImplementedException();
        }

        private void cmbmevki_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtadi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtadi_TextChanged(object sender, EventArgs e)
        {
            txtadi.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtsoyadi_TextChanged(object sender, EventArgs e)
        {
            txtsoyadi.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void richnot_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtveliad_TextChanged(object sender, EventArgs e)
        {
            txtveliad.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtokul_TextChanged(object sender, EventArgs e)
        {
            txtokul.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void cmbmevki_TextChanged(object sender, EventArgs e)
        {
            cmbmevki.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtsinif_TextChanged(object sender, EventArgs e)
        {
            txtsinif.Properties.CharacterCasing = CharacterCasing.Upper;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                msklisansno.Enabled = true;
            }

            else
            {
                msklisansno.Enabled = false;
            }
        }

        string imagepath;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = "Jpeg Dosyaları (*.Jpeg)|*.jpeg| Jpg Dosyaları(*.jpg)|*.jpg| Png Dosyaları(*.png)|*png| Gif dosyaları (*.gif)|*gif| Tif Dosyaları(*.tif)|*tif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                circlePic2.Image = Image.FromFile(openFileDialog1.FileName);

                imagepath = openFileDialog1.FileName;
                txtresimyolu.Text = imagepath;
            }


        }
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public Image image { get; set; }

        private void gridView1_Click(object sender, EventArgs e)
        {
            //var strRow = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["id"]).ToString();

        }

        private void txtresimyolu_EditValueChanged(object sender, EventArgs e)
        {

        }

        public byte[] Resim { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = circlePic2.Image;
            circlePic2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            circlePic2.Image = img;
            RotateImage(img, 90);

            //Döndürme yapmadan yatay çevirme işlemi
            //img.RotateFlip(RotateFlipType.RotateNoneFlipX);

        }

        private void RotateImage()
        {
            throw new NotImplementedException();
        }

        //private void radioA_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblgrup.Text = "A";
        //}

        //private void radioB_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblgrup.Text = "B";
        //}

        //private void radioC_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblgrup.Text = "C";
        //}

        //private void radioD_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblgrup.Text = "D";
        //}

        private void txtmail_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtdogumyeri_EditValueChanged(object sender, EventArgs e)
        {
            txtdogumyeri.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtanneadi_EditValueChanged(object sender, EventArgs e)
        {
            txtanneadi.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtannemeslek_EditValueChanged(object sender, EventArgs e)
        {
            txtannemeslek.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtanneisadres_EditValueChanged(object sender, EventArgs e)
        {
            txtanneisadres.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtveliad_EditValueChanged(object sender, EventArgs e)
        {
            txtveliad.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtbabameslek_EditValueChanged(object sender, EventArgs e)
        {
            txtbabameslek.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtbabaisadres_EditValueChanged(object sender, EventArgs e)
        {
            txtbabaisadres.Properties.CharacterCasing = CharacterCasing.Upper;
        }


        private void msktc_TextChanged(object sender, EventArgs e)
        {
            //mukerrer();
            //if (durum == false)
            //{
            //    btnmukerrer.BackColor = Color.Red;
            //}
            //else
            //{
            //    btnmukerrer.BackColor = Color.Lime;
            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //Football_Club.Raporlar.XtraReport1 rp = new Football_Club.Raporlar.XtraReport1();
            //DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //if (dr!=null)
            //{
            //    rp.ad = dr["id"].ToString();
            //    rp.ShowPreview();
            //}
        }

        private void btnmukerrer_Click(object sender, EventArgs e)
        {

        }

        private void circlePic1_Click(object sender, EventArgs e)
        {

        }

        private void doubleBitmapControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl29_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblgrup_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator7_Load(object sender, EventArgs e)
        {

        }

        private void labelControl28_Click(object sender, EventArgs e)
        {

        }

        private void txtannebabamail_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl27_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void labelControl25_Click(object sender, EventArgs e)
        {

        }

        private void labelControl23_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator6_Load(object sender, EventArgs e)
        {

        }

        private void mskannetel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelControl20_Click(object sender, EventArgs e)
        {

        }

        private void labelControl22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void labelControl26_Click(object sender, EventArgs e)
        {

        }

        private void labelControl24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void mskvelitel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void txtokul_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtsinif_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtokulno_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void labelControl17_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void mskkilo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskboy_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void msktelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskdogum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void futbolcularBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl21_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator5_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator4_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbltoplamoyuncu_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string ara = txtadi.Text;
            SqlConnection baglanti = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from Futbolcular where Adi like '%" + txtara.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DialogResult dialogum;
            dialogum = MessageBox.Show("Futbolcu listeden silmek istediğinizden emin misiniz?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogum == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from Futbolcular where id=@p1 ", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtid.Text);
                if (sil.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Futbolcu Listeden Silindi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                futbolculistele();
                temizle();
                bgl.baglanti().Close();
            }
            if (dialogum == DialogResult.No)
            {
                MessageBox.Show("Futbolcu Silme İşlemi İpal Edildi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                futbolculistele();
            }
        }

        private void labelControl32_Click(object sender, EventArgs e)
        {

        }

        private void cmbgrup_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void cmbgrup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lblgrup.Text = cmbgrup.Text;
        }
    }
}