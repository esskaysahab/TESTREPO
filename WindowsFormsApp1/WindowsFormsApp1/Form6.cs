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

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        void loadData()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Bus", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Bus (Student_id,Card_no,Install_month,Paid_date,Total_fine,Report) values (@id,@card,@month,@date,@fine,@report)", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@card", textBox3.Text);
            cmd.Parameters.AddWithValue("@month", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@fine", textBox5.Text);
            cmd.Parameters.AddWithValue("@report", textBox4.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Payment Saved");

            comboBox1.SelectedIndex = -1;
            textBox5.Clear();
            textBox4.Clear();

            cls();
            loadData();
        }

        string sid;
        string sname;
        string bus;

        public Form6(string id, string name, string b)
        {
            InitializeComponent();

            sid = id;
            sname = name;
            bus = b;
        }

        void cls()
        {
            textBox3.Clear();      // Card no
            comboBox1.SelectedIndex = -1;  // Month
            comboBox2.SelectedIndex = -1;  // Installment
            textBox5.Clear();      // Total fine
            textBox4.Clear();      // Report
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Bus WHERE Student_id=@id AND Install_month=@month", con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@month", comboBox1.Text);

                int result = cmd.ExecuteNonQuery();

                con.Close();

                if (result > 0)
                {
                    MessageBox.Show("Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }

                cls();
                loadData();
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int fee = 300;

            int fine = fee * 10 / 100;
            int total = fee + fine;

            textBox5.Text = total.ToString();

            textBox4.Text =
            "Bus Fee = 300\nFine Added = 10%\nTotal Payable = " + total;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 f = new Form4();
            f.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = sid;     // Student ID
            textBox2.Text = sname;   // Student Name
            textBox3.Text = bus;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

            comboBox2.Text = "300";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Student_id"].Value.ToString();
                textBox3.Text = row.Cells["Card_no"].Value.ToString();
                comboBox1.Text = row.Cells["Install_month"].Value.ToString();
                dateTimePicker1.Text = row.Cells["Paid_date"].Value.ToString();
                textBox5.Text = row.Cells["Total_fine"].Value.ToString();
                textBox4.Text = row.Cells["Report"].Value.ToString();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
