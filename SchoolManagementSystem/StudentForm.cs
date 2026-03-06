using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class StudentForm : Form
    {
        private readonly bool _isAdmin;
        private readonly int? _studentIdOnly; // when student logs in, only this id is allowed
        private int _currentStudentId; // for update/delete

        public StudentForm(bool isAdmin, int? studentId = null)
        {
            _isAdmin = isAdmin;
            _studentIdOnly = studentId;
            InitializeComponent();
            AdjustForRole();
            if (_studentIdOnly.HasValue)
                LoadStudent(_studentIdOnly.Value);
        }

        private void AdjustForRole()
        {
            if (!_isAdmin)
            {
                lblStudentId.Visible = false;
                txtStudentId.Visible = false;
                btnSearch.Visible = false;
                btnDelete.Visible = false;
                btnAddNew.Visible = false;
                dgvStudents.Visible = false;
                grpSearch.Visible = false;
                lblTitle.Text = "My Profile";
                txtStudentId.Visible = false;
                lblStudentId.Visible = false;
            }
            else
            {
                grpSearch.Visible = true;
                dgvStudents.Visible = true;
            }
        }

        private void LoadStudent(int studentId)
        {
            try
            {
                string sql = "SELECT Student_id, Student_name, Fathers_name, Address, Phone, Voter_id, Class, Roll_no, Sec, Library_Card, Bus FROM Student WHERE Student_id = @Id";
                DbHelper.ReadSingleRow(sql, reader =>
                {
                    _currentStudentId = reader.GetInt32(0);
                    txtStudentId.Text = _currentStudentId.ToString();
                    txtStudentName.Text = reader["Student_name"].ToString();
                    txtFathersName.Text = reader["Fathers_name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtVoterId.Text = reader["Voter_id"].ToString();
                    txtClass.Text = reader["Class"].ToString();
                    txtRollNo.Text = reader["Roll_no"] != DBNull.Value ? reader["Roll_no"].ToString() : "";
                    txtSec.Text = reader["Sec"].ToString();
                    txtLibraryCard.Text = reader["Library_Card"].ToString();
                    txtBus.Text = reader["Bus"].ToString();
                }, new SqlParameter("@Id", studentId));
                // Load photo separately (column may not exist in older DBs - run AddPhotoColumn.sql)
                try
                {
                    string sqlPhoto = "SELECT Photo FROM Student WHERE Student_id = @Id";
                    DbHelper.ReadSingleRow(sqlPhoto, reader =>
                    {
                        if (reader["Photo"] != DBNull.Value && reader["Photo"] != null)
                        {
                            var bytes = (byte[])reader["Photo"];
                            if (bytes != null && bytes.Length > 0)
                            {
                                using (var ms = new MemoryStream(bytes))
                                using (var img = Image.FromStream(ms))
                                    picStudent.Image = (Image)img.Clone();
                            }
                        }
                    }, new SqlParameter("@Id", studentId));
                }
                catch { try { picStudent.Image = null; } catch { } }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Enter Phone or Student Name to search.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string sql = @"SELECT Student_id, Student_name, Fathers_name, Address, Phone, Class, Roll_no, Sec 
FROM Student 
WHERE Phone LIKE @Search OR Student_name LIKE @Search OR CAST(Student_id AS VARCHAR(20)) = @Search";
                var dt = DbHelper.FillTable(sql, new SqlParameter("@Search", "%" + searchText + "%"));
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Enter ID, Phone or Student Name to search.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"
        SELECT Student_id, Student_name, Fathers_name, Address, Phone, Class, Roll_no, Sec 
        FROM Student 
        WHERE 
            Student_name LIKE @Search 
            OR Phone LIKE @Search 
            OR CAST(Student_id AS VARCHAR(20)) LIKE @Search";

                var dt = DbHelper.FillTable(sql,
                    new SqlParameter("@Search", "%" + searchText + "%"));

                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var row = dgvStudents.SelectedRows[0];
                if (row.Cells["Student_id"].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells["Student_id"].Value);
                    LoadStudent(id);
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _currentStudentId = 0;
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtFathersName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtVoterId.Clear();
            txtClass.Clear();
            txtRollNo.Clear();
            txtSec.Clear();
            txtLibraryCard.Clear();
            txtBus.Clear();
            picStudent.Image = null;

            


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtStudentName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Student Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(phone)) { MessageBox.Show("Phone is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int rollNo = 0;
            int.TryParse(txtRollNo.Text.Trim(), out rollNo);

            if (_currentStudentId > 0) // Update
            {
                try
                {
                    byte[] photoBytes = GetPhotoBytes();
                    // For updates we will NOT touch the photo from Admin/Student form to avoid GDI+ issues.
                    // Photo can still be set at registration time.
                    string sql = @"UPDATE Student SET Student_name=@n, Fathers_name=@fn, Address=@a, Phone=@p, Voter_id=@v, Class=@c, Roll_no=@r, Sec=@s, Library_Card=@lc, Bus=@b, Photo=@photo WHERE Student_id=@id";
                    var pars = new[]
                    {
                        new SqlParameter("@n", name),
                        new SqlParameter("@fn", (object)txtFathersName.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@a", (object)txtAddress.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@p", phone),
                        new SqlParameter("@v", (object)txtVoterId.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@c", (object)txtClass.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@r", rollNo > 0 ? (object)rollNo : DBNull.Value),
                        new SqlParameter("@s", (object)txtSec.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@lc", (object)txtLibraryCard.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@b", (object)txtBus.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@photo", (object)photoBytes ?? DBNull.Value), 
                        new SqlParameter("@id", _currentStudentId)
                    };
                    DbHelper.ExecuteNonQuery(sql, pars);
                    MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_isAdmin) btnSearch.PerformClick();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return;
            }

            // Insert (Admin only)
            if (!_isAdmin) return;
            try
            {
                string checkSql = "SELECT COUNT(1) FROM Student WHERE Phone = @Phone";
                if ((int)DbHelper.ExecuteScalar(checkSql, new SqlParameter("@Phone", phone)) > 0)
                {
                    MessageBox.Show("A student with this Phone already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // For admin-created students we also ignore the photo, to completely avoid GDI+ save issues here.
                string insertSql = @"INSERT INTO Student (Student_name, Fathers_name, Address, Phone, Voter_id, Class, Roll_no, Sec, Library_Card, Bus)
VALUES (@n, @fn, @a, @p, @v, @c, @r, @s, @lc, @b);
SELECT CAST(SCOPE_IDENTITY() AS INT);";
                var pars = new[]
                {
                    new SqlParameter("@n", name),
                    new SqlParameter("@fn", (object)txtFathersName.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@a", (object)txtAddress.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@p", phone),
                    new SqlParameter("@v", (object)txtVoterId.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@c", (object)txtClass.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@r", rollNo > 0 ? (object)rollNo : DBNull.Value),
                    new SqlParameter("@s", (object)txtSec.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@lc", (object)txtLibraryCard.Text.Trim() ?? DBNull.Value),
                    new SqlParameter("@b", (object)txtBus.Text.Trim() ?? DBNull.Value)
                };
                /* int newId = (int)DbHelper.ExecuteScalar(insertSql, pars);
                 MessageBox.Show("Student added. Student ID: " + newId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 _currentStudentId = newId;
                 txtStudentId.Text = newId.ToString();
                 btnSearch.PerformClick();*/

                int newId = (int)DbHelper.ExecuteScalar(insertSql, pars);

                // Auto Create Login (Username = Phone, Password = Phone)
                string loginSql = "INSERT INTO [Login] (Type, Username, Password) VALUES (@Type, @Username, @Password)";

                DbHelper.ExecuteNonQuery(loginSql,
                    new SqlParameter("@Type", "student"),
                    new SqlParameter("@Username", phone),
                    new SqlParameter("@Password", phone)
                );

                //  Success Message with Login Info
                MessageBox.Show(
                    "Student Successfully Added!\n\n" +
                    "Student ID: " + newId +
                    "\nUsername: " + phone +
                    "\nPassword: " + phone,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                _currentStudentId = newId;
                txtStudentId.Text = newId.ToString();

                btnSearch.PerformClick();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            picStudent.Image = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_isAdmin || _currentStudentId <= 0) return;
            if (MessageBox.Show("Delete this student record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                DbHelper.ExecuteNonQuery("DELETE FROM [Login] WHERE Username = (SELECT Phone FROM Student WHERE Student_id = @id)", new SqlParameter("@id", _currentStudentId));
                DbHelper.ExecuteNonQuery("DELETE FROM Library WHERE Student_id = @id", new SqlParameter("@id", _currentStudentId));
                DbHelper.ExecuteNonQuery("DELETE FROM Bus WHERE Student_id = @id", new SqlParameter("@id", _currentStudentId));
                DbHelper.ExecuteNonQuery("DELETE FROM Installment WHERE Student_id = @id", new SqlParameter("@id", _currentStudentId));
                DbHelper.ExecuteNonQuery("DELETE FROM Student WHERE Student_id = @id", new SqlParameter("@id", _currentStudentId));
                MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAddNew.PerformClick();
                btnSearch.PerformClick();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadAllStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=SAHABNOTEBOOK;Initial Catalog=School;Integrated Security=True;"))
                {
                    string sql = "SELECT * FROM Student";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
          LoadAllStudents();
        }
    }
}
