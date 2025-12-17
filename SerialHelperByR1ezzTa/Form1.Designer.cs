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
            txtRxTail = new TextBox();
            txtRxHeader = new TextBox();
            chkRxTail = new CheckBox();
            chkRxHeader = new CheckBox();
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
            txtTxTail = new TextBox();
            chkTxTail = new CheckBox();
            txtTxHeader = new TextBox();
            chkTxHeader = new CheckBox();
            label11 = new Label();
            label10 = new Label();
            btnClear = new Button();
            txtAutoSendMs = new TextBox();
            chkAutoSend = new CheckBox();
            btnSend = new Button();
            txtSend = new TextBox();
            tabPage2 = new TabPage();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            panel1 = new Panel();
            lblCursorInfo = new Label();
            rbMeasureActual = new RadioButton();
            rbMeasureTarget = new RadioButton();
            chkShowCursors = new CheckBox();
            btnSaveImage = new Button();
            btnSaveData = new Button();
            btnPause = new Button();
            chkAutoScroll = new CheckBox();
            tabPage3 = new TabPage();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            panel2 = new Panel();
            btnSaveSpecImg = new Button();
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
            splitContainer1.Margin = new Padding(5, 4, 5, 4);
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
            splitContainer1.Size = new Size(1540, 839);
            splitContainer1.SplitterDistance = 407;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtRxTail);
            groupBox3.Controls.Add(txtRxHeader);
            groupBox3.Controls.Add(chkRxTail);
            groupBox3.Controls.Add(chkRxHeader);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(cbbTxMode);
            groupBox3.Controls.Add(cbbRxMode);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 527);
            groupBox3.Margin = new Padding(5, 4, 5, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5, 4, 5, 4);
            groupBox3.Size = new Size(407, 312);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "解码设置";
            // 
            // txtRxTail
            // 
            txtRxTail.Location = new Point(114, 257);
            txtRxTail.Name = "txtRxTail";
            txtRxTail.Size = new Size(150, 30);
            txtRxTail.TabIndex = 7;
            // 
            // txtRxHeader
            // 
            txtRxHeader.Location = new Point(114, 182);
            txtRxHeader.Name = "txtRxHeader";
            txtRxHeader.Size = new Size(150, 30);
            txtRxHeader.TabIndex = 6;
            // 
            // chkRxTail
            // 
            chkRxTail.AutoSize = true;
            chkRxTail.Location = new Point(114, 223);
            chkRxTail.Name = "chkRxTail";
            chkRxTail.Size = new Size(144, 28);
            chkRxTail.TabIndex = 5;
            chkRxTail.Text = "自定义帧尾收";
            chkRxTail.UseVisualStyleBackColor = true;
            // 
            // chkRxHeader
            // 
            chkRxHeader.AutoSize = true;
            chkRxHeader.Location = new Point(114, 148);
            chkRxHeader.Name = "chkRxHeader";
            chkRxHeader.Size = new Size(144, 28);
            chkRxHeader.TabIndex = 4;
            chkRxHeader.Text = "自定义帧头收";
            chkRxHeader.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(40, 100);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 24);
            label9.TabIndex = 3;
            label9.Text = "发送模式";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 44);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(82, 24);
            label8.TabIndex = 2;
            label8.Text = "接收模式";
            // 
            // cbbTxMode
            // 
            cbbTxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTxMode.FormattingEnabled = true;
            cbbTxMode.Items.AddRange(new object[] { "ASCII", "HEX" });
            cbbTxMode.Location = new Point(165, 95);
            cbbTxMode.Margin = new Padding(5, 4, 5, 4);
            cbbTxMode.Name = "cbbTxMode";
            cbbTxMode.Size = new Size(188, 32);
            cbbTxMode.TabIndex = 1;
            // 
            // cbbRxMode
            // 
            cbbRxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRxMode.FormattingEnabled = true;
            cbbRxMode.Items.AddRange(new object[] { "ASCII", "HEX" });
            cbbRxMode.Location = new Point(165, 40);
            cbbRxMode.Margin = new Padding(5, 4, 5, 4);
            cbbRxMode.Name = "cbbRxMode";
            cbbRxMode.Size = new Size(188, 32);
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
            groupBox2.Location = new Point(0, 282);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(407, 557);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "统计信息";
            // 
            // lblRxCount
            // 
            lblRxCount.AutoSize = true;
            lblRxCount.Location = new Point(145, 144);
            lblRxCount.Margin = new Padding(5, 0, 5, 0);
            lblRxCount.Name = "lblRxCount";
            lblRxCount.Size = new Size(21, 24);
            lblRxCount.TabIndex = 4;
            lblRxCount.Text = "0";
            // 
            // lblTxCount
            // 
            lblTxCount.AutoSize = true;
            lblTxCount.Location = new Point(145, 80);
            lblTxCount.Margin = new Padding(5, 0, 5, 0);
            lblTxCount.Name = "lblTxCount";
            lblTxCount.Size = new Size(21, 24);
            lblTxCount.TabIndex = 3;
            lblTxCount.Text = "0";
            // 
            // btnClearCount
            // 
            btnClearCount.Location = new Point(217, 179);
            btnClearCount.Margin = new Padding(5, 4, 5, 4);
            btnClearCount.Name = "btnClearCount";
            btnClearCount.Size = new Size(118, 32);
            btnClearCount.TabIndex = 2;
            btnClearCount.Text = "清空计数";
            btnClearCount.UseVisualStyleBackColor = true;
            btnClearCount.Click += btnClearCount_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 144);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 24);
            label4.TabIndex = 1;
            label4.Text = "RX :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 80);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(41, 24);
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
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(407, 282);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "串口设置";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(66, 209);
            btnRefresh.Margin = new Padding(5, 4, 5, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(118, 32);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "刷新串口";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(217, 209);
            btnOpen.Margin = new Padding(5, 4, 5, 4);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(118, 32);
            btnOpen.TabIndex = 4;
            btnOpen.Text = "打开串口";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // cbbBaud
            // 
            cbbBaud.FormattingEnabled = true;
            cbbBaud.Location = new Point(145, 126);
            cbbBaud.Margin = new Padding(5, 4, 5, 4);
            cbbBaud.Name = "cbbBaud";
            cbbBaud.Size = new Size(188, 32);
            cbbBaud.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 130);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 24);
            label2.TabIndex = 2;
            label2.Text = "波特率";
            // 
            // cbbPort
            // 
            cbbPort.FormattingEnabled = true;
            cbbPort.Location = new Point(145, 62);
            cbbPort.Margin = new Padding(5, 4, 5, 4);
            cbbPort.Name = "cbbPort";
            cbbPort.Size = new Size(188, 32);
            cbbPort.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 64);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
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
            tabControl1.Margin = new Padding(5, 4, 5, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1127, 839);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer2);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Margin = new Padding(5, 4, 5, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(5, 4, 5, 4);
            tabPage1.Size = new Size(1119, 802);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "基础收发";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(5, 4);
            splitContainer2.Margin = new Padding(5, 4, 5, 4);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(rtbReceive);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtTxTail);
            splitContainer2.Panel2.Controls.Add(chkTxTail);
            splitContainer2.Panel2.Controls.Add(txtTxHeader);
            splitContainer2.Panel2.Controls.Add(chkTxHeader);
            splitContainer2.Panel2.Controls.Add(label11);
            splitContainer2.Panel2.Controls.Add(label10);
            splitContainer2.Panel2.Controls.Add(btnClear);
            splitContainer2.Panel2.Controls.Add(txtAutoSendMs);
            splitContainer2.Panel2.Controls.Add(chkAutoSend);
            splitContainer2.Panel2.Controls.Add(btnSend);
            splitContainer2.Panel2.Controls.Add(txtSend);
            splitContainer2.Size = new Size(1109, 794);
            splitContainer2.SplitterDistance = 361;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 0;
            // 
            // rtbReceive
            // 
            rtbReceive.Dock = DockStyle.Fill;
            rtbReceive.Location = new Point(0, 0);
            rtbReceive.Margin = new Padding(5, 4, 5, 4);
            rtbReceive.Name = "rtbReceive";
            rtbReceive.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbReceive.Size = new Size(1109, 361);
            rtbReceive.TabIndex = 0;
            rtbReceive.Text = "";
            // 
            // txtTxTail
            // 
            txtTxTail.Location = new Point(898, 147);
            txtTxTail.Name = "txtTxTail";
            txtTxTail.Size = new Size(150, 30);
            txtTxTail.TabIndex = 10;
            // 
            // chkTxTail
            // 
            chkTxTail.AutoSize = true;
            chkTxTail.Location = new Point(898, 113);
            chkTxTail.Name = "chkTxTail";
            chkTxTail.Size = new Size(144, 28);
            chkTxTail.TabIndex = 9;
            chkTxTail.Text = "自定义帧尾发";
            chkTxTail.UseVisualStyleBackColor = true;
            // 
            // txtTxHeader
            // 
            txtTxHeader.Location = new Point(898, 66);
            txtTxHeader.Name = "txtTxHeader";
            txtTxHeader.Size = new Size(150, 30);
            txtTxHeader.TabIndex = 8;
            // 
            // chkTxHeader
            // 
            chkTxHeader.AutoSize = true;
            chkTxHeader.Location = new Point(898, 32);
            chkTxHeader.Name = "chkTxHeader";
            chkTxHeader.Size = new Size(144, 28);
            chkTxHeader.TabIndex = 7;
            chkTxHeader.Text = "自定义帧头发";
            chkTxHeader.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1037, 282);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(35, 24);
            label11.TabIndex = 6;
            label11.Text = "ms";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(872, 282);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(46, 24);
            label10.TabIndex = 5;
            label10.Text = "间隔";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(910, 360);
            btnClear.Margin = new Padding(5, 4, 5, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(118, 32);
            btnClear.TabIndex = 4;
            btnClear.Text = "清空接收";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtAutoSendMs
            // 
            txtAutoSendMs.Location = new Point(922, 278);
            txtAutoSendMs.Margin = new Padding(5, 4, 5, 4);
            txtAutoSendMs.Name = "txtAutoSendMs";
            txtAutoSendMs.Size = new Size(103, 30);
            txtAutoSendMs.TabIndex = 3;
            // 
            // chkAutoSend
            // 
            chkAutoSend.AutoSize = true;
            chkAutoSend.Location = new Point(891, 223);
            chkAutoSend.Margin = new Padding(5, 4, 5, 4);
            chkAutoSend.Name = "chkAutoSend";
            chkAutoSend.Size = new Size(108, 28);
            chkAutoSend.TabIndex = 2;
            chkAutoSend.Text = "定时发送";
            chkAutoSend.UseVisualStyleBackColor = true;
            chkAutoSend.CheckedChanged += chkAutoSend_CheckedChanged;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(910, 319);
            btnSend.Margin = new Padding(5, 4, 5, 4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(118, 32);
            btnSend.TabIndex = 1;
            btnSend.Text = "发送";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtSend
            // 
            txtSend.Location = new Point(5, 4);
            txtSend.Margin = new Padding(5, 4, 5, 4);
            txtSend.Multiline = true;
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(856, 413);
            txtSend.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(formsPlot1);
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Margin = new Padding(5, 4, 5, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(5, 4, 5, 4);
            tabPage2.Size = new Size(1119, 802);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "数据绘图";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(5, 145);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1109, 653);
            formsPlot1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCursorInfo);
            panel1.Controls.Add(rbMeasureActual);
            panel1.Controls.Add(rbMeasureTarget);
            panel1.Controls.Add(chkShowCursors);
            panel1.Controls.Add(btnSaveImage);
            panel1.Controls.Add(btnSaveData);
            panel1.Controls.Add(btnPause);
            panel1.Controls.Add(chkAutoScroll);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 4);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 141);
            panel1.TabIndex = 0;
            // 
            // lblCursorInfo
            // 
            lblCursorInfo.AutoSize = true;
            lblCursorInfo.Location = new Point(150, 27);
            lblCursorInfo.Name = "lblCursorInfo";
            lblCursorInfo.Size = new Size(136, 24);
            lblCursorInfo.TabIndex = 13;
            lblCursorInfo.Text = "（光标未开启）";
            // 
            // rbMeasureActual
            // 
            rbMeasureActual.AutoSize = true;
            rbMeasureActual.Location = new Point(36, 98);
            rbMeasureActual.Name = "rbMeasureActual";
            rbMeasureActual.Size = new Size(89, 28);
            rbMeasureActual.TabIndex = 12;
            rbMeasureActual.Text = "测量蓝";
            rbMeasureActual.UseVisualStyleBackColor = true;
            // 
            // rbMeasureTarget
            // 
            rbMeasureTarget.AutoSize = true;
            rbMeasureTarget.Checked = true;
            rbMeasureTarget.Location = new Point(36, 64);
            rbMeasureTarget.Name = "rbMeasureTarget";
            rbMeasureTarget.Size = new Size(89, 28);
            rbMeasureTarget.TabIndex = 11;
            rbMeasureTarget.TabStop = true;
            rbMeasureTarget.Text = "测量红";
            rbMeasureTarget.UseVisualStyleBackColor = true;
            // 
            // chkShowCursors
            // 
            chkShowCursors.AutoSize = true;
            chkShowCursors.Location = new Point(36, 26);
            chkShowCursors.Name = "chkShowCursors";
            chkShowCursors.Size = new Size(108, 28);
            chkShowCursors.TabIndex = 10;
            chkShowCursors.Text = "光标测量";
            chkShowCursors.UseVisualStyleBackColor = true;
            chkShowCursors.CheckedChanged += chkShowCursors_CheckedChanged;
            // 
            // btnSaveImage
            // 
            btnSaveImage.Location = new Point(837, 82);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(112, 34);
            btnSaveImage.TabIndex = 9;
            btnSaveImage.Text = "导出图片";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += btnSaveImage_Click;
            // 
            // btnSaveData
            // 
            btnSaveData.Location = new Point(837, 20);
            btnSaveData.Name = "btnSaveData";
            btnSaveData.Size = new Size(112, 34);
            btnSaveData.TabIndex = 8;
            btnSaveData.Text = "导出为CSV";
            btnSaveData.UseVisualStyleBackColor = true;
            btnSaveData.Click += btnSaveData_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(641, 73);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(112, 34);
            btnPause.TabIndex = 7;
            btnPause.Text = "暂停";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // chkAutoScroll
            // 
            chkAutoScroll.AutoSize = true;
            chkAutoScroll.Checked = true;
            chkAutoScroll.CheckState = CheckState.Checked;
            chkAutoScroll.Location = new Point(641, 25);
            chkAutoScroll.Margin = new Padding(5, 4, 5, 4);
            chkAutoScroll.Name = "chkAutoScroll";
            chkAutoScroll.Size = new Size(108, 28);
            chkAutoScroll.TabIndex = 6;
            chkAutoScroll.Text = "自动滚屏";
            chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(formsPlot2);
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 33);
            tabPage3.Margin = new Padding(5, 4, 5, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(5, 4, 5, 4);
            tabPage3.Size = new Size(1119, 802);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "频谱分析";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1F;
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(5, 178);
            formsPlot2.Margin = new Padding(5, 4, 5, 4);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(1109, 620);
            formsPlot2.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSaveSpecImg);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(5, 4);
            panel2.Margin = new Padding(5, 4, 5, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1109, 174);
            panel2.TabIndex = 0;
            // 
            // btnSaveSpecImg
            // 
            btnSaveSpecImg.Location = new Point(740, 66);
            btnSaveSpecImg.Name = "btnSaveSpecImg";
            btnSaveSpecImg.Size = new Size(112, 34);
            btnSaveSpecImg.TabIndex = 2;
            btnSaveSpecImg.Text = "导出图片";
            btnSaveSpecImg.UseVisualStyleBackColor = true;
            btnSaveSpecImg.Click += btnSaveSpecImg_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 839);
            Controls.Add(splitContainer1);
            Margin = new Padding(5, 4, 5, 4);
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
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Panel panel2;
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
        private Button btnPause;
        private Button btnSaveImage;
        private Button btnSaveData;
        private Button btnSaveSpecImg;
        private TextBox txtRxTail;
        private TextBox txtRxHeader;
        private CheckBox chkRxTail;
        private CheckBox chkRxHeader;
        private TextBox txtTxTail;
        private CheckBox chkTxTail;
        private TextBox txtTxHeader;
        private CheckBox chkTxHeader;
        private RadioButton rbMeasureActual;
        private RadioButton rbMeasureTarget;
        private CheckBox chkShowCursors;
        private Label lblCursorInfo;
    }
}
