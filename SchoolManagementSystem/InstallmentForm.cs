using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class InstallmentForm : Form
    {
        private const decimal ElectricDefault = 255.70m;
        private readonly bool _isAdmin;
        private readonly int? _restrictStudentId;

        public InstallmentForm(bool isAdmin, int? studentId)
        {
            _isAdmin = isAdmin;
            _restrictStudentId = studentId;
            InitializeComponent();
            txtElectric.Text = ElectricDefault.ToString("F2");
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
            decimal gst = installment * 0.18m; // 18%
            decimal electric = ElectricDefault;
            decimal.TryParse(txtElectric.Text.Trim(), out electric);
            int lateDays = (int)(dtpPaidDate.Value.Date - dtpDueDate.Value.Date).TotalDays;
            if (lateDays < 0) lateDays = 0;
            decimal lateFine = installment * 0.1279m * lateDays; // 12.79% × LateDays
            txtGst.Text = gst.ToString("F2");
            txtTotalFine.Text = lateFine.ToString("F2");
            txtReport.Text = string.Format("GST 18%: {0:F2}, Electric: {1:F2}, Due: {2:yyyy-MM-dd}, Paid: {3:yyyy-MM-dd}, Late {4} day(s), Fine: {5:F2}", gst, electric, dtpDueDate.Value.Date, dtpPaidDate.Value.Date, lateDays, lateFine);
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
            decimal gst = 0;
            decimal.TryParse(txtGst.Text.Trim(), out gst);
            decimal electric = ElectricDefault;
            decimal.TryParse(txtElectric.Text.Trim(), out electric);
            decimal totalFine = 0;
            decimal.TryParse(txtTotalFine.Text.Trim(), out totalFine);

            try
            {
                string sql = @"INSERT INTO Installment (Student_id, Installment, Gst, Electric, Paid_date, Total_fine, Report)
VALUES (@Student_id, @Installment, @Gst, @Electric, @Paid_date, @Total_fine, @Report)";
                var pars = new[]
                {
                    new SqlParameter("@Student_id", studentId),
                    new SqlParameter("@Installment", installment),
                    new SqlParameter("@Gst", gst),
                    new SqlParameter("@Electric", electric),
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
            txtInstallment.Clear();
            txtGst.Clear();
            txtElectric.Text = ElectricDefault.ToString("F2");
            dtpPaidDate.Value = DateTime.Today;
            txtTotalFine.Clear();
            txtReport.Clear();
        }
    }
}
