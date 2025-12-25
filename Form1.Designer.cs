namespace XInput_PTZ_Controller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            IpA = new TextBox();
            IpB = new TextBox();
            IpX = new TextBox();
            IpY = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            Username = new TextBox();
            Password = new TextBox();
            IpLabel = new Label();
            StartButton = new Button();
            StopButton = new Button();
            OnlineLabel = new Label();
            CameraPanel = new Panel();
            CameraLabel1 = new Label();
            CameraLabel2 = new Label();
            OnlineY = new Panel();
            OnlineX = new Panel();
            OnlineB = new Panel();
            OnlineA = new Panel();
            IpPanel = new Panel();
            ModelLabel = new Label();
            NameLabel = new Label();
            ModelY = new TextBox();
            ModelX = new TextBox();
            ModelB = new TextBox();
            ModelA = new TextBox();
            NameY = new TextBox();
            NameX = new TextBox();
            NameB = new TextBox();
            NameA = new TextBox();
            ChannelY = new TextBox();
            ChannelX = new TextBox();
            ChannelB = new TextBox();
            ChannelA = new TextBox();
            ChannelLabel2 = new Label();
            ChannelLabel1 = new Label();
            CameraYLabel = new Label();
            CameraXLabel = new Label();
            CameraBLabel = new Label();
            CameraALabel = new Label();
            SavePassword = new CheckBox();
            AudioOn = new CheckBox();
            SubStream = new RadioButton();
            MainStream = new RadioButton();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            ToolStripOpen = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripStart = new ToolStripMenuItem();
            ToolStripStop = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripClose = new ToolStripMenuItem();
            VideoView = new LibVLCSharp.WinForms.VideoView();
            PresetsPanel = new Panel();
            PresetsDropdownPanel = new Panel();
            MenuBox = new ComboBox();
            RbLabel = new Label();
            LbBox = new ComboBox();
            RbBox = new ComboBox();
            LbLabel = new Label();
            RtBox = new ComboBox();
            LtLabel = new Label();
            MenuLabel = new Label();
            RtLabel = new Label();
            LtBox = new ComboBox();
            ViewBox = new ComboBox();
            ViewLabel = new Label();
            PresetsLabel = new Label();
            HardwareDecode = new CheckBox();
            FitScreen = new CheckBox();
            NoStream = new RadioButton();
            StartPanel = new Panel();
            SettingsButton = new Button();
            LoginLabel = new Label();
            UserPanel = new Panel();
            StartMinimized = new CheckBox();
            ControllerPanel = new Panel();
            ControllerLabel = new Label();
            ControllerNumLabel = new Label();
            ControllerNum = new NumericUpDown();
            PollingController = new ProgressBar();
            RtspPanel = new Panel();
            ActiveCam = new Label();
            RtspControlsPanel = new Panel();
            VideoPanel = new Panel();
            PollingTimer = new System.Windows.Forms.Timer(components);
            CameraPanel.SuspendLayout();
            IpPanel.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VideoView).BeginInit();
            PresetsPanel.SuspendLayout();
            PresetsDropdownPanel.SuspendLayout();
            StartPanel.SuspendLayout();
            UserPanel.SuspendLayout();
            ControllerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ControllerNum).BeginInit();
            RtspPanel.SuspendLayout();
            RtspControlsPanel.SuspendLayout();
            VideoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // IpA
            // 
            IpA.BackColor = SystemColors.Control;
            IpA.Font = new Font("Segoe UI", 8.25F);
            IpA.ForeColor = SystemColors.WindowText;
            IpA.Location = new Point(8, 6);
            IpA.Margin = new Padding(2);
            IpA.MaxLength = 21;
            IpA.Name = "IpA";
            IpA.Size = new Size(139, 22);
            IpA.TabIndex = 1;
            IpA.TextAlign = HorizontalAlignment.Center;
            IpA.TextChanged += CameraDataTextChanged;
            IpA.Leave += TextBox_Leave;
            // 
            // IpB
            // 
            IpB.BackColor = SystemColors.Control;
            IpB.Font = new Font("Segoe UI", 8.25F);
            IpB.Location = new Point(8, 31);
            IpB.Margin = new Padding(2);
            IpB.MaxLength = 21;
            IpB.Name = "IpB";
            IpB.Size = new Size(139, 22);
            IpB.TabIndex = 2;
            IpB.TextAlign = HorizontalAlignment.Center;
            IpB.TextChanged += CameraDataTextChanged;
            IpB.Leave += TextBox_Leave;
            // 
            // IpX
            // 
            IpX.BackColor = SystemColors.Control;
            IpX.Font = new Font("Segoe UI", 8.25F);
            IpX.Location = new Point(8, 56);
            IpX.Margin = new Padding(2);
            IpX.MaxLength = 21;
            IpX.Name = "IpX";
            IpX.Size = new Size(139, 22);
            IpX.TabIndex = 3;
            IpX.TextAlign = HorizontalAlignment.Center;
            IpX.TextChanged += CameraDataTextChanged;
            IpX.Leave += TextBox_Leave;
            // 
            // IpY
            // 
            IpY.BackColor = SystemColors.Control;
            IpY.Font = new Font("Segoe UI", 8.25F);
            IpY.Location = new Point(8, 81);
            IpY.Margin = new Padding(2);
            IpY.MaxLength = 21;
            IpY.Name = "IpY";
            IpY.Size = new Size(139, 22);
            IpY.TabIndex = 4;
            IpY.TextAlign = HorizontalAlignment.Center;
            IpY.TextChanged += CameraDataTextChanged;
            IpY.Leave += TextBox_Leave;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = SystemColors.ActiveCaptionText;
            UsernameLabel.Location = new Point(41, 6);
            UsernameLabel.Margin = new Padding(2, 0, 2, 0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(58, 13);
            UsernameLabel.TabIndex = 10;
            UsernameLabel.Text = "Username";
            UsernameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.ForeColor = SystemColors.ActiveCaptionText;
            PasswordLabel.Location = new Point(41, 26);
            PasswordLabel.Margin = new Padding(2, 0, 2, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(56, 13);
            PasswordLabel.TabIndex = 11;
            PasswordLabel.Text = "Password";
            PasswordLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Username
            // 
            Username.BackColor = SystemColors.Control;
            Username.Location = new Point(103, 4);
            Username.Margin = new Padding(2);
            Username.Name = "Username";
            Username.Size = new Size(110, 23);
            Username.TabIndex = 5;
            Username.TextAlign = HorizontalAlignment.Center;
            Username.TextChanged += CameraDataTextChanged;
            Username.Leave += TextBox_Leave;
            // 
            // Password
            // 
            Password.BackColor = SystemColors.Control;
            Password.Location = new Point(103, 25);
            Password.Margin = new Padding(2);
            Password.Name = "Password";
            Password.Size = new Size(110, 23);
            Password.TabIndex = 6;
            Password.TextAlign = HorizontalAlignment.Center;
            Password.UseSystemPasswordChar = true;
            Password.TextChanged += CameraDataTextChanged;
            Password.Leave += TextBox_Leave;
            // 
            // IpLabel
            // 
            IpLabel.AutoSize = true;
            IpLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            IpLabel.ForeColor = SystemColors.ActiveCaptionText;
            IpLabel.Location = new Point(116, 18);
            IpLabel.Margin = new Padding(2, 0, 2, 0);
            IpLabel.Name = "IpLabel";
            IpLabel.Size = new Size(62, 13);
            IpLabel.TabIndex = 14;
            IpLabel.Text = "IP Address";
            // 
            // StartButton
            // 
            StartButton.BackColor = SystemColors.Control;
            StartButton.Enabled = false;
            StartButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            StartButton.Location = new Point(49, 111);
            StartButton.Margin = new Padding(2);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(78, 25);
            StartButton.TabIndex = 9;
            StartButton.TabStop = false;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.EnabledChanged += StartButton_EnabledChanged;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.BackColor = SystemColors.Control;
            StopButton.Enabled = false;
            StopButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            StopButton.Location = new Point(129, 111);
            StopButton.Margin = new Padding(2);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(78, 25);
            StopButton.TabIndex = 10;
            StopButton.TabStop = false;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = false;
            StopButton.EnabledChanged += StopButton_EnabledChanged;
            StopButton.Click += StopButton_Click;
            // 
            // OnlineLabel
            // 
            OnlineLabel.AutoSize = true;
            OnlineLabel.BackColor = SystemColors.Control;
            OnlineLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            OnlineLabel.Location = new Point(539, 18);
            OnlineLabel.Margin = new Padding(2, 0, 2, 0);
            OnlineLabel.Name = "OnlineLabel";
            OnlineLabel.Size = new Size(41, 13);
            OnlineLabel.TabIndex = 25;
            OnlineLabel.Text = "Online";
            // 
            // CameraPanel
            // 
            CameraPanel.BackColor = SystemColors.Control;
            CameraPanel.BorderStyle = BorderStyle.Fixed3D;
            CameraPanel.Controls.Add(CameraLabel1);
            CameraPanel.Controls.Add(CameraLabel2);
            CameraPanel.Controls.Add(OnlineY);
            CameraPanel.Controls.Add(OnlineX);
            CameraPanel.Controls.Add(OnlineB);
            CameraPanel.Controls.Add(OnlineA);
            CameraPanel.Controls.Add(IpLabel);
            CameraPanel.Controls.Add(IpPanel);
            CameraPanel.Controls.Add(ModelLabel);
            CameraPanel.Controls.Add(NameLabel);
            CameraPanel.Controls.Add(ModelY);
            CameraPanel.Controls.Add(ModelX);
            CameraPanel.Controls.Add(ModelB);
            CameraPanel.Controls.Add(ModelA);
            CameraPanel.Controls.Add(NameY);
            CameraPanel.Controls.Add(NameX);
            CameraPanel.Controls.Add(NameB);
            CameraPanel.Controls.Add(NameA);
            CameraPanel.Controls.Add(ChannelY);
            CameraPanel.Controls.Add(ChannelX);
            CameraPanel.Controls.Add(ChannelB);
            CameraPanel.Controls.Add(ChannelA);
            CameraPanel.Controls.Add(ChannelLabel2);
            CameraPanel.Controls.Add(ChannelLabel1);
            CameraPanel.Controls.Add(CameraYLabel);
            CameraPanel.Controls.Add(CameraXLabel);
            CameraPanel.Controls.Add(CameraBLabel);
            CameraPanel.Controls.Add(CameraALabel);
            CameraPanel.Controls.Add(OnlineLabel);
            CameraPanel.Location = new Point(7, 353);
            CameraPanel.Margin = new Padding(2);
            CameraPanel.Name = "CameraPanel";
            CameraPanel.Size = new Size(589, 144);
            CameraPanel.TabIndex = 26;
            // 
            // CameraLabel1
            // 
            CameraLabel1.AutoSize = true;
            CameraLabel1.BackColor = SystemColors.Control;
            CameraLabel1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            CameraLabel1.Location = new Point(26, 6);
            CameraLabel1.Margin = new Padding(2, 0, 2, 0);
            CameraLabel1.Name = "CameraLabel1";
            CameraLabel1.Size = new Size(27, 13);
            CameraLabel1.TabIndex = 52;
            CameraLabel1.Text = "PTZ";
            // 
            // CameraLabel2
            // 
            CameraLabel2.AutoSize = true;
            CameraLabel2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            CameraLabel2.Location = new Point(16, 18);
            CameraLabel2.Name = "CameraLabel2";
            CameraLabel2.Size = new Size(46, 13);
            CameraLabel2.TabIndex = 51;
            CameraLabel2.Text = "Camera";
            // 
            // OnlineY
            // 
            OnlineY.BorderStyle = BorderStyle.Fixed3D;
            OnlineY.Location = new Point(553, 115);
            OnlineY.Name = "OnlineY";
            OnlineY.Size = new Size(15, 15);
            OnlineY.TabIndex = 50;
            // 
            // OnlineX
            // 
            OnlineX.BorderStyle = BorderStyle.Fixed3D;
            OnlineX.Location = new Point(553, 91);
            OnlineX.Name = "OnlineX";
            OnlineX.Size = new Size(15, 15);
            OnlineX.TabIndex = 49;
            // 
            // OnlineB
            // 
            OnlineB.BorderStyle = BorderStyle.Fixed3D;
            OnlineB.Location = new Point(553, 65);
            OnlineB.Name = "OnlineB";
            OnlineB.Size = new Size(15, 15);
            OnlineB.TabIndex = 48;
            // 
            // OnlineA
            // 
            OnlineA.BackColor = SystemColors.Control;
            OnlineA.BorderStyle = BorderStyle.Fixed3D;
            OnlineA.Location = new Point(553, 41);
            OnlineA.Name = "OnlineA";
            OnlineA.Size = new Size(15, 15);
            OnlineA.TabIndex = 47;
            // 
            // IpPanel
            // 
            IpPanel.BackColor = SystemColors.Control;
            IpPanel.Controls.Add(IpB);
            IpPanel.Controls.Add(IpY);
            IpPanel.Controls.Add(IpX);
            IpPanel.Controls.Add(IpA);
            IpPanel.Location = new Point(69, 33);
            IpPanel.Name = "IpPanel";
            IpPanel.Size = new Size(149, 103);
            IpPanel.TabIndex = 32;
            // 
            // ModelLabel
            // 
            ModelLabel.AutoSize = true;
            ModelLabel.BackColor = SystemColors.Control;
            ModelLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            ModelLabel.Location = new Point(369, 18);
            ModelLabel.Name = "ModelLabel";
            ModelLabel.Size = new Size(87, 13);
            ModelLabel.TabIndex = 46;
            ModelLabel.Text = "Model Number";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.BackColor = SystemColors.Control;
            NameLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            NameLabel.Location = new Point(242, 18);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(80, 13);
            NameLabel.TabIndex = 45;
            NameLabel.Text = "Camera Name";
            // 
            // ModelY
            // 
            ModelY.BackColor = SystemColors.Control;
            ModelY.Enabled = false;
            ModelY.Font = new Font("Segoe UI", 8.25F);
            ModelY.Location = new Point(343, 113);
            ModelY.Name = "ModelY";
            ModelY.Size = new Size(143, 22);
            ModelY.TabIndex = 44;
            ModelY.TextAlign = HorizontalAlignment.Center;
            // 
            // ModelX
            // 
            ModelX.BackColor = SystemColors.Control;
            ModelX.Enabled = false;
            ModelX.Font = new Font("Segoe UI", 8.25F);
            ModelX.Location = new Point(343, 88);
            ModelX.Name = "ModelX";
            ModelX.Size = new Size(143, 22);
            ModelX.TabIndex = 43;
            ModelX.TextAlign = HorizontalAlignment.Center;
            // 
            // ModelB
            // 
            ModelB.BackColor = SystemColors.Control;
            ModelB.Enabled = false;
            ModelB.Font = new Font("Segoe UI", 8.25F);
            ModelB.Location = new Point(343, 63);
            ModelB.Name = "ModelB";
            ModelB.Size = new Size(143, 22);
            ModelB.TabIndex = 42;
            ModelB.TextAlign = HorizontalAlignment.Center;
            // 
            // ModelA
            // 
            ModelA.BackColor = SystemColors.Control;
            ModelA.Enabled = false;
            ModelA.Font = new Font("Segoe UI", 8.25F);
            ModelA.Location = new Point(343, 39);
            ModelA.Name = "ModelA";
            ModelA.Size = new Size(143, 22);
            ModelA.TabIndex = 41;
            ModelA.TextAlign = HorizontalAlignment.Center;
            // 
            // NameY
            // 
            NameY.BackColor = SystemColors.Control;
            NameY.Enabled = false;
            NameY.Font = new Font("Segoe UI", 8.25F);
            NameY.Location = new Point(232, 113);
            NameY.Name = "NameY";
            NameY.Size = new Size(97, 22);
            NameY.TabIndex = 40;
            NameY.TextAlign = HorizontalAlignment.Center;
            // 
            // NameX
            // 
            NameX.BackColor = SystemColors.Control;
            NameX.Enabled = false;
            NameX.Font = new Font("Segoe UI", 8.25F);
            NameX.Location = new Point(232, 88);
            NameX.Name = "NameX";
            NameX.Size = new Size(97, 22);
            NameX.TabIndex = 39;
            NameX.TextAlign = HorizontalAlignment.Center;
            // 
            // NameB
            // 
            NameB.BackColor = SystemColors.Control;
            NameB.Enabled = false;
            NameB.Font = new Font("Segoe UI", 8.25F);
            NameB.Location = new Point(232, 63);
            NameB.Name = "NameB";
            NameB.Size = new Size(97, 22);
            NameB.TabIndex = 38;
            NameB.TextAlign = HorizontalAlignment.Center;
            // 
            // NameA
            // 
            NameA.BackColor = SystemColors.Control;
            NameA.Enabled = false;
            NameA.Font = new Font("Segoe UI", 8.25F);
            NameA.Location = new Point(232, 39);
            NameA.Name = "NameA";
            NameA.Size = new Size(97, 22);
            NameA.TabIndex = 37;
            NameA.TextAlign = HorizontalAlignment.Center;
            // 
            // ChannelY
            // 
            ChannelY.BackColor = SystemColors.Control;
            ChannelY.Enabled = false;
            ChannelY.Font = new Font("Segoe UI", 8.25F);
            ChannelY.Location = new Point(500, 113);
            ChannelY.Margin = new Padding(2);
            ChannelY.Name = "ChannelY";
            ChannelY.ReadOnly = true;
            ChannelY.Size = new Size(24, 22);
            ChannelY.TabIndex = 36;
            ChannelY.TabStop = false;
            ChannelY.TextAlign = HorizontalAlignment.Center;
            // 
            // ChannelX
            // 
            ChannelX.BackColor = SystemColors.Control;
            ChannelX.Enabled = false;
            ChannelX.Font = new Font("Segoe UI", 8.25F);
            ChannelX.Location = new Point(500, 88);
            ChannelX.Margin = new Padding(2);
            ChannelX.Name = "ChannelX";
            ChannelX.ReadOnly = true;
            ChannelX.Size = new Size(24, 22);
            ChannelX.TabIndex = 35;
            ChannelX.TabStop = false;
            ChannelX.TextAlign = HorizontalAlignment.Center;
            // 
            // ChannelB
            // 
            ChannelB.BackColor = SystemColors.Control;
            ChannelB.Enabled = false;
            ChannelB.Font = new Font("Segoe UI", 8.25F);
            ChannelB.Location = new Point(500, 63);
            ChannelB.Margin = new Padding(2);
            ChannelB.Name = "ChannelB";
            ChannelB.ReadOnly = true;
            ChannelB.Size = new Size(24, 22);
            ChannelB.TabIndex = 34;
            ChannelB.TabStop = false;
            ChannelB.TextAlign = HorizontalAlignment.Center;
            // 
            // ChannelA
            // 
            ChannelA.BackColor = SystemColors.Control;
            ChannelA.Enabled = false;
            ChannelA.Font = new Font("Segoe UI", 8.25F);
            ChannelA.Location = new Point(500, 38);
            ChannelA.Margin = new Padding(2);
            ChannelA.Name = "ChannelA";
            ChannelA.ReadOnly = true;
            ChannelA.Size = new Size(24, 22);
            ChannelA.TabIndex = 33;
            ChannelA.TabStop = false;
            ChannelA.TextAlign = HorizontalAlignment.Center;
            // 
            // ChannelLabel2
            // 
            ChannelLabel2.AutoSize = true;
            ChannelLabel2.BackColor = SystemColors.Control;
            ChannelLabel2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            ChannelLabel2.Location = new Point(487, 18);
            ChannelLabel2.Margin = new Padding(2, 0, 2, 0);
            ChannelLabel2.Name = "ChannelLabel2";
            ChannelLabel2.Size = new Size(50, 13);
            ChannelLabel2.TabIndex = 32;
            ChannelLabel2.Text = "Channel";
            // 
            // ChannelLabel1
            // 
            ChannelLabel1.AutoSize = true;
            ChannelLabel1.BackColor = SystemColors.Control;
            ChannelLabel1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            ChannelLabel1.Location = new Point(498, 6);
            ChannelLabel1.Margin = new Padding(2, 0, 2, 0);
            ChannelLabel1.Name = "ChannelLabel1";
            ChannelLabel1.Size = new Size(27, 13);
            ChannelLabel1.TabIndex = 30;
            ChannelLabel1.Text = "PTZ";
            // 
            // CameraYLabel
            // 
            CameraYLabel.AutoSize = true;
            CameraYLabel.BackColor = SystemColors.Control;
            CameraYLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CameraYLabel.ForeColor = Color.FromArgb(192, 192, 0);
            CameraYLabel.Location = new Point(10, 115);
            CameraYLabel.Margin = new Padding(2, 0, 2, 0);
            CameraYLabel.Name = "CameraYLabel";
            CameraYLabel.Size = new Size(57, 15);
            CameraYLabel.TabIndex = 29;
            CameraYLabel.Text = "Camera Y";
            // 
            // CameraXLabel
            // 
            CameraXLabel.AutoSize = true;
            CameraXLabel.BackColor = SystemColors.Control;
            CameraXLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CameraXLabel.ForeColor = Color.Blue;
            CameraXLabel.Location = new Point(10, 91);
            CameraXLabel.Margin = new Padding(2, 0, 2, 0);
            CameraXLabel.Name = "CameraXLabel";
            CameraXLabel.Size = new Size(57, 15);
            CameraXLabel.TabIndex = 28;
            CameraXLabel.Text = "Camera X";
            // 
            // CameraBLabel
            // 
            CameraBLabel.AutoSize = true;
            CameraBLabel.BackColor = SystemColors.Control;
            CameraBLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CameraBLabel.ForeColor = Color.Red;
            CameraBLabel.Location = new Point(9, 65);
            CameraBLabel.Margin = new Padding(2, 0, 2, 0);
            CameraBLabel.Name = "CameraBLabel";
            CameraBLabel.Size = new Size(57, 15);
            CameraBLabel.TabIndex = 27;
            CameraBLabel.Text = "Camera B";
            // 
            // CameraALabel
            // 
            CameraALabel.AutoSize = true;
            CameraALabel.BackColor = SystemColors.Control;
            CameraALabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CameraALabel.ForeColor = Color.FromArgb(0, 192, 0);
            CameraALabel.Location = new Point(8, 40);
            CameraALabel.Margin = new Padding(2, 0, 2, 0);
            CameraALabel.Name = "CameraALabel";
            CameraALabel.Size = new Size(58, 15);
            CameraALabel.TabIndex = 26;
            CameraALabel.Text = "Camera A";
            // 
            // SavePassword
            // 
            SavePassword.AutoSize = true;
            SavePassword.CheckAlign = ContentAlignment.MiddleRight;
            SavePassword.Enabled = false;
            SavePassword.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavePassword.Location = new Point(127, 48);
            SavePassword.Margin = new Padding(2);
            SavePassword.Name = "SavePassword";
            SavePassword.RightToLeft = RightToLeft.No;
            SavePassword.Size = new Size(87, 16);
            SavePassword.TabIndex = 7;
            SavePassword.TabStop = false;
            SavePassword.Text = "save password";
            SavePassword.TextAlign = ContentAlignment.MiddleRight;
            SavePassword.UseVisualStyleBackColor = true;
            SavePassword.CheckedChanged += SavePassword_CheckedChanged;
            // 
            // AudioOn
            // 
            AudioOn.AutoSize = true;
            AudioOn.CheckAlign = ContentAlignment.MiddleRight;
            AudioOn.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AudioOn.ImageAlign = ContentAlignment.MiddleLeft;
            AudioOn.Location = new Point(167, 2);
            AudioOn.Name = "AudioOn";
            AudioOn.Size = new Size(76, 17);
            AudioOn.TabIndex = 16;
            AudioOn.Text = "Audio On";
            AudioOn.UseVisualStyleBackColor = true;
            AudioOn.CheckedChanged += RestartVideo;
            // 
            // SubStream
            // 
            SubStream.AutoSize = true;
            SubStream.Checked = true;
            SubStream.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubStream.Location = new Point(11, 18);
            SubStream.Name = "SubStream";
            SubStream.Size = new Size(83, 17);
            SubStream.TabIndex = 14;
            SubStream.TabStop = true;
            SubStream.Text = "Sub Stream";
            SubStream.UseVisualStyleBackColor = true;
            SubStream.CheckedChanged += RestartVideo;
            // 
            // MainStream
            // 
            MainStream.AutoSize = true;
            MainStream.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainStream.Location = new Point(11, 2);
            MainStream.Name = "MainStream";
            MainStream.Size = new Size(89, 17);
            MainStream.TabIndex = 13;
            MainStream.Text = "Main Stream";
            MainStream.UseVisualStyleBackColor = true;
            MainStream.CheckedChanged += RestartVideo;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Tag = "";
            notifyIcon.DoubleClick += Form1_Normal;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.AutoClose = false;
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripOpen, toolStripSeparator1, ToolStripStart, ToolStripStop, toolStripSeparator2, ToolStripClose });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(105, 104);
            // 
            // ToolStripOpen
            // 
            ToolStripOpen.BackColor = SystemColors.Control;
            ToolStripOpen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ToolStripOpen.Name = "ToolStripOpen";
            ToolStripOpen.Size = new Size(104, 22);
            ToolStripOpen.Text = "Open";
            ToolStripOpen.Click += Form1_Normal;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(101, 6);
            // 
            // ToolStripStart
            // 
            ToolStripStart.BackColor = SystemColors.Control;
            ToolStripStart.Name = "ToolStripStart";
            ToolStripStart.Size = new Size(104, 22);
            ToolStripStart.Text = "Start";
            ToolStripStart.Click += StartButton_Click;
            // 
            // ToolStripStop
            // 
            ToolStripStop.BackColor = SystemColors.Control;
            ToolStripStop.Name = "ToolStripStop";
            ToolStripStop.Size = new Size(104, 22);
            ToolStripStop.Text = "Stop";
            ToolStripStop.Click += StopButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(101, 6);
            // 
            // ToolStripClose
            // 
            ToolStripClose.BackColor = SystemColors.Control;
            ToolStripClose.Name = "ToolStripClose";
            ToolStripClose.Size = new Size(104, 22);
            ToolStripClose.Text = "Close";
            ToolStripClose.Click += ToolStripClose_Click;
            // 
            // VideoView
            // 
            VideoView.BackColor = Color.Black;
            VideoView.Dock = DockStyle.Fill;
            VideoView.Location = new Point(0, 0);
            VideoView.Margin = new Padding(0);
            VideoView.MediaPlayer = null;
            VideoView.Name = "VideoView";
            VideoView.Size = new Size(585, 339);
            VideoView.TabIndex = 0;
            VideoView.Text = "videoView";
            // 
            // PresetsPanel
            // 
            PresetsPanel.BackColor = SystemColors.Control;
            PresetsPanel.BorderStyle = BorderStyle.Fixed3D;
            PresetsPanel.Controls.Add(PresetsDropdownPanel);
            PresetsPanel.Controls.Add(PresetsLabel);
            PresetsPanel.Location = new Point(601, 163);
            PresetsPanel.Name = "PresetsPanel";
            PresetsPanel.Size = new Size(255, 187);
            PresetsPanel.TabIndex = 28;
            // 
            // PresetsDropdownPanel
            // 
            PresetsDropdownPanel.Controls.Add(MenuBox);
            PresetsDropdownPanel.Controls.Add(RbLabel);
            PresetsDropdownPanel.Controls.Add(LbBox);
            PresetsDropdownPanel.Controls.Add(RbBox);
            PresetsDropdownPanel.Controls.Add(LbLabel);
            PresetsDropdownPanel.Controls.Add(RtBox);
            PresetsDropdownPanel.Controls.Add(LtLabel);
            PresetsDropdownPanel.Controls.Add(MenuLabel);
            PresetsDropdownPanel.Controls.Add(RtLabel);
            PresetsDropdownPanel.Controls.Add(LtBox);
            PresetsDropdownPanel.Controls.Add(ViewBox);
            PresetsDropdownPanel.Controls.Add(ViewLabel);
            PresetsDropdownPanel.Dock = DockStyle.Bottom;
            PresetsDropdownPanel.Location = new Point(0, 28);
            PresetsDropdownPanel.Name = "PresetsDropdownPanel";
            PresetsDropdownPanel.Size = new Size(251, 155);
            PresetsDropdownPanel.TabIndex = 53;
            // 
            // MenuBox
            // 
            MenuBox.BackColor = SystemColors.Control;
            MenuBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MenuBox.Font = new Font("Calibri", 8.25F);
            MenuBox.FormattingEnabled = true;
            MenuBox.Location = new Point(87, 6);
            MenuBox.MaxDropDownItems = 100;
            MenuBox.Name = "MenuBox";
            MenuBox.Size = new Size(156, 21);
            MenuBox.TabIndex = 0;
            MenuBox.SelectedIndexChanged += PresetSelectedIndexChanged;
            // 
            // RbLabel
            // 
            RbLabel.AutoSize = true;
            RbLabel.Font = new Font("Segoe UI", 8F);
            RbLabel.Location = new Point(6, 129);
            RbLabel.Name = "RbLabel";
            RbLabel.Size = new Size(78, 13);
            RbLabel.TabIndex = 51;
            RbLabel.Text = "Right Bumper";
            // 
            // LbBox
            // 
            LbBox.BackColor = SystemColors.Control;
            LbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LbBox.Font = new Font("Calibri", 8.25F);
            LbBox.FormattingEnabled = true;
            LbBox.Location = new Point(87, 102);
            LbBox.MaxDropDownItems = 100;
            LbBox.Name = "LbBox";
            LbBox.Size = new Size(156, 21);
            LbBox.TabIndex = 45;
            LbBox.SelectedIndexChanged += PresetSelectedIndexChanged;
            // 
            // RbBox
            // 
            RbBox.BackColor = SystemColors.Control;
            RbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RbBox.Font = new Font("Calibri", 8.25F);
            RbBox.FormattingEnabled = true;
            RbBox.Location = new Point(87, 126);
            RbBox.MaxDropDownItems = 100;
            RbBox.Name = "RbBox";
            RbBox.Size = new Size(156, 21);
            RbBox.TabIndex = 46;
            RbBox.SelectedIndexChanged += PresetSelectedIndexChanged;
            // 
            // LbLabel
            // 
            LbLabel.AutoSize = true;
            LbLabel.Font = new Font("Segoe UI", 8F);
            LbLabel.Location = new Point(6, 105);
            LbLabel.Name = "LbLabel";
            LbLabel.Size = new Size(69, 13);
            LbLabel.TabIndex = 50;
            LbLabel.Text = "Left Bumper";
            // 
            // RtBox
            // 
            RtBox.BackColor = SystemColors.Control;
            RtBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RtBox.Font = new Font("Calibri", 8.25F);
            RtBox.FormattingEnabled = true;
            RtBox.Location = new Point(87, 78);
            RtBox.MaxDropDownItems = 100;
            RtBox.Name = "RtBox";
            RtBox.Size = new Size(156, 21);
            RtBox.TabIndex = 44;
            RtBox.SelectedIndexChanged += PresetSelectedIndexChanged;
            // 
            // LtLabel
            // 
            LtLabel.AutoSize = true;
            LtLabel.Font = new Font("Segoe UI", 8F);
            LtLabel.Location = new Point(6, 57);
            LtLabel.Name = "LtLabel";
            LtLabel.Size = new Size(64, 13);
            LtLabel.TabIndex = 41;
            LtLabel.Text = "Left Trigger";
            // 
            // MenuLabel
            // 
            MenuLabel.AutoSize = true;
            MenuLabel.Font = new Font("Segoe UI", 8F);
            MenuLabel.Location = new Point(6, 9);
            MenuLabel.Name = "MenuLabel";
            MenuLabel.Size = new Size(76, 13);
            MenuLabel.TabIndex = 47;
            MenuLabel.Text = "Menu Button";
            // 
            // RtLabel
            // 
            RtLabel.AutoSize = true;
            RtLabel.Font = new Font("Segoe UI", 8F);
            RtLabel.Location = new Point(6, 81);
            RtLabel.Name = "RtLabel";
            RtLabel.Size = new Size(73, 13);
            RtLabel.TabIndex = 49;
            RtLabel.Text = "Right Trigger";
            // 
            // LtBox
            // 
            LtBox.BackColor = SystemColors.Control;
            LtBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LtBox.Font = new Font("Calibri", 8.25F);
            LtBox.FormattingEnabled = true;
            LtBox.Location = new Point(87, 54);
            LtBox.MaxDropDownItems = 100;
            LtBox.Name = "LtBox";
            LtBox.Size = new Size(156, 21);
            LtBox.TabIndex = 43;
            LtBox.SelectedIndexChanged += PresetSelectedIndexChanged;
            // 
            // ViewBox
            // 
            ViewBox.BackColor = SystemColors.Control;
            ViewBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ViewBox.Font = new Font("Calibri", 8.25F);
            ViewBox.FormattingEnabled = true;
            ViewBox.Location = new Point(87, 30);
            ViewBox.MaxDropDownItems = 100;
            ViewBox.Name = "ViewBox";
            ViewBox.Size = new Size(156, 21);
            ViewBox.TabIndex = 42;
            ViewBox.SelectedIndexChanged += PresetSelectedIndexChanged;
            // 
            // ViewLabel
            // 
            ViewLabel.AutoSize = true;
            ViewLabel.Font = new Font("Segoe UI", 8F);
            ViewLabel.Location = new Point(6, 33);
            ViewLabel.Name = "ViewLabel";
            ViewLabel.Size = new Size(71, 13);
            ViewLabel.TabIndex = 48;
            ViewLabel.Text = "View Button";
            // 
            // PresetsLabel
            // 
            PresetsLabel.Dock = DockStyle.Top;
            PresetsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PresetsLabel.Location = new Point(0, 0);
            PresetsLabel.Name = "PresetsLabel";
            PresetsLabel.Size = new Size(251, 35);
            PresetsLabel.TabIndex = 52;
            PresetsLabel.Text = "Presets";
            PresetsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HardwareDecode
            // 
            HardwareDecode.AutoSize = true;
            HardwareDecode.CheckAlign = ContentAlignment.MiddleRight;
            HardwareDecode.Font = new Font("Segoe UI", 8F);
            HardwareDecode.Location = new Point(156, 34);
            HardwareDecode.Name = "HardwareDecode";
            HardwareDecode.Size = new Size(87, 17);
            HardwareDecode.TabIndex = 53;
            HardwareDecode.Text = "HW Decode";
            HardwareDecode.UseVisualStyleBackColor = true;
            HardwareDecode.CheckedChanged += RestartVideo;
            // 
            // FitScreen
            // 
            FitScreen.AutoSize = true;
            FitScreen.CheckAlign = ContentAlignment.MiddleRight;
            FitScreen.Font = new Font("Segoe UI", 8F);
            FitScreen.Location = new Point(153, 18);
            FitScreen.Name = "FitScreen";
            FitScreen.Size = new Size(90, 17);
            FitScreen.TabIndex = 52;
            FitScreen.Text = "Fit To Screen";
            FitScreen.UseVisualStyleBackColor = true;
            FitScreen.CheckedChanged += RestartVideo;
            // 
            // NoStream
            // 
            NoStream.AutoSize = true;
            NoStream.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoStream.Location = new Point(11, 34);
            NoStream.Name = "NoStream";
            NoStream.Size = new Size(75, 17);
            NoStream.TabIndex = 40;
            NoStream.TabStop = true;
            NoStream.Text = "Video Off";
            NoStream.UseVisualStyleBackColor = true;
            // 
            // StartPanel
            // 
            StartPanel.BackColor = SystemColors.Control;
            StartPanel.BorderStyle = BorderStyle.Fixed3D;
            StartPanel.Controls.Add(SettingsButton);
            StartPanel.Controls.Add(LoginLabel);
            StartPanel.Controls.Add(UserPanel);
            StartPanel.Controls.Add(StopButton);
            StartPanel.Controls.Add(StartButton);
            StartPanel.Location = new Point(601, 353);
            StartPanel.Name = "StartPanel";
            StartPanel.Size = new Size(255, 144);
            StartPanel.TabIndex = 29;
            // 
            // SettingsButton
            // 
            SettingsButton.BackColor = SystemColors.Control;
            SettingsButton.BackgroundImage = (Image)resources.GetObject("SettingsButton.BackgroundImage");
            SettingsButton.BackgroundImageLayout = ImageLayout.Center;
            SettingsButton.Location = new Point(8, 111);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(25, 25);
            SettingsButton.TabIndex = 11;
            SettingsButton.TabStop = false;
            SettingsButton.UseVisualStyleBackColor = false;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // LoginLabel
            // 
            LoginLabel.Dock = DockStyle.Top;
            LoginLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LoginLabel.Location = new Point(0, 0);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(251, 35);
            LoginLabel.TabIndex = 33;
            LoginLabel.Text = "Camera Login";
            LoginLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserPanel
            // 
            UserPanel.Controls.Add(StartMinimized);
            UserPanel.Controls.Add(Username);
            UserPanel.Controls.Add(Password);
            UserPanel.Controls.Add(PasswordLabel);
            UserPanel.Controls.Add(SavePassword);
            UserPanel.Controls.Add(UsernameLabel);
            UserPanel.Location = new Point(0, 28);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(251, 82);
            UserPanel.TabIndex = 9;
            // 
            // StartMinimized
            // 
            StartMinimized.AutoSize = true;
            StartMinimized.CheckAlign = ContentAlignment.MiddleRight;
            StartMinimized.Enabled = false;
            StartMinimized.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartMinimized.ImageAlign = ContentAlignment.MiddleRight;
            StartMinimized.Location = new Point(123, 62);
            StartMinimized.Name = "StartMinimized";
            StartMinimized.Size = new Size(91, 16);
            StartMinimized.TabIndex = 8;
            StartMinimized.TabStop = false;
            StartMinimized.Text = "start minimized";
            StartMinimized.TextAlign = ContentAlignment.MiddleRight;
            StartMinimized.UseVisualStyleBackColor = true;
            // 
            // ControllerPanel
            // 
            ControllerPanel.BackColor = SystemColors.Control;
            ControllerPanel.BorderStyle = BorderStyle.Fixed3D;
            ControllerPanel.Controls.Add(ControllerLabel);
            ControllerPanel.Controls.Add(ControllerNumLabel);
            ControllerPanel.Controls.Add(ControllerNum);
            ControllerPanel.Controls.Add(PollingController);
            ControllerPanel.Location = new Point(601, 6);
            ControllerPanel.Name = "ControllerPanel";
            ControllerPanel.Size = new Size(255, 65);
            ControllerPanel.TabIndex = 30;
            // 
            // ControllerLabel
            // 
            ControllerLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ControllerLabel.Location = new Point(1, 17);
            ControllerLabel.Name = "ControllerLabel";
            ControllerLabel.Size = new Size(251, 20);
            ControllerLabel.TabIndex = 17;
            ControllerLabel.Text = "Waiting For Start";
            ControllerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ControllerNumLabel
            // 
            ControllerNumLabel.AutoSize = true;
            ControllerNumLabel.Font = new Font("Segoe UI", 8F);
            ControllerNumLabel.Location = new Point(53, 41);
            ControllerNumLabel.Name = "ControllerNumLabel";
            ControllerNumLabel.Size = new Size(103, 13);
            ControllerNumLabel.TabIndex = 16;
            ControllerNumLabel.Text = "Controller Number";
            // 
            // ControllerNum
            // 
            ControllerNum.Location = new Point(163, 37);
            ControllerNum.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            ControllerNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ControllerNum.Name = "ControllerNum";
            ControllerNum.Size = new Size(31, 23);
            ControllerNum.TabIndex = 15;
            ControllerNum.TextAlign = HorizontalAlignment.Center;
            ControllerNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ControllerNum.ValueChanged += ControllerNum_ValueChanged;
            // 
            // PollingController
            // 
            PollingController.Anchor = AnchorStyles.None;
            PollingController.BackColor = SystemColors.Control;
            PollingController.Location = new Point(2, 1);
            PollingController.MarqueeAnimationSpeed = 50;
            PollingController.Name = "PollingController";
            PollingController.Size = new Size(248, 13);
            PollingController.TabIndex = 14;
            // 
            // RtspPanel
            // 
            RtspPanel.BackColor = SystemColors.Control;
            RtspPanel.BorderStyle = BorderStyle.Fixed3D;
            RtspPanel.Controls.Add(ActiveCam);
            RtspPanel.Controls.Add(RtspControlsPanel);
            RtspPanel.Location = new Point(601, 74);
            RtspPanel.Name = "RtspPanel";
            RtspPanel.Size = new Size(255, 86);
            RtspPanel.TabIndex = 31;
            // 
            // ActiveCam
            // 
            ActiveCam.Dock = DockStyle.Top;
            ActiveCam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ActiveCam.Location = new Point(0, 0);
            ActiveCam.Name = "ActiveCam";
            ActiveCam.Size = new Size(251, 30);
            ActiveCam.TabIndex = 55;
            ActiveCam.Text = "Waiting For Start";
            ActiveCam.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RtspControlsPanel
            // 
            RtspControlsPanel.Controls.Add(HardwareDecode);
            RtspControlsPanel.Controls.Add(AudioOn);
            RtspControlsPanel.Controls.Add(MainStream);
            RtspControlsPanel.Controls.Add(FitScreen);
            RtspControlsPanel.Controls.Add(NoStream);
            RtspControlsPanel.Controls.Add(SubStream);
            RtspControlsPanel.Dock = DockStyle.Bottom;
            RtspControlsPanel.Location = new Point(0, 28);
            RtspControlsPanel.Name = "RtspControlsPanel";
            RtspControlsPanel.Size = new Size(251, 54);
            RtspControlsPanel.TabIndex = 54;
            // 
            // VideoPanel
            // 
            VideoPanel.BackColor = Color.Black;
            VideoPanel.BorderStyle = BorderStyle.Fixed3D;
            VideoPanel.Controls.Add(VideoView);
            VideoPanel.Location = new Point(8, 7);
            VideoPanel.Name = "VideoPanel";
            VideoPanel.Size = new Size(589, 343);
            VideoPanel.TabIndex = 32;
            // 
            // PollingTimer
            // 
            PollingTimer.Interval = 1000000;
            PollingTimer.Tick += PollingTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(866, 506);
            Controls.Add(VideoPanel);
            Controls.Add(RtspPanel);
            Controls.Add(ControllerPanel);
            Controls.Add(StartPanel);
            Controls.Add(PresetsPanel);
            Controls.Add(CameraPanel);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XInput PTZ Controller V1.0";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            CameraPanel.ResumeLayout(false);
            CameraPanel.PerformLayout();
            IpPanel.ResumeLayout(false);
            IpPanel.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)VideoView).EndInit();
            PresetsPanel.ResumeLayout(false);
            PresetsDropdownPanel.ResumeLayout(false);
            PresetsDropdownPanel.PerformLayout();
            StartPanel.ResumeLayout(false);
            UserPanel.ResumeLayout(false);
            UserPanel.PerformLayout();
            ControllerPanel.ResumeLayout(false);
            ControllerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ControllerNum).EndInit();
            RtspPanel.ResumeLayout(false);
            RtspControlsPanel.ResumeLayout(false);
            RtspControlsPanel.PerformLayout();
            VideoPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox IpA;
        private TextBox IpB;
        private TextBox IpX;
        private TextBox IpY;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox Username;
        private TextBox Password;
        private Label IpLabel;
        private Button StartButton;
        private Button StopButton;
        private Label OnlineLabel;
        private Panel CameraPanel;
        private Label CameraYLabel;
        private Label CameraXLabel;
        private Label CameraBLabel;
        private Label CameraALabel;
        private Label ChannelLabel1;
        private CheckBox SavePassword;
        private Label ChannelLabel2;
        private TextBox ChannelY;
        private TextBox ChannelX;
        private TextBox ChannelB;
        private TextBox ChannelA;
        private NotifyIcon notifyIcon;
        private LibVLCSharp.WinForms.VideoView VideoView;
        private CheckBox AudioOn;
        private RadioButton SubStream;
        private RadioButton MainStream;
        private Panel PresetsPanel;
        private TextBox ModelY;
        private TextBox ModelX;
        private TextBox ModelB;
        private TextBox ModelA;
        private TextBox NameY;
        private TextBox NameX;
        private TextBox NameB;
        private TextBox NameA;
        private Label ModelLabel;
        private Label NameLabel;
        private Panel StartPanel;
        private Panel ControllerPanel;
        private RadioButton NoStream;
        private ComboBox MenuBox;
        private Label LtLabel;
        private ComboBox RbBox;
        private ComboBox LbBox;
        private ComboBox RtBox;
        private ComboBox LtBox;
        private ComboBox ViewBox;
        private Label RbLabel;
        private Label LbLabel;
        private Label RtLabel;
        private Label ViewLabel;
        private Label MenuLabel;
        private CheckBox FitScreen;
        private CheckBox HardwareDecode;
        private Panel RtspPanel;
        private ProgressBar PollingController;
        private CheckBox StartMinimized;
        private Panel UserPanel;
        private Panel IpPanel;
        private Panel VideoPanel;
        private ContextMenuStrip contextMenuStrip;
        private Label ControllerNumLabel;
        private NumericUpDown ControllerNum;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ToolStripOpen;
        private ToolStripMenuItem ToolStripStart;
        private ToolStripMenuItem ToolStripStop;
        private ToolStripMenuItem ToolStripClose;
        private Panel OnlineB;
        private Panel OnlineA;
        private Panel OnlineY;
        private Panel OnlineX;
        private Label ActiveCam;
        private Label PresetsLabel;
        private Label LoginLabel;
        private Label ControllerLabel;
        private Panel PresetsDropdownPanel;
        private Panel RtspControlsPanel;
        private Label CameraLabel2;
        private Button SettingsButton;
        private System.Windows.Forms.Timer PollingTimer;
        private Label CameraLabel1;
    }
}
