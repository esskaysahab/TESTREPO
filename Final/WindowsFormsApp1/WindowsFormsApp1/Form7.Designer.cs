namespace WindowsFormsApp1
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.lblBookName = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.dtpSubmitDate = new System.Windows.Forms.DateTimePicker();
            this.lblSubmitDate = new System.Windows.Forms.Label();
            this.btnCalculateFine = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.lblReport = new System.Windows.Forms.Label();
            this.txtTotalFine = new System.Windows.Forms.TextBox();
            this.lblTotalFine = new System.Windows.Forms.Label();
            this.txtElectric = new System.Windows.Forms.TextBox();
            this.lblElectric = new System.Windows.Forms.Label();
            this.txtGst = new System.Windows.Forms.TextBox();
            this.lblGst = new System.Windows.Forms.Label();
            this.txtInstallment = new System.Windows.Forms.TextBox();
            this.lblInstallment = new System.Windows.Forms.Label();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.lblPaidDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bus",
            "Library",
            "Installment"});
            this.comboBox1.Location = new System.Drawing.Point(307, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(261, 21);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(375, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 18);
            this.label13.TabIndex = 58;
            this.label13.Text = "Avaliable Facilities::";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(38, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 357);
            this.panel1.TabIndex = 60;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.textBox11);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.dtpPaidDate);
            this.panel4.Controls.Add(this.lblPaidDate);
            this.panel4.Controls.Add(this.dtpDueDate);
            this.panel4.Controls.Add(this.lblDueDate);
            this.panel4.Controls.Add(this.textBox10);
            this.panel4.Controls.Add(this.txtElectric);
            this.panel4.Controls.Add(this.lblElectric);
            this.panel4.Controls.Add(this.txtGst);
            this.panel4.Controls.Add(this.lblGst);
            this.panel4.Controls.Add(this.txtInstallment);
            this.panel4.Controls.Add(this.lblInstallment);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.textBox8);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.textBox9);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(582, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 316);
            this.panel4.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(81, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Installment Form";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnCalculateFine);
            this.panel3.Controls.Add(this.txtReport);
            this.panel3.Controls.Add(this.lblReport);
            this.panel3.Controls.Add(this.txtTotalFine);
            this.panel3.Controls.Add(this.lblTotalFine);
            this.panel3.Controls.Add(this.dtpSubmitDate);
            this.panel3.Controls.Add(this.lblSubmitDate);
            this.panel3.Controls.Add(this.dtpIssueDate);
            this.panel3.Controls.Add(this.lblIssueDate);
            this.panel3.Controls.Add(this.txtBookName);
            this.panel3.Controls.Add(this.lblBookName);
            this.panel3.Controls.Add(this.txtCardNo);
            this.panel3.Controls.Add(this.lblCardNo);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(299, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 316);
            this.panel3.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(108, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Library Form";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(12, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 317);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 21);
            this.button2.TabIndex = 39;
            this.button2.Text = "Calculate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Bus Form";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(112, 208);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(68, 20);
            this.textBox5.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Total Fine:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 26);
            this.button1.TabIndex = 35;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(112, 182);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 34;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(112, 236);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(140, 20);
            this.textBox4.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Installment:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.comboBox3.Location = new System.Drawing.Point(112, 120);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(140, 21);
            this.comboBox3.TabIndex = 31;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 151);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 20);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Report:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Paid Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Install Month:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Bus Card No:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 94);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 20);
            this.textBox3.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Student Name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Student ID:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Student Name:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(111, 63);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(140, 20);
            this.textBox6.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Student ID:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(111, 37);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(140, 20);
            this.textBox7.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Student Name:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(87, 62);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(162, 20);
            this.textBox8.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Student ID:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(87, 38);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(162, 20);
            this.textBox9.TabIndex = 41;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 26);
            this.button3.TabIndex = 44;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(108, 273);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 26);
            this.button4.TabIndex = 45;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(111, 115);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(140, 20);
            this.txtBookName.TabIndex = 48;
            // 
            // lblBookName
            // 
            this.lblBookName.AutoSize = true;
            this.lblBookName.Location = new System.Drawing.Point(19, 122);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(66, 13);
            this.lblBookName.TabIndex = 47;
            this.lblBookName.Text = "Book Name:";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(111, 89);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(140, 20);
            this.txtCardNo.TabIndex = 46;
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Location = new System.Drawing.Point(19, 96);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(49, 13);
            this.lblCardNo.TabIndex = 45;
            this.lblCardNo.Text = "Card No:";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueDate.Location = new System.Drawing.Point(111, 141);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(140, 20);
            this.dtpIssueDate.TabIndex = 50;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(19, 147);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(61, 13);
            this.lblIssueDate.TabIndex = 49;
            this.lblIssueDate.Text = "Issue Date:";
            // 
            // dtpSubmitDate
            // 
            this.dtpSubmitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSubmitDate.Location = new System.Drawing.Point(111, 171);
            this.dtpSubmitDate.Name = "dtpSubmitDate";
            this.dtpSubmitDate.Size = new System.Drawing.Size(140, 20);
            this.dtpSubmitDate.TabIndex = 52;
            // 
            // lblSubmitDate
            // 
            this.lblSubmitDate.AutoSize = true;
            this.lblSubmitDate.Location = new System.Drawing.Point(19, 171);
            this.lblSubmitDate.Name = "lblSubmitDate";
            this.lblSubmitDate.Size = new System.Drawing.Size(68, 13);
            this.lblSubmitDate.TabIndex = 51;
            this.lblSubmitDate.Text = "Submit Date:";
            // 
            // btnCalculateFine
            // 
            this.btnCalculateFine.Location = new System.Drawing.Point(188, 198);
            this.btnCalculateFine.Name = "btnCalculateFine";
            this.btnCalculateFine.Size = new System.Drawing.Size(63, 25);
            this.btnCalculateFine.TabIndex = 57;
            this.btnCalculateFine.Text = "Calculate Fine";
            this.btnCalculateFine.UseVisualStyleBackColor = true;
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(111, 226);
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(140, 20);
            this.txtReport.TabIndex = 56;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(25, 230);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(42, 13);
            this.lblReport.TabIndex = 55;
            this.lblReport.Text = "Report:";
            // 
            // txtTotalFine
            // 
            this.txtTotalFine.Location = new System.Drawing.Point(111, 200);
            this.txtTotalFine.Name = "txtTotalFine";
            this.txtTotalFine.Size = new System.Drawing.Size(71, 20);
            this.txtTotalFine.TabIndex = 54;
            // 
            // lblTotalFine
            // 
            this.lblTotalFine.AutoSize = true;
            this.lblTotalFine.Location = new System.Drawing.Point(19, 200);
            this.lblTotalFine.Name = "lblTotalFine";
            this.lblTotalFine.Size = new System.Drawing.Size(57, 13);
            this.lblTotalFine.TabIndex = 53;
            this.lblTotalFine.Text = "Total Fine:";
            // 
            // txtElectric
            // 
            this.txtElectric.Location = new System.Drawing.Point(64, 116);
            this.txtElectric.Name = "txtElectric";
            this.txtElectric.Size = new System.Drawing.Size(80, 20);
            this.txtElectric.TabIndex = 51;
            // 
            // lblElectric
            // 
            this.lblElectric.AutoSize = true;
            this.lblElectric.Location = new System.Drawing.Point(13, 123);
            this.lblElectric.Name = "lblElectric";
            this.lblElectric.Size = new System.Drawing.Size(45, 13);
            this.lblElectric.TabIndex = 50;
            this.lblElectric.Text = "Electric:";
            // 
            // txtGst
            // 
            this.txtGst.Location = new System.Drawing.Point(186, 114);
            this.txtGst.Name = "txtGst";
            this.txtGst.Size = new System.Drawing.Size(63, 20);
            this.txtGst.TabIndex = 49;
            // 
            // lblGst
            // 
            this.lblGst.AutoSize = true;
            this.lblGst.Location = new System.Drawing.Point(148, 120);
            this.lblGst.Name = "lblGst";
            this.lblGst.Size = new System.Drawing.Size(32, 13);
            this.lblGst.TabIndex = 48;
            this.lblGst.Text = "GST:";
            // 
            // txtInstallment
            // 
            this.txtInstallment.Location = new System.Drawing.Point(87, 88);
            this.txtInstallment.Name = "txtInstallment";
            this.txtInstallment.Size = new System.Drawing.Size(162, 20);
            this.txtInstallment.TabIndex = 47;
            // 
            // lblInstallment
            // 
            this.lblInstallment.AutoSize = true;
            this.lblInstallment.Location = new System.Drawing.Point(17, 88);
            this.lblInstallment.Name = "lblInstallment";
            this.lblInstallment.Size = new System.Drawing.Size(60, 13);
            this.lblInstallment.TabIndex = 46;
            this.lblInstallment.Text = "Installment:";
            // 
            // dtpPaidDate
            // 
            this.dtpPaidDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaidDate.Location = new System.Drawing.Point(142, 167);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(107, 20);
            this.dtpPaidDate.TabIndex = 56;
            // 
            // lblPaidDate
            // 
            this.lblPaidDate.AutoSize = true;
            this.lblPaidDate.Location = new System.Drawing.Point(159, 151);
            this.lblPaidDate.Name = "lblPaidDate";
            this.lblPaidDate.Size = new System.Drawing.Size(57, 13);
            this.lblPaidDate.TabIndex = 55;
            this.lblPaidDate.Text = "Paid Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(29, 166);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(107, 20);
            this.dtpDueDate.TabIndex = 54;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(52, 150);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(56, 13);
            this.lblDueDate.TabIndex = 53;
            this.lblDueDate.Text = "Due Date:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(65, 238);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(184, 20);
            this.textBox10.TabIndex = 52;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(186, 207);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 25);
            this.button5.TabIndex = 60;
            this.button5.Text = "Calculate Fine";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(87, 208);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(93, 20);
            this.textBox11.TabIndex = 59;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 58;
            this.label17.Text = "Total Fine:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 61;
            this.label18.Text = "Report:";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label13);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.Label lblPaidDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox txtElectric;
        private System.Windows.Forms.Label lblElectric;
        private System.Windows.Forms.TextBox txtGst;
        private System.Windows.Forms.Label lblGst;
        private System.Windows.Forms.TextBox txtInstallment;
        private System.Windows.Forms.Label lblInstallment;
        private System.Windows.Forms.Button btnCalculateFine;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.TextBox txtTotalFine;
        private System.Windows.Forms.Label lblTotalFine;
        private System.Windows.Forms.DateTimePicker dtpSubmitDate;
        private System.Windows.Forms.Label lblSubmitDate;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblCardNo;
    }
}