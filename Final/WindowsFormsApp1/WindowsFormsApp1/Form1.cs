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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        void cls()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Login where Type=@Type and Username=@Username and Password=@Password", con);

            cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (comboBox1.Text == "Admin")
                {
                    MessageBox.Show("Admin Login Successful");
                }
                else if (comboBox1.Text == "Student")
                {
                    MessageBox.Show("Welcome Student");
                }

                timer1.Start();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }

            con.Close();
            */
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Student");

            progressBar1.Value = 0;
        
            timer1.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* 

            progressBar1.Increment(5);

            if (progressBar1.Value == 100)
            {
                timer1.Stop();

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from Login where Type=@Type and Username=@Username and Password=@Password", con);

                cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if (comboBox1.Text == "Admin")
                    {
                        MessageBox.Show("Welcome Admin");

                        Form3 f = new Form3();
                        f.Show();
                        this.Hide();
                    }
                    else if (comboBox1.Text == "Student")
                    {
                        MessageBox.Show("Welcome Student");

                        Form4 f = new Form4();
                        f.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                    cls(); // form clear
                }

                con.Close();
            }*/

            progressBar1.Increment(5);

            if (progressBar1.Value == 100)
            {
                timer1.Stop();

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from Login where Type=@Type and Username=@Username and Password=@Password", con);

                cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (comboBox1.Text == "Admin")
                    {
                        MessageBox.Show("Welcome Admin");

                        Form3 f = new Form3();
                        f.Show();
                        this.Hide();
                    }

                    else if (comboBox1.Text == "Student")
                    {
                        MessageBox.Show("Welcome Student");

                        string sid = dr["Student_id"].ToString();

                        Form4 f = new Form4(sid);
                        f.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                    cls();
                }

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

            this.Hide();
        }
    }
}
