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
        private void frmpersoneller_Load(object sender, EventArgs e)
        {
            txtadi.CharacterCasing = CharacterCasing.Upper;
            txtsoyadi.CharacterCasing = CharacterCasing.Upper;
            //txtmail.CharacterCasing = CharacterCasing.Upper;


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

            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personeller", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand kaydet = new SqlCommand("insert into Personeller(Adi,Soyadi,TC,Telefon,DogumTarihi,Mail,Belge,Belge2,Gorevi,LisansNo) values(@adi,@soyadi,@tc,@telefon,@dogumt,@mail,@belge,@belge2,@gorevi,@lisansno)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@adi", txtadi.Text);
            kaydet.Parameters.AddWithValue("@soyadi", txtsoyadi.Text);
            kaydet.Parameters.AddWithValue("@tc", msktc.Text.ToString());
            kaydet.Parameters.AddWithValue("@telefon", msktelefon.Text.ToString());
            kaydet.Parameters.AddWithValue("@dogumt", mskdogumtarihi.Text.ToString());
            kaydet.Parameters.AddWithValue("@mail", txtmail.Text);
            kaydet.Parameters.AddWithValue("belge", cmbelge.Text);
            kaydet.Parameters.AddWithValue("@belge2", txtlisans2.Text);
            kaydet.Parameters.AddWithValue("@gorevi", cmbgorev.Text);
            kaydet.Parameters.AddWithValue("@lisansno", txtlisansno.Text.ToString());
            if (kaydet.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Personel Eklemesi Yapıldı", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Temizle();
            sqlbaglantisi bgl2 = new sqlbaglantisi();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personeller", bgl2.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl2.baglanti().Close();
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
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
