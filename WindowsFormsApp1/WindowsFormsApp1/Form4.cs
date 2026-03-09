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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string studentID;

        public Form4(string id)
        {
            InitializeComponent();
            studentID = id;
        }

        byte[] ImageToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Student where Student_id=@id", con);
            da.SelectCommand.Parameters.AddWithValue("@id", studentID);

            DataTable dt = new DataTable();
            da.Fill(dt);

            /* con.Open();

             SqlDataAdapter da = new SqlDataAdapter("select * from Student where Student_id=@id", con);
                da.SelectCommand.Parameters.AddWithValue("@id", sid);

            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();*/

       


            if (dt.Rows.Count > 0)
            {
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
            }

            con.Close();

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
                    MessageBox.Show(" Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed (ID Not Found)");
                }

                con.Close();
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

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
            // this.Close();
        }

      /*  private void button9_Click(object sender, EventArgs e)
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
        }*/

       
        void loadData()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Bus", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

        }

        

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
