using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using ScottPlot;
using FftSharp;


// ========================================================================
// @Title:       多功能串口助手
// @Description: 串口通信、波形实时绘制、FFT 频谱分析
// @Author:      R1ezzTa
// @Date:        2025
// @Version:     1.0
// ========================================================================

namespace SerialHelperByR1ezzTa
{
    public partial class Form1 : Form
    {

        // ----------------------------------------
        // @Module: 串口通信
        // ----------------------------------------
        SerialPort serialPort = new SerialPort();
        private long rxCount = 0; 
        private long txCount = 0; 
        System.Windows.Forms.Timer autoSendTimer = new System.Windows.Forms.Timer();

        // ----------------------------------------
        // @Module: 绘图变量
        // ----------------------------------------

        // 波形数据缓冲区
        double[] dataTarget = new double[500];
        double[] dataActual = new double[500];

        //扫描光标
        int nextDataIndex = 0;

        //屏幕刷新定时器
        System.Windows.Forms.Timer plotTimer = new System.Windows.Forms.Timer();

        // 扫描线
        ScottPlot.Plottables.VerticalLine vLine;

        //仿真波形相位
        double waveformPhase = 0;

        //最大波形长度
        int maxDataCount = 5000;

        public Form1()
        {
            InitializeComponent();

            dataTarget = new double[maxDataCount];
            dataActual = new double[maxDataCount];
        }


        //@Event: 窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {
            // ----------------------------------------
            // @Module: 初始化串口列表
            // ----------------------------------------
            string[] ports = SerialPort.GetPortNames();

            //把名字加到 cbbPort 下拉框里
            cbbPort.Items.Clear();
            cbbPort.Items.AddRange(ports);

            //如果有串口，默认选中第一个
            if (cbbPort.Items.Count > 0)
            {
                cbbPort.SelectedIndex = 0;
            }

            //给波特率下拉框填点常用值
            string[] baudRates = new string[] {
                "1200", "2400", "4800", "9600", "19200",
                "38400", "57600", "74880", "115200",
                "230400", "460800", "921600"
            };
            cbbBaud.Items.AddRange(baudRates);
            cbbBaud.SelectedItem = "9600"; 



            // 绑定接收事件
            serialPort.DataReceived += SerialPort_DataReceived;

            //默认选中 ASCII 模式
            cbbRxMode.SelectedIndex = 0; 
            cbbTxMode.SelectedIndex = 0;

            autoSendTimer.Interval = 1000; // 默认1秒
            autoSendTimer.Tick += AutoSendTimer_Tick;

            // ----------------------------------------
            // @Module: 初始化绘图
            // ----------------------------------------

            

            // 添加波形线
            var line1 = formsPlot1.Plot.Add.Signal(dataTarget);
            line1.Color = ScottPlot.Colors.Red;     
            line1.LineWidth = 1;
            line1.LegendText = "Target";

            var line2 = formsPlot1.Plot.Add.Signal(dataActual);
            line2.Color = ScottPlot.Colors.Blue;    
            line2.LineWidth =1;
            line2.LegendText = "Actual";

            //添加扫描线
            vLine = formsPlot1.Plot.Add.VerticalLine(0);
            vLine.Color = ScottPlot.Colors.Green;   
            vLine.LineWidth = 1;                   
            vLine.LinePattern = ScottPlot.LinePattern.Dashed; // 虚线

            //白底黑字
            formsPlot1.Plot.FigureBackground.Color = ScottPlot.Colors.White;
            formsPlot1.Plot.DataBackground.Color = ScottPlot.Colors.White;
            formsPlot1.Plot.Axes.Color(ScottPlot.Colors.Black);           
            formsPlot1.Plot.Grid.MajorLineColor = ScottPlot.Colors.Black.WithAlpha(0.15);

            //锁定 X 轴范围
            formsPlot1.Plot.Axes.SetLimitsX(0, maxDataCount);

            // 启动绘图刷新定时器
            plotTimer.Interval = 50;
            plotTimer.Tick += PlotTimer_Tick;
            plotTimer.Start();
        }


        //@Event: 串口开关按钮
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


                    // 锁死，防止运行中修改
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


        //@Function: 日志输出到接收窗口
        private void LogToWindow(string text, Color color)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (rtbReceive.TextLength > 50000) rtbReceive.Clear(); // 防止内存溢出

