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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        /*byte[] ImageToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }*/

        byte[] ImageToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

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

                textBox1.Text = "S" + num.ToString("000");
            }
            else
            {
                textBox1.Text = "S001";
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Student_id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox12.Text.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                textBox1.Text = dt.Rows[0]["Student_id"].ToString();
                textBox2.Text = dt.Rows[0]["Student_name"].ToString();
                textBox3.Text = dt.Rows[0]["Fathers_name"].ToString();
                textBox4.Text = dt.Rows[0]["Address"].ToString();
                textBox5.Text = dt.Rows[0]["Phone"].ToString();
                textBox6.Text = dt.Rows[0]["Voter_id"].ToString();
                textBox7.Text = dt.Rows[0]["Class"].ToString();
                textBox8.Text = dt.Rows[0]["Roll_no"].ToString();
                textBox9.Text = dt.Rows[0]["Sec"].ToString();
                textBox10.Text = dt.Rows[0]["Library_Card"].ToString();
                textBox11.Text = dt.Rows[0]["Bus"].ToString();

                if (dt.Rows[0]["Photo"] != DBNull.Value)
                {
                    byte[] img = (byte[])dt.Rows[0]["Photo"];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }

                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Student SET Student_name=@name, Fathers_name=@father, Address=@address, Phone=@phone, Voter_id=@voter, Class=@class, Roll_no=@roll, Sec=@sec, Library_Card=@lib, Bus=@bus, Photo=@photo WHERE Student_id=@id", con);

                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@father", SqlDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = textBox4.Text;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = textBox5.Text;
                cmd.Parameters.Add("@voter", SqlDbType.VarChar).Value = textBox6.Text;
                cmd.Parameters.Add("@class", SqlDbType.VarChar).Value = textBox7.Text;
                cmd.Parameters.Add("@roll", SqlDbType.VarChar).Value = textBox8.Text;
                cmd.Parameters.Add("@sec", SqlDbType.VarChar).Value = textBox9.Text;
                cmd.Parameters.Add("@lib", SqlDbType.VarChar).Value = textBox10.Text;
                cmd.Parameters.Add("@bus", SqlDbType.VarChar).Value = textBox11.Text;

                // Photo Handling
                if (pictureBox1.Image != null)
                {
                    byte[] img = ImageToByte(pictureBox1.Image);
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = img;
                }
                else
                {
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = DBNull.Value;
                }

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Student Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed (ID Not Found)");
                }

                con.Close();

                cls();
                LoadData();

                button1.Enabled = false;
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Student values(@id,@name,@father,@address,@phone,@voter,@class,@roll,@sec,@lib,@bus,@photo)", con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@father", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@voter", textBox6.Text);
            cmd.Parameters.AddWithValue("@class", textBox7.Text);
            cmd.Parameters.AddWithValue("@roll", textBox8.Text);
            cmd.Parameters.AddWithValue("@sec", textBox9.Text);
            cmd.Parameters.AddWithValue("@lib", textBox10.Text);
            cmd.Parameters.AddWithValue("@bus", textBox11.Text);

            if (pictureBox1.Image != null)
                cmd.Parameters.AddWithValue("@photo", ImageToByte(pictureBox1.Image));
            else
                cmd.Parameters.AddWithValue("@photo", DBNull.Value);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Student Inserted");

            con.Close();

            cls();
            LoadData();


        }

        void cls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox12.Clear();
            pictureBox1.Image = null;

            GenerateID();
        }

        void LoadData()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE Student_id=@id", con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text.Trim());

                int result = cmd.ExecuteNonQuery();

                con.Close();

                if (result > 0)
                {
                    MessageBox.Show("Student Deleted");
                }
                else
                {
                    MessageBox.Show("Delete Failed (ID Not Found)");
                }
            
                cls();
                LoadData();

                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            GenerateID();
            LoadData();

            button1.Enabled = false; // update
            button2.Enabled = false; // delete
            textBox1.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Student_id"].Value.ToString();
                textBox2.Text = row.Cells["Student_name"].Value.ToString();
                textBox3.Text = row.Cells["Fathers_name"].Value.ToString();
                textBox4.Text = row.Cells["Address"].Value.ToString();
                textBox5.Text = row.Cells["Phone"].Value.ToString();
                textBox6.Text = row.Cells["Voter_id"].Value.ToString();
                textBox7.Text = row.Cells["Class"].Value.ToString();
                textBox8.Text = row.Cells["Roll_no"].Value.ToString();
                textBox9.Text = row.Cells["Sec"].Value.ToString();
                textBox10.Text = row.Cells["Library_Card"].Value.ToString();
                textBox11.Text = row.Cells["Bus"].Value.ToString();

                if (row.Cells["Photo"].Value != DBNull.Value)
                {
                    byte[] img = (byte[])row.Cells["Photo"].Value;
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }

                button1.Enabled = true; // update
                button2.Enabled = true; // delete
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cls();          //  All textbox clear
            GenerateID();   // New ID generate

            LoadData();
            button1.Enabled = false;   // update disable
            button2.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Close();
        }
    }
}
