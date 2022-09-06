using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace KullanicilarArasiVeritTabanliMesajlasmaSistemi_KAVTMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=THINKPAD-E470;Initial Catalog=MesajlasmaSistemi;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_KİSİLER WHERE NUMARA=@P1 AND SİFRE =@P2",bag);
            cmd.Parameters.AddWithValue("@P1",mskdTxtNumara.Text);
            cmd.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader(); 
            if (dr.Read())
            {
                Form2 frm2 = new Form2();
                frm2.numara = mskdTxtNumara.Text; //maskedtextbox'daki değeri frm2'deki numara değişkenine ata ! 
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }
            bag.Close();
        }
    }
}
