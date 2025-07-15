using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        // ================== 公共事件 ==================

        /// <summary>
        /// 当连接状态发生改变时触发
        /// </summary>
        public event Action<bool, string> ConnectionStatusChanged;

        /// <summary>
        /// 当温度数据更新时触发
        /// </summary>
        public event Action<float> TemperatureUpdated;

        /// <summary>
        /// 当湿度数据更新时触发
        /// </summary>
        public event Action<float> HumidityUpdated;

        /// <summary>
        /// 当光照状态更新时触发
        /// </summary>
        public event Action<string> LightStatusUpdated;

        // ================== 私有成员变量 ==================

        private StringBuilder buffer = new StringBuilder();
        private const int WM_DEVICECHANGE = 0x0219;

        // ================== 公共属性 ==================

        /// <summary>
        /// 用于标记是否要永久关闭此窗口，解决主程序退出时的异常
        /// </summary>
        public bool IsPermanentClose { get; set; } = false;

        // ================== 构造函数 ==================

        public Form2()
        {
            InitializeComponent();
        }

        // ================== 公共方法 ==================

        public bool IsSerialPortOpen()
        {
            return serialPort1 != null && serialPort1.IsOpen;
        }

        public void CloseSerialPort()
        {
            if (IsSerialPortOpen())
            {
                serialPort1.Close();
            }
        }

        public string GetPortInfo()
        {
            if (IsSerialPortOpen())
            {
                return $"{serialPort1.PortName}, {serialPort1.BaudRate}";
            }
            return "N/A";
        }

        

        // ================== 窗体和控件事件 ==================

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateComPorts();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    btnConnect.Text = "打开串口";
                    cbPort.Enabled = true;
                    cbBaudRate.Enabled = true;
                    ConnectionStatusChanged?.Invoke(false, "N/A");
                }
                else
                {
                    serialPort1.PortName = cbPort.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cbBaudRate.Text);
                    serialPort1.Open();
                    btnConnect.Text = "关闭串口";
                    cbPort.Enabled = false;
                    cbBaudRate.Enabled = false;
                    ConnectionStatusChanged?.Invoke(true, GetPortInfo());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(50);
                string receivedData = serialPort1.ReadExisting();

                // 在尝试Invoke之前，检查窗口是否已被销毁
                if (this.IsDisposed || !this.IsHandleCreated) return;

                this.Invoke((MethodInvoker)delegate
                {
                    if (rbReceiveAscii.Checked)
                    {
                        rtbReceive.AppendText(receivedData);
                    }
                    else
                    {
                        byte[] byteBuffer = Encoding.Default.GetBytes(receivedData);
                        string hexData = BitConverter.ToString(byteBuffer).Replace("-", " ") + " ";
                        rtbReceive.AppendText(hexData);
                    }
                    rtbReceive.ScrollToCaret();
                    buffer.Append(receivedData);
                    ProcessBuffer();
                });
            }
            catch
            {
                // 在窗口关闭期间，忽略这里的异常
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string textToSend = txtSend.Text;
                if (string.IsNullOrEmpty(textToSend)) return;

                if (rbSendAscii.Checked)
                {
                    serialPort1.Write(textToSend);
                }
                else
                {
                    textToSend = textToSend.Replace(" ", "").Replace("\r", "").Replace("\n", "");
                    if (textToSend.Length % 2 != 0)
                    {
                        MessageBox.Show("HEX字符串长度必须为偶数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    byte[] hexBuffer = Enumerable.Range(0, textToSend.Length)
                                                 .Where(x => x % 2 == 0)
                                                 .Select(x => Convert.ToByte(textToSend.Substring(x, 2), 16))
                                                 .ToArray();
                    serialPort1.Write(hexBuffer, 0, hexBuffer.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearReceive_Click(object sender, EventArgs e)
        {
            rtbReceive.Clear();
        }

        // ================== 私有辅助方法 ==================

        private void ProcessBuffer()
        {
            while (buffer.ToString().Contains("\n"))
            {
                int newlineIndex = buffer.ToString().IndexOf("\n");
                string line = buffer.ToString().Substring(0, newlineIndex).Trim();
                buffer.Remove(0, newlineIndex + 1);

                if (!string.IsNullOrEmpty(line))
                {
                    ParseAndTriggerEvent(line);
                }
            }
        }

        private void ParseAndTriggerEvent(string line)
        {
            try
            {
                if (line.Contains("Current Temp:"))
                {
                    string tempStr = line.Split(':')[1].Trim().Split(' ')[0];
                    if (float.TryParse(tempStr, out float tempValue))
                    {
                        TemperatureUpdated?.Invoke(tempValue);
                    }
                }
                else if (line.Contains("Current Humidity:"))
                {
                    string humidityStr = line.Split(':')[1].Trim().Split(' ')[0];
                    if (float.TryParse(humidityStr, out float humidityValue))
                    {
                        HumidityUpdated?.Invoke(humidityValue);
                    }
                }
                else if (line.Contains("Last Light:"))
                {
                    string lightStatus = line.Split(':')[1].Trim();
                    LightStatusUpdated?.Invoke(lightStatus);
                }
            }
            catch
            {
                // 解析失败则忽略
            }
        }

        private void UpdateComPorts()
        {
            string previousSelectedPort = cbPort.SelectedItem?.ToString();
            bool wasConnected = serialPort1.IsOpen;
            string connectedPortName = wasConnected ? serialPort1.PortName : null;

            cbPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            cbPort.Items.AddRange(ports);

            if (wasConnected && !ports.Contains(connectedPortName))
            {
                serialPort1.Close();
                btnConnect.Text = "打开串口";
                cbPort.Enabled = true;
                cbBaudRate.Enabled = true;
                ConnectionStatusChanged?.Invoke(false, "N/A");
                MessageBox.Show($"{connectedPortName} 已断开连接。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (ports.Length > 0)
            {
                if (previousSelectedPort != null && ports.Contains(previousSelectedPort))
                {
                    cbPort.SelectedItem = previousSelectedPort;
                }
                else
                {
                    cbPort.SelectedIndex = 0;
                }
                btnConnect.Enabled = true;
            }
            else
            {
                cbPort.Text = "无可用串口";
                btnConnect.Enabled = false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE)
            {
                UpdateComPorts();
            }
        }
    }
}
