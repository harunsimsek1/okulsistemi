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
    public partial class frmogrenciler : Form
    {
        public frmogrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-F59JTTH\SQLEXPRESS;Initial Catalog=okulsistemi;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void frmogrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kulupad";
            comboBox1.ValueMember = "kulupid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        string c = " ";
        private void button3_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == true)
            {
                c = "kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "erkek";
            }
            ds.ogrenciekle(textBox2.Text, textBox3.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("öğrenci eklendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedValue.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.ogrencisilme(int.Parse(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.ogrencigüncelleme(textBox2.Text, textBox3.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(textBox1.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "erkek";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "erkek";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencigetir(textBox4.Text);
        }
    }
}
