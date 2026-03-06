using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class LibraryForm : Form
    {
        private readonly bool _isAdmin;
        private readonly int? _restrictStudentId;

        public LibraryForm(bool isAdmin, int? studentId)
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
                    txtCardNo.Text = reader["Library_Card"].ToString();
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
            if (dtpIssueDate.Value.Date > dtpSubmitDate.Value.Date)
            {
                MessageBox.Show("Submit date cannot be before Issue date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int lateDays = (int)(dtpSubmitDate.Value.Date - dtpIssueDate.Value.Date).TotalDays;
            decimal fine = lateDays * 10.25m;
            txtTotalFine.Text = fine.ToString("F2");
            txtReport.Text = lateDays > 0 ? "Late by " + lateDays + " day(s). Fine: " + fine.ToString("F2") : "No fine.";
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
            if (string.IsNullOrEmpty(txtBookName.Text.Trim()))
            {
                MessageBox.Show("Book Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalFine = 0;
            decimal.TryParse(txtTotalFine.Text.Trim(), out totalFine);

            try
            {
                string sql = @"INSERT INTO Library (Student_id, Card_no, Book_name, Issue_date, Submit_date, Total_fine, Report)
VALUES (@Student_id, @Card_no, @Book_name, @Issue_date, @Submit_date, @Total_fine, @Report)";
                var pars = new[]
                {
                    new SqlParameter("@Student_id", studentId),
                    new SqlParameter("@Card_no", (object)txtCardNo.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@Book_name", txtBookName.Text.Trim()),
                    new SqlParameter("@Issue_date", dtpIssueDate.Value.Date),
                    new SqlParameter("@Submit_date", dtpSubmitDate.Value.Date),
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
            txtBookName.Clear();
            dtpIssueDate.Value = DateTime.Today;
            dtpSubmitDate.Value = DateTime.Today;
            txtTotalFine.Clear();
            txtReport.Clear();
        }
    }
}
