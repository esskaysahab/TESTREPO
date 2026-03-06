namespace SchoolManagementSystem
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStudentForm = new System.Windows.Forms.Button();
            this.btnLibraryForm = new System.Windows.Forms.Button();
            this.btnBusForm = new System.Windows.Forms.Button();
            this.btnInstallmentForm = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(310, 46);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(249, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin Dashboard";
            // 
            // btnStudentForm
            // 
            this.btnStudentForm.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnStudentForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStudentForm.BackgroundImage")));
            this.btnStudentForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentForm.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnStudentForm.Location = new System.Drawing.Point(90, 144);
            this.btnStudentForm.Name = "btnStudentForm";
            this.btnStudentForm.Size = new System.Drawing.Size(163, 97);
            this.btnStudentForm.TabIndex = 1;
            this.btnStudentForm.Text = "Manage Students";
            this.btnStudentForm.UseVisualStyleBackColor = false;
            this.btnStudentForm.Click += new System.EventHandler(this.btnStudentForm_Click);
            // 
            // btnLibraryForm
            // 
            this.btnLibraryForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibraryForm.Location = new System.Drawing.Point(336, 144);
            this.btnLibraryForm.Name = "btnLibraryForm";
            this.btnLibraryForm.Size = new System.Drawing.Size(163, 97);
            this.btnLibraryForm.TabIndex = 2;
            this.btnLibraryForm.Text = "Library";
            this.btnLibraryForm.UseVisualStyleBackColor = true;
            this.btnLibraryForm.Click += new System.EventHandler(this.btnLibraryForm_Click);
            // 
            // btnBusForm
            // 
            this.btnBusForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusForm.Location = new System.Drawing.Point(580, 144);
            this.btnBusForm.Name = "btnBusForm";
            this.btnBusForm.Size = new System.Drawing.Size(163, 97);
            this.btnBusForm.TabIndex = 3;
            this.btnBusForm.Text = "Bus";
            this.btnBusForm.UseVisualStyleBackColor = true;
            this.btnBusForm.Click += new System.EventHandler(this.btnBusForm_Click);
            // 
            // btnInstallmentForm
            // 
            this.btnInstallmentForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallmentForm.Location = new System.Drawing.Point(90, 260);
            this.btnInstallmentForm.Name = "btnInstallmentForm";
            this.btnInstallmentForm.Size = new System.Drawing.Size(163, 97);
            this.btnInstallmentForm.TabIndex = 4;
            this.btnInstallmentForm.Text = "Installment";
            this.btnInstallmentForm.UseVisualStyleBackColor = true;
            this.btnInstallmentForm.Click += new System.EventHandler(this.btnInstallmentForm_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(336, 260);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(163, 97);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "View Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(580, 260);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(163, 97);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 406);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnInstallmentForm);
            this.Controls.Add(this.btnBusForm);
            this.Controls.Add(this.btnLibraryForm);
            this.Controls.Add(this.btnStudentForm);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin - School Management System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStudentForm;
        private System.Windows.Forms.Button btnLibraryForm;
        private System.Windows.Forms.Button btnBusForm;
        private System.Windows.Forms.Button btnInstallmentForm;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
    }
}