                rtbReceive.SelectionStart = rtbReceive.TextLength;
                rtbReceive.SelectionLength = 0;
                rtbReceive.SelectionColor = color;
                rtbReceive.AppendText(text + "\r\n");
                rtbReceive.ScrollToCaret();
            });
        }

        //@Function: 字节数组转 HEX 字符串
        private string ByteToHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) sb.Append(b.ToString("X2") + " ");
            return sb.ToString();
        }

        //@Function: HEX 字符串转字节数组
        private byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            if (msg.Length % 2 != 0) msg = msg.Insert(0, "0"); // 补齐偶数位
            byte[] buffer = new byte[msg.Length / 2];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToByte(msg.Substring(i * 2, 2), 16);
            return buffer;
        }

        //@Function: 串口数据接收事件
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
                // @Module: 界面更新和变量共享
                // ----------------------------------------
                this.Invoke((MethodInvoker)delegate
                {
                    //更新统计信息
                    lblRxCount.Text = rxCount.ToString();

                    //解码
                    string displayMsg = "";
                    if (cbbRxMode.Text == "HEX")
                    {
                        displayMsg = ByteToHex(buf);
                    }
                    else
                    {
                        displayMsg = System.Text.Encoding.UTF8.GetString(buf);
                    }

                    //更新显示到接收窗口
                    LogToWindow(displayMsg, System.Drawing.Color.Black);

                    // ----------------------------------------
                    // @Module: 波形解析
                    // ----------------------------------------
                    if (tabControl1.SelectedIndex == 1 && cbbRxMode.Text == "ASCII")
                    {
                        try
                        {
                            string cleanData = displayMsg.Trim();
                            //输入切割
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
                });
            }

            //@Event: 异常断开处理
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    // 强制关闭串口
                    if (serialPort.IsOpen) serialPort.Close();

                    // 更新按钮状态
                    btnOpen.Text = "打开串口";
                    btnOpen.BackColor = Color.LightGreen;
                    MessageBox.Show ("状态：异常断开");

                    // 自动刷新列表
                    btnRefresh_Click(null, null);
                });
            }
        }

        //@Event: 发送按钮
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("请先打开串口"); return; }
            string str = txtSend.Text;
            if (string.IsNullOrEmpty(str)) return;

            try
            {
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


        //@Event: 清空接收窗口按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbReceive.Clear();
            rxCount = 0;
            txCount = 0;

        }

        //@Event: 清零计数按钮
        private void btnClearCount_Click(object sender, EventArgs e)
        {
            rxCount = 0;
            txCount = 0;

            lblRxCount.Text = "0";
            lblTxCount.Text = "0";

        }


        //@Event: 自动发送定时器滴答
        private void AutoSendTimer_Tick(object sender, EventArgs e)
        {
            // ==========================================
            //  模式 A: 串口
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
            //  模式 B: 仿真
            //  不需要插串口，直接调用测试函数
            // ==========================================

            RunTestSignalGenerator(); 
        }


        //@Event: 自动发送
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

                //时间间隔
                if (int.TryParse(txtAutoSendMs.Text, out int interval) && interval > 0)
                {
                    autoSendTimer.Interval = interval; 
                    autoSendTimer.Start();

                    //锁死输入框，防止运行中修改时间
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

        //@Event: 绘图刷新定时器
        private void PlotTimer_Tick(object sender, EventArgs e)
        {
            // 时域 
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

            // 频域
            else if (tabControl1.SelectedIndex == 2)
            {
                UpdateSpectrum(); 
            }
        }

        //@Function: 更新频谱图
        private void UpdateSpectrum()
        {
            // 准备数据
            int fftLength = 4096;
            double[] paddedAudio = new double[fftLength];
            // 将 dataTarget 的数据复制过来，不够的补0
            int len = Math.Min(dataTarget.Length, fftLength);
            Array.Copy(dataTarget, 0, paddedAudio, 0, len);

            // 实例化窗口对象
            var window = new FftSharp.Windows.Hanning();
            window.ApplyInPlace(paddedAudio);

            //FFT 变换
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(paddedAudio);
            double[] power = FftSharp.FFT.Power(spectrum);

            // 生成频率轴
            // 假设采样率为 50Hz (因为 autoSendTimer=20ms)
            double sampleRate = 50;
            double[] freqs = FftSharp.FFT.FrequencyScale(power.Length, sampleRate);

            formsPlot2.Plot.Clear();

            var sp = formsPlot2.Plot.Add.ScatterLine(freqs, power);
            sp.Color = ScottPlot.Colors.BlueViolet;
            sp.LineWidth = 2;

            formsPlot2.Plot.Axes.AutoScale();
            formsPlot2.Refresh();
        }

        //@Function: 测试信号发生器 
        private void RunTestSignalGenerator()
        {
            // 步长，改大波形变密，改小波形变稀疏
            waveformPhase += 0.2;

            // 生成信号，模拟单片机发来的数据
            // 信号 A: 纯净的正弦波
            double signalA = 50 + 40 * Math.Sin(waveformPhase);

            // 信号 B: 带噪声的余弦波
            Random rnd = new Random();
            double noise = (rnd.NextDouble() - 0.5) * 5; // -2.5 到 +2.5 的随机噪声
            double signalB = 50 + 30 * Math.Sin(waveformPhase) + 15 * Math.Sin(waveformPhase * 3) + noise;

            //填入全局数组
            dataTarget[nextDataIndex] = signalA;
            dataActual[nextDataIndex] = signalB;

            //回环写入
            nextDataIndex++;
            if (nextDataIndex >= dataTarget.Length) nextDataIndex = 0;
        }


        //@Event: 刷新串口列表
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

        
    }

}