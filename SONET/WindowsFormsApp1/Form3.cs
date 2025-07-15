using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        // ================== 数据库连接字符串 ==================
        private string connectionString = "Server=localhost;Database=SensorDataDB;User ID=sa;Password=xyh040529;";

        // ================== UI 控件 ==================
        private DataGridView dgvHistory;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnExport;
        private Label lblStatus;

        public Form3()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadData();
        }

        /// <summary>
        /// 手动创建和布局窗口内的控件
        /// </summary>
        private void InitializeCustomComponents()
        {
            this.Text = "历史数据查询";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 创建按钮
            btnRefresh = new Button { Text = "刷新数据", Location = new Point(20, 20), Size = new Size(100, 30) };
            btnDelete = new Button { Text = "删除选中行", Location = new Point(130, 20), Size = new Size(100, 30) };
            btnExport = new Button { Text = "导出为CSV", Location = new Point(240, 20), Size = new Size(100, 30) };

            // 状态标签
            lblStatus = new Label { Text = "准备就绪", Location = new Point(350, 28), AutoSize = true, ForeColor = Color.Blue };

            // 创建DataGridView
            dgvHistory = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 80),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // 添加控件到窗口
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnExport);
            this.Controls.Add(lblStatus);
            this.Controls.Add(dgvHistory);

            // 绑定事件
            btnRefresh.Click += BtnRefresh_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExport.Click += BtnExport_Click;
        }

        /// <summary>
        /// 从数据库加载数据到DataGridView
        /// </summary>
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ID, LogTime AS '记录时间', Temperature AS '温度 (℃)', Humidity AS '湿度 (%)', LightStatus AS '光照状态' FROM SensorLog ORDER BY LogTime DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHistory.DataSource = dt;
                    lblStatus.Text = $"加载成功！共 {dt.Rows.Count} 条记录。";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败: " + ex.Message, "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "加载数据失败！";
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的行。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确定要永久删除选中的记录吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        foreach (DataGridViewRow row in dgvHistory.SelectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["ID"].Value);
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM SensorLog WHERE ID = @ID", conn))
                            {
                                cmd.Parameters.AddWithValue("@ID", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    lblStatus.Text = "删除成功！";
                    LoadData(); // 重新加载数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除数据失败: " + ex.Message, "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "删除失败！";
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可以导出。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV 文件 (*.csv)|*.csv",
                FileName = $"历史数据_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // 添加表头
                    var headers = dgvHistory.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", headers.Select(column => $"\"{column.HeaderText}\"").ToArray()));

                    // 添加行数据
                    foreach (DataGridViewRow row in dgvHistory.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        sb.AppendLine(string.Join(",", cells.Select(cell => $"\"{cell.Value}\"").ToArray()));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("数据导出成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "数据已成功导出！";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "导出失败！";
                }
            }
        }
    }
}
