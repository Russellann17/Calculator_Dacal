namespace Calculator_Dacal
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btn0 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn3 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn2 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn1 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn6 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn5 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn4 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn9 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn8 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btn7 = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnEquals = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnDivide = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnMultiply = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnSubtract = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnAdd = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnPercent = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnBackspace = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnClear = new Calculator_Dacal.FormDesign.RoundButton();
            this.roundedPanel1 = new Calculator_Dacal.FormDesign.RoundedPanel();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.roundedPanel2 = new Calculator_Dacal.FormDesign.RoundedPanel();
            this.btnNegative = new Calculator_Dacal.FormDesign.RoundButton();
            this.btnDecimal = new Calculator_Dacal.FormDesign.RoundButton();
            this.lbHistory = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 39);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(301, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 39);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Calculator";
            // 
            // btnHistory
            // 
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.ForeColor = System.Drawing.Color.Transparent;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.Location = new System.Drawing.Point(0, 0);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(51, 25);
            this.btnHistory.TabIndex = 2;
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.History_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn0.BorderRadius = 20;
            this.btn0.ButtonImage = null;
            this.btn0.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn0.Location = new System.Drawing.Point(84, 240);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 54);
            this.btn0.TabIndex = 72;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn3.BorderRadius = 20;
            this.btn3.ButtonImage = null;
            this.btn3.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn3.Location = new System.Drawing.Point(163, 181);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 54);
            this.btn3.TabIndex = 71;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn2.BorderRadius = 20;
            this.btn2.ButtonImage = null;
            this.btn2.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn2.Location = new System.Drawing.Point(84, 181);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 54);
            this.btn2.TabIndex = 70;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn1.BorderRadius = 20;
            this.btn1.ButtonImage = null;
            this.btn1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn1.Location = new System.Drawing.Point(6, 181);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 54);
            this.btn1.TabIndex = 69;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn6.BorderRadius = 20;
            this.btn6.ButtonImage = null;
            this.btn6.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn6.Location = new System.Drawing.Point(163, 122);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 54);
            this.btn6.TabIndex = 68;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn5.BorderRadius = 20;
            this.btn5.ButtonImage = null;
            this.btn5.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn5.Location = new System.Drawing.Point(84, 122);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 54);
            this.btn5.TabIndex = 67;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn4.BorderRadius = 20;
            this.btn4.ButtonImage = null;
            this.btn4.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn4.Location = new System.Drawing.Point(6, 122);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 54);
            this.btn4.TabIndex = 66;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn9.BorderRadius = 20;
            this.btn9.ButtonImage = null;
            this.btn9.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn9.Location = new System.Drawing.Point(163, 64);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 54);
            this.btn9.TabIndex = 65;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn8.BorderRadius = 20;
            this.btn8.ButtonImage = null;
            this.btn8.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn8.Location = new System.Drawing.Point(84, 64);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 54);
            this.btn8.TabIndex = 64;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btn7.BorderRadius = 20;
            this.btn7.ButtonImage = null;
            this.btn7.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.btn7.Location = new System.Drawing.Point(6, 64);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 54);
            this.btn7.TabIndex = 63;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // btnEquals
            // 
            this.btnEquals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnEquals.BorderRadius = 20;
            this.btnEquals.ButtonImage = null;
            this.btnEquals.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.btnEquals.Location = new System.Drawing.Point(244, 240);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(75, 54);
            this.btnEquals.TabIndex = 62;
            this.btnEquals.Text = "=";
            this.btnEquals.UseVisualStyleBackColor = false;
            this.btnEquals.Click += new System.EventHandler(this.Equals_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnDivide.BorderRadius = 20;
            this.btnDivide.ButtonImage = null;
            this.btnDivide.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnDivide.Location = new System.Drawing.Point(242, 181);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(75, 54);
            this.btnDivide.TabIndex = 61;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = false;
            this.btnDivide.Click += new System.EventHandler(this.OperatorValue_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnMultiply.BorderRadius = 20;
            this.btnMultiply.ButtonImage = null;
            this.btnMultiply.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.btnMultiply.Location = new System.Drawing.Point(242, 122);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(75, 54);
            this.btnMultiply.TabIndex = 60;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseVisualStyleBackColor = false;
            this.btnMultiply.Click += new System.EventHandler(this.OperatorValue_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnSubtract.BorderRadius = 20;
            this.btnSubtract.ButtonImage = null;
            this.btnSubtract.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.btnSubtract.Location = new System.Drawing.Point(242, 64);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(75, 54);
            this.btnSubtract.TabIndex = 59;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = false;
            this.btnSubtract.Click += new System.EventHandler(this.OperatorValue_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnAdd.BorderRadius = 20;
            this.btnAdd.ButtonImage = null;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(242, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 54);
            this.btnAdd.TabIndex = 58;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.OperatorValue_Click);
            // 
            // btnPercent
            // 
            this.btnPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnPercent.BorderRadius = 20;
            this.btnPercent.ButtonImage = null;
            this.btnPercent.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnPercent.Location = new System.Drawing.Point(163, 6);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(75, 54);
            this.btnPercent.TabIndex = 57;
            this.btnPercent.Text = "%";
            this.btnPercent.UseVisualStyleBackColor = false;
            this.btnPercent.Click += new System.EventHandler(this.Percent_Click);
            // 
            // btnBackspace
            // 
            this.btnBackspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnBackspace.BorderRadius = 20;
            this.btnBackspace.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnBackspace.ButtonImage")));
            this.btnBackspace.Location = new System.Drawing.Point(84, 6);
            this.btnBackspace.Name = "btnBackspace";
            this.btnBackspace.Size = new System.Drawing.Size(75, 54);
            this.btnBackspace.TabIndex = 56;
            this.btnBackspace.UseVisualStyleBackColor = false;
            this.btnBackspace.Click += new System.EventHandler(this.Backspace_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(92)))));
            this.btnClear.BorderRadius = 20;
            this.btnClear.ButtonImage = null;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(6, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 54);
            this.btnClear.TabIndex = 55;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.roundedPanel1.BorderRadius = 20;
            this.roundedPanel1.Controls.Add(this.txtDisplay);
            this.roundedPanel1.Controls.Add(this.txtresult);
            this.roundedPanel1.Controls.Add(this.btnHistory);
            this.roundedPanel1.Location = new System.Drawing.Point(12, 55);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(329, 110);
            this.roundedPanel1.TabIndex = 74;
            // 
            // txtDisplay
            // 
            this.txtDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisplay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDisplay.Enabled = false;
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtDisplay.ForeColor = System.Drawing.Color.Black;
            this.txtDisplay.Location = new System.Drawing.Point(0, 32);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(329, 31);
            this.txtDisplay.TabIndex = 18;
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtresult
            // 
            this.txtresult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtresult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtresult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtresult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtresult.Enabled = false;
            this.txtresult.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtresult.ForeColor = System.Drawing.Color.Black;
            this.txtresult.Location = new System.Drawing.Point(0, 63);
            this.txtresult.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.Size = new System.Drawing.Size(329, 47);
            this.txtresult.TabIndex = 17;
            this.txtresult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.roundedPanel2.BorderRadius = 20;
            this.roundedPanel2.Controls.Add(this.btnNegative);
            this.roundedPanel2.Controls.Add(this.btnDecimal);
            this.roundedPanel2.Controls.Add(this.btnClear);
            this.roundedPanel2.Controls.Add(this.btn0);
            this.roundedPanel2.Controls.Add(this.btnBackspace);
            this.roundedPanel2.Controls.Add(this.btn3);
            this.roundedPanel2.Controls.Add(this.btnPercent);
            this.roundedPanel2.Controls.Add(this.btn2);
            this.roundedPanel2.Controls.Add(this.btnAdd);
            this.roundedPanel2.Controls.Add(this.btn1);
            this.roundedPanel2.Controls.Add(this.btnSubtract);
            this.roundedPanel2.Controls.Add(this.btn6);
            this.roundedPanel2.Controls.Add(this.btnMultiply);
            this.roundedPanel2.Controls.Add(this.btn5);
            this.roundedPanel2.Controls.Add(this.btnDivide);
            this.roundedPanel2.Controls.Add(this.btn4);
            this.roundedPanel2.Controls.Add(this.btnEquals);
            this.roundedPanel2.Controls.Add(this.btn9);
            this.roundedPanel2.Controls.Add(this.btn7);
            this.roundedPanel2.Controls.Add(this.btn8);
            this.roundedPanel2.Location = new System.Drawing.Point(12, 171);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(329, 304);
            this.roundedPanel2.TabIndex = 75;
            // 
            // btnNegative
            // 
            this.btnNegative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btnNegative.BorderRadius = 20;
            this.btnNegative.ButtonImage = null;
            this.btnNegative.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNegative.Location = new System.Drawing.Point(163, 240);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(75, 54);
            this.btnNegative.TabIndex = 74;
            this.btnNegative.Text = "+/-";
            this.btnNegative.UseVisualStyleBackColor = false;
            this.btnNegative.Click += new System.EventHandler(this.Negative_Click);
            // 
            // btnDecimal
            // 
            this.btnDecimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(98)))), ((int)(((byte)(146)))));
            this.btnDecimal.BorderRadius = 20;
            this.btnDecimal.ButtonImage = null;
            this.btnDecimal.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecimal.Location = new System.Drawing.Point(6, 240);
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new System.Drawing.Size(75, 54);
            this.btnDecimal.TabIndex = 73;
            this.btnDecimal.Text = ".";
            this.btnDecimal.UseVisualStyleBackColor = false;
            this.btnDecimal.Click += new System.EventHandler(this.NumValue_Click);
            // 
            // lbHistory
            // 
            this.lbHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(187)))), ((int)(((byte)(208)))));
            this.lbHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbHistory.FormattingEnabled = true;
            this.lbHistory.Location = new System.Drawing.Point(0, 173);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.ScrollAlwaysVisible = true;
            this.lbHistory.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbHistory.Size = new System.Drawing.Size(354, 316);
            this.lbHistory.TabIndex = 77;
            this.lbHistory.Visible = false;
            // 
            // Calculator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(187)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(354, 489);
            this.Controls.Add(this.lbHistory);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHistory;
        private FormDesign.RoundButton btn0;
        private FormDesign.RoundButton btn3;
        private FormDesign.RoundButton btn2;
        private FormDesign.RoundButton btn1;
        private FormDesign.RoundButton btn6;
        private FormDesign.RoundButton btn5;
        private FormDesign.RoundButton btn4;
        private FormDesign.RoundButton btn9;
        private FormDesign.RoundButton btn8;
        private FormDesign.RoundButton btn7;
        private FormDesign.RoundButton btnEquals;
        private FormDesign.RoundButton btnDivide;
        private FormDesign.RoundButton btnMultiply;
        private FormDesign.RoundButton btnSubtract;
        private FormDesign.RoundButton btnAdd;
        private FormDesign.RoundButton btnPercent;
        private FormDesign.RoundButton btnBackspace;
        private FormDesign.RoundButton btnClear;
        private FormDesign.RoundedPanel roundedPanel1;
        private FormDesign.RoundedPanel roundedPanel2;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.TextBox txtresult;
        private FormDesign.RoundButton btnNegative;
        private FormDesign.RoundButton btnDecimal;
        private System.Windows.Forms.ListBox lbHistory;
    }
}

