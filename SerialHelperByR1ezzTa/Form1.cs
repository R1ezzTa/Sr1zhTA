using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using ScottPlot;
using FftSharp;

namespace SerialHelperByR1ezzTa
{
    public partial class Form1 : Form
    {

        /****************全局变量********************/
        SerialPort serialPort = new SerialPort();
        private long rxCount = 0; // 接收计数
        private long txCount = 0; // 发送计数
        System.Windows.Forms.Timer autoSendTimer = new System.Windows.Forms.Timer();
        // === 绘图专用变量 ===
        // 1. 定义数据缓存 (长度 500，代表屏幕上显示 500 个点)
        // ScottPlot 处理几十万个点都很轻松，这里先用 500 做演示
        double[] dataTarget = new double[500];
        double[] dataActual = new double[500];

        // 2. 扫描光标 (记录当前画到第几个点)
        int nextDataIndex = 0;

        // 3. 屏幕刷新定时器 (把数据和绘图分开，防止卡顿)
        System.Windows.Forms.Timer plotTimer = new System.Windows.Forms.Timer();

        // 扫描线 (光标线)
        ScottPlot.Plottables.VerticalLine vLine;

        double waveformPhase = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // === 模块一：初始化串口列表 ===
            // 1. 找：获取电脑上所有串口名字 (如 "COM1", "COM3")
            string[] ports = SerialPort.GetPortNames();

            // 2. 填：把名字加到 cbbPort 下拉框里
            // (确保你的下拉框改名成了 cbbPort，没改名就用 comboBox1)
            cbbPort.Items.Clear();
            cbbPort.Items.AddRange(ports);

            // 3. 选：如果有串口，默认选中第一个
            if (cbbPort.Items.Count > 0)
            {
                cbbPort.SelectedIndex = 0;
            }

            // 4. 设：给波特率下拉框 cbbBaud 填点常用值
            cbbBaud.Items.Add("9600");
            cbbBaud.Items.Add("115200");
            cbbBaud.SelectedIndex = 1; // 默认选中 115200



            // 【新增】绑定接收事件 (很重要！没这句收不到数据)
            serialPort.DataReceived += SerialPort_DataReceived;
            // === 新增：默认选中 ASCII 模式 (索引0) ===
            cbbRxMode.SelectedIndex = 0; // 默认接收 ASCII
            cbbTxMode.SelectedIndex = 0; // 默认发送 ASCII
            autoSendTimer.Interval = 1000; // 默认1秒
            autoSendTimer.Tick += AutoSendTimer_Tick; // 绑定每到时间要干的事

            // === 模块：初始化绘图 (白底 + 扫描线) ===

            // 1. 添加波形线
            var line1 = formsPlot1.Plot.Add.Signal(dataTarget);
            line1.Color = ScottPlot.Colors.Red;      // 红线
            line1.LineWidth = 2;
            line1.LegendText = "目标值";

            var line2 = formsPlot1.Plot.Add.Signal(dataActual);
            line2.Color = ScottPlot.Colors.Blue;     // 蓝线
            line2.LineWidth = 2;
            line2.LegendText = "实际值";

            // 2. 【新功能】添加绿色扫描线 (垂直线)
            vLine = formsPlot1.Plot.Add.VerticalLine(0);
            vLine.Color = ScottPlot.Colors.Green;    // 绿色，和红蓝区分开
            vLine.LineWidth = 2;                     // 线宽
            vLine.LinePattern = ScottPlot.LinePattern.Dashed; // 虚线样式，更像示波器光标

            // 3. 【修改】设置为白底黑字风格 (科研风格)
            formsPlot1.Plot.FigureBackground.Color = ScottPlot.Colors.White; // 整个画布背景变白
            formsPlot1.Plot.DataBackground.Color = ScottPlot.Colors.White;   // 数据区背景变白
            formsPlot1.Plot.Axes.Color(ScottPlot.Colors.Black);              // 坐标轴变黑
            formsPlot1.Plot.Grid.MajorLineColor = ScottPlot.Colors.Black.WithAlpha(0.15); // 网格线变成淡淡的黑色

            // 4. 锁定 X 轴范围
            formsPlot1.Plot.Axes.SetLimitsX(0, 500);

            // 5. 启动绘图刷新定时器
            plotTimer.Interval = 50;
            plotTimer.Tick += PlotTimer_Tick;
            plotTimer.Start();
        }

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


                    // 锁死设置，防止运行中修改
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

        // === 模块三：工具函数 (日志与HEX转换) ===

        // 3.1 彩色日志打印 (解决了跨线程报错问题)
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

