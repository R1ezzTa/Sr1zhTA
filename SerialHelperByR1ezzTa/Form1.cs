using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using ScottPlot;
using FftSharp;


// ========================================================================
// @Title:       Multi functional serial helper
// @Description: Serial communication, real-time waveform drawing, FFT spectrum analysis
// @Author:      R1ezzTa
// @Date:        2025
// @Version:     1.0
// ========================================================================

namespace SerialHelperByR1ezzTa
{
    public partial class Form1 : Form
    {

        // ----------------------------------------
        // @Module: Serial communication
        // ----------------------------------------
        SerialPort serialPort = new SerialPort();
        private long rxCount = 0;
        private long txCount = 0;
        System.Windows.Forms.Timer autoSendTimer = new System.Windows.Forms.Timer();

        // ----------------------------------------
        // @Module: Drawing variables
        // ----------------------------------------

        private bool isWaveformPaused = false;

        // Waveform data buffer
        double[] dataTarget = new double[500];
        double[] dataActual = new double[500];

        //Scan cursor
        int nextDataIndex = 0;

        //Screen refresh timer
        System.Windows.Forms.Timer plotTimer = new System.Windows.Forms.Timer();

        // scan line
        ScottPlot.Plottables.VerticalLine vLine;

        //Simulated waveform phase
        double waveformPhase = 0;

        //Maximum waveform length
        int maxDataCount = 5000;

        public Form1()
        {
            InitializeComponent();

            dataTarget = new double[maxDataCount];
            dataActual = new double[maxDataCount];
        }


        //@Event: Form loading
        private void Form1_Load(object sender, EventArgs e)
        {
            // ----------------------------------------
            // @Module: Initialize serial port list
            // ----------------------------------------
            string[] ports = SerialPort.GetPortNames();

            //Add the name to the cbbPort dropdown menu
            cbbPort.Items.Clear();
            cbbPort.Items.AddRange(ports);

            //If there is a serial port, the first one is selected by default
            if (cbbPort.Items.Count > 0)
            {
                cbbPort.SelectedIndex = 0;
            }

            //Fill in common values for the baud rate dropdown menu
            string[] baudRates = new string[] {
                "1200", "2400", "4800", "9600", "19200",
                "38400", "57600", "74880", "115200",
                "230400", "460800", "921600"
            };
            cbbBaud.Items.AddRange(baudRates);
            cbbBaud.SelectedItem = "9600";



            // Bind to receive events
            serialPort.DataReceived += SerialPort_DataReceived;

            //Default selection of ASCII mode
            cbbRxMode.SelectedIndex = 0;
            cbbTxMode.SelectedIndex = 0;

            autoSendTimer.Interval = 1000; //Default 1 second
            autoSendTimer.Tick += AutoSendTimer_Tick;

            // ----------------------------------------
            // @Module: Initialize drawing
            // ----------------------------------------



            // Add waveform lines
            var line1 = formsPlot1.Plot.Add.Signal(dataTarget);
            line1.Color = ScottPlot.Colors.Red;
            line1.LineWidth = 1;
            line1.LegendText = "Target";

            var line2 = formsPlot1.Plot.Add.Signal(dataActual);
            line2.Color = ScottPlot.Colors.Blue;
            line2.LineWidth = 1;
            line2.LegendText = "Actual";

            //Add scan line
            vLine = formsPlot1.Plot.Add.VerticalLine(0);
            vLine.Color = ScottPlot.Colors.Green;
            vLine.LineWidth = 1;
            vLine.LinePattern = ScottPlot.LinePattern.Dashed;


            formsPlot1.Plot.FigureBackground.Color = ScottPlot.Colors.White;
            formsPlot1.Plot.DataBackground.Color = ScottPlot.Colors.White;
            formsPlot1.Plot.Axes.Color(ScottPlot.Colors.Black);
            formsPlot1.Plot.Grid.MajorLineColor = ScottPlot.Colors.Black.WithAlpha(0.15);

            //Lock the X-axis range
            formsPlot1.Plot.Axes.SetLimitsX(0, maxDataCount);

            // Start the drawing refresh timer
            plotTimer.Interval = 50;
            plotTimer.Tick += PlotTimer_Tick;
            plotTimer.Start();
        }


        //@Event: Serial port switch button
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = cbbPort.Text;
                    serialPort.BaudRate = int.Parse(cbbBaud.Text);
                    serialPort.Open();

