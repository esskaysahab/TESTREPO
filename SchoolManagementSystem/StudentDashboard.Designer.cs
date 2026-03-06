namespace SchoolManagementSystem
{
    partial class StudentDashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnLibraryForm = new System.Windows.Forms.Button();
            this.btnBusForm = new System.Windows.Forms.Button();
            this.btnInstallmentForm = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(100, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Dashboard";
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Location = new System.Drawing.Point(100, 80);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(220, 35);
            this.btnMyProfile.TabIndex = 1;
            this.btnMyProfile.Text = "My Profile (View / Update)";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnLibraryForm
            // 
            this.btnLibraryForm.Location = new System.Drawing.Point(100, 130);
            this.btnLibraryForm.Name = "btnLibraryForm";
            this.btnLibraryForm.Size = new System.Drawing.Size(220, 35);
            this.btnLibraryForm.TabIndex = 2;
            this.btnLibraryForm.Text = "Library";
            this.btnLibraryForm.UseVisualStyleBackColor = true;
            this.btnLibraryForm.Click += new System.EventHandler(this.btnLibraryForm_Click);
            // 
            // btnBusForm
            // 
            this.btnBusForm.Location = new System.Drawing.Point(100, 180);
            this.btnBusForm.Name = "btnBusForm";
            this.btnBusForm.Size = new System.Drawing.Size(220, 35);
            this.btnBusForm.TabIndex = 3;
            this.btnBusForm.Text = "Bus";
            this.btnBusForm.UseVisualStyleBackColor = true;
            this.btnBusForm.Click += new System.EventHandler(this.btnBusForm_Click);
            // 
            // btnInstallmentForm
            // 
            this.btnInstallmentForm.Location = new System.Drawing.Point(100, 230);
            this.btnInstallmentForm.Name = "btnInstallmentForm";
            this.btnInstallmentForm.Size = new System.Drawing.Size(220, 35);
            this.btnInstallmentForm.TabIndex = 4;
            this.btnInstallmentForm.Text = "Installment";
            this.btnInstallmentForm.UseVisualStyleBackColor = true;
            this.btnInstallmentForm.Click += new System.EventHandler(this.btnInstallmentForm_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(100, 280);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 35);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 335);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnInstallmentForm);
            this.Controls.Add(this.btnBusForm);
            this.Controls.Add(this.btnLibraryForm);
            this.Controls.Add(this.btnMyProfile);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student - School Management System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnLibraryForm;
        private System.Windows.Forms.Button btnBusForm;
        private System.Windows.Forms.Button btnInstallmentForm;
        private System.Windows.Forms.Button btnLogout;
    }
}
