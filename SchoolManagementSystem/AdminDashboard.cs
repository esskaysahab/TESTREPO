using System;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnStudentForm_Click(object sender, EventArgs e)
        {
            var f = new StudentForm(isAdmin: true);
            f.ShowDialog();
        }

        private void btnLibraryForm_Click(object sender, EventArgs e)
        {
            var f = new LibraryForm(isAdmin: true, studentId: null);
            f.ShowDialog();
        }

        private void btnBusForm_Click(object sender, EventArgs e)
        {
            var f = new BusForm(isAdmin: true, studentId: null);
            f.ShowDialog();
        }

        private void btnInstallmentForm_Click(object sender, EventArgs e)
        {
            var f = new InstallmentForm(isAdmin: true, studentId: null);
            f.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var f = new ReportForms();
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
           login.FormClosed += (s, args) => Application.Exit();
            login.Show();
           // this.Close();
        }
    }
}
