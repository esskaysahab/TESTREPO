using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtStudentName.Text.Trim();
            string fathersName = txtFathersName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string voterId = txtVoterId.Text.Trim();
            string cls = txtClass.Text.Trim();
            string rollNoText = txtRollNo.Text.Trim();
            string sec = txtSec.Text.Trim();
            string libraryCard = txtLibraryCard.Text.Trim();
            string bus = txtBus.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Student Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Phone is required (used as Username for login).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rollNo = 0;
            if (!string.IsNullOrEmpty(rollNoText) && !int.TryParse(rollNoText, out rollNo))
            {
                MessageBox.Show("Roll No must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Duplicate prevention: check if Phone already exists
            try
            {
                string checkSql = "SELECT COUNT(1) FROM Student WHERE Phone = @Phone";
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("A student with this Phone number already exists. Please use a unique Phone.", "Duplicate Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking duplicate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] photoBytes = GetPhotoBytes();

            try
            {
                string insertStudent = @"INSERT INTO Student (Student_name, Fathers_name, Address, Phone, Voter_id, Class, Roll_no, Sec, Library_Card, Bus, Photo)
VALUES (@Student_name, @Fathers_name, @Address, @Phone, @Voter_id, @Class, @Roll_no, @Sec, @Library_Card, @Bus, @Photo);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int studentId;
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(insertStudent, conn))
                    {
                        cmd.Parameters.AddWithValue("@Student_name", name);
                        cmd.Parameters.AddWithValue("@Fathers_name", (object)fathersName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Voter_id", (object)voterId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Class", (object)cls ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Roll_no", rollNo > 0 ? (object)rollNo : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Sec", (object)sec ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Library_Card", (object)libraryCard ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Bus", (object)bus ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", (object)photoBytes ?? DBNull.Value);
                        studentId = (int)cmd.ExecuteScalar();
                    }

                    // Automatically create Login record: Type = 'student', Username = Phone, Password = Phone
                    string insertLogin = "INSERT INTO [Login] (Type, Username, Password) VALUES ('student', @Username, @Password)";
                    using (var cmd = new SqlCommand(insertLogin, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", phone);
                        cmd.Parameters.AddWithValue("@Password", phone);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful. Your Student ID is: " + studentId + "\n\nLogin with:\nUsername: " + phone+ "\nPassword: " + phone, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GetPhotoBytes()
        {
            if (picStudent.Image == null) return null;
            try
            {
                using (var bmp = new Bitmap(picStudent.Image))
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch
            {
                // If anything goes wrong while converting the image, just skip saving the photo
                return null;
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                ofd.Title = "Select student photo";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picStudent.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void picStudent_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
