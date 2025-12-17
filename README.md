# 📈 SerialHelper By R1ezzTa

![License](https://img.shields.io/badge/license-MIT-green) ![Language](https://img.shields.io/badge/language-C%23-blue) ![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)

**SerialHelper** 是一款专为嵌入式开发（STM32/Arduino/ESP32）设计的上位机工具。它不仅具备传统串口助手的收发功能，还集成了**实时波形绘制**和**FFT频谱分析**功能，是调试 PID 控制、传感器数据和信号处理的利器。

## ✨ Features

### 1. Basic Communication
- **通用收发**：支持自动枚举串口号，支持标准波特率设置。
-  **多格式支持**：支持 **HEX (十六进制)** 与 **ASCII** 格式的混合收发。
-  **数据统计**：实时统计 RX/TX 字节数，支持长时间挂机测试。

### 2.Real-time Oscilloscope
-  **双通道显示**：支持目标值  与实际值 同屏对比，专为 PID 调试设计。
- **高性能绘图**：基于 **ScottPlot 5** 和 **环形缓冲区 (Ring Buffer)** 架构，数据点不卡顿。
-  **光标测量 (Cursors)**：提供 A/B 两根可拖动光标，实时测量 **时间差 ($\Delta X$)** 和 **幅值差 ($\Delta Y$)**。
-  **交互操作**：支持鼠标滚轮缩放、拖拽平移、自动滚屏 。

### 3. Data Processing
-  **FFT 频谱分析**：内置 FftSharp 算法，实时将时域信号转换为频域图，精准定位噪声频率。
-  **协议解析**：支持**自定义帧头/帧尾**（如 `HEAD:`...`;`），自动剥离协议包装，解决串口粘包问题。
-  **数据导出**：一键导出波形数据为 **CSV** 表格（Excel 可读）。
- **截图保存**：一键保存高清波形图片 (PNG/JPG)。

---

## 🛠️ 技术栈 (Tech Stack)

- **开发语言**: C# (.NET 8.0 / .NET Framework 4.8)
- **UI 框架**: Windows Forms 
- **绘图库**: [ScottPlot 5](https://scottplot.net/) 
- **算法库**: [FftSharp](https://github.com/swharden/FftSharp) 

---

## 📝 通信协议说明 (Protocol)

为了在“波形显示”模式下正确绘图，建议单片机发送的数据满足以下格式：

### 1. 基础格式 (ASCII)
使用英文逗号 `,` 分隔两个通道的数据，并以换行符结尾：

```text
数值1,数值2\r\n

```

**Arduino 代码示例:**

```cpp
// 发送目标值和实际值
Serial.print(target_value);
Serial.print(",");
Serial.println(actual_value); // println 会自动加 \r\n
// 输出示例: 50.00,48.52

```

### 2. 进阶格式 (带帧头帧尾)

如果在软件中勾选了“自定义帧头/帧尾”（例如设置帧头为 `S:`，帧尾为 `;`），单片机发送：

```text
S:数值1,数值2;

```

软件会自动剥离 `S:` 和 `;`，提取中间的 `数值1,数值2` 进行绘图。此功能可防止数据错位。

---

## 🚀 快速开始 (Getting Started)

1. **环境准备**：安装 Visual Studio 2022。
2. **下载源码**：Clone 本仓库到本地。
3. **依赖安装**：打开 `.sln` 文件，VS 会自动还原 NuGet 包（ScottPlot.WinForms, FftSharp）。
4. **运行**：点击 **启动 (Start)** 即可运行。

---

## 👤 作者 (Author)

**R1ezzTa **


---

**License**: MIT License

