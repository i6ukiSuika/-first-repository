namespace WindowsFormsApp1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.btnClearReceive = new System.Windows.Forms.Button();
            this.rbReceiveHex = new System.Windows.Forms.RadioButton();
            this.rbReceiveAscii = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.gbReceiveSettings = new System.Windows.Forms.GroupBox();
            this.rtbReceive = new System.Windows.Forms.RichTextBox();
            this.gbSendSettings = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rbSendHex = new System.Windows.Forms.RadioButton();
            this.rbSendAscii = new System.Windows.Forms.RadioButton();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.gbPortSettings.SuspendLayout();
            this.gbReceiveSettings.SuspendLayout();
            this.gbSendSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Controls.Add(this.btnClearReceive);
            this.gbPortSettings.Controls.Add(this.rbReceiveHex);
            this.gbPortSettings.Controls.Add(this.rbReceiveAscii);
            this.gbPortSettings.Controls.Add(this.btnConnect);
            this.gbPortSettings.Controls.Add(this.cbBaudRate);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.cbPort);
            this.gbPortSettings.Controls.Add(this.lblPort);
            this.gbPortSettings.Location = new System.Drawing.Point(12, 12);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Size = new System.Drawing.Size(281, 546);
            this.gbPortSettings.TabIndex = 0;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "串口设置";
            // 
            // btnClearReceive
            // 
            this.btnClearReceive.Location = new System.Drawing.Point(54, 470);
            this.btnClearReceive.Name = "btnClearReceive";
            this.btnClearReceive.Size = new System.Drawing.Size(159, 44);
            this.btnClearReceive.TabIndex = 7;
            this.btnClearReceive.Text = "清空";
            this.btnClearReceive.UseVisualStyleBackColor = true;
            this.btnClearReceive.Click += new System.EventHandler(this.btnClearReceive_Click);
            // 
            // rbReceiveHex
            // 
            this.rbReceiveHex.AutoSize = true;
            this.rbReceiveHex.Location = new System.Drawing.Point(54, 413);
            this.rbReceiveHex.Name = "rbReceiveHex";
            this.rbReceiveHex.Size = new System.Drawing.Size(60, 22);
            this.rbReceiveHex.TabIndex = 6;
            this.rbReceiveHex.Text = "HEX";
            this.rbReceiveHex.UseVisualStyleBackColor = true;
            // 
            // rbReceiveAscii
            // 
            this.rbReceiveAscii.AutoSize = true;
            this.rbReceiveAscii.Checked = true;
            this.rbReceiveAscii.Location = new System.Drawing.Point(54, 358);
            this.rbReceiveAscii.Name = "rbReceiveAscii";
            this.rbReceiveAscii.Size = new System.Drawing.Size(78, 22);
            this.rbReceiveAscii.TabIndex = 5;
            this.rbReceiveAscii.TabStop = true;
            this.rbReceiveAscii.Text = "ASCII";
            this.rbReceiveAscii.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(54, 267);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(159, 44);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "打开串口";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "56000",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(124, 179);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(121, 26);
            this.cbBaudRate.TabIndex = 3;
            this.cbBaudRate.Text = "115200";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(27, 182);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(80, 18);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "波特率：";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(124, 114);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 26);
            this.cbPort.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(27, 117);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(80, 18);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "串口号：";
            // 
            // gbReceiveSettings
            // 
            this.gbReceiveSettings.Controls.Add(this.rtbReceive);
            this.gbReceiveSettings.Location = new System.Drawing.Point(299, 12);
            this.gbReceiveSettings.Name = "gbReceiveSettings";
            this.gbReceiveSettings.Size = new System.Drawing.Size(960, 546);
            this.gbReceiveSettings.TabIndex = 1;
            this.gbReceiveSettings.TabStop = false;
            this.gbReceiveSettings.Text = "接收区";
            // 
            // rtbReceive
            // 
            this.rtbReceive.Location = new System.Drawing.Point(6, 27);
            this.rtbReceive.Name = "rtbReceive";
            this.rtbReceive.ReadOnly = true;
            this.rtbReceive.Size = new System.Drawing.Size(961, 519);
            this.rtbReceive.TabIndex = 0;
            this.rtbReceive.Text = "";
            // 
            // gbSendSettings
            // 
            this.gbSendSettings.Controls.Add(this.btnSend);
            this.gbSendSettings.Controls.Add(this.rbSendHex);
            this.gbSendSettings.Controls.Add(this.rbSendAscii);
            this.gbSendSettings.Controls.Add(this.txtSend);
            this.gbSendSettings.Location = new System.Drawing.Point(12, 564);
            this.gbSendSettings.Name = "gbSendSettings";
            this.gbSendSettings.Size = new System.Drawing.Size(1253, 227);
            this.gbSendSettings.TabIndex = 2;
            this.gbSendSettings.TabStop = false;
            this.gbSendSettings.Text = "发送区";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1085, 168);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(162, 50);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rbSendHex
            // 
            this.rbSendHex.AutoSize = true;
            this.rbSendHex.Location = new System.Drawing.Point(1010, 58);
            this.rbSendHex.Name = "rbSendHex";
            this.rbSendHex.Size = new System.Drawing.Size(60, 22);
            this.rbSendHex.TabIndex = 2;
            this.rbSendHex.Text = "HEX";
            this.rbSendHex.UseVisualStyleBackColor = true;
            // 
            // rbSendAscii
            // 
            this.rbSendAscii.AutoSize = true;
            this.rbSendAscii.Checked = true;
            this.rbSendAscii.Location = new System.Drawing.Point(1010, 28);
            this.rbSendAscii.Name = "rbSendAscii";
            this.rbSendAscii.Size = new System.Drawing.Size(78, 22);
            this.rbSendAscii.TabIndex = 1;
            this.rbSendAscii.TabStop = true;
            this.rbSendAscii.Text = "ASCII";
            this.rbSendAscii.UseVisualStyleBackColor = true;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(7, 28);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(979, 190);
            this.txtSend.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 794);
            this.Controls.Add(this.gbSendSettings);
            this.Controls.Add(this.gbReceiveSettings);
            this.Controls.Add(this.gbPortSettings);
            this.Name = "Form2";
            this.Text = "SerialPort";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.gbReceiveSettings.ResumeLayout(false);
            this.gbSendSettings.ResumeLayout(false);
            this.gbSendSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPortSettings;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClearReceive;
        private System.Windows.Forms.RadioButton rbReceiveHex;
        private System.Windows.Forms.RadioButton rbReceiveAscii;
        private System.Windows.Forms.GroupBox gbReceiveSettings;
        private System.Windows.Forms.RichTextBox rtbReceive;
        private System.Windows.Forms.GroupBox gbSendSettings;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RadioButton rbSendHex;
        private System.Windows.Forms.RadioButton rbSendAscii;
        private System.Windows.Forms.TextBox txtSend;
        private System.IO.Ports.SerialPort serialPort1;
    }
}