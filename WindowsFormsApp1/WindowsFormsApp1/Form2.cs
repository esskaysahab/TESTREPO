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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        void cls()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
              con.Open();

    // Login table insert
    SqlCommand cmd1 = new SqlCommand(
    "INSERT INTO Login VALUES('Student',@username,@password,@id)", con);

    cmd1.Parameters.AddWithValue("@username", textBox1.Text);
    cmd1.Parameters.AddWithValue("@password", textBox2.Text);
    cmd1.Parameters.AddWithValue("@id", textBox3.Text);

    cmd1.ExecuteNonQuery();


    // Student table insert (only ID)
    SqlCommand cmd2 = new SqlCommand(
    "INSERT INTO Student(Student_id) VALUES(@id)", con);

    cmd2.Parameters.AddWithValue("@id", textBox3.Text);

    cmd2.ExecuteNonQuery();


    MessageBox.Show("Sign Up Successful");

    con.Close();
             
             */

            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Login values(@Type,@Username,@Password,@Student_id)", con);

            cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@Student_id", textBox3.Text);

            cmd.ExecuteNonQuery();

            // Student table insert (only ID)
            SqlCommand cmd2 = new SqlCommand(
            "INSERT INTO Student(Student_id) VALUES(@id)", con);

            cmd2.Parameters.AddWithValue("@id", textBox3.Text);

            cmd2.ExecuteNonQuery();


            MessageBox.Show("Sign Up Successful");

            con.Close();

            MessageBox.Show("Account Created Successfully");

            con.Close();
            cls();

            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        void GenerateID()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Student_id FROM Student ORDER BY Student_id DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string id = dr[0].ToString();
                int num = int.Parse(id.Substring(1));
                num++;

                textBox3.Text = "S" + num.ToString("000");
            }
            else
            {
                textBox3.Text = "S001";
            }

            con.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Student");
            textBox3.ReadOnly = true;
            GenerateID();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

            this.Hide();
        }
    }
    
}
