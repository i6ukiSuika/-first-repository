using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Linq;
using System.Data.SqlClient; // 用于SQL Server
using HslControls;
using HslControls.Charts;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        // ================== 串口和数据处理成员 ==================
        private SerialPort serialPort;
        private StringBuilder buffer = new StringBuilder();
        private long receivedBytes = 0;
        private long sentBytes = 0;

        // ================== 滑动面板UI成员 ==================
        private Panel pnlConfig;
        private Timer panelAnimator;
        private bool isPanelVisible = false;
        private const int PANEL_HEIGHT = 320;
        private const int ANIMATION_STEP = 25;
        private GroupBox gbSettings, gbReceive, gbSend;
        private Label lblPort, lblBaud;
        private ComboBox cbPort, cbBaudRate;
        private RadioButton rbReceiveAscii, rbReceiveHex, rbSendAscii, rbSendHex;
        private Button btnConnect, btnClear, btnSend, btnHidePanel;
        private RichTextBox rtbReceive;
        private TextBox txtSend;

        // ================== 数据库功能成员 ==================
        private Timer dbSaveTimer;
        private string connectionString = "Server=localhost;Database=SensorDataDB;User ID=sa;Password=xyh040529;";
        private float lastTemperature = -999;
        private float lastHumidity = -999;
        private string lastLightStatus = "N/A";



        public MainForm()
        {
            InitializeComponent();
            // 设置主窗口尺寸和双缓冲
            this.Width = 1000;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.KeyPreview = true; // 允许窗体预处理键盘事件
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;

            // 初始化并创建滑动面板及其所有控件
            InitializeSlidingPanel();

            // 初始化动画定时器
            panelAnimator = new Timer();
            panelAnimator.Interval = 15; // 动画帧率
            panelAnimator.Tick += PanelAnimator_Tick;

            dbSaveTimer = new Timer();
            dbSaveTimer.Interval = 30000; // 每30秒保存一次
            dbSaveTimer.Tick += DbSaveTimer_Tick;
            dbSaveTimer.Start();

        }

        #region 滑动面板初始化与动画
        /// <summary>
        /// 创建并初始化滑动面板和所有内部控件
        /// </summary>
        private void InitializeSlidingPanel()
        {
            pnlConfig = new Panel
            {
                Width = this.ClientSize.Width,
                Height = PANEL_HEIGHT,
                Location = new Point(0, this.ClientSize.Height), // 初始位置在窗口底部外侧
                BackColor = SystemColors.Control,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right // 锚定到底部和两侧
            };
            this.Controls.Add(pnlConfig);
            pnlConfig.BringToFront(); // 确保面板在最上层

            // --- 在面板上创建控件 ---

            // 关闭/隐藏面板的按钮
            btnHidePanel = new Button { Text = "v", Width = 40, Height = 25, Location = new Point(pnlConfig.Width / 2 - 20, 5), Anchor = AnchorStyles.Top };
            btnHidePanel.Click += (s, ev) => TogglePanel();
            pnlConfig.Controls.Add(btnHidePanel);

            // --- 分区1: 串口设置 ---
            gbSettings = new GroupBox { Text = "串口设置", Location = new Point(20, 40), Size = new Size(250, 260) };
            pnlConfig.Controls.Add(gbSettings);

            lblPort = new Label { Text = "串口号:", Location = new Point(15, 30), AutoSize = true };
            cbPort = new ComboBox { Width = 100, Location = new Point(75, 27), DropDownStyle = ComboBoxStyle.DropDownList };
            gbSettings.Controls.Add(lblPort);
            gbSettings.Controls.Add(cbPort);

            lblBaud = new Label { Text = "波特率:", Location = new Point(15, 60), AutoSize = true };
            cbBaudRate = new ComboBox { Width = 150, Location = new Point(75, 57) };
            cbBaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            cbBaudRate.SelectedItem = "115200";
            gbSettings.Controls.Add(lblBaud);
            gbSettings.Controls.Add(cbBaudRate);

            btnConnect = new Button { Text = "打开串口", Width = 210, Height = 30, Location = new Point(15, 100) };
            btnConnect.Click += BtnConnect_Click;
            gbSettings.Controls.Add(btnConnect);

            // --- 分区2: 接收区 ---
            gbReceive = new GroupBox { Text = "接收区", Location = new Point(280, 40), Size = new Size(450, 260), Anchor = AnchorStyles.Top | AnchorStyles.Left };
            pnlConfig.Controls.Add(gbReceive);

            rtbReceive = new RichTextBox { Location = new Point(15, 25), Size = new Size(420, 180), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            gbReceive.Controls.Add(rtbReceive);

            rbReceiveAscii = new RadioButton { Text = "ASCII", Location = new Point(15, 220), Checked = true, AutoSize = true };
            rbReceiveHex = new RadioButton { Text = "HEX", Location = new Point(100, 220), AutoSize = true };
            gbReceive.Controls.Add(rbReceiveAscii);
            gbReceive.Controls.Add(rbReceiveHex);

            btnClear = new Button { Text = "清空接收", Width = 100, Location = new Point(335, 215) };
            btnClear.Click += (s, ev) => rtbReceive.Clear();
            gbReceive.Controls.Add(btnClear);

            // --- 分区3: 发送区 ---
            gbSend = new GroupBox { Text = "发送区", Location = new Point(740, 40), Size = new Size(250, 260), Anchor = AnchorStyles.Top | AnchorStyles.Left };
            pnlConfig.Controls.Add(gbSend);

            txtSend = new TextBox { Location = new Point(15, 25), Size = new Size(220, 180), Multiline = true, ScrollBars = ScrollBars.Vertical };
            gbSend.Controls.Add(txtSend);

            rbSendAscii = new RadioButton { Text = "ASCII", Location = new Point(15, 220), Checked = true, AutoSize = true };
            rbSendHex = new RadioButton { Text = "HEX", Location = new Point(80, 220), AutoSize = true };
            gbSend.Controls.Add(rbSendAscii);
            gbSend.Controls.Add(rbSendHex);

            btnSend = new Button { Text = "发送数据", Width = 100, Location = new Point(135, 215) };
            btnSend.Click += BtnSend_Click;
            gbSend.Controls.Add(btnSend);

            // 扫描串口
            UpdateComPorts();
        }

        private void PanelAnimator_Tick(object sender, EventArgs e)
        {
            int targetY;
            if (isPanelVisible)
            {
                targetY = this.ClientSize.Height - PANEL_HEIGHT;
                if (pnlConfig.Top > targetY) pnlConfig.Top = Math.Max(targetY, pnlConfig.Top - ANIMATION_STEP);
                else panelAnimator.Stop();
            }
            else
            {
                targetY = this.ClientSize.Height;
                if (pnlConfig.Top < targetY) pnlConfig.Top = Math.Min(targetY, pnlConfig.Top + ANIMATION_STEP);
                else panelAnimator.Stop();
            }
        }

        private void TogglePanel()
        {
            isPanelVisible = !isPanelVisible;
            btnHidePanel.Text = isPanelVisible ? "v" : "^";
            panelAnimator.Start();
        }
        #endregion

        #region 串口逻辑
        private void UpdateComPorts()
        {
            string previousSelectedPort = cbPort.SelectedItem?.ToString();
            cbPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            cbPort.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                if (previousSelectedPort != null && ports.Contains(previousSelectedPort)) cbPort.SelectedItem = previousSelectedPort;
                else cbPort.SelectedIndex = 0;
                btnConnect.Enabled = true;
            }
            else
            {
                cbPort.Text = "无可用串口";
                btnConnect.Enabled = false;
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen) serialPort.Close();
                else { serialPort.PortName = cbPort.Text; serialPort.BaudRate = Convert.ToInt32(cbBaudRate.Text); serialPort.Open(); }
                UpdateConnectionStatus();
            }
            catch (Exception ex) { MessageBox.Show($"操作失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); UpdateConnectionStatus(); }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(50);
                string receivedData = serialPort.ReadExisting();
                receivedBytes += receivedData.Length;
                if (this.IsDisposed || !this.IsHandleCreated) return;
                this.Invoke((MethodInvoker)delegate { UpdateDataStats(); if (rbReceiveAscii.Checked) rtbReceive.AppendText(receivedData); else { byte[] byteBuffer = Encoding.Default.GetBytes(receivedData); string hexData = BitConverter.ToString(byteBuffer).Replace("-", " ") + " "; rtbReceive.AppendText(hexData); } rtbReceive.ScrollToCaret(); buffer.Append(receivedData); ProcessBuffer(); });
            }
            catch { }
        }

        private void ProcessBuffer()
        {
            while (buffer.ToString().Contains("\n"))
            {
                int newlineIndex = buffer.ToString().IndexOf("\n");
                string line = buffer.ToString().Substring(0, newlineIndex).Trim();
                buffer.Remove(0, newlineIndex + 1);
                if (!string.IsNullOrEmpty(line)) ParseAndDisplayData(line);
            }
        }

        private void ParseAndDisplayData(string line)
        {
            try
            {
                if (line.Contains("Current Temp:"))
                {
                    string tempStr = line.Split(':')[1].Trim().Split(' ')[0];
                    if (float.TryParse(tempStr, out float tempValue))
                    {
                        lbl_Param_Temperature.Text = $"{tempValue:F1}℃";
                        hslThermometer_Main.Value = tempValue;
                        lastTemperature = tempValue;
                    }
                }
                else if (line.Contains("Current Humidity:"))
                {
                    string humidityStr = line.Split(':')[1].Trim().Split(' ')[0];
                    if (float.TryParse(humidityStr, out float humidityValue))
                    {
                        lbl_Param_Humidity.Text = $"{humidityValue:F0}%";
                        hslGauge_Humidity.Value = humidityValue;
                        lastHumidity = humidityValue;
                    }
                }
                else if (line.Contains("Last Light:"))
                {
                    string lightStatus = line.Split(':')[1].Trim();
                    lastLightStatus = lightStatus;
                    if (lightStatus == "LIGHT") { lbl_Param_Light.Text = "亮"; hslLantern_Light.LanternBackground = Color.LimeGreen; }
                    else if (lightStatus == "DARK") { lbl_Param_Light.Text = "暗"; hslLantern_Light.LanternBackground = Color.DarkGray; }
                    else { lbl_Param_Light.Text = "N/A"; hslLantern_Light.LanternBackground = Color.LightGray; }
                }
            }
            catch { }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("请先打开串口！"); return; }
            try
            {
                string textToSend = txtSend.Text;
                if (string.IsNullOrEmpty(textToSend)) return;
                byte[] data;
                if (rbSendAscii.Checked) data = Encoding.Default.GetBytes(textToSend);
                else { textToSend = textToSend.Replace(" ", "").Replace("\r", "").Replace("\n", ""); if (textToSend.Length % 2 != 0) { MessageBox.Show("HEX字符串长度必须为偶数！"); return; } data = Enumerable.Range(0, textToSend.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(textToSend.Substring(x, 2), 16)).ToArray(); }
                serialPort.Write(data, 0, data.Length);
                sentBytes += data.Length;
                UpdateDataStats();
            }
            catch (Exception ex) { MessageBox.Show($"发送失败: {ex.Message}"); }
        }
        #endregion

        #region 数据库逻辑
        private void DbSaveTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen && lastTemperature > -990 && lastHumidity > -990)
            {
                SaveDataToDatabase(lastTemperature, lastHumidity, lastLightStatus);
            }
        }

        private void SaveDataToDatabase(float temp, float humidity, string light)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO SensorLog (Temperature, Humidity, LightStatus) VALUES (@Temperature, @Humidity, @LightStatus)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Temperature", temp);
                        cmd.Parameters.AddWithValue("@Humidity", humidity);
                        cmd.Parameters.AddWithValue("@LightStatus", light);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("自动保存数据失败: " + ex.Message);
            }
        }
        #endregion

        #region 主窗口UI事件和更新
        private void btn_ConfigureSerialPort_Click(object sender, EventArgs e) { TogglePanel(); }
        private void UpdateConnectionStatus()
        {
            if (serialPort.IsOpen)
            {
                lbl_SerialPortStatus.Text = "已连接";
                lbl_SerialPortStatus.ForeColor = Color.Green;
                btnConnect.Text = "关闭串口";
                cbPort.Enabled = false;
                cbBaudRate.Enabled = false;
            }
            else
            {
                lbl_SerialPortStatus.Text = "未连接";
                lbl_SerialPortStatus.ForeColor = SystemColors.ControlText;
                btnConnect.Text = "打开串口";
                cbPort.Enabled = true;
                cbBaudRate.Enabled = true;
                lbl_Param_Temperature.Text = "0℃";
                lbl_Param_Humidity.Text = "0%";
                lbl_Param_Light.Text = "N/A";
                hslThermometer_Main.Value = 0;
                hslGauge_Humidity.Value = 0;
                hslLantern_Light.LanternBackground = Color.LightGray;
            }
            receivedBytes = 0;
            sentBytes = 0;
            UpdateDataStats();
        }
        private void UpdateDataStats() { lbl_DataStats.Text = $"{receivedBytes}R / {sentBytes}S"; }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) { if (serialPort != null && serialPort.IsOpen) serialPort.Close(); }
        private void menuItem_Disconnect_Click(object sender, EventArgs e) { if (serialPort.IsOpen) serialPort.Close(); UpdateConnectionStatus(); }
        private void menuItem_Connect_Click(object sender, EventArgs e) { TogglePanel(); }


        /// <summary>
        /// 【修改】“历史数据查询”菜单项点击事件
        /// </summary>
        private void menuItem_QueryHistory_Click(object sender, EventArgs e)
        {
            Form3 historyForm = new Form3();
            historyForm.Show(); // 以非模态方式打开，不阻塞主窗口
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            // 创建并以对话框模式显示Form4
            // 使用 using 语句可以确保Form4在关闭后被正确释放资源
            using (Form4 aboutForm = new Form4())
            {
                aboutForm.ShowDialog(this); // ShowDialog会阻塞主窗口，直到“关于”窗口关闭
            }
        }
        #endregion
    }
}