                    btnOpen.Text = "关闭串口";
                    btnOpen.BackColor = Color.Salmon;


                    // Locked to prevent modifications during operation
                    cbbPort.Enabled = false;
                    cbbBaud.Enabled = false;
                }
                else
                {
                    serialPort.Close();
                    btnOpen.Text = "打开串口";
                    btnOpen.BackColor = Color.LightGreen;


                    cbbPort.Enabled = true;
                    cbbBaud.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口错误：" + ex.Message);
            }
        }


        //@Function: Log output to the receiving window
        private void LogToWindow(string text, Color color)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (rtbReceive.TextLength > 50000) rtbReceive.Clear(); // Prevent memory overflow

                rtbReceive.SelectionStart = rtbReceive.TextLength;
                rtbReceive.SelectionLength = 0;
                rtbReceive.SelectionColor = color;
                rtbReceive.AppendText(text + "\r\n");
                rtbReceive.ScrollToCaret();
            });
        }

        //@Function: Byte array to HEX string conversion
        private string ByteToHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) sb.Append(b.ToString("X2") + " ");
            return sb.ToString();
        }

        //@Function: HEX string to byte array conversion
        private byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            if (msg.Length % 2 != 0) msg = msg.Insert(0, "0"); // Fill in even numbers
            byte[] buffer = new byte[msg.Length / 2];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToByte(msg.Substring(i * 2, 2), 16);
            return buffer;
        }

        //@Event: Serial port data reception 
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen) return;

            try
            {
                int n = serialPort.BytesToRead;
                if (n == 0) return;

                byte[] buf = new byte[n];
                serialPort.Read(buf, 0, n);

                rxCount += n;

                // ----------------------------------------
                // @Module: Interface updates and variable sharing
                // ----------------------------------------
                this.Invoke((MethodInvoker)delegate
                {
                    // update statistics
                    lblRxCount.Text = rxCount.ToString();

                    // 1. Get Raw Data
                    string displayMsg = "";
                    if (cbbRxMode.Text == "HEX")
                    {
                        displayMsg = ByteToHex(buf);
                    }
                    else
                    {
                        displayMsg = System.Text.Encoding.UTF8.GetString(buf);
                    }

                    // ==========================================
                    // [INSERTED] Frame Header & Tail Parsing Logic
                    // ==========================================
                    string processedMsg = displayMsg;
                    bool keepProcessing = true; // Valid flag

                    // A. Process Rx Header
                    if (chkRxHeader.Checked && !string.IsNullOrEmpty(txtRxHeader.Text))
                    {
                        string header = txtRxHeader.Text.Replace("\\r", "\r").Replace("\\n", "\n");
                        int idx = processedMsg.IndexOf(header);

                        if (idx >= 0)
                        {
                            // Keep content AFTER the header
                            processedMsg = processedMsg.Substring(idx + header.Length);
                        }
                        else
                        {
                            keepProcessing = false; // Header not found, discard
                        }
                    }

                    // B. Process Rx Tail
                    if (keepProcessing && chkRxTail.Checked && !string.IsNullOrEmpty(txtRxTail.Text))
                    {
                        string tail = txtRxTail.Text.Replace("\\r", "\r").Replace("\\n", "\n");
                        int idx = processedMsg.IndexOf(tail);

                        if (idx >= 0)
                        {
                            // Keep content BEFORE the tail
                            processedMsg = processedMsg.Substring(0, idx);
                        }
                    }

                    // ==========================================
                    // [END] Logic
                    // ==========================================

                    // Only display and plot if data is valid (keepProcessing is true)
                    if (keepProcessing)
                    {
                        // Update display to receive window (Using processedMsg)
                        LogToWindow(processedMsg, System.Drawing.Color.Black);

                        // ----------------------------------------
                        // @Module: waveform analysis
                        // ----------------------------------------
                        if (tabControl1.SelectedIndex == 1 && cbbRxMode.Text == "ASCII")
                        {
                            if (isWaveformPaused) return;

                            try
                            {
                                // Use processedMsg for waveform parsing
                                string cleanData = processedMsg.Trim();
                                string[] parts = cleanData.Split(',');

                                if (parts.Length >= 2)
                                {
                                    if (double.TryParse(parts[0], out double val1) &&
                                        double.TryParse(parts[1], out double val2))
                                    {
                                        dataTarget[nextDataIndex] = val1;
                                        dataActual[nextDataIndex] = val2;

                                        nextDataIndex++;
                                        if (nextDataIndex >= dataTarget.Length) nextDataIndex = 0;

                                        formsPlot1.Plot.Axes.SetLimitsX(0, maxDataCount);
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                });
            }
            //@Event: Abnormal disconnection handling
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (serialPort.IsOpen) serialPort.Close();
                    btnOpen.Text = "打开串口";
                    btnOpen.BackColor = Color.LightGreen;
                    MessageBox.Show("状态：异常断开");
                    btnRefresh_Click(null, null);
                });
            }
        }

        //@Event: Send button 
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("请先打开串口"); return; }

            string str = txtSend.Text;
            if (string.IsNullOrEmpty(str)) return;

            try
            {
                // ==========================================
                // [INSERTED] Frame Header & Tail Appending Logic
                // ==========================================

                // 1. Append Header
                if (chkTxHeader.Checked && !string.IsNullOrEmpty(txtTxHeader.Text))
                {
                    string header = txtTxHeader.Text.Replace("\\r", "\r").Replace("\\n", "\n");
                    str = header + str;
                }

                // 2. Append Tail
                if (chkTxTail.Checked && !string.IsNullOrEmpty(txtTxTail.Text))
                {
                    string tail = txtTxTail.Text.Replace("\\r", "\r").Replace("\\n", "\n");
                    str = str + tail;
                }
                // ==========================================

                // Send Logic (Uses the modified 'str')
                if (cbbTxMode.Text == "HEX")
                {
                    byte[] data = HexToByte(str);
                    serialPort.Write(data, 0, data.Length);
                    txCount += data.Length;
                }
                else
                {
                    serialPort.Write(str);
                    txCount += str.Length;
                }

                LogToWindow("[发送] " + str, Color.SeaGreen);
                lblTxCount.Text = txCount.ToString();
            }
            catch (FormatException)
            {
                LogToWindow("[错误] HEX模式下请输入16进制数", Color.Red);
            }
            catch (Exception ex)
            {
                LogToWindow("[错误] " + ex.Message, Color.Red);
            }
        }


        //@Event: Clear receiving window button
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbReceive.Clear();
            rxCount = 0;
            txCount = 0;

        }

        //@Event: Reset count button
        private void btnClearCount_Click(object sender, EventArgs e)
        {
            rxCount = 0;
            txCount = 0;

            lblRxCount.Text = "0";
            lblTxCount.Text = "0";

        }


        //@Event: Automatically send timer tick
        private void AutoSendTimer_Tick(object sender, EventArgs e)
        {
            // ==========================================
            // Mode A: Serial
            // ==========================================
            /*
            if (serialPort.IsOpen)
            {
                btnSend_Click(null, null);
            }
            else
            {
                chkAutoSend.Checked = false;
            }
            */

            // ==========================================
            //  Mode B: Simulation
            //  No need to plug in the serial port, simply call the test function
            // ==========================================

            RunTestSignalGenerator();
        }


        //@Event: automatically send
        private void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoSend.Checked)
            {

                if (!serialPort.IsOpen)
                {
                    MessageBox.Show("请先打开串口！");
                    chkAutoSend.Checked = false;
                    return;
                }

                //time interval
                if (int.TryParse(txtAutoSendMs.Text, out int interval) && interval > 0)
                {
                    autoSendTimer.Interval = interval;
                    autoSendTimer.Start();

                    //Lock the input box to prevent time modification during operation
                    txtAutoSendMs.Enabled = false;
                }
                else
                {
                    MessageBox.Show("请输入正确的时间间隔（数字，单位毫秒）！");
                    chkAutoSend.Checked = false;
                }
            }
            else
            {
                autoSendTimer.Stop();
                txtAutoSendMs.Enabled = true;
            }
        }

        //@Event: Drawing refresh timer
        private void PlotTimer_Tick(object sender, EventArgs e)
        {
            // time domain
            if (tabControl1.SelectedIndex == 1)
            {
                vLine.X = nextDataIndex;
                if (chkAutoScroll.Checked)
                {
                    formsPlot1.Plot.Axes.AutoScale(invertX: false, invertY: false);
                    formsPlot1.Plot.Axes.SetLimitsX(0, maxDataCount);
                }
                formsPlot1.Refresh();
            }

            // frequency domain
            else if (tabControl1.SelectedIndex == 2)
            {
                UpdateSpectrum();
            }
        }

        //@Function: Update spectrum diagram
        private void UpdateSpectrum()
        {
            // prepare data
            int fftLength = 4096;
            double[] paddedAudio = new double[fftLength];
            // Copy the data from dataTarget and add 0 if it's not enough
            int len = Math.Min(dataTarget.Length, fftLength);
            Array.Copy(dataTarget, 0, paddedAudio, 0, len);

            // Instantiate window object
            var window = new FftSharp.Windows.Hanning();
            window.ApplyInPlace(paddedAudio);

            //FFT 
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(paddedAudio);
            double[] power = FftSharp.FFT.Power(spectrum);

            // Generate frequency axis
            // Assuming a sampling rate of 50Hz (because autoSendTimer=20ms)
            double sampleRate = 50;
            double[] freqs = FftSharp.FFT.FrequencyScale(power.Length, sampleRate);

            formsPlot2.Plot.Clear();

            var sp = formsPlot2.Plot.Add.ScatterLine(freqs, power);
            sp.Color = ScottPlot.Colors.BlueViolet;
            sp.LineWidth = 2;

            formsPlot2.Plot.Axes.AutoScale();
            formsPlot2.Refresh();
        }

        //@Function: text signal generator
        private void RunTestSignalGenerator()
        {
            // Step size, increase waveform density, decrease waveform sparsity
            waveformPhase += 0.2;

            // Generate signals and simulate data sent by microcontrollers
            // Signal A: Pure sine wave
            double signalA = 50 + 40 * Math.Sin(waveformPhase);

            // Signal B: cosine wave with noise
            Random rnd = new Random();
            double noise = (rnd.NextDouble() - 0.5) * 5; // -Random noise ranging from 2.5 to+2.5
            double signalB = 50 + 30 * Math.Sin(waveformPhase) + 15 * Math.Sin(waveformPhase * 3) + noise;

            //Fill in the global array
            dataTarget[nextDataIndex] = signalA;
            dataActual[nextDataIndex] = signalB;

            //Loop Write
            nextDataIndex++;
            if (nextDataIndex >= dataTarget.Length) nextDataIndex = 0;
        }


        //@Event: refresh serial port list
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                MessageBox.Show("请先关闭串口再刷新！");
                return;
            }

            string currentPort = cbbPort.Text;

            cbbPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            cbbPort.Items.AddRange(ports);

            if (cbbPort.Items.Contains(currentPort))
            {
                cbbPort.Text = currentPort;
            }
            else if (cbbPort.Items.Count > 0)
            {
                cbbPort.SelectedIndex = 0;
            }

        }

        //@Event: Pause/Resume drawing button
        private void btnPause_Click(object sender, EventArgs e)
        {
            isWaveformPaused = !isWaveformPaused;


            if (isWaveformPaused)
            {
                btnPause.Text = "继续绘图";
                btnPause.BackColor = Color.LightGreen;
            }
            else
            {
                btnPause.Text = "暂停";
                btnPause.BackColor = Color.LightSalmon;
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (dataTarget == null || dataActual == null)
            {
                MessageBox.Show("没有数据可保存！");
                return;
            }
            //auto pause
            bool wasPaused = isWaveformPaused;
            if (!isWaveformPaused)
            {
                btnPause_Click(null, null);
            }


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV 文件 (*.csv)|*.csv|文本文件 (*.txt)|*.txt";
            sfd.FileName = "WaveformData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            sfd.Title = "导出波形数据";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("Index,Target_Value,Actual_Value");

                        for (int i = 0; i < maxDataCount; i++)
                        {
                            string line = string.Format("{0},{1},{2}", i, dataTarget[i], dataActual[i]);
                            sw.WriteLine(line);
                        }
                    }
                    MessageBox.Show("保存成功！\n路径：" + sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败：" + ex.Message);
                }
            }

            if (!wasPaused)
            {
                btnPause_Click(null, null);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG 图片|*.png|JPG 图片|*.jpg";
            sfd.FileName = "Waveform_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                formsPlot1.Plot.SavePng(sfd.FileName, 800, 600);
                MessageBox.Show("图片已保存！");
            }
        }

        private void btnSaveSpecImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG 图片|*.png|JPG 图片|*.jpg";
            sfd.FileName = "Spectrum_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            sfd.Title = "保存频谱分析图";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    formsPlot2.Plot.SavePng(sfd.FileName, 800, 600);
                    MessageBox.Show("频谱图保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败：" + ex.Message);
                }
            }
        }
    }

}