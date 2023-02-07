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
    public partial class frmsınavnot : Form
    {
        public frmsınavnot()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-F59JTTH\SQLEXPRESS;Initial Catalog=okulsistemi;Integrated Security=True");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int notid;
        DataSet1TableAdapters.NotlarTableAdapter ds = new DataSet1TableAdapters.NotlarTableAdapter();
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.notlistesi(int.Parse(textBox1.Text));
        }

        private void frmsınavnot_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "dersad";
            comboBox1.ValueMember = "dersid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        string durum;
        private void button1_Click(object sender, EventArgs e)
        {
         
            sinav1 = Convert.ToInt32(textBox3.Text);
            sinav2 = Convert.ToInt32(textBox2.Text);
            sinav3 = Convert.ToInt32(textBox4.Text);
            proje = Convert.ToInt32(textBox5.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            textBox6.Text = ortalama.ToString();
            if(ortalama >= 50)
            {
                textBox7.Text = "true";
            }
            else
            {
                textBox7.Text = "false";
            }
        }

        private void button2_Click(object sender, EventArgs e) => ds.notgüncelle(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(textBox1.Text), byte.Parse(textBox3.ToString()), byte.Parse(textBox2.ToString()), byte.Parse(textBox4.ToString()), byte.Parse(textBox5.ToString()), double.Parse(textBox6.ToString()), bool.Parse(textBox7.Text));
    }
}
