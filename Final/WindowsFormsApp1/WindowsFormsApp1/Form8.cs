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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        
         public Form8(string role)
         {
            InitializeComponent();

             if(role == "admin")
             {
                 button1.Enabled = true;
                 button2.Enabled = true;
                 button3.Enabled = true;
             }

            if(role == "student")
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = false;
                button5.Enabled = false;
            }
         }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");
        void loadStudent()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select Student_id,Student_name,Bus from Student", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            loadStudent();

           // textBox1.ReadOnly = true;
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
                    textBox2.Text = row.Cells["Student_name"].Value.ToString();
                    textBox3.Text = row.Cells["Bus"].Value.ToString();
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Bus values(@id,@card,@month,@date,@fine,@report)", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@card", textBox3.Text);
            cmd.Parameters.AddWithValue("@month", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@fine", textBox5.Text);
            cmd.Parameters.AddWithValue("@report", textBox4.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Saved Successfully");
            cls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Bus where Student_id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text.Trim());

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox3.Text = dr["Card_no"].ToString();
                comboBox1.Text = dr["Install_month"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["Paid_date"]);
                textBox5.Text = dr["Total_fine"].ToString();
                textBox4.Text = dr["Report"].ToString();

                button3.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }

            dr.Close();
            con.Close();
            cls();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update Bus set Card_no=@card,Install_month=@month,Paid_date=@date,Total_fine=@fine,Report=@report where Student_id=@id", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@card", textBox3.Text);
            cmd.Parameters.AddWithValue("@month", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@fine", textBox5.Text);
            cmd.Parameters.AddWithValue("@report", textBox4.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Updated Successfully");
            cls();
        }

        void cls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            textBox4.Clear();
            textBox5.Clear();

            dateTimePicker1.Value = DateTime.Now;

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from Bus where Student_id=@id", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Deleted Successfully");
            cls();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int fee = Convert.ToInt32(comboBox2.Text);

            int fine = fee * 10 / 100;
            int total = fee + fine;

            textBox5.Text = total.ToString();

            textBox4.Text = "Fee = " + fee +
                            "\nFine = 10%" +
                            "\nTotal = " + total;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
