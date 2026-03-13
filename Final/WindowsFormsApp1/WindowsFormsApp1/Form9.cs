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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        void cls()
        {
            textBox1.Clear();  // Student ID
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();


            dateTimePicker1.Value = DateTime.Now;

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double installment;

            // check valid number
            if (!double.TryParse(textBox2.Text, out installment))
            {
                MessageBox.Show("Enter valid Installment amount");
                return;
            }

            double gst = installment * 18 / 100;
            double electric = 255.70;

            double total = installment + gst + electric;

            textBox3.Text = gst.ToString("0.00");
            textBox4.Text = electric.ToString("0.00");
            textBox5.Text = total.ToString("0.00");

            textBox6.Text =
            "Installment = " + installment +
            "\nGST (18%) = " + gst +
            "\nElectric = 255.70" +
            "\nTotal = " + total;

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox2.Text = "1000";
            textBox4.Text = "255.70";
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            // First check student exists
            SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Student WHERE Student_id=@id", con);
            check.Parameters.AddWithValue("@id", textBox1.Text.Trim());

            int count = (int)check.ExecuteScalar();

            if (count == 0)
            {
                MessageBox.Show("Student ID not found in Student table");
                con.Close();
                cls();
                return;
            }

            // Insert installment
            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Installment (Student_id,Installment,Gst,Electric,Paid_date,Total_fine,Report) VALUES (@id,@install,@gst,@electric,@date,@fine,@report)", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@install", textBox2.Text);
            cmd.Parameters.AddWithValue("@gst", textBox3.Text);
            cmd.Parameters.AddWithValue("@electric", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@fine", textBox5.Text);
            cmd.Parameters.AddWithValue("@report", textBox6.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Installment Saved Successfully");

            cls();   // clear fields
        }
    }
}
