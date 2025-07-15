namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip_File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_QueryHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_ConnectionStatus = new System.Windows.Forms.GroupBox();
            this.btn_ConfigureSerialPort = new System.Windows.Forms.Button();
            this.lbl_DataStats = new System.Windows.Forms.Label();
            this.lbl_SerialPortStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_RealTimeParams = new System.Windows.Forms.GroupBox();
            this.lbl_Param_Light = new System.Windows.Forms.Label();
            this.lbl_Param_Humidity = new System.Windows.Forms.Label();
            this.lbl_Param_Temperature = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.hslThermometer_Main = new HslControls.HslThermometer();
            this.hslGauge_Humidity = new HslControls.HslDialPlate();
            this.lbl_Gauge_Humidity = new System.Windows.Forms.Label();
            this.lbl_Gauge_Temperature = new System.Windows.Forms.Label();
            this.hslLantern_Light = new HslControls.HslLanternSimple();
            this.menuStrip1.SuspendLayout();
            this.groupBox_ConnectionStatus.SuspendLayout();
            this.groupBox_RealTimeParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_File,
            this.menuStrip_Data,
            this.menuStrip_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1404, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip_File
            // 
            this.menuStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Connect,
            this.menuItem_Disconnect});
            this.menuStrip_File.Name = "menuStrip_File";
            this.menuStrip_File.Size = new System.Drawing.Size(62, 28);
            this.menuStrip_File.Text = "连接";
            // 
            // menuItem_Connect
            // 
            this.menuItem_Connect.Name = "menuItem_Connect";
            this.menuItem_Connect.Size = new System.Drawing.Size(208, 34);
            this.menuItem_Connect.Text = "连接串口(C)";
            this.menuItem_Connect.Click += new System.EventHandler(this.menuItem_Connect_Click);
            // 
            // menuItem_Disconnect
            // 
            this.menuItem_Disconnect.Name = "menuItem_Disconnect";
            this.menuItem_Disconnect.Size = new System.Drawing.Size(208, 34);
            this.menuItem_Disconnect.Text = "断开连接(D)";
            this.menuItem_Disconnect.Click += new System.EventHandler(this.menuItem_Disconnect_Click);
            // 
            // menuStrip_Data
            // 
            this.menuStrip_Data.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_QueryHistory});
            this.menuStrip_Data.Name = "menuStrip_Data";
            this.menuStrip_Data.Size = new System.Drawing.Size(62, 28);
            this.menuStrip_Data.Text = "数据";
            // 
            // menuItem_QueryHistory
            // 
            this.menuItem_QueryHistory.Name = "menuItem_QueryHistory";
            this.menuItem_QueryHistory.Size = new System.Drawing.Size(270, 34);
            this.menuItem_QueryHistory.Text = "历史数据查询(H)";
            this.menuItem_QueryHistory.Click += new System.EventHandler(this.menuItem_QueryHistory_Click);
            // 
            // menuStrip_Help
            // 
            this.menuStrip_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.menuStrip_Help.Name = "menuStrip_Help";
            this.menuStrip_Help.Size = new System.Drawing.Size(62, 28);
            this.menuStrip_Help.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // groupBox_ConnectionStatus
            // 
            this.groupBox_ConnectionStatus.Controls.Add(this.btn_ConfigureSerialPort);
            this.groupBox_ConnectionStatus.Controls.Add(this.lbl_DataStats);
            this.groupBox_ConnectionStatus.Controls.Add(this.lbl_SerialPortStatus);
            this.groupBox_ConnectionStatus.Controls.Add(this.label2);
            this.groupBox_ConnectionStatus.Controls.Add(this.label1);
            this.groupBox_ConnectionStatus.Location = new System.Drawing.Point(35, 67);
            this.groupBox_ConnectionStatus.Name = "groupBox_ConnectionStatus";
            this.groupBox_ConnectionStatus.Size = new System.Drawing.Size(295, 384);
            this.groupBox_ConnectionStatus.TabIndex = 1;
            this.groupBox_ConnectionStatus.TabStop = false;
            this.groupBox_ConnectionStatus.Text = "连接状态";
            // 
            // btn_ConfigureSerialPort
            // 
            this.btn_ConfigureSerialPort.Location = new System.Drawing.Point(87, 260);
            this.btn_ConfigureSerialPort.Name = "btn_ConfigureSerialPort";
            this.btn_ConfigureSerialPort.Size = new System.Drawing.Size(124, 77);
            this.btn_ConfigureSerialPort.TabIndex = 4;
            this.btn_ConfigureSerialPort.Text = "配置串口";
            this.btn_ConfigureSerialPort.UseVisualStyleBackColor = true;
            this.btn_ConfigureSerialPort.Click += new System.EventHandler(this.btn_ConfigureSerialPort_Click);
            // 
            // lbl_DataStats
            // 
            this.lbl_DataStats.AutoSize = true;
            this.lbl_DataStats.Font = new System.Drawing.Font("宋体", 11F);
            this.lbl_DataStats.Location = new System.Drawing.Point(175, 170);
            this.lbl_DataStats.Name = "lbl_DataStats";
            this.lbl_DataStats.Size = new System.Drawing.Size(65, 22);
            this.lbl_DataStats.TabIndex = 3;
            this.lbl_DataStats.Text = "0R/0S";
            // 
            // lbl_SerialPortStatus
            // 
            this.lbl_SerialPortStatus.AutoSize = true;
            this.lbl_SerialPortStatus.Font = new System.Drawing.Font("宋体", 11F);
            this.lbl_SerialPortStatus.Location = new System.Drawing.Point(175, 75);
            this.lbl_SerialPortStatus.Name = "lbl_SerialPortStatus";
            this.lbl_SerialPortStatus.Size = new System.Drawing.Size(76, 22);
            this.lbl_SerialPortStatus.TabIndex = 2;
            this.lbl_SerialPortStatus.Text = "未连接";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(20, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "接收/发送:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(20, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口状态:";
            // 
            // groupBox_RealTimeParams
            // 
            this.groupBox_RealTimeParams.Controls.Add(this.lbl_Param_Light);
            this.groupBox_RealTimeParams.Controls.Add(this.lbl_Param_Humidity);
            this.groupBox_RealTimeParams.Controls.Add(this.lbl_Param_Temperature);
            this.groupBox_RealTimeParams.Controls.Add(this.label7);
            this.groupBox_RealTimeParams.Controls.Add(this.label6);
            this.groupBox_RealTimeParams.Controls.Add(this.label5);
            this.groupBox_RealTimeParams.Location = new System.Drawing.Point(1097, 103);
            this.groupBox_RealTimeParams.Name = "groupBox_RealTimeParams";
            this.groupBox_RealTimeParams.Size = new System.Drawing.Size(294, 227);
            this.groupBox_RealTimeParams.TabIndex = 2;
            this.groupBox_RealTimeParams.TabStop = false;
            this.groupBox_RealTimeParams.Text = "实时参数";
            // 
            // lbl_Param_Light
            // 
            this.lbl_Param_Light.AutoSize = true;
            this.lbl_Param_Light.Font = new System.Drawing.Font("宋体", 11F);
            this.lbl_Param_Light.Location = new System.Drawing.Point(181, 147);
            this.lbl_Param_Light.Name = "lbl_Param_Light";
            this.lbl_Param_Light.Size = new System.Drawing.Size(32, 22);
            this.lbl_Param_Light.TabIndex = 5;
            this.lbl_Param_Light.Text = "亮";
            // 
            // lbl_Param_Humidity
            // 
            this.lbl_Param_Humidity.AutoSize = true;
            this.lbl_Param_Humidity.Font = new System.Drawing.Font("宋体", 11F);
            this.lbl_Param_Humidity.Location = new System.Drawing.Point(178, 96);
            this.lbl_Param_Humidity.Name = "lbl_Param_Humidity";
            this.lbl_Param_Humidity.Size = new System.Drawing.Size(32, 22);
            this.lbl_Param_Humidity.TabIndex = 4;
            this.lbl_Param_Humidity.Text = "0%";
            // 
            // lbl_Param_Temperature
            // 
            this.lbl_Param_Temperature.AutoSize = true;
            this.lbl_Param_Temperature.Font = new System.Drawing.Font("宋体", 11F);
            this.lbl_Param_Temperature.Location = new System.Drawing.Point(178, 47);
            this.lbl_Param_Temperature.Name = "lbl_Param_Temperature";
            this.lbl_Param_Temperature.Size = new System.Drawing.Size(43, 22);
            this.lbl_Param_Temperature.TabIndex = 3;
            this.lbl_Param_Temperature.Text = "0℃";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(19, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "实时光照：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(19, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "实时湿度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(19, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "实时温度：";
            // 
            // hslThermometer_Main
            // 
            this.hslThermometer_Main.Location = new System.Drawing.Point(401, 44);
            this.hslThermometer_Main.Name = "hslThermometer_Main";
            this.hslThermometer_Main.Size = new System.Drawing.Size(232, 407);
            this.hslThermometer_Main.TabIndex = 3;
            this.hslThermometer_Main.TemperatureBackColor = System.Drawing.Color.LightGray;
            // 
            // hslGauge_Humidity
            // 
            this.hslGauge_Humidity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hslGauge_Humidity.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hslGauge_Humidity.Location = new System.Drawing.Point(726, 67);
            this.hslGauge_Humidity.Name = "hslGauge_Humidity";
            this.hslGauge_Humidity.Size = new System.Drawing.Size(321, 321);
            this.hslGauge_Humidity.TabIndex = 5;
            // 
            // lbl_Gauge_Humidity
            // 
            this.lbl_Gauge_Humidity.AutoSize = true;
            this.lbl_Gauge_Humidity.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Gauge_Humidity.Location = new System.Drawing.Point(839, 458);
            this.lbl_Gauge_Humidity.Name = "lbl_Gauge_Humidity";
            this.lbl_Gauge_Humidity.Size = new System.Drawing.Size(106, 24);
            this.lbl_Gauge_Humidity.TabIndex = 7;
            this.lbl_Gauge_Humidity.Text = "实时湿度";
            // 
            // lbl_Gauge_Temperature
            // 
            this.lbl_Gauge_Temperature.AutoSize = true;
            this.lbl_Gauge_Temperature.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Gauge_Temperature.Location = new System.Drawing.Point(460, 458);
            this.lbl_Gauge_Temperature.Name = "lbl_Gauge_Temperature";
            this.lbl_Gauge_Temperature.Size = new System.Drawing.Size(106, 24);
            this.lbl_Gauge_Temperature.TabIndex = 8;
            this.lbl_Gauge_Temperature.Text = "实时温度";
            // 
            // hslLantern_Light
            // 
            this.hslLantern_Light.LanternBackground = System.Drawing.Color.LightGreen;
            this.hslLantern_Light.Location = new System.Drawing.Point(626, 194);
            this.hslLantern_Light.Name = "hslLantern_Light";
            this.hslLantern_Light.Size = new System.Drawing.Size(82, 107);
            this.hslLantern_Light.TabIndex = 9;
            this.hslLantern_Light.Text = "光照";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 893);
            this.Controls.Add(this.hslLantern_Light);
            this.Controls.Add(this.lbl_Gauge_Temperature);
            this.Controls.Add(this.lbl_Gauge_Humidity);
            this.Controls.Add(this.hslGauge_Humidity);
            this.Controls.Add(this.hslThermometer_Main);
            this.Controls.Add(this.groupBox_RealTimeParams);
            this.Controls.Add(this.groupBox_ConnectionStatus);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "环境监控系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_ConnectionStatus.ResumeLayout(false);
            this.groupBox_ConnectionStatus.PerformLayout();
            this.groupBox_RealTimeParams.ResumeLayout(false);
            this.groupBox_RealTimeParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_File;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Connect;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Disconnect;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Data;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Help;
        private System.Windows.Forms.ToolStripMenuItem menuItem_QueryHistory;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_ConnectionStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ConfigureSerialPort;
        private System.Windows.Forms.Label lbl_DataStats;
        private System.Windows.Forms.Label lbl_SerialPortStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_RealTimeParams;
        private System.Windows.Forms.Label lbl_Param_Light;
        private System.Windows.Forms.Label lbl_Param_Humidity;
        private System.Windows.Forms.Label lbl_Param_Temperature;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private HslControls.HslThermometer hslThermometer_Main;
        private HslControls.HslDialPlate hslGauge_Humidity;
        private System.Windows.Forms.Label lbl_Gauge_Humidity;
        private System.Windows.Forms.Label lbl_Gauge_Temperature;
        private HslControls.HslLanternSimple hslLantern_Light;
    }
}

