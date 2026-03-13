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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;


            if (comboBox1.Text == "Bus")
            {
                panel2.Visible = true;
            }
            else if (comboBox1.Text == "Library")
            {
                panel3.Visible = true;
            }
            else if (comboBox1.Text == "Installment")
             {
                  panel4.Visible = true;
             }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=SAHABNOTEBOOK;Initial Catalog=sahabsc;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            int fee = 300;

            int fine = fee * 10 / 100;
            int total = fee + fine;

            textBox5.Text = total.ToString();

            textBox4.Text =
            "Bus Fee = 300\nFine Added = 10%\nTotal Payable = " + total;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
