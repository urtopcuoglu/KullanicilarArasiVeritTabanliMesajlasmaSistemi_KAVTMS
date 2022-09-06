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
using System.Data.Sql;

namespace KullanicilarArasiVeritTabanliMesajlasmaSistemi_KAVTMS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection bag = new SqlConnection(@"Data Source=THINKPAD-E470;Initial Catalog=MesajlasmaSistemi;Integrated Security=True");
            void gelenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TBL_MESAJLAR WHERE ALİCİ ="+numara,bag);   //numara değişkeninden gelen değere göre bilgileri çekecek
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        void gidenkutusu ()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TBL_MESAJLAR WHERE GONDEREN="+numara,bag);
            DataTable dt2 = new DataTable();    
            dataGridView2.DataSource = dt2;
            da2.Fill(dt2);
            dataGridView2.DataSource= dt2;  
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            gelenkutusu();
            gidenkutusu();

            //AD SOYAD ÇEKME
            bag.Open();
            SqlCommand   cmd2 = new SqlCommand("Select Ad,Soyad From TBL_KİSİLER WHERE NUMARA="+numara,bag);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] +" "+ dr[1];
            }
            bag.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand cmd3 = new SqlCommand("INSERT INTO TBL_MESAJLAR (GONDEREN,ALİCİ,BASLİK,İCERİK) VALUES(@P1,@P2,@P3,@P4)",bag);
            cmd3.Parameters.AddWithValue("@P1",numara);
            cmd3.Parameters.AddWithValue("@P2",txtAlici.Text);
            cmd3.Parameters.AddWithValue("@P3", txtBaslik.Text);
            cmd3.Parameters.AddWithValue("@P4", richTextBox1.Text);
            cmd3.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("İleti Gönderildi.");
            
            gidenkutusu();
            gelenkutusu();
        }
    }
}
