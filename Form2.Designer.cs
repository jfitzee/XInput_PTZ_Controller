namespace XInput_PTZ_Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            CgiTimeoutLabel = new Label();
            CgiTimeout = new NumericUpDown();
            SettingsCloseButton = new Button();
            PollDelayLabel = new Label();
            PollingDelay = new NumericUpDown();
            HttpTimeoutLable = new Label();
            HttpTimeout = new NumericUpDown();
            SwapJoysticks = new CheckBox();
            FirstApiLabel = new Label();
            FirstApi = new ComboBox();
            VlcBufferLabel = new Label();
            VlcBuffer = new NumericUpDown();
            PollCameras = new CheckBox();
            PollCamerasTime = new NumericUpDown();
            PollCamerasLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)CgiTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PollingDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HttpTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VlcBuffer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PollCamerasTime).BeginInit();
            SuspendLayout();
            // 
            // CgiTimeoutLabel
            // 
            CgiTimeoutLabel.AutoSize = true;
            CgiTimeoutLabel.Location = new Point(8, 118);
            CgiTimeoutLabel.Name = "CgiTimeoutLabel";
            CgiTimeoutLabel.Size = new Size(184, 15);
            CgiTimeoutLabel.TabIndex = 0;
            CgiTimeoutLabel.Text = "CGI PTZ movement timeout (sec)";
            // 
            // CgiTimeout
            // 
            CgiTimeout.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            CgiTimeout.Location = new Point(198, 116);
            CgiTimeout.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            CgiTimeout.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            CgiTimeout.Name = "CgiTimeout";
            CgiTimeout.Size = new Size(55, 23);
            CgiTimeout.TabIndex = 1;
            CgiTimeout.TabStop = false;
            CgiTimeout.TextAlign = HorizontalAlignment.Center;
            CgiTimeout.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // SettingsCloseButton
            // 
            SettingsCloseButton.Location = new Point(315, 142);
            SettingsCloseButton.Name = "SettingsCloseButton";
            SettingsCloseButton.Size = new Size(75, 23);
            SettingsCloseButton.TabIndex = 2;
            SettingsCloseButton.Text = "Close";
            SettingsCloseButton.UseVisualStyleBackColor = true;
            SettingsCloseButton.Click += SettingsCloseButton_Click;
            // 
            // PollDelayLabel
            // 
            PollDelayLabel.AutoSize = true;
            PollDelayLabel.Location = new Point(22, 92);
            PollDelayLabel.Name = "PollDelayLabel";
            PollDelayLabel.Size = new Size(170, 15);
            PollDelayLabel.TabIndex = 3;
            PollDelayLabel.Text = "Controller polling delay (msec)";
            // 
            // PollingDelay
            // 
            PollingDelay.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            PollingDelay.Location = new Point(198, 90);
            PollingDelay.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            PollingDelay.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            PollingDelay.Name = "PollingDelay";
            PollingDelay.Size = new Size(55, 23);
            PollingDelay.TabIndex = 4;
            PollingDelay.TextAlign = HorizontalAlignment.Center;
            PollingDelay.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // HttpTimeoutLable
            // 
            HttpTimeoutLable.AutoSize = true;
            HttpTimeoutLable.Location = new Point(82, 66);
            HttpTimeoutLable.Name = "HttpTimeoutLable";
            HttpTimeoutLable.Size = new Size(110, 15);
            HttpTimeoutLable.TabIndex = 5;
            HttpTimeoutLable.Text = "HTTP timeout (sec)";
            // 
            // HttpTimeout
            // 
            HttpTimeout.Location = new Point(198, 64);
            HttpTimeout.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            HttpTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            HttpTimeout.Name = "HttpTimeout";
            HttpTimeout.Size = new Size(55, 23);
            HttpTimeout.TabIndex = 6;
            HttpTimeout.TextAlign = HorizontalAlignment.Center;
            HttpTimeout.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SwapJoysticks
            // 
            SwapJoysticks.AutoSize = true;
            SwapJoysticks.BackColor = SystemColors.Control;
            SwapJoysticks.CheckAlign = ContentAlignment.MiddleRight;
            SwapJoysticks.Location = new Point(288, 13);
            SwapJoysticks.Name = "SwapJoysticks";
            SwapJoysticks.Size = new Size(102, 19);
            SwapJoysticks.TabIndex = 8;
            SwapJoysticks.TabStop = false;
            SwapJoysticks.Text = "Swap joysticks";
            SwapJoysticks.TextAlign = ContentAlignment.MiddleRight;
            SwapJoysticks.UseVisualStyleBackColor = false;
            // 
            // FirstApiLabel
            // 
            FirstApiLabel.AutoSize = true;
            FirstApiLabel.Location = new Point(111, 15);
            FirstApiLabel.Name = "FirstApiLabel";
            FirstApiLabel.Size = new Size(81, 15);
            FirstApiLabel.TabIndex = 9;
            FirstApiLabel.Text = "First API to try";
            // 
            // FirstApi
            // 
            FirstApi.FormattingEnabled = true;
            FirstApi.Items.AddRange(new object[] { "ISAPI", "CGI" });
            FirstApi.Location = new Point(198, 12);
            FirstApi.Name = "FirstApi";
            FirstApi.Size = new Size(55, 23);
            FirstApi.TabIndex = 10;
            FirstApi.Text = "ISAPI";
            // 
            // VlcBufferLabel
            // 
            VlcBufferLabel.AutoSize = true;
            VlcBufferLabel.Location = new Point(63, 144);
            VlcBufferLabel.Name = "VlcBufferLabel";
            VlcBufferLabel.Size = new Size(129, 15);
            VlcBufferLabel.TabIndex = 11;
            VlcBufferLabel.Text = "VLC buffer time (msec)";
            // 
            // VlcBuffer
            // 
            VlcBuffer.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            VlcBuffer.Location = new Point(198, 142);
            VlcBuffer.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            VlcBuffer.Name = "VlcBuffer";
            VlcBuffer.Size = new Size(55, 23);
            VlcBuffer.TabIndex = 12;
            VlcBuffer.TextAlign = HorizontalAlignment.Center;
            // 
            // PollCameras
            // 
            PollCameras.AutoSize = true;
            PollCameras.CheckAlign = ContentAlignment.MiddleRight;
            PollCameras.Location = new Point(297, 38);
            PollCameras.Name = "PollCameras";
            PollCameras.Size = new Size(93, 19);
            PollCameras.TabIndex = 13;
            PollCameras.TabStop = false;
            PollCameras.Text = "Poll cameras";
            PollCameras.TextAlign = ContentAlignment.MiddleRight;
            PollCameras.UseVisualStyleBackColor = true;
            PollCameras.CheckedChanged += PollCameras_CheckedChanged;
            // 
            // PollCamerasTime
            // 
            PollCamerasTime.Enabled = false;
            PollCamerasTime.Location = new Point(198, 38);
            PollCamerasTime.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            PollCamerasTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PollCamerasTime.Name = "PollCamerasTime";
            PollCamerasTime.Size = new Size(55, 23);
            PollCamerasTime.TabIndex = 14;
            PollCamerasTime.TabStop = false;
            PollCamerasTime.TextAlign = HorizontalAlignment.Center;
            PollCamerasTime.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // PollCamerasLabel
            // 
            PollCamerasLabel.AutoSize = true;
            PollCamerasLabel.Enabled = false;
            PollCamerasLabel.Location = new Point(50, 39);
            PollCamerasLabel.Name = "PollCamerasLabel";
            PollCamerasLabel.Size = new Size(142, 15);
            PollCamerasLabel.TabIndex = 15;
            PollCamerasLabel.Text = "Check online status (min)";
            // 
            // Form2
            // 
            AcceptButton = SettingsCloseButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(405, 178);
            Controls.Add(PollCamerasLabel);
            Controls.Add(PollCamerasTime);
            Controls.Add(PollCameras);
            Controls.Add(VlcBuffer);
            Controls.Add(VlcBufferLabel);
            Controls.Add(FirstApi);
            Controls.Add(FirstApiLabel);
            Controls.Add(SwapJoysticks);
            Controls.Add(HttpTimeout);
            Controls.Add(HttpTimeoutLable);
            Controls.Add(PollingDelay);
            Controls.Add(PollDelayLabel);
            Controls.Add(SettingsCloseButton);
            Controls.Add(CgiTimeout);
            Controls.Add(CgiTimeoutLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XInput PTZ Controller Settings";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)CgiTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)PollingDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)HttpTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)VlcBuffer).EndInit();
            ((System.ComponentModel.ISupportInitialize)PollCamerasTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CgiTimeoutLabel;
        private Button SettingsCloseButton;
        public NumericUpDown CgiTimeout;
        private Label PollDelayLabel;
        private NumericUpDown PollingDelay;
        private Label HttpTimeoutLable;
        private NumericUpDown HttpTimeout;
        private CheckBox SwapJoysticks;
        private Label FirstApiLabel;
        private ComboBox FirstApi;
        private Label VlcBufferLabel;
        private NumericUpDown VlcBuffer;
        private CheckBox PollCameras;
        private NumericUpDown PollCamerasTime;
        private Label PollCamerasLabel;
    }
}