namespace SchoolManagementSystem
{
    partial class BusForm
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
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblSec = new System.Windows.Forms.Label();
            this.txtSec = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblInstallMonth = new System.Windows.Forms.Label();
            this.txtInstallMonth = new System.Windows.Forms.TextBox();
            this.lblInstallment = new System.Windows.Forms.Label();
            this.txtInstallment = new System.Windows.Forms.TextBox();
            this.lblPaidDate = new System.Windows.Forms.Label();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalFine = new System.Windows.Forms.Label();
            this.txtTotalFine = new System.Windows.Forms.TextBox();
            this.lblReport = new System.Windows.Forms.Label();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnCalculateFine = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bus Form";
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(24, 55);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(61, 13);
            this.lblStudentId.TabIndex = 1;
            this.lblStudentId.Text = "Student ID:";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(120, 52);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(120, 20);
            this.txtStudentId.TabIndex = 2;
            this.txtStudentId.Leave += new System.EventHandler(this.txtStudentId_Leave);
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(24, 85);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(78, 13);
            this.lblStudentName.TabIndex = 3;
            this.lblStudentName.Text = "Student Name:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(120, 82);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(240, 20);
            this.txtStudentName.TabIndex = 4;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(24, 115);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(35, 13);
            this.lblClass.TabIndex = 5;
            this.lblClass.Text = "Class:";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(120, 112);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(120, 20);
            this.txtClass.TabIndex = 6;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(260, 115);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(28, 13);
            this.lblSec.TabIndex = 7;
            this.lblSec.Text = "Sec:";
            // 
            // txtSec
            // 
            this.txtSec.Location = new System.Drawing.Point(300, 112);
            this.txtSec.Name = "txtSec";
            this.txtSec.ReadOnly = true;
            this.txtSec.Size = new System.Drawing.Size(60, 20);
            this.txtSec.TabIndex = 8;
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Location = new System.Drawing.Point(24, 145);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(48, 13);
            this.lblCardNo.TabIndex = 9;
            this.lblCardNo.Text = "Card No:";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(120, 142);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(120, 20);
            this.txtCardNo.TabIndex = 10;
            // 
            // lblInstallMonth
            // 
            this.lblInstallMonth.AutoSize = true;
            this.lblInstallMonth.Location = new System.Drawing.Point(24, 175);
            this.lblInstallMonth.Name = "lblInstallMonth";
            this.lblInstallMonth.Size = new System.Drawing.Size(76, 13);
            this.lblInstallMonth.TabIndex = 11;
            this.lblInstallMonth.Text = "Install Month:";
            // 
            // txtInstallMonth
            // 
            this.txtInstallMonth.Location = new System.Drawing.Point(120, 172);
            this.txtInstallMonth.Name = "txtInstallMonth";
            this.txtInstallMonth.Size = new System.Drawing.Size(120, 20);
            this.txtInstallMonth.TabIndex = 12;
            // 
            // lblInstallment
            // 
            this.lblInstallment.AutoSize = true;
            this.lblInstallment.Location = new System.Drawing.Point(24, 205);
            this.lblInstallment.Name = "lblInstallment";
            this.lblInstallment.Size = new System.Drawing.Size(61, 13);
            this.lblInstallment.TabIndex = 13;
            this.lblInstallment.Text = "Installment:";
            // 
            // txtInstallment
            // 
            this.txtInstallment.Location = new System.Drawing.Point(120, 202);
            this.txtInstallment.Name = "txtInstallment";
            this.txtInstallment.Size = new System.Drawing.Size(120, 20);
            this.txtInstallment.TabIndex = 14;
            // 
            // lblPaidDate
            // 
            this.lblPaidDate.AutoSize = true;
            this.lblPaidDate.Location = new System.Drawing.Point(260, 205);
            this.lblPaidDate.Name = "lblPaidDate";
            this.lblPaidDate.Size = new System.Drawing.Size(54, 13);
            this.lblPaidDate.TabIndex = 15;
            this.lblPaidDate.Text = "Paid Date:";
            // 
            // dtpPaidDate
            // 
            this.dtpPaidDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaidDate.Location = new System.Drawing.Point(320, 202);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(120, 20);
            this.dtpPaidDate.TabIndex = 16;
            // 
            // lblTotalFine
            // 
            this.lblTotalFine.AutoSize = true;
            this.lblTotalFine.Location = new System.Drawing.Point(24, 235);
            this.lblTotalFine.Name = "lblTotalFine";
            this.lblTotalFine.Size = new System.Drawing.Size(58, 13);
            this.lblTotalFine.TabIndex = 17;
            this.lblTotalFine.Text = "Total Fine:";
            // 
            // txtTotalFine
            // 
            this.txtTotalFine.Location = new System.Drawing.Point(120, 232);
            this.txtTotalFine.Name = "txtTotalFine";
            this.txtTotalFine.Size = new System.Drawing.Size(120, 20);
            this.txtTotalFine.TabIndex = 18;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(24, 265);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(42, 13);
            this.lblReport.TabIndex = 19;
            this.lblReport.Text = "Report:";
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(120, 262);
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(320, 20);
            this.txtReport.TabIndex = 20;
            // 
            // btnCalculateFine
            // 
            this.btnCalculateFine.Location = new System.Drawing.Point(260, 230);
            this.btnCalculateFine.Name = "btnCalculateFine";
            this.btnCalculateFine.Size = new System.Drawing.Size(100, 25);
            this.btnCalculateFine.TabIndex = 21;
            this.btnCalculateFine.Text = "Calculate Fine";
            this.btnCalculateFine.UseVisualStyleBackColor = true;
            this.btnCalculateFine.Click += new System.EventHandler(this.btnCalculateFine_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 345);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCalculateFine);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.txtTotalFine);
            this.Controls.Add(this.lblTotalFine);
            this.Controls.Add(this.dtpPaidDate);
            this.Controls.Add(this.lblPaidDate);
            this.Controls.Add(this.txtInstallment);
            this.Controls.Add(this.lblInstallment);
            this.Controls.Add(this.txtInstallMonth);
            this.Controls.Add(this.lblInstallMonth);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.lblCardNo);
            this.Controls.Add(this.txtSec);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bus";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblInstallMonth;
        private System.Windows.Forms.TextBox txtInstallMonth;
        private System.Windows.Forms.Label lblInstallment;
        private System.Windows.Forms.TextBox txtInstallment;
        private System.Windows.Forms.Label lblPaidDate;
        private System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.Label lblTotalFine;
        private System.Windows.Forms.TextBox txtTotalFine;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Button btnCalculateFine;
        private System.Windows.Forms.Button btnSave;
    }
}
