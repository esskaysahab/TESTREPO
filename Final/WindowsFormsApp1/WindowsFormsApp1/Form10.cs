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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime issue = dateTimePicker1.Value;
            DateTime submit = dateTimePicker2.Value;

            int days = (submit - issue).Days;

            if (days > 0)
            {
                double fine = days * 10.25;

                textBox5.Text = fine.ToString("0.00");

                textBox4.Text =
                "Late Days = " + days +
                "\nFine per Day = 10.25" +
                "\nTotal Fine = " + fine;
            }
            else
            {
                textBox5.Text = "0";

                textBox4.Text = "No Fine";
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        void cls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox5.Clear();
            textBox4.Clear();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Library (Student_id,Card_no,Book_name,Issue_date,Submit_date,Total_fine,Report) VALUES (@id,@card,@book,@issue,@submit,@fine,@report)", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@card", textBox2.Text);
            cmd.Parameters.AddWithValue("@book", textBox3.Text);
            cmd.Parameters.AddWithValue("@issue", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@submit", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@fine", textBox5.Text);
            cmd.Parameters.AddWithValue("@report", textBox4.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Library Record Saved");

            cls();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
