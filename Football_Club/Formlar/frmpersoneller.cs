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

namespace Football_Club.Formlar
{
    public partial class frmpersoneller : Form
    {
        public frmpersoneller()
        {
            InitializeComponent();
        }


        void Temizle()
        {
            txtadi.Text = "";
            txtsoyadi.Text = "";
            msktc.Text = "";
            msktelefon.Text = "";
            mskdogumtarihi.Text = "";
            txtmail.Text = "";
            cmbelge.Text = "";
            cmbgorev.Text = "";
            txtlisansno.Text = "";
        }

        void personellistele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personeller", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void frmpersoneller_Load(object sender, EventArgs e)
        {
            
            txtadi.CharacterCasing = CharacterCasing.Upper;
            txtsoyadi.CharacterCasing = CharacterCasing.Upper;
            //txtmail.CharacterCasing = CharacterCasing.Upper;

            personellistele();


            //sqlbaglantisi bgl= new sqlbaglantisi();
            ////bgl.baglanti().Open();
            //SqlCommand komut = new SqlCommand("Select Belge from Belgeler",bgl.baglanti());
            //SqlDataReader droku= komut.ExecuteReader();
            //while ( droku.Read())
            //{
            //    cmbelge.Text = droku["Belge"].ToString();
            //}  
            //bgl.baglanti().Close();

            SqlConnection baglan5 = new SqlConnection("Server=.;Database=Futbol_Bilgi; integrated security=true");
            baglan5.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select Belge from Belgeler";
            komut.Connection = baglan5;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbelge.Items.Add(dr["Belge"].ToString());
            }
            baglan5.Close();



        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand kaydet = new SqlCommand("insert into Personeller(Adi,Soyadi,TC,Telefon,DogumTarihi,Mail,Belge,Belge2,Gorevi,LisansNo) values(@adi,@soyadi,@tc,@telefon,@dogumt,@mail,@belge,@belge2,@gorevi,@lisansno)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@adi", txtadi.Text);
            kaydet.Parameters.AddWithValue("@soyadi", txtsoyadi.Text);
            kaydet.Parameters.AddWithValue("@tc", msktc.Text.ToString());
            kaydet.Parameters.AddWithValue("@telefon", msktelefon.Text.ToString());
            kaydet.Parameters.AddWithValue("@dogumt", Convert.ToDateTime(mskdogumtarihi.Text.ToString()));
            kaydet.Parameters.AddWithValue("@mail", txtmail.Text);
            kaydet.Parameters.AddWithValue("belge", cmbelge.Text);
            kaydet.Parameters.AddWithValue("@belge2", richTextBox1.Text);
            kaydet.Parameters.AddWithValue("@gorevi", cmbgorev.Text);
            kaydet.Parameters.AddWithValue("@lisansno", txtlisansno.Text.ToString());
           
            if (kaydet.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Personel Eklemesi Yapıldı", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Temizle();
            personellistele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtadi.Text = dr["Adi"].ToString();
                txtsoyadi.Text = dr["Soyadi"].ToString();
                msktc.Text = dr["TC"].ToString();
                msktelefon.Text = dr["Telefon"].ToString();
                mskdogumtarihi.Text = dr["DogumTarihi"].ToString();
                txtmail.Text = dr["Mail"].ToString();
                cmbelge.Text = dr["Belge"].ToString();
                cmbgorev.Text = dr["Gorevi"].ToString();
                txtlisansno.Text = dr["LisansNo"].ToString();
                richTextBox1.Text = dr["Belge2"].ToString();
                txtid.Text = dr["id"].ToString();

            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand guncelle = new SqlCommand("Update Personeller set Adi=@p1, Soyadi=@p2,Gorevi=@p3, LisansNo=@p4,TC=@p5, DogumTarihi=@p6, Telefon=@p7, Belge=@p8, Belge2=@p9, Mail=@p10 where id=@p11", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtadi.Text);
            guncelle.Parameters.AddWithValue("@p2", txtsoyadi.Text);
            guncelle.Parameters.AddWithValue("@p3", cmbgorev.Text);
            guncelle.Parameters.AddWithValue("@p4", txtlisansno.Text.ToString());
            guncelle.Parameters.AddWithValue("@p5", msktc.Text.ToString());
            guncelle.Parameters.AddWithValue("@p6", Convert.ToDateTime(mskdogumtarihi.Text.ToString()));
            guncelle.Parameters.AddWithValue("@p7", msktelefon.Text.ToString());
            guncelle.Parameters.AddWithValue("@p8", cmbelge.Text);
            guncelle.Parameters.AddWithValue("@p9", richTextBox1.Text);
            guncelle.Parameters.AddWithValue("@p10", txtmail.Text);
            guncelle.Parameters.AddWithValue("@p11", txtid.Text);
            if (guncelle.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Güncelleme başarıyla gerçekleşti ", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                personellistele();
                bgl.baglanti().Close();

            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DialogResult dialogum;
            dialogum = MessageBox.Show("Personeli listeden silmek istediğinizden emin misiniz?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogum == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from Personeller where id=@p1 ", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtid.Text);
                if (sil.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Personel Listeden Silindi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                personellistele();
                Temizle();
                bgl.baglanti().Close();
            }
            if (dialogum == DialogResult.No)
            {
                MessageBox.Show("Futbolcu Silme İşlemi İpal Edildi", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personellistele();
            }
        }

        
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