        // 3.2 字节转 HEX 字符串 (例如: {0x0A} -> "0A ")
        private string ByteToHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) sb.Append(b.ToString("X2") + " ");
            return sb.ToString();
        }

        // 3.3 HEX 字符串转字节 (例如: "0A 0B" -> {0x0A, 0x0B})
        private byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            if (msg.Length % 2 != 0) msg = msg.Insert(0, "0"); // 补齐偶数位
            byte[] buffer = new byte[msg.Length / 2];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToByte(msg.Substring(i * 2, 2), 16);
            return buffer;
        }

        // === 模块四：接收功能 ===
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen) return;

            // 防止关闭串口时瞬间报错
            try
            {
                int n = serialPort.BytesToRead;
                if (n == 0) return;

                byte[] buf = new byte[n];
                serialPort.Read(buf, 0, n);

                // === A. 累加计数 ===
                rxCount += n;

                // === 关键：所有涉及界面更新和变量共享的逻辑，全都要放在 Invoke 里 ===
                this.Invoke((MethodInvoker)delegate
                {
                    // === B. 更新左侧“统计信息” ===
                    lblRxCount.Text = rxCount.ToString();

                    // === C. 核心解码逻辑 ===
                    string displayMsg = "";
                    if (cbbRxMode.Text == "HEX")
                    {
                        displayMsg = ByteToHex(buf);
                    }
                    else
                    {
                        displayMsg = System.Text.Encoding.UTF8.GetString(buf);
                    }

                    // === D. 显示到接收窗口 ===
                    LogToWindow(displayMsg, System.Drawing.Color.Black);

                    // ================== E. 波形数据解析 (搬进来了！) ==================
                    // 现在可以直接访问 displayMsg、tabControl1 和 cbbRxMode 了，安全无虞
                    if (tabControl1.SelectedIndex == 1 && cbbRxMode.Text == "ASCII")
                    {
                        try
                        {
                            string cleanData = displayMsg.Trim();
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

                                    // 【ScottPlot 5.0 修正写法】
                                    // 旧写法: formsPlot1.Plot.SetAxisLimits(...)
                                    // 新写法: formsPlot1.Plot.Axes.SetLimitsX(...)
                                    formsPlot1.Plot.Axes.SetLimitsX(0, 500);
                                }
                            }
                        }
                        catch { }
                    }
                });
            }
            // 在 SerialPort_DataReceived 的 catch 里加强逻辑
            catch (Exception ex)
            {
                // 如果发生错误，甚至可以直接判断是否是因为设备移除
                this.Invoke((MethodInvoker)delegate
                {
                    // 强制关闭串口
                    if (serialPort.IsOpen) serialPort.Close();

                    // 更新按钮状态
                    btnOpen.Text = "打开串口";
                    btnOpen.BackColor = Color.LightGreen;
                    MessageBox.Show ("状态：异常断开");

                    // 自动刷新一下列表
                    btnRefresh_Click(null, null);
                });
            }
        }

        // === 模块五：发送功能 ===
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("请先打开串口"); return; }
            string str = txtSend.Text;
            if (string.IsNullOrEmpty(str)) return;

            try
            {
                // === 根据发送 ComboBox 判断 ===
                if (cbbTxMode.Text == "HEX")
                {
                    // HEX 发送模式：用户必须输入 "AA BB"
                    // 这里会抛出 FormatException 如果用户输入了 "Hello"
                    byte[] data = HexToByte(str);
                    serialPort.Write(data, 0, data.Length);
                    txCount += data.Length;
                }
                else
                {
                    // ASCII 发送模式：直接发字符串
                    serialPort.Write(str);
                    txCount += str.Length;
                }

                // 显示日志 (绿色)
                LogToWindow("[发送] " + str, Color.SeaGreen);
                lblTxCount.Text = txCount.ToString(); // 更新计数
            }
            catch (FormatException)
            {
                // 专门捕获 HEX 转换失败的错误
                LogToWindow("[错误] HEX模式下请输入16进制数(如 AA BB)，不能输入字母！", Color.Red);
            }
            catch (Exception ex)
            {
                LogToWindow("[错误] " + ex.Message, Color.Red);
            }
        }

        // === 模块六：清空功能 ===
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbReceive.Clear();
            rxCount = 0;
            txCount = 0;

        }

        private void btnClearCount_Click(object sender, EventArgs e)
        {
            // 1. 变量归零
            rxCount = 0;
            txCount = 0;

            // 2. 界面 Label 更新
            lblRxCount.Text = "0";
            lblTxCount.Text = "0";

            // 3. (可选) 同时也清空一下状态栏，保持同步
            //lblStatus.Text = "RX: 0 | TX: 0";
        }

        private void AutoSendTimer_Tick(object sender, EventArgs e)
        {
            // ==========================================
            //  模式 A: 【实战模式】 (真发串口)
            //  (平时用这个，取消注释)
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
            //  模式 B: 【仿真模式】 (测波形、测频谱专用)
            //  (不需要插串口，直接调用测试函数)
            // ==========================================

            RunTestSignalGenerator(); // <--- 只要这一行，就在跑测试！
        }

        private void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoSend.Checked)
            {
                // === 开启自动发送 ===

                // 1. 先做个安全检查：串口开没开？
                if (!serialPort.IsOpen)
                {
                    MessageBox.Show("请先打开串口！");
                    chkAutoSend.Checked = false; // 马上取消勾选
                    return;
                }

                // 2. 获取用户输入的时间间隔
                // 使用 int.TryParse 防止用户输入 "abc" 导致程序崩溃
                if (int.TryParse(txtAutoSendMs.Text, out int interval) && interval > 0)
                {
                    autoSendTimer.Interval = interval; // 设置时间
                    autoSendTimer.Start();             // 启动引擎！

                    // 3. 界面优化：把输入框锁死，防止运行中乱改时间
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
                // === 关闭自动发送 ===
                autoSendTimer.Stop(); // 熄火

                // 解锁输入框，允许用户修改时间
                txtAutoSendMs.Enabled = true;
            }
        }

        private void PlotTimer_Tick(object sender, EventArgs e)
        {
            // === 分页 1: 时域波形 (之前的代码) ===
            if (tabControl1.SelectedIndex == 1)
            {
                // ... (你之前的绿线、刷新代码保持不变) ...
                vLine.X = nextDataIndex;
                if (chkAutoScroll.Checked)
                {
                    formsPlot1.Plot.Axes.AutoScale(invertX: false, invertY: false);
                    formsPlot1.Plot.Axes.SetLimitsX(0, 500);
                }
                formsPlot1.Refresh();
            }

            // === 分页 2: 频域分析 (新加的) ===
            else if (tabControl1.SelectedIndex == 2)
            {
                UpdateSpectrum(); // <--- 只要切到第3页，就执行 FFT
            }
        }

        // === 模块：频谱分析核心逻辑 ===
        // === 模块：频谱分析 (适配 FftSharp 2.x/3.x 新版语法) ===
        private void UpdateSpectrum()
        {
            // 1. 准备数据 (补零到 1024)
            int fftLength = 1024;
            double[] paddedAudio = new double[fftLength];
            // 将 dataTarget 的数据复制过来，不够的补0
            int len = Math.Min(dataTarget.Length, fftLength);
            Array.Copy(dataTarget, 0, paddedAudio, 0, len);

            // 2. 加窗 (新版写法：实例化窗口对象)
            // 解决 "Window未包含Hanning" 报错
            var window = new FftSharp.Windows.Hanning();
            window.ApplyInPlace(paddedAudio);

            // 3. FFT 变换 (新版写法：使用 FFT 类)
            // 解决 "Transform不存在" 报错
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(paddedAudio);
            double[] power = FftSharp.FFT.Power(spectrum);

            // 4. 生成频率轴
            // 假设采样率为 50Hz (因为 autoSendTimer=20ms)，如果你的定时器是 1ms，这里就填 1000
            double sampleRate = 50;
            double[] freqs = FftSharp.FFT.FrequencyScale(power.Length, sampleRate);

            // 5. 绘图 (ScottPlot 5.0 写法)
            formsPlot2.Plot.Clear();

            // 使用 ScatterLine 画频谱线
            var sp = formsPlot2.Plot.Add.ScatterLine(freqs, power);
            sp.Color = ScottPlot.Colors.BlueViolet;
            sp.LineWidth = 2;

            formsPlot2.Plot.Axes.AutoScale();
            formsPlot2.Refresh();
        }

        // === 核心测试模块：信号发生器 ===
        // 以后测 FFT 时，直接改这里的公式就行，不用动其他代码
        private void RunTestSignalGenerator()
        {
            // 1. 模拟时间推进 (相位增加)
            // 0.2 是步长，改大波形变密，改小波形变稀疏
            waveformPhase += 0.2;

            // 2. 生成信号 (模拟单片机发来的数据)
            // 信号 A: 纯净的正弦波 (模拟目标值)
            // 50是直流偏置，40是振幅
            double signalA = 50 + 40 * Math.Sin(waveformPhase);

            // 信号 B: 带噪声的余弦波 (模拟实际采样值)
            // 以后测 FFT 可以把这个改成 signalA + 20 * Math.Sin(3 * waveformPhase) 来测试谐波
            Random rnd = new Random();
            double noise = (rnd.NextDouble() - 0.5) * 5; // -2.5 到 +2.5 的随机噪声
            double signalB = 50 + 30 * Math.Sin(waveformPhase) + 15 * Math.Sin(waveformPhase * 3) + noise;

            // 3. 填入全局数组 (这一步和串口接收时的逻辑一样)
            dataTarget[nextDataIndex] = signalA;
            dataActual[nextDataIndex] = signalB;

            // 4. 移动光标 (回环写入)
            nextDataIndex++;
            if (nextDataIndex >= dataTarget.Length) nextDataIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 1. 如果串口已经打开了，就不允许刷新（防止误操作）
            if (serialPort.IsOpen)
            {
                MessageBox.Show("请先关闭串口再刷新！");
                return;
            }

            // 2. 记住当前选中的名字 (比如 "COM3")
            // 这样刷新完后，如果 COM3 还在，我们尽量保持选中它，不用用户重新选
            string currentPort = cbbPort.Text;

            // 3. 清空旧列表
            cbbPort.Items.Clear();

            // 4. 获取最新列表并添加
            string[] ports = SerialPort.GetPortNames();
            cbbPort.Items.AddRange(ports);

            // 5. 智能恢复选中项
            if (cbbPort.Items.Contains(currentPort))
            {
                // 如果刚才选的还在，就继续选中它
                cbbPort.Text = currentPort;
            }
            else if (cbbPort.Items.Count > 0)
            {
                // 如果刚才选的没了（比如拔掉了），就默认选第一个
                cbbPort.SelectedIndex = 0;
            }

            // (可选) 可以在状态栏提示一下
            //lblStatus.Text = $"刷新完成，发现 {ports.Length} 个设备";
        }

        // ==========================================
        //  监听 USB 拔出事件 (Windows 消息)
        // ==========================================

        // 定义系统消息的编号 (这是 Windows 规定的死值)
        private const int WM_DEVICECHANGE = 0x0219;          // 硬件改变消息
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004; // 设备已移除
        private const int DBT_DEVICEARRIVAL = 0x8000;        // 设备已插入

        protected override void WndProc(ref Message m)
        {
            // 如果系统发来的消息是 "硬件改变"
            if (m.Msg == WM_DEVICECHANGE)
            {
                // 进一步判断：如果是 "设备已移除"
                if (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE)
                {
                    // === 核心逻辑：检测当前串口是否还活着 ===
                    if (serialPort.IsOpen)
                    {
                        // 1. 获取当前电脑上还剩下的所有串口
                        string[] existingPorts = SerialPort.GetPortNames();
                        string currentPortName = serialPort.PortName;

                        // 2. 检查我们当前用的这个串口，还在不在列表里？
                        bool portStillExists = false;
                        foreach (string port in existingPorts)
                        {
                            if (port == currentPortName)
                            {
                                portStillExists = true;
                                break;
                            }
                        }

                        // 3. 如果不在列表里了，说明刚刚拔掉的就是它！
                        if (!portStillExists)
                        {
                            // 强制关闭逻辑
                            ForceCloseSerialPort();
                        }
                    }

                    // (可选) 顺便自动刷新一下下拉框，让用户看到最新列表
                    // 这里为了安全，我们延迟一点点再刷新，给 Windows 反应时间
                    this.BeginInvoke(new Action(() => {
                        btnRefresh_Click(null, null);
                    }));
                }
            }

            // 继续执行系统原来的消息处理
            base.WndProc(ref m);
        }

        // 封装一个强制关闭函数，专门处理拔线情况
        private void ForceCloseSerialPort()
        {
            // 因为这是在系统消息线程，操作 UI 需要 Invoke
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    // 1. 关闭定时器 (防止继续读写报错)
                    autoSendTimer.Stop();
                    chkAutoSend.Checked = false;

                    // 2. 关闭串口 (虽然物理断了，但逻辑上要走一遍 Close 释放资源)
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                }
                catch
                {
                    // 拔线时 Close 可能会报错，直接忽略即可
                }

                // 3. 更新界面状态
                btnOpen.Text = "打开串口";
                btnOpen.BackColor = System.Drawing.Color.LightGreen;
                //lblStatus.Text = "状态：异常断开 (设备移除)";

                // 4. 弹窗提示 (可选，不想弹窗太烦人可以注释掉)
                MessageBox.Show("检测到串口设备已移除！连接自动断开。");
            });
        }
    }

}