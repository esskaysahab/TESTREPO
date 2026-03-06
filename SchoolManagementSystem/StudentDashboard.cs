using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class StudentDashboard : Form
    {
        private readonly string _username; // Phone
        private readonly int _studentId;

        public StudentDashboard(string username)
        {
            _username = username;
            _studentId = GetStudentIdByPhone(username);
            InitializeComponent();
        }

        private int GetStudentIdByPhone(string phone)
        {
            try
            {
                string sql = "SELECT Student_id FROM Student WHERE Phone = @Phone";
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        var obj = cmd.ExecuteScalar();
                        return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            var f = new StudentForm(isAdmin: false, studentId: _studentId);
            f.ShowDialog();
        }

        private void btnLibraryForm_Click(object sender, EventArgs e)
        {
            var f = new LibraryForm(isAdmin: false, studentId: _studentId);
            f.ShowDialog();
        }

        private void btnBusForm_Click(object sender, EventArgs e)
        {
            var f = new BusForm(isAdmin: false, studentId: _studentId);
            f.ShowDialog();
        }

        private void btnInstallmentForm_Click(object sender, EventArgs e)
        {
            var f = new InstallmentForm(isAdmin: false, studentId: _studentId);
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
            login.FormClosed += (s, args) => Application.Exit();
            login.Show();
            //this.Close();
        }
    }
}
