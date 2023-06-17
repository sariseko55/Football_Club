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
    public partial class frmtakimekle : Form
    {
        public frmtakimekle()
        {
            InitializeComponent();
        }

        bool durum;
        void mukerrer()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand komut1 = new SqlCommand("Select * from Takimlar where TakimAdi=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txttakım.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
        }



        public void listele()
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Takimlar order by TakimAdi asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            txttakım.Text = "";
        }

        public static string takimkayit = "";
        private void frmtakimekle_Load(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id,TakimAdi from Takimlar order by TakimAdi asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            txttakım.Text = "";
            txttakım.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Seçtiğiniz takımı listeden silmek istediğinizden emin misiniz?", "Bilgi Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from Takimlar where TakimAdi=@TakimAdi", bgl.baglanti());
                sil.Parameters.AddWithValue("@TakimAdi", txttakım.Text);
                if (sil.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(txttakım.Text + " " + "Takımı Listeden Silindi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                listele();
                txttakım.Text = "";
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txttakım.Text = dr["TakimAdi"].ToString();
                //textEdit1.Text = dr["id"].ToString();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mukerrer();
            if (durum == true)
            {
                sqlbaglantisi bgl = new sqlbaglantisi();

                SqlCommand ekle = new SqlCommand("insert into Takimlar (TakimAdi) Values(@p1)", bgl.baglanti());
                ekle.Parameters.AddWithValue("@p1", txttakım.Text.ToString());

                if (ekle.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(txttakım.Text + " listeye eklendi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttakım.Text = "";
                }
            }
            if (durum == false)
            {
                MessageBox.Show(txttakım.Text + " " + "takımını daha önce listeye eklediniz!\n Lütfen başka takım ekleyiniz...", "Mükerrer Kayıt!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmmaclar frmac = new frmmaclar();
            takimkayit = txttakım.Text.ToString();
            listele();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand guncelle = new SqlCommand("Update Takimlar set TakimAdi=@p1 where id=@p2", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txttakım.Text);
            guncelle.Parameters.AddWithValue("@p2", textEdit1.Text.ToString());
            if (guncelle.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Seçilen takım güncellemesi yapılmıştır!", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            listele();
            txttakım.Text = "";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void txttakım_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            { 
                txttakım.Text = dr["TakimAdi"].ToString();
                textEdit1.Text = dr["id"].ToString();
            } 
        }
    }
}

