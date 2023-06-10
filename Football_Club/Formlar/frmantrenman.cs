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
    public partial class frmantrenman : Form
    {
        public frmantrenman()
        {
            InitializeComponent();
        }

        SqlConnection baglan= new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
        void antrenmanlistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Antrenman order by Tarih desc", baglan);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtcalisma.Text = "";
            richdetay.Text = "";
            datetarih.Text = "";
            txtcalismaaciklama.Text = "";
            textEdit2.Text = "";
        }
        private void frmantrenman_Load(object sender, EventArgs e)
        {           
            antrenmanlistele();
            temizle();
            txtcalisma.CharacterCasing = CharacterCasing.Upper;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (datetarih.Value.ToString() == "" || richdetay.Text == "")
            {
                MessageBox.Show("Lütfen Antrenman Tarihi, Çalışma Adını ve Çalışma Açıklamasını boş bırakmayınız!!", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
                baglan.Open();
                SqlCommand ekle = new SqlCommand("insert into Antrenman(Tarih,CalismaAdi,CalismaAciklama) values (@p1,@p2,@p3)", baglan);               
                ekle.Parameters.AddWithValue("@p1", datetarih.Value);
                ekle.Parameters.AddWithValue("@p2", txtcalisma.Text);
                ekle.Parameters.AddWithValue("@p3", richdetay.Text);

                if (ekle.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Antrenman Programı listeye eklendi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    antrenmanlistele();
                    temizle();
                }
            }
                        
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
             DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Antrenmanı listeden silmek istediğinizden emin misiniz?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from Antrenman where id=@p1", baglan);
                sil.Parameters.AddWithValue("@p1", txtid.Text.ToString());
                if (sil.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Antrenman Listeden Silindi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                antrenmanlistele();
                temizle();
            }
        }

        private void buni(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("Update Antrenman set CalismaAdi=@p1, Tarih=@p2, CalismaAciklama=@p3 where id=@p4", baglan);
            guncelle.Parameters.AddWithValue("@p1", txtcalisma.Text);
            guncelle.Parameters.AddWithValue("@p2", datetarih.Value);
            guncelle.Parameters.AddWithValue("@p3", richdetay.Text);
            guncelle.Parameters.AddWithValue("@p4", txtid.Text.ToString());

            if (guncelle.ExecuteNonQuery()> 0)
            {
                MessageBox.Show("Antrenman Güncelleme Başarıyla Yapıldı","Bilgi Mesajı", MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Information);
                antrenmanlistele();
            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             DataRow dr= gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                datetarih.Text = dr["Tarih"].ToString();
                txtcalisma.Text = dr["CalismaAdi"].ToString();
                richdetay.Text = dr["CalismaAciklama"].ToString();
                txtid.Text = dr["id"].ToString();
            }
        }

       
       

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            textEdit2.Properties.CharacterCasing = CharacterCasing.Upper;
            SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Antrenman where CalismaAdi like '%" + textEdit2.Text + "%'", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //SqlConnection baglan= new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("select * from Antrenman where CalismaAdi like '%" + textEdit2.Text + "%'", baglan);
            //SqlDataAdapter da = new SqlDataAdapter(komut);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //gridControl1.DataSource = ds.Tables[0];
            //baglan.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }
            
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("select * from Antrenman where Tarih like '%" + dateTimePicker2.Value.Date + "%'", baglan);
            //SqlDataAdapter da = new SqlDataAdapter(komut);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //gridControl1.DataSource = ds.Tables[0];
            //baglan.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("Update Antrenman set Tarih=@p1, CalismaAdi=@p2, CalismaAciklama=@p3 where id=@p4", baglan);
            guncelle.Parameters.AddWithValue("@p1", datetarih.Value);
            guncelle.Parameters.AddWithValue("@p2", txtcalisma.Text);
            guncelle.Parameters.AddWithValue("@p3", richdetay.Text);
            guncelle.Parameters.AddWithValue("@p4", txtid.Text.ToString());
            if (guncelle.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Antrenman Güncellemesi Yapıldı", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                antrenmanlistele();
                baglan.Close();

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            antrenmanlistele();
            textEdit2.Text = "";
           
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=.; Database=Futbol_Bilgi; integrated security=true");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Antrenman where CalismaAciklama like '%" + txtcalismaaciklama.Text + "%'", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglan.Close();
        }

     }
 }
