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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Bus", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Total Amount
                SqlCommand cmd = new SqlCommand( "SELECT SUM(CAST(Total_fine AS DECIMAL(10,2))) FROM Bus", con);

                object total = cmd.ExecuteScalar();

                textBox1.Text = total == DBNull.Value ? "0" : total.ToString();

                con.Close();
            }
        }

       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Installment", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Total Amount
                SqlCommand cmd = new SqlCommand( "SELECT SUM(TRY_CAST(Total_fine AS DECIMAL(10,2))) FROM Installment", con);

                object total = cmd.ExecuteScalar();

                textBox1.Text = total == DBNull.Value ? "0" : total.ToString();

                con.Close();
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            //textBox1.Text = total == DBNull.Value ? "0" : total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
