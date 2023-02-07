using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okulsistemi
{
    public partial class frmdersler : Form
    {
        public frmdersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DerslerTableAdapter ds = new DataSet1TableAdapters.DerslerTableAdapter();
        private void frmdersler_Load(object sender, EventArgs e)
        {
            

            dataGridView1.DataSource = ds.derslistesi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.derslistesi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.dersekle(textBox2.Text);
            MessageBox.Show("ders ekleme ilemi başarılı");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.derssilme(byte.Parse(textBox1.Text));
            MessageBox.Show("Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.UpdateQuery(textBox2.Text, byte.Parse(textBox1.Text));
            MessageBox.Show("güncellendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
    }
}
