本上位机软件旨在接收、处理、展示并存储来自无线协调器节点的环境数据。它提供了一个功能丰富且用户友好的图形界面，将底层的硬件数据转化为直观的可视化信息，并实现了数据的持久化存储与管理。

系统核心数据流:
协调器节点通过串口 (USB-to-Serial) 将整合后的环境数据（温度、湿度、光照状态）发送给本上位机软件。软件接收后，会执行以下操作：

实时解析：将ASCII数据流解析为结构化的数据。

界面更新：在主界面上通过仪表盘、温度计等控件实时刷新显示。

自动存储：定时将数据存入 SQL Server 数据库，以供后续分析。

历史追溯：提供专门的窗口查询、管理和导出所有历史数据。

✨ 主要功能
实时数据显示:

使用 HSLControls 控件库，通过动态的温度计和仪表盘直观展示实时温度和湿度。

通过状态指示灯清晰显示当前环境的光照状态（亮/暗/未知）。

滑动式交互面板:

终极解决方案: 摒弃传统的多窗口模式，将串口配置、数据收发监控等所有调试功能集成到一个可从主窗口底部平滑滑出/滑入的面板中，极大提升了用户体验和操作的流畅性。

全功能串口调试:

自动扫描并列出可用串口。

支持自定义波特率等常用参数。

支持ASCII和HEX两种模式的数据收发与显示。

数据库集成:

自动记录: 每隔30秒自动将最新的环境数据存入 SQL Server 数据库。

历史数据管理: 提供独立的“历史数据查询”窗口，支持对数据库中的记录进行刷新、删除和导出为CSV文件。

现代化用户体验:

支持 F11一键全屏显示，提供沉浸式监控体验。

提供专业的“关于”窗口，展示团队和项目信息。

整体界面布局清晰、美观。

🛠️ 技术栈
开发语言: C#

框架: .NET Framework (适用于 Windows Forms)

UI控件库: HslControls (用于美观的仪表盘和温度计)

数据库: Microsoft SQL Server

开发环境: Visual Studio

⚙️ 安装与配置指南
数据库配置:

确保您已安装 SQL Server (推荐 Express 版本)。

打开 SQL Server Management Studio (SSMS)，启用“SQL Server 和 Windows 身份验证模式”。

启用 sa 账户，并将其密码设置为 xyh040529。

通过 SQL Server Configuration Manager 启用 TCP/IP 协议并重启SQL Server服务。

在 SSMS 中，创建一个新的数据库，命名为 SensorDataDB。

执行以下 SQL脚本 来创建 SensorLog 表。

项目运行:

使用 Visual Studio 打开本项目的解决方案文件 (.sln)。

在 MainForm.cs 文件中，确认数据库连接字符串 connectionString 中的服务器地址 (Server=...) 是否与您的SQL Server实例匹配（本机通常为 localhost 或 .）。

直接点击“启动”按钮（或按 F5）编译并运行程序。

数据库表结构
CREATE TABLE [dbo].[SensorLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [datetime] NOT NULL,
	[Temperature] [decimal](5, 2) NOT NULL,
	[Humidity] [decimal](5, 2) NOT NULL,
	[LightStatus] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_SensorLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO
ALTER TABLE [dbo].[SensorLog] ADD CONSTRAINT [DF_SensorLog_LogTime] DEFAULT (getdate()) FOR [LogTime];
GO

📖 使用说明
连接硬件: 将协调器节点的USB转串口模块连接到电脑。

配置连接:

点击主界面的“配置串口”按钮，底部面板滑出。

在“串口设置”区，从下拉列表中选择正确的COM口。

确认波特率与硬件固件设置一致（默认为115200）。

点击“打开串口”按钮。连接成功后，主界面的“连接状态”会变为绿色“已连接”。

查看数据:

主界面的仪表盘和指示灯将开始实时显示数据。

滑动面板的“接收区”会显示从串口收到的原始数据。

历史数据:

点击菜单栏“数据” -> “历史数据查询”。

在弹出的新窗口中，可以查看、删除或导出所有被自动记录的数据。# -
这是一个基于 C# WinForms 开发的上位机应用程序，作为“无线环境监控系统”的核心人机交互与数据管理中心
