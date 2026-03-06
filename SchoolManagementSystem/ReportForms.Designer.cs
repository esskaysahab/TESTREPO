namespace SchoolManagementSystem
{
    partial class ReportForms
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
            this.rbBusReport = new System.Windows.Forms.RadioButton();
            this.rbInstallmentReport = new System.Windows.Forms.RadioButton();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "View Reports";
            // 
            // rbBusReport
            // 
            this.rbBusReport.AutoSize = true;
            this.rbBusReport.Location = new System.Drawing.Point(24, 50);
            this.rbBusReport.Name = "rbBusReport";
            this.rbBusReport.Size = new System.Drawing.Size(80, 17);
            this.rbBusReport.TabIndex = 1;
            this.rbBusReport.Text = "Bus Report";
            this.rbBusReport.UseVisualStyleBackColor = true;
            this.rbBusReport.CheckedChanged += new System.EventHandler(this.rbBusReport_CheckedChanged);
            // 
            // rbInstallmentReport
            // 
            this.rbInstallmentReport.AutoSize = true;
            this.rbInstallmentReport.Location = new System.Drawing.Point(130, 50);
            this.rbInstallmentReport.Name = "rbInstallmentReport";
            this.rbInstallmentReport.Size = new System.Drawing.Size(105, 17);
            this.rbInstallmentReport.TabIndex = 2;
            this.rbInstallmentReport.Text = "Installment Report";
            this.rbInstallmentReport.UseVisualStyleBackColor = true;
            this.rbInstallmentReport.CheckedChanged += new System.EventHandler(this.rbInstallmentReport_CheckedChanged);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(24, 85);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(740, 320);
            this.dgvReport.TabIndex = 3;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(24, 418);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(150, 19);
            this.lblGrandTotal.TabIndex = 4;
            this.lblGrandTotal.Text = "Grand Total (Fine): 0.00";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.rbBusReport);
            this.panel1.Controls.Add(this.rbInstallmentReport);
            this.panel1.Controls.Add(this.dgvReport);
            this.panel1.Controls.Add(this.lblGrandTotal);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 450);
            this.panel1.TabIndex = 5;
            // 
            // ReportForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbBusReport;
        private System.Windows.Forms.RadioButton rbInstallmentReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Panel panel1;
    }
}
