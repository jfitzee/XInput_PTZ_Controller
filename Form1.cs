////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using LibVLCSharp.Shared;
using SharpDX.XInput;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace XInput_PTZ_Controller
{
    public partial class Form1 : Form
    {
        private readonly NetworkCredential cameraCredentials = new();
        private readonly HttpClientHandler cameraHandler;
        private Controller controller = new();
        private State currReading, prevReading;
        private string activeCamera = "A", controllerName = "", cameraButton = "";
        private bool applicationExit = false, controllerConnected = false, iniFileLoaded = false, videoIsOn = false;
        private int prevPan = 0, prevTilt = 0, prevZoom = 0, prevFocus = 0, prevIris = 0;
        private readonly string[,] allPresets = new string[4, 100];
        private readonly int[,] activePresets = new int[4, 6];
        private readonly int[] numPresets = new int[4];
        private readonly string[] cameraApi = new string[4];
        public string firstApi = "ISAPI";
        public int httpTimeout = 3, pollingDelay = 100, cgiTimeoutValue = 15, vlcBuffer = 0, pollCamerasTime = 15;
        public bool swapJoysticks = false, pollCameras = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
            Core.Initialize();
            cameraHandler = new HttpClientHandler { Credentials = cameraCredentials };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            LoadIniFile();
            this.ShowIcon = true;
            if (StartMinimized.Checked) { this.WindowState = FormWindowState.Minimized; } else { this.Show(); }
            CheckCameraLoginReady();
            if (StartButton.Enabled == true) { StartButton.PerformClick(); } else { SetCameraControls(); }
            await XInputPtzControllerMain();
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private async Task XInputPtzControllerMain()
        {
            while (!applicationExit)
            {
                if (StartButton.Enabled) { await Task.Delay(pollingDelay * 2); continue; } else { await Task.Delay(pollingDelay); }
                if (IsOnline(activeCamera) && VideoView.MediaPlayer is not null && VideoView.MediaPlayer.State == VLCState.Ended)
                {
                    SetCameraOffline(activeCamera);
                    SwitchVideo("OFF");
                }
                if (controllerConnected != controller.IsConnected)
                {
                    if (controllerConnected && IsOnline(activeCamera)) { StopPTZmovement(activeCamera); }
                    controllerConnected = controller.IsConnected;
                    if (controllerConnected) { ControllerNum_ValueChanged(this, EventArgs.Empty); }
                    UpdateGui();
                }
                if (controllerConnected)
                {
                    try { currReading = controller.GetState(); } catch { controllerConnected = false; UpdateGui(); continue; }
                    if (currReading.Gamepad.Equals(prevReading.Gamepad) == false)
                    {
                        cameraButton = CameraButtonSelected();
                        if (cameraButton != "" && !(cameraButton == activeCamera && IsOnline(activeCamera)))
                        {
                            if (cameraButton == activeCamera && IsOnline(activeCamera)) { StopPTZmovement(activeCamera); }
                            SwitchVideo("OFF");
                            activeCamera = cameraButton;
                            SetCameraControls();
                            if (!IsOnline(activeCamera))
                            {
                                CheckCameraConnection(activeCamera);
                                SetCameraControls();
                            }
                            SwitchVideo("ON");
                        }
                        if (IsOnline(activeCamera))
                        {
                            ProcessControllerInput();
                        }
                        prevReading = currReading;
                    }
                }
            }
            return;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void StartButton_Click(object sender, EventArgs e)
        {
            SetCameraInputs(false);
            cameraCredentials.UserName = Username.Text;
            cameraCredentials.Password = Password.Text;
            CheckCameraConnections();
            SetCameraControls();
            SwitchVideo("ON");
            ControllerNum_ValueChanged(this, EventArgs.Empty);
            if (pollCameras) { PollingTimer.Interval = pollingDelay * 1000; PollingTimer.Enabled = true; }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SetCameraInputs(true);
            if (IsOnline(activeCamera)) { StopPTZmovement(activeCamera); }
            SwitchVideo("OFF");
            if (pollCameras) { PollingTimer.Enabled = false; }
            ChannelA.Text = ""; NameA.Text = ""; ModelA.Text = ""; OnlineA.BackColor = System.Drawing.SystemColors.Control;
            ChannelB.Text = ""; NameB.Text = ""; ModelB.Text = ""; OnlineB.BackColor = System.Drawing.SystemColors.Control;
            ChannelX.Text = ""; NameX.Text = ""; ModelX.Text = ""; OnlineX.BackColor = System.Drawing.SystemColors.Control;
            ChannelY.Text = ""; NameY.Text = ""; ModelY.Text = ""; OnlineY.BackColor = System.Drawing.SystemColors.Control;
            UserPanel.Focus();
            ClearPresetBoxes();
            SetCameraControls();
            for (int i = 0; i < 4; i++) { cameraApi[i] = ""; }
        }
        private void SetCameraInputs(bool trueFalse)
        {
            StartButton.Enabled = trueFalse;
            StopButton.Enabled = !trueFalse;
            SettingsButton.Enabled = trueFalse;
            IpPanel.Enabled = trueFalse;
            UserPanel.Enabled = trueFalse;
            if (trueFalse && SavePassword.Enabled && SavePassword.Checked) { StartMinimized.Enabled = true; } else { StartMinimized.Enabled = false; }
            ControllerNum.Enabled = !trueFalse;
            ControllerNumLabel.Enabled = !trueFalse;
        }

        private void CheckCameraLoginReady()
        {
            if (Username.Text != "" && Password.Text != "" && (IpA.Text != "" || IpB.Text != "" || IpX.Text != "" || IpY.Text != ""))
            {
                StartButton.Enabled = true;
            }
            else
            {
                StartButton.Enabled = false;
            }
        }

        private void SavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (SavePassword.Checked)
            {
                StartMinimized.Enabled = true;
            }
            else
            {
                StartMinimized.Enabled = false;
                StartMinimized.Checked = false;
            }
        }

        private void CameraDataTextChanged(object sender, EventArgs e)
        {
            if (!StopButton.Enabled) { CheckCameraLoginReady(); }
            TextBox sentTextBox = (TextBox)sender;
            switch (sentTextBox.Name)
            {
                case "IpA": DefaultActivePresets("A"); break;
                case "IpB": DefaultActivePresets("B"); break;
                case "IpX": DefaultActivePresets("X"); break;
                case "IpY": DefaultActivePresets("Y"); break;
                case "Password":
                    if (Password.Text != "") { SavePassword.Enabled = true; } else { SavePassword.Enabled = false; SavePassword.Checked = false; }
                    break;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            //TextBox tempTextBox = (TextBox)sender;
            //tempTextBox.BorderStyle = BorderStyle.None; tempTextBox.BorderStyle = BorderStyle.Fixed3D;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SetCameraControls()
        {
            if (IsOnline(activeCamera)) { RtspControlsPanel.Enabled = true; SetPresetBoxes(); }
            else { RtspControlsPanel.Enabled = false; ClearPresetBoxes(); }
            UpdateGui();
        }

        private void UpdateGui()
        {
            notifyIcon.Text = "XInput PTZ Controller" + Environment.NewLine + Environment.NewLine;
            if (StopButton.Enabled)
            {
                notifyIcon.Text += "PTZ Control Started" + Environment.NewLine;
            }
            else
            {
                notifyIcon.Text += "PTZ Control Stopped" + Environment.NewLine + "Waiting For Start";
            }
            if (StopButton.Enabled && controllerConnected)
            {
                ControllerLabel.Text = controllerName + " " + controller.UserIndex + " Connected";
                PollingController.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                if (!StopButton.Enabled) { ControllerLabel.Text = "Waiting For Start"; }
                else { ControllerLabel.Text = "Controller Not Connected"; }
                PollingController.Style = ProgressBarStyle.Blocks;
            }
            if (StopButton.Enabled)
            {
                notifyIcon.Text += ControllerLabel.Text + Environment.NewLine;
                ActiveCam.Text = "Camera " + activeCamera + " - ";
                if (IsOnline(activeCamera))
                {
                    ActiveCam.Text += GetCameraName(activeCamera);
                }
                else
                {
                    ActiveCam.Text += "Offline";
                }
                notifyIcon.Text += ActiveCam.Text;
            }
            else { ActiveCam.Text = "Waiting For Start"; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PollingTimer_Tick(object sender, EventArgs e)
        {
            CheckCameraConnections();
        }

        private void SetCameraOffline(string cameraLabel)
        {
            switch (cameraLabel)
            {
                case "A": OnlineA.BackColor = Color.Red; break;
                case "B": OnlineB.BackColor = Color.Red; break;
                case "X": OnlineX.BackColor = Color.Red; break;
                case "Y": OnlineY.BackColor = Color.Red; break;
            }
            if (cameraLabel == activeCamera) { SetCameraControls(); SwitchVideo("OFF"); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void CheckCameraConnections()
        {
            CheckCameraConnection("A");
            CheckCameraConnection("B");
            CheckCameraConnection("X");
            CheckCameraConnection("Y");
        }

        private void CheckCameraConnection(string cameraLabel)
        {
            if (GetCameraIP(cameraLabel) == "") { return; }
            int channelID;
            if (cameraApi[CameraIndex(cameraLabel)] == "ISAPI") { channelID = IsapiGetPtzChannel(cameraLabel); }
            else if (cameraApi[CameraIndex(cameraLabel)] == "CGI") { channelID = CgiGetPtzChannel(cameraLabel); }
            else
            {
                if (firstApi == "ISAPI") { channelID = IsapiGetPtzChannel(cameraLabel); } else { channelID = CgiGetPtzChannel(cameraLabel); }
                if (channelID == 0)
                {
                    if (firstApi == "ISAPI") { channelID = CgiGetPtzChannel(cameraLabel); } else { channelID = IsapiGetPtzChannel(cameraLabel); }
                }
            }
            if (channelID == -1)
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    MessageBox.Show("Camera " + cameraLabel + ": PTZ not enabled on this camera." + Environment.NewLine + Environment.NewLine +
                                    "REMOVING THIS CAMERA IP ADDRESS.", "Camera does not support PTZ.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                switch (cameraLabel)
                {
                    case "A": IpA.Text = ""; break;
                    case "B": IpB.Text = ""; break;
                    case "X": IpX.Text = ""; break;
                    case "Y": IpY.Text = ""; break;
                }
                return;
            }
            if (channelID == 0)
            {
                SetCameraOffline(cameraLabel);
                return;
            }
            if (channelID > 0)
            {
                switch (cameraLabel)
                {
                    case "A": OnlineA.BackColor = Color.Green; ChannelA.Text = channelID.ToString(); break;
                    case "B": OnlineB.BackColor = Color.Green; ChannelB.Text = channelID.ToString(); break;
                    case "X": OnlineX.BackColor = Color.Green; ChannelX.Text = channelID.ToString(); break;
                    case "Y": OnlineY.BackColor = Color.Green; ChannelY.Text = channelID.ToString(); break;
                }
                if (cameraApi[CameraIndex(cameraLabel)] == "ISAPI")
                {
                    IsapiGetDeviceInfo(cameraLabel);
                    if (numPresets[CameraIndex(cameraLabel)] == 0) { IsapiGetPresets(cameraLabel); }
                }
                else
                {
                    CgiGetDeviceInfo(cameraLabel);
                    if (numPresets[CameraIndex(cameraLabel)] == 0) { CgiGetPresets(cameraLabel); }
                }
                if (cameraLabel == activeCamera) { SetCameraControls(); SwitchVideo("ON"); }
            }
        }

        private int IsapiGetPtzChannel(string cameraLabel)
        {
            try
            {
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                HttpRequestMessage cameraRequest = new(method: HttpMethod.Get, requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                                                   "/ISAPI/PTZCtrl/channels"));
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
                string? cameraStream = cameraResponse.Content.ReadAsStringAsync().Result;
                string? Xml = cameraStream;
                if (string.IsNullOrEmpty(Xml)) { return 0; }
                var xElement = XElement.Parse(Xml);
                XNamespace ns = "http://www.hikvision.com/ver20/XMLSchema";
                var ptzChannelElement = xElement.Element(ns + "PTZChannel");
                var enabledElement = ptzChannelElement?.Element(ns + "enabled");
                if (enabledElement != null && enabledElement.Value == "true")
                {
                    var videoInputIDElement = ptzChannelElement?.Element(ns + "videoInputID");
                    string channelID = videoInputIDElement != null ? videoInputIDElement.Value : string.Empty;
                    cameraApi[CameraIndex(cameraLabel)] = "ISAPI";
                    return int.Parse(channelID);
                }
                else { return -1; }
            }
            catch { return 0; }
        }

        private int CgiGetPtzChannel(string cameraLabel)
        {
            for (int tryChannel = 1; tryChannel <= 4; tryChannel++)
            {
                try
                {
                    var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                    HttpRequestMessage cameraRequest = new(method: HttpMethod.Get,
                                                           requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                               "/cgi-bin/ptz.cgi?action=getCurrentProtocolCaps&channel=" +
                                                                               tryChannel.ToString()));
                    var cameraResponse = cameraClient.Send(cameraRequest);
                    cameraResponse.EnsureSuccessStatusCode();
                    string? cameraStream = cameraResponse.Content.ReadAsStringAsync().Result;
                    if (string.IsNullOrEmpty(cameraStream)) { continue; }
                    if (!cameraStream.Contains("Pan=true") || !cameraStream.Contains("Tile=true") || !cameraStream.Contains("Zoom=true")) { continue; }
                    cameraApi[CameraIndex(cameraLabel)] = "CGI";
                    return tryChannel;
                }
                catch { return 0; }
            }
            return -1;
        }

        private void IsapiGetDeviceInfo(string cameraLabel)
        {
            try
            {
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                HttpRequestMessage cameraRequest = new(method: HttpMethod.Get, requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                                                   "/ISAPI/System/deviceInfo"));
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
                var cameraStream = cameraResponse.Content.ReadAsStringAsync().Result;
                var Xml = cameraStream;
                if (string.IsNullOrEmpty(Xml)) { return; }
                var xElement = XElement.Parse(Xml);
                XNamespace ns = "http://www.hikvision.com/ver20/XMLSchema";
                var deviceNameElement = xElement.Element(ns + "deviceName");
                switch (cameraLabel)
                {
                    case "A": if (deviceNameElement != null) { NameA.Text = deviceNameElement.Value; } else { NameA.Text = ""; } break;
                    case "B": if (deviceNameElement != null) { NameB.Text = deviceNameElement.Value; } else { NameB.Text = ""; } break;
                    case "X": if (deviceNameElement != null) { NameX.Text = deviceNameElement.Value; } else { NameX.Text = ""; } break;
                    case "Y": if (deviceNameElement != null) { NameY.Text = deviceNameElement.Value; } else { NameY.Text = ""; } break;
                }
                var modelElement = xElement.Element(ns + "model");
                switch (cameraLabel)
                {
                    case "A": if (modelElement != null) { ModelA.Text = modelElement.Value; } break;
                    case "B": if (modelElement != null) { ModelB.Text = modelElement.Value; } break;
                    case "X": if (modelElement != null) { ModelX.Text = modelElement.Value; } break;
                    case "Y": if (modelElement != null) { ModelY.Text = modelElement.Value; } break;
                }
            }
            catch { return; }
        }

        private void CgiGetDeviceInfo(string cameraLabel)
        {
            try
            {
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                HttpRequestMessage cameraRequest = new(method: HttpMethod.Get, requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                                                   "/cgi-bin/magicBox.cgi?action=getDeviceType"));
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
                var cameraStream = cameraResponse.Content.ReadAsStringAsync().Result;
                cameraStream = cameraStream[5..].ReplaceLineEndings(String.Empty);
                switch (cameraLabel)
                {
                    case "A": if (cameraStream != null) { ModelA.Text = cameraStream; } break;
                    case "B": if (cameraStream != null) { ModelB.Text = cameraStream; } break;
                    case "X": if (cameraStream != null) { ModelX.Text = cameraStream; } break;
                    case "Y": if (cameraStream != null) { ModelY.Text = cameraStream; } break;
                }
                cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                HttpRequestMessage cameraRequest2 = new(method: HttpMethod.Get, requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                                                    "/cgi-bin/magicBox.cgi?action=getMachineName "));
                cameraResponse = cameraClient.Send(cameraRequest2);
                cameraResponse.EnsureSuccessStatusCode();
                cameraStream = cameraResponse.Content.ReadAsStringAsync().Result;
                cameraStream = cameraStream[5..].ReplaceLineEndings(String.Empty);
                switch (cameraLabel)
                {
                    case "A": if (cameraStream != null) { NameA.Text = cameraStream; } break;
                    case "B": if (cameraStream != null) { NameB.Text = cameraStream; } break;
                    case "X": if (cameraStream != null) { NameX.Text = cameraStream; } break;
                    case "Y": if (cameraStream != null) { NameY.Text = cameraStream; } break;
                }
            }
            catch { return; }
        }

        private void IsapiGetPresets(string cameraLabel)
        {
            allPresets[CameraIndex(cameraLabel), 0] = " ";
            try
            {
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                HttpRequestMessage cameraRequest = new(method: HttpMethod.Get, requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                                                   "/ISAPI/PTZCtrl/channels/" +
                                                                                                   GetCameraChannel(cameraLabel) + "/presets"));
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
                var cameraStream = new StreamReader(cameraResponse.Content.ReadAsStreamAsync().Result).ReadToEnd();
                var Xml = cameraStream;
                if (string.IsNullOrEmpty(Xml)) { return; }
                var xElement = XElement.Parse(Xml);
                XNamespace ns = "http://www.hikvision.com/ver20/XMLSchema";
                for (int i = 1; i < 100; i++) { allPresets[CameraIndex(cameraLabel), i] = ""; }
                int j = 1;
                foreach (XElement PTZPresetElement in xElement.Elements())
                {
                    var idElement = PTZPresetElement?.Element(ns + "id");
                    if (idElement != null) { allPresets[CameraIndex(cameraLabel), j] = int.Parse(idElement.Value).ToString("000"); }
                    var presetNameElement = PTZPresetElement?.Element(ns + "presetName");
                    if (presetNameElement != null)
                    {
                        allPresets[CameraIndex(cameraLabel), j] += " > " + presetNameElement.Value;
                    }
                    j++;
                    numPresets[CameraIndex(cameraLabel)] = j - 1;
                    if (j == 100) { break; }
                }
            }
            catch { return; }
        }

        private void CgiGetPresets(string cameraLabel)
        {
            allPresets[CameraIndex(cameraLabel), 0] = " ";
            try
            {
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
                HttpRequestMessage cameraRequest = new(method: HttpMethod.Get, requestUri: new Uri("http://" + GetCameraIP(cameraLabel) +
                                                                                                   "/cgi-bin/ptz.cgi?action=getPresets&channel=" +
                                                                                                   GetCameraChannel(cameraLabel)));
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
                var cameraStream = new StreamReader(cameraResponse.Content.ReadAsStreamAsync().Result).ReadToEnd();
                var lines = cameraStream.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
                var regex = new Regex(@"presets\[(?<index>\d+)\].(?<property>\w+)=(?<value>.*)");
                foreach (var line in lines)
                {
                    var match = regex.Match(line);
                    if (match.Success)
                    {
                        int index = int.Parse(match.Groups["index"].Value);
                        string property = match.Groups["property"].Value;
                        string value = match.Groups["value"].Value;
                        if (property == "Index")
                        {
                            numPresets[CameraIndex(cameraLabel)] = int.Parse(value);
                        }
                        else if (property == "Name")
                        {
                            allPresets[CameraIndex(cameraLabel), numPresets[CameraIndex(cameraLabel)]] = numPresets[CameraIndex(cameraLabel)].ToString("000") +
                                                                                                                    " > " + value;
                        }
                        if (numPresets[CameraIndex(cameraLabel)] == 100) { break; }
                    }
                }
            }
            catch { return; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SetPresetBoxes()
        {
            ClearPresetBoxes();
            int i = 0;
            while (allPresets[CameraIndex(activeCamera), i] != null && allPresets[CameraIndex(activeCamera), i] != "")
            {
                MenuBox.Items.Add(allPresets[CameraIndex(activeCamera), i]);
                ViewBox.Items.Add(allPresets[CameraIndex(activeCamera), i]);
                LtBox.Items.Add(allPresets[CameraIndex(activeCamera), i]);
                RtBox.Items.Add(allPresets[CameraIndex(activeCamera), i]);
                LbBox.Items.Add(allPresets[CameraIndex(activeCamera), i]);
                RbBox.Items.Add(allPresets[CameraIndex(activeCamera), i]);
                i++;
            }
            MenuBox.SelectedIndex = activePresets[CameraIndex(activeCamera), 0];
            ViewBox.SelectedIndex = activePresets[CameraIndex(activeCamera), 1];
            LtBox.SelectedIndex = activePresets[CameraIndex(activeCamera), 2];
            RtBox.SelectedIndex = activePresets[CameraIndex(activeCamera), 3];
            LbBox.SelectedIndex = activePresets[CameraIndex(activeCamera), 4];
            RbBox.SelectedIndex = activePresets[CameraIndex(activeCamera), 5];
            PresetsDropdownPanel.Enabled = true;
        }

        private void ClearPresetBoxes()
        {
            MenuBox.Items.Clear();
            ViewBox.Items.Clear();
            LtBox.Items.Clear();
            RtBox.Items.Clear();
            LbBox.Items.Clear();
            RbBox.Items.Clear();
            PresetsDropdownPanel.Enabled = false;
        }

        private void DefaultActivePresets(string selectedCamera)
        {
            for (int i = 1; i <= 6; i++)
            {
                if (i <= numPresets[CameraIndex(selectedCamera)]) { activePresets[CameraIndex(selectedCamera), i - 1] = i; }
                else { activePresets[CameraIndex(selectedCamera), i - 1] = 0; }
            }
        }

        private void PresetSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox sentComboBox = (ComboBox)sender;
            switch (sentComboBox.Name)
            {
                case "MenuBox": activePresets[CameraIndex(activeCamera), 0] = MenuBox.SelectedIndex; break;
                case "ViewBox": activePresets[CameraIndex(activeCamera), 1] = ViewBox.SelectedIndex; break;
                case "LtBox": activePresets[CameraIndex(activeCamera), 2] = LtBox.SelectedIndex; break;
                case "RtBox": activePresets[CameraIndex(activeCamera), 3] = RtBox.SelectedIndex; break;
                case "LbBox": activePresets[CameraIndex(activeCamera), 4] = LbBox.SelectedIndex; break;
                case "RbBox": activePresets[CameraIndex(activeCamera), 5] = RbBox.SelectedIndex; break;
            }
            VideoView.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ControllerNum_ValueChanged(object sender, EventArgs e)
        {
            UserIndex userIndex = (UserIndex)((int)ControllerNum.Value - 1);
            controller = new(userIndex);
            VideoView.Focus();
            if (controller.IsConnected)
            {
                Capabilities capabilities = controller.GetCapabilities(deviceQueryType: (DeviceQueryType)((int)ControllerNum.Value - 1));
                controllerName = capabilities.Type.ToString();
            }
            UpdateGui();
        }

        private string CameraButtonSelected()
        {
            if ((currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))) return "A";
            else if ((currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))) return "B";
            else if ((currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))) return "X";
            else if ((currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))) return "Y";
            else return "";
        }

        private void ProcessControllerInput()
        {
            if (swapJoysticks)
            {
                (currReading.Gamepad.RightThumbX, currReading.Gamepad.LeftThumbX) = (currReading.Gamepad.LeftThumbX, currReading.Gamepad.RightThumbX);
                (currReading.Gamepad.RightThumbY, currReading.Gamepad.LeftThumbY) = (currReading.Gamepad.LeftThumbY, currReading.Gamepad.RightThumbY);
            }
            int pan = (int)(Math.Truncate((double)currReading.Gamepad.RightThumbX / 32768 * 10) * 10);
            pan = Math.Max(Math.Min((int)Math.Round((double)pan / 15) * 15, 100), -100);
            int tilt = (int)(Math.Truncate((double)currReading.Gamepad.RightThumbY / 32768 * 10) * 10);
            tilt = Math.Max(Math.Min((int)Math.Round((double)tilt / 15) * 15, 100), -100);
            int zoom = (int)(Math.Truncate((double)currReading.Gamepad.LeftThumbY / 32768 * 10) * 10);
            zoom = Math.Max(Math.Min((int)Math.Round((double)zoom / 15) * 15, 100), -100);
            if (pan != prevPan || tilt != prevTilt || zoom != prevZoom)
            {
                CameraPanTiltZoom(activeCamera, pan, tilt, zoom);
                prevPan = pan; prevTilt = tilt; prevZoom = zoom;
            }

            int focus = 0;
            if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp)) { focus = 50; }
            else if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown)) { focus = -50; }
            if (focus != prevFocus)
            {
                CameraFocus(activeCamera, focus);
                prevFocus = focus;
            }

            int iris = 0;
            if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight)) { iris = 50; }
            else if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft)) { iris = -50; }
            if (iris != prevIris)
            {
                CameraIris(activeCamera, iris);
                prevIris = iris;
            }

            if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back) && MenuBox.Text != " ")
            {
                CameraPreset(activeCamera, int.Parse(MenuBox.Text.ToString()[..3]));
            }
            else if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start) && ViewBox.Text != " ")
            {
                CameraPreset(activeCamera, int.Parse(ViewBox.Text.ToString()[..3]));
            }
            else if (currReading.Gamepad.LeftTrigger > 200 && LtBox.Text != " ")
            {
                CameraPreset(activeCamera, int.Parse(LtBox.Text.ToString()[..3]));
            }
            else if (currReading.Gamepad.RightTrigger > 200 && RtBox.Text != " ")
            {
                CameraPreset(activeCamera, int.Parse(RtBox.Text.ToString()[..3]));
            }
            else if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder) && LbBox.Text != " ")
            {
                CameraPreset(activeCamera, int.Parse(LbBox.Text.ToString()[..3]));
            }
            else if (currReading.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder) && RbBox.Text != " ")
            {
                CameraPreset(activeCamera, int.Parse(RbBox.Text.ToString()[..3]));
            }
        }

        private void CameraPanTiltZoom(string cameraLabel, int pan, int tilt, int zoom)
        {
            if (cameraApi[CameraIndex(cameraLabel)] == "ISAPI")
            {
                CameraCommand(cameraLabel, "PTZ", "/ISAPI/PTZCtrl/channels/" + GetCameraChannel(cameraLabel) + "/continuous",
                                                  "<PTZData><pan>" + pan + "</pan><tilt>" + tilt + "</tilt><zoom>" + zoom + "</zoom></PTZData>");
            }
            else if (cameraApi[CameraIndex(cameraLabel)] == "CGI")
            {
                string action;
                if (pan == 0 && tilt == 0 && zoom == 0) { action = "stop"; } else { action = "start"; }
                pan = Math.Max(Math.Min((int)Math.Round((double)pan / 12), 8), -8);
                tilt = Math.Max(Math.Min((int)Math.Round((double)tilt / 12), 8), -8);
                CameraCommand(cameraLabel, "PTZ", "/cgi-bin/ptz.cgi?action=" + action + "&channel=" + GetCameraChannel(cameraLabel) +
                                                  "&code=Continuously&arg1=" + pan + "&arg2=" + tilt + "&arg3=" + zoom +
                                                  "&arg4=" + cgiTimeoutValue, "");
            }
        }

        private void CameraFocus(string cameraLabel, int focus)
        {
            if (cameraApi[CameraIndex(cameraLabel)] == "ISAPI")
            {
                CameraCommand(cameraLabel, "Focus", "/ISAPI/System/Video/inputs/channels/" + GetCameraChannel(cameraLabel) + "/focus",
                                                    "<FocusData><focus>" + focus + "</focus></FocusData>");
            }
            else if (cameraApi[CameraIndex(cameraLabel)] == "CGI")
            {
                string action, code;
                if (focus > 0) { action = "start"; code = "FocusNear"; }
                else if (focus < 0) { action = "start"; code = "FocusFar"; }
                else { action = "stop"; code = "FocusNear"; }
                CameraCommand(cameraLabel, "Focus", "/cgi-bin/ptz.cgi?action=" + action + "&channel=" + GetCameraChannel(cameraLabel) +
                                                    "&code=" + code + "&arg1=0&arg2=0&arg3=0", "");
            }
        }

        private void CameraIris(string cameraLabel, int iris)
        {
            if (cameraApi[CameraIndex(cameraLabel)] == "ISAPI")
            {
                CameraCommand(cameraLabel, "Iris", "/ISAPI/System/Video/inputs/channels/" + GetCameraChannel(cameraLabel) + "/iris",
                                                   "<IrisData><iris>" + iris + "</iris></IrisData>");
            }
            else if (cameraApi[CameraIndex(cameraLabel)] == "CGI")
            {
                string action, code;
                if (iris > 0) { action = "start"; code = "IrisLarge"; }
                else if (iris < 0) { action = "start"; code = "IrisSmall"; }
                else { action = "stop"; code = "IrisLarge"; }
                CameraCommand(cameraLabel, "Iris", "/cgi-bin/ptz.cgi?action=" + action + "&channel=" + GetCameraChannel(cameraLabel) +
                                                   "&code=" + code + "&arg1=0&arg2=0&arg3=0", "");
            }
        }

        private void CameraPreset(string cameraLabel, int preset)
        {
            if (cameraApi[CameraIndex(cameraLabel)] == "ISAPI")
            {
                CameraCommand(cameraLabel, "Preset", "/ISAPI/PTZCtrl/channels/" + GetCameraChannel(cameraLabel) +
                                           "/presets/" + preset + "/goto", "");
            }
            else if (cameraApi[CameraIndex(cameraLabel)] == "CGI")
            {
                CameraCommand(cameraLabel, "Preset", "/cgi-bin/ptz.cgi?action=start&channel=" + GetCameraChannel(cameraLabel) +
                                                     "&code=GotoPreset&arg1=0&arg2=" + preset + "&arg3=0", "");
            }
        }

        private void StopPTZmovement(string cameraToStop)
        {
            CameraPanTiltZoom(cameraToStop, 0, 0, 0); CameraFocus(cameraToStop, 0); CameraIris(cameraToStop, 0);
            prevPan = 0; prevTilt = 0; prevZoom = 0; prevFocus = 0; prevIris = 0;
        }

        private void CameraCommand(string cameraLabel, string commandType, string path, string body)
        {
            var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(httpTimeout) };
            try
            {
                var cameraRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("http://" + GetCameraIP(cameraLabel) + path),
                    Content = new StringContent(body, System.Text.Encoding.UTF8)
                };
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
            }
            catch { if (!(cameraApi[CameraIndex(cameraLabel)] == "CGI" && commandType == "Preset")) { SetCameraOffline(cameraLabel); } }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SwitchVideo(string videoSwitch)
        {
            if (videoSwitch == "OFF" && videoIsOn && VideoView.MediaPlayer is not null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(stateInfo => { try { VideoView.MediaPlayer.Stop(); } catch { } });
                videoIsOn = false;
            }
            else if (videoSwitch == "ON" && !videoIsOn && !NoStream.Checked && IsOnline(activeCamera) && this.WindowState != FormWindowState.Minimized)
            {
                string ip = GetCameraIP(activeCamera);
                string channel, stream, uri;
                if (cameraApi[CameraIndex(activeCamera)] == "ISAPI")
                {
                    if (MainStream.Checked) { stream = "01"; } else { stream = "02"; }
                    if (ip.Contains(":65"))
                    {
                        ip = ip[..^6];
                        channel = string.Concat(GetCameraIP(activeCamera).AsSpan(GetCameraIP(activeCamera).Length - 2), stream);
                        if (string.Equals(channel[0], "0")) { channel = channel[1..]; }
                    }
                    else
                    {
                        channel = GetCameraChannel(activeCamera) + stream;
                    }
                    uri = "rtsp://" + Username.Text + ":" + Password.Text + "@" + ip + ":554/Streaming/channels/" + channel + "?transport=udp";
                }
                else
                {
                    if (MainStream.Checked) { stream = "0"; } else { stream = "1"; }
                    channel = GetCameraChannel(activeCamera);
                    uri = "rtsp://" + Username.Text + ":" + Password.Text + "@" + ip + ":554/cam/realmonitor?channel=" + channel + "&subtype=" + stream;
                }
                using var libvlc = new LibVLC();
                using var media = new Media(libvlc, new Uri(@uri));
                if (AudioOn.Checked == false) { media.AddOption(":no-audio"); }
                VideoView.MediaPlayer = new MediaPlayer(media) { NetworkCaching = (uint)vlcBuffer, Scale = 0 };
                if (FitScreen.Checked) { VideoView.MediaPlayer.AspectRatio = VideoView.Width + ":" + VideoView.Height; }
                VideoView.MediaPlayer.EnableHardwareDecoding = HardwareDecode.Checked;
                VideoView.MediaPlayer.Play();
                videoIsOn = true;
            }
        }

        private void RestartVideo(object sender, EventArgs e)
        {
            if (iniFileLoaded) { SwitchVideo("OFF"); SwitchVideo("ON"); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                this.ShowIcon = true;
                notifyIcon.Visible = false;
                SwitchVideo("ON");
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                SwitchVideo("OFF");
            }
        }

        private void Form1_Normal(object sender, EventArgs e)
        {
            contextMenuStrip.Close();
            this.WindowState = FormWindowState.Normal;
        }

        private void StartButton_EnabledChanged(object sender, EventArgs e)
        {
            ToolStripStart.Enabled = StartButton.Enabled;
        }

        private void StopButton_EnabledChanged(object sender, EventArgs e)
        {
            ToolStripStop.Enabled = StopButton.Enabled;
        }

        private void ToolStripClose_Click(object sender, EventArgs e)
        {
            Form1_FormClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Form2 Form2 = new();
            Form2.Show();
            Form2.Activate();
            Form2.FormClosed += (s, args) =>
            {
                this.Enabled = true;
                if (StartButton.Enabled) { StartButton.Focus(); } else { UserPanel.Focus(); }
            };
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static int CameraIndex(string cameraLabel)
        {
            return cameraLabel switch { "A" => 0, "B" => 1, "X" => 2, "Y" => 3, _ => -1 };
        }

        private string GetCameraIP(string cameraLabel)
        {
            return cameraLabel switch { "A" => IpA.Text, "B" => IpB.Text, "X" => IpX.Text, "Y" => IpY.Text, _ => "" };
        }

        private string GetCameraChannel(string cameraLabel)
        {
            return cameraLabel switch { "A" => ChannelA.Text, "B" => ChannelB.Text, "X" => ChannelX.Text, "Y" => ChannelY.Text, _ => "" };
        }

        private string GetCameraName(string cameraLabel)
        {
            return cameraLabel switch { "A" => NameA.Text, "B" => NameB.Text, "X" => NameX.Text, "Y" => NameY.Text, _ => "" };
        }

        private bool IsOnline(string cameraLabel)
        {
            return cameraLabel switch
            {
                "A" => OnlineA.BackColor == Color.Green,
                "B" => OnlineB.BackColor == Color.Green,
                "X" => OnlineX.BackColor == Color.Green,
                "Y" => OnlineY.BackColor == Color.Green,
                 _  => false
            };
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoadIniFile()
        {
            if (File.Exists("XInput_PTZ_Controller.ini"))
            {
                var iniFile = File.OpenRead("XInput_PTZ_Controller.ini");
                var iniReader = new StreamReader(iniFile);
                Username.Text = iniReader.ReadLine();
                Password.Text = iniReader.ReadLine();
                if (Password.Text != "") { SavePassword.Checked = true; } else { Password.Select(); }
                if (iniReader.ReadLine() == "True") { StartMinimized.Checked = true; } else { StartMinimized.Checked = false; }
                IpA.Text = iniReader.ReadLine();
                IpB.Text = iniReader.ReadLine();
                IpX.Text = iniReader.ReadLine();
                IpY.Text = iniReader.ReadLine();
                ControllerNum.Value = decimal.Parse(iniReader.ReadLine()!);
                activeCamera = iniReader.ReadLine()!;
                if (iniReader.ReadLine() == "True") { AudioOn.Checked = true; } else { AudioOn.Checked = false; }
                if (iniReader.ReadLine() == "True") { HardwareDecode.Checked = true; } else { HardwareDecode.Checked = false; }
                if (iniReader.ReadLine() == "True") { FitScreen.Checked = true; } else { FitScreen.Checked = false; }
                if (iniReader.ReadLine() == "True") { SubStream.Checked = true; } else { SubStream.Checked = false; }
                if (iniReader.ReadLine() == "True") { MainStream.Checked = true; } else { MainStream.Checked = false; }
                if (iniReader.ReadLine() == "True") { NoStream.Checked = true; } else { NoStream.Checked = false; }
                firstApi = iniReader.ReadLine()!;
                httpTimeout = int.Parse(iniReader.ReadLine()!);
                pollingDelay = int.Parse(iniReader.ReadLine()!);
                cgiTimeoutValue = int.Parse(iniReader.ReadLine()!);
                swapJoysticks = bool.Parse(iniReader.ReadLine()!);
                vlcBuffer = int.Parse(iniReader.ReadLine()!);
                pollCameras = bool.Parse(iniReader.ReadLine()!);
                pollCamerasTime = int.Parse(iniReader.ReadLine()!);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        string? tempStr = iniReader.ReadLine();
                        if (tempStr is not null) { activePresets[i, j] = int.Parse(tempStr); }
                    }
                }
                iniFile.Close();
            }
            iniFileLoaded = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsOnline(activeCamera)) { StopPTZmovement(activeCamera); }
            if (!SavePassword.Checked) { Password.Text = ""; StartMinimized.Checked = false; }
            string iniFileText = Username.Text + Environment.NewLine +
                                 Password.Text + Environment.NewLine +
                                 StartMinimized.Checked.ToString() + Environment.NewLine +
                                 IpA.Text + Environment.NewLine +
                                 IpB.Text + Environment.NewLine +
                                 IpX.Text + Environment.NewLine +
                                 IpY.Text + Environment.NewLine +
                                 ControllerNum.Value.ToString() + Environment.NewLine +
                                 activeCamera + Environment.NewLine +
                                 AudioOn.Checked.ToString() + Environment.NewLine +
                                 HardwareDecode.Checked.ToString() + Environment.NewLine +
                                 FitScreen.Checked.ToString() + Environment.NewLine +
                                 SubStream.Checked.ToString() + Environment.NewLine +
                                 MainStream.Checked.ToString() + Environment.NewLine +
                                 NoStream.Checked.ToString() + Environment.NewLine +
                                 firstApi + Environment.NewLine +
                                 httpTimeout.ToString() + Environment.NewLine +
                                 pollingDelay.ToString() + Environment.NewLine +
                                 cgiTimeoutValue.ToString() + Environment.NewLine +
                                 swapJoysticks.ToString() + Environment.NewLine +
                                 vlcBuffer.ToString() + Environment.NewLine +
                                 pollCameras.ToString() + Environment.NewLine +
                                 pollCamerasTime.ToString() + Environment.NewLine;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    iniFileText += activePresets[i, j] + Environment.NewLine;
                }
            }
            File.WriteAllText("XInput_PTZ_Controller.ini", iniFileText);
            applicationExit = true;
        }
    }
}