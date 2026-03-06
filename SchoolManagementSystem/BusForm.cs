using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class BusForm : Form
    {
        private readonly bool _isAdmin;
        private readonly int? _restrictStudentId;

        public BusForm(bool isAdmin, int? studentId)
        {
            _isAdmin = isAdmin;
            _restrictStudentId = studentId;
            InitializeComponent();
            if (_restrictStudentId.HasValue)
            {
                txtStudentId.Text = _restrictStudentId.ToString();
                txtStudentId.ReadOnly = true;
                LoadStudentData(_restrictStudentId.Value);
            }
        }

        private void txtStudentId_Leave(object sender, EventArgs e)
        {
            if (_restrictStudentId.HasValue) return;
            string sidText = txtStudentId.Text.Trim();
            if (string.IsNullOrEmpty(sidText)) return;
            if (!int.TryParse(sidText, out int sid)) return;
            LoadStudentData(sid);
        }

        private void LoadStudentData(int studentId)
        {
            try
            {
                string sql = "SELECT Student_name, Class, Sec, Library_Card, Bus FROM Student WHERE Student_id = @Id";
                bool found = false;
                DbHelper.ReadSingleRow(sql, reader =>
                {
                    found = true;
                    txtStudentName.Text = reader["Student_name"].ToString();
                    txtClass.Text = reader["Class"].ToString();
                    txtSec.Text = reader["Sec"].ToString();
                    txtCardNo.Text = reader["Bus"].ToString();
                }, new SqlParameter("@Id", studentId));
                if (!found)
                    MessageBox.Show("Student not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculateFine_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtInstallment.Text.Trim(), out decimal installment) || installment <= 0)
            {
                MessageBox.Show("Enter a valid Installment amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal fine = installment * 0.10m; // 10%
            txtTotalFine.Text = fine.ToString("F2");
            txtReport.Text = "Bus fine 10% of installment: " + fine.ToString("F2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sidText = txtStudentId.Text.Trim();
            if (string.IsNullOrEmpty(sidText) || !int.TryParse(sidText, out int studentId))
            {
                MessageBox.Show("Enter a valid Student ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_restrictStudentId.HasValue && studentId != _restrictStudentId.Value)
            {
                MessageBox.Show("You can only add records for your own Student ID.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtInstallment.Text.Trim(), out decimal installment))
            {
                MessageBox.Show("Enter a valid Installment amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal totalFine = 0;
            decimal.TryParse(txtTotalFine.Text.Trim(), out totalFine);

            try
            {
                string sql = @"INSERT INTO Bus (Student_id, Card_no, Install_month, Installment, Paid_date, Total_fine, Report)
VALUES (@Student_id, @Card_no, @Install_month, @Installment, @Paid_date, @Total_fine, @Report)";
                var pars = new[]
                {
                    new SqlParameter("@Student_id", studentId),
                    new SqlParameter("@Card_no", (object)txtCardNo.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@Install_month", (object)txtInstallMonth.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@Installment", installment),
                    new SqlParameter("@Paid_date", dtpPaidDate.Value.Date),
                    new SqlParameter("@Total_fine", totalFine),
                    new SqlParameter("@Report", (object)txtReport.Text.Trim() ?? DBNull.Value)
                };
                DbHelper.ExecuteNonQuery(sql, pars);
                MessageBox.Show("Saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            if (!_restrictStudentId.HasValue)
                txtStudentId.Clear();
            txtStudentName.Clear();
            txtClass.Clear();
            txtSec.Clear();
            txtCardNo.Clear();
            txtInstallMonth.Clear();
            txtInstallment.Clear();
            dtpPaidDate.Value = DateTime.Today;
            txtTotalFine.Clear();
            txtReport.Clear();
        }
    }
}
