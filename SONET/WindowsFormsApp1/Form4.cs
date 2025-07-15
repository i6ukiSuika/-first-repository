using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics; // 用于打开链接

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        // ================== UI 控件 ==================
        private Label lblTitle;
        private Label lblVersion;
        private Label lblCopyright;
        private GroupBox gbDetails;
        private Label lblGroup, lblMembers, lblProducer, lblSchool;
        private LinkLabel linkLabelProject;
        private Button btnOk;

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public Form4()
        {
            InitializeComponent(); 
            InitializeCustomComponents();
        }

        /// <summary>
        /// 手动创建和布局窗口内的所有控件
        /// </summary>
        private void InitializeCustomComponents()
        {
            // --- 窗口基础设置 ---
            this.Text = "关于“无线环境监控系统”";
            this.Size = new Size(450, 380);
            this.FormBorderStyle = FormBorderStyle.FixedDialog; 
            this.StartPosition = FormStartPosition.CenterParent; // 居中于父窗口显示
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // --- 控件创建与布局 ---

            lblTitle = new Label
            {
                Text = "无线环境监控系统",
                Font = new Font("微软雅黑", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            lblVersion = new Label
            {
                Text = "版本 V1.0",
                Font = new Font("微软雅黑", 10F),
                AutoSize = true,
                Location = new Point(25, 60)
            };

            gbDetails = new GroupBox
            {
                Text = "开发团队信息",
                Location = new Point(20, 100),
                Size = new Size(390, 150)
            };

            lblGroup = new Label { Text = "组    别：东软2班 第二组", Font = new Font("宋体", 10.5F), AutoSize = true, Location = new Point(20, 30) };
            lblMembers = new Label { Text = "小组成员：许远杭、冯博洋、郑力豪、李坤涛、孙羽", Font = new Font("宋体", 10.5F), AutoSize = true, Location = new Point(20, 60) };
            lblProducer = new Label { Text = "该版本编写者：许远杭", Font = new Font("宋体", 10.5F), AutoSize = true, Location = new Point(20, 90) };
            lblSchool = new Label { Text = "学    校：哈尔滨工程大学", Font = new Font("宋体", 10.5F), AutoSize = true, Location = new Point(20, 120) };


            gbDetails.Controls.Add(lblGroup);
            gbDetails.Controls.Add(lblMembers);
            gbDetails.Controls.Add(lblSchool);
            gbDetails.Controls.Add(lblProducer);

            linkLabelProject = new LinkLabel
            {
                Text = "访问项目仓库",
                AutoSize = true,
                Location = new Point(20, 265)
            };
            linkLabelProject.LinkClicked += (s, ev) => {
                try
                {
                
                    Process.Start("https://github.com/i6ukiSuika/-first-repository");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法打开链接: " + ex.Message);
                }
            };

            lblCopyright = new Label
            {
                Text = "Copyright © 2025 第二组. All Rights Reserved.",
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(20, 300)
            };

            btnOk = new Button
            {
                Text = "确定",
                DialogResult = DialogResult.OK, // 设置后，点击按钮会自动关闭窗口
                Size = new Size(80, 30),
                Location = new Point(330, 295)
            };

            // --- 将控件添加到窗口 ---
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblVersion);
            this.Controls.Add(gbDetails);
            this.Controls.Add(linkLabelProject);
            this.Controls.Add(lblCopyright);
            this.Controls.Add(btnOk);

            this.AcceptButton = btnOk; 
        }

        // Designer.cs 文件中通常会有一个空的 InitializeComponent 方法
       
    }
}
