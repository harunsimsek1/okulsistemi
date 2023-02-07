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

namespace okulsistemi
{
    public partial class frmogrenci : Form
    {
        public frmogrenci()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-F59JTTH\SQLEXPRESS;Initial Catalog=okulsistemi;Integrated Security=True");
        private void frmogrenci_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select dersad,sınav1,sınav2,sınav3,proje,ortalama,durum from notlar inner join dersler on notlar.dersnotid=dersler.dersid where ogrencinotid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
           // this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
