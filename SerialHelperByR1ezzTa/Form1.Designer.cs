namespace SerialHelperByR1ezzTa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            cbbTxMode = new ComboBox();
            cbbRxMode = new ComboBox();
            groupBox2 = new GroupBox();
            lblRxCount = new Label();
            lblTxCount = new Label();
            btnClearCount = new Button();
            label4 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnRefresh = new Button();
            btnOpen = new Button();
            cbbBaud = new ComboBox();
            label2 = new Label();
            cbbPort = new ComboBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer2 = new SplitContainer();
            rtbReceive = new RichTextBox();
            btnClear = new Button();
            txtAutoSendMs = new TextBox();
            chkAutoSend = new CheckBox();
            btnSend = new Button();
            txtSend = new TextBox();
            tabPage2 = new TabPage();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            panel1 = new Panel();
            chkAutoScroll = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            tabPage3 = new TabPage();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            panel2 = new Panel();
            comboBox3 = new ComboBox();
            label7 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(980, 594);
            splitContainer1.SplitterDistance = 259;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(cbbTxMode);
            groupBox3.Controls.Add(cbbRxMode);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 373);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(259, 221);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "解码设置";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 79);
            label9.Name = "label9";
            label9.Size = new Size(56, 17);
            label9.TabIndex = 3;
            label9.Text = "发送模式";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 40);
            label8.Name = "label8";
            label8.Size = new Size(56, 17);
            label8.TabIndex = 2;
            label8.Text = "接收模式";
            // 
            // cbbTxMode
            // 
            cbbTxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTxMode.FormattingEnabled = true;
            cbbTxMode.Items.AddRange(new object[] { "ASCII", "HEX" });
            cbbTxMode.Location = new Point(92, 76);
            cbbTxMode.Name = "cbbTxMode";
            cbbTxMode.Size = new Size(121, 25);
            cbbTxMode.TabIndex = 1;
            // 
            // cbbRxMode
            // 
            cbbRxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRxMode.FormattingEnabled = true;
            cbbRxMode.Items.AddRange(new object[] { "ASCII", "HEX" });
            cbbRxMode.Location = new Point(92, 37);
            cbbRxMode.Name = "cbbRxMode";
            cbbRxMode.Size = new Size(121, 25);
            cbbRxMode.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblRxCount);
            groupBox2.Controls.Add(lblTxCount);
            groupBox2.Controls.Add(btnClearCount);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 200);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(259, 394);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "统计信息";
            // 
            // lblRxCount
            // 
            lblRxCount.AutoSize = true;
            lblRxCount.Location = new Point(92, 102);
            lblRxCount.Name = "lblRxCount";
            lblRxCount.Size = new Size(15, 17);
            lblRxCount.TabIndex = 4;
            lblRxCount.Text = "0";
            // 
            // lblTxCount
            // 
            lblTxCount.AutoSize = true;
            lblTxCount.Location = new Point(92, 57);
            lblTxCount.Name = "lblTxCount";
            lblTxCount.Size = new Size(15, 17);
            lblTxCount.TabIndex = 3;
            lblTxCount.Text = "0";
            // 
            // btnClearCount
            // 
            btnClearCount.Location = new Point(138, 127);
            btnClearCount.Name = "btnClearCount";
            btnClearCount.Size = new Size(75, 23);
            btnClearCount.TabIndex = 2;
            btnClearCount.Text = "清空计数";
            btnClearCount.UseVisualStyleBackColor = true;
            btnClearCount.Click += btnClearCount_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 102);
            label4.Name = "label4";
            label4.Size = new Size(31, 17);
            label4.TabIndex = 1;
            label4.Text = "RX :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 57);
            label3.Name = "label3";
            label3.Size = new Size(30, 17);
            label3.TabIndex = 0;
            label3.Text = "TX :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnOpen);
            groupBox1.Controls.Add(cbbBaud);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbbPort);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "串口设置";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(42, 148);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "刷新串口";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(138, 148);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 4;
            btnOpen.Text = "打开串口";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // cbbBaud
            // 
            cbbBaud.FormattingEnabled = true;
            cbbBaud.Location = new Point(92, 89);
            cbbBaud.Name = "cbbBaud";
            cbbBaud.Size = new Size(121, 25);
            cbbBaud.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 92);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 2;
            label2.Text = "波特率";
            // 
            // cbbPort
            // 
            cbbPort.FormattingEnabled = true;
            cbbPort.Location = new Point(92, 44);
            cbbPort.Name = "cbbPort";
            cbbPort.Size = new Size(121, 25);
            cbbPort.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 45);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "串口号";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(717, 594);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer2);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(709, 564);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "基础收发";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(rtbReceive);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(label11);
            splitContainer2.Panel2.Controls.Add(label10);
            splitContainer2.Panel2.Controls.Add(btnClear);
            splitContainer2.Panel2.Controls.Add(txtAutoSendMs);
            splitContainer2.Panel2.Controls.Add(chkAutoSend);
            splitContainer2.Panel2.Controls.Add(btnSend);
            splitContainer2.Panel2.Controls.Add(txtSend);
            splitContainer2.Size = new Size(703, 558);
            splitContainer2.SplitterDistance = 254;
            splitContainer2.TabIndex = 0;
            // 
            // rtbReceive
            // 
            rtbReceive.Dock = DockStyle.Fill;
            rtbReceive.Location = new Point(0, 0);
            rtbReceive.Name = "rtbReceive";
            rtbReceive.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbReceive.Size = new Size(703, 254);
            rtbReceive.TabIndex = 0;
            rtbReceive.Text = "";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(579, 255);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 4;
            btnClear.Text = "清空接收";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtAutoSendMs
            // 
            txtAutoSendMs.Location = new Point(587, 197);
            txtAutoSendMs.Name = "txtAutoSendMs";
            txtAutoSendMs.Size = new Size(67, 23);
            txtAutoSendMs.TabIndex = 3;
            // 
            // chkAutoSend
            // 
            chkAutoSend.AutoSize = true;
            chkAutoSend.Location = new Point(555, 170);
            chkAutoSend.Name = "chkAutoSend";
            chkAutoSend.Size = new Size(75, 21);
            chkAutoSend.TabIndex = 2;
            chkAutoSend.Text = "定时发送";
            chkAutoSend.UseVisualStyleBackColor = true;
            chkAutoSend.CheckedChanged += chkAutoSend_CheckedChanged;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(579, 226);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "发送";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtSend
            // 
            txtSend.Location = new Point(3, 3);
            txtSend.Multiline = true;
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(546, 294);
            txtSend.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(formsPlot1);
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(709, 564);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "数据绘图";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(3, 103);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(703, 458);
            formsPlot1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(chkAutoScroll);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 100);
            panel1.TabIndex = 0;
            // 
            // chkAutoScroll
            // 
            chkAutoScroll.AutoSize = true;
            chkAutoScroll.Checked = true;
            chkAutoScroll.CheckState = CheckState.Checked;
            chkAutoScroll.Location = new Point(276, 59);
            chkAutoScroll.Name = "chkAutoScroll";
            chkAutoScroll.Size = new Size(75, 21);
            chkAutoScroll.TabIndex = 6;
            chkAutoScroll.Text = "自动滚屏";
            chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(276, 37);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(87, 21);
            checkBox3.TabIndex = 5;
            checkBox3.Text = "显示实际值";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(276, 12);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(87, 21);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "显示目标值";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(103, 35);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(103, 6);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 41);
            label6.Name = "label6";
            label6.Size = new Size(75, 17);
            label6.TabIndex = 1;
            label6.Text = "自定义帧头2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 9);
            label5.Name = "label5";
            label5.Size = new Size(75, 17);
            label5.TabIndex = 0;
            label5.Text = "自定义帧头1";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(formsPlot2);
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(709, 564);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "频谱分析";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1F;
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(3, 126);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(703, 435);
            formsPlot2.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox3);
            panel2.Controls.Add(label7);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(703, 123);
            panel2.TabIndex = 0;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(110, 42);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 25);
            comboBox3.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(367, 50);
            label7.Name = "label7";
            label7.Size = new Size(43, 17);
            label7.TabIndex = 0;
            label7.Text = "label7";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(555, 200);
            label10.Name = "label10";
            label10.Size = new Size(32, 17);
            label10.TabIndex = 5;
            label10.Text = "间隔";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(660, 200);
            label11.Name = "label11";
            label11.Size = new Size(25, 17);
            label11.TabIndex = 6;
            label11.Text = "ms";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 594);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Sr1zhTA";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button btnClearCount;
        private Label label4;
        private Label label3;
        private Button btnOpen;
        private ComboBox cbbBaud;
        private Label label2;
        private ComboBox cbbPort;
        private Label label1;
        private SplitContainer splitContainer2;
        private RichTextBox rtbReceive;
        private TextBox txtAutoSendMs;
        private CheckBox chkAutoSend;
        private Button btnSend;
        private TextBox txtSend;
        private Panel panel1;
        private CheckBox chkAutoScroll;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label6;
        private Label label5;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Panel panel2;
        private ComboBox comboBox3;
        private Label label7;
        private Button btnClear;
        private Label lblRxCount;
        private Label lblTxCount;
        private ComboBox cbbTxMode;
        private ComboBox cbbRxMode;
        private Label label9;
        private Label label8;
        private Button btnRefresh;
        private Label label11;
        private Label label10;
    }
}
