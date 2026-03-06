using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class ReportForms : Form
    {
        public ReportForms()
        {
            InitializeComponent();
        }

        private void rbBusReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBusReport.Checked)
                LoadBusReport();
        }

        private void rbInstallmentReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInstallmentReport.Checked)
                LoadInstallmentReport();
        }

        private void ReportForms_Load(object sender, EventArgs e)
        {
            rbBusReport.Checked = true;
            LoadBusReport();
        }

        private void LoadBusReport()
        {
            try
            {
                string sql = @"SELECT b.Id, b.Student_id, s.Student_name, s.Class, s.Sec, b.Card_no, b.Install_month, b.Installment, b.Paid_date, b.Total_fine, b.Report
FROM Bus b
INNER JOIN Student s ON s.Student_id = b.Student_id
ORDER BY b.Paid_date DESC";
                DataTable dt = DbHelper.FillTable(sql);
                dgvReport.DataSource = dt;
                decimal grandTotal = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Total_fine"] != DBNull.Value && row["Total_fine"] != null)
                        grandTotal += Convert.ToDecimal(row["Total_fine"]);
                }
                lblGrandTotal.Text = "Grand Total (Fine): " + grandTotal.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInstallmentReport()
        {
            try
            {
                string sql = @"SELECT i.Id, i.Student_id, s.Student_name, s.Class, s.Sec, i.Installment, i.Gst, i.Electric, i.Paid_date, i.Total_fine, i.Report
FROM Installment i
INNER JOIN Student s ON s.Student_id = i.Student_id
ORDER BY i.Paid_date DESC";
                DataTable dt = DbHelper.FillTable(sql);
                dgvReport.DataSource = dt;
                decimal grandTotal = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Total_fine"] != DBNull.Value && row["Total_fine"] != null)
                        grandTotal += Convert.ToDecimal(row["Total_fine"]);
                }
                lblGrandTotal.Text = "Grand Total (Fine): " + grandTotal.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
