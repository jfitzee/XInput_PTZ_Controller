///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace XInput_PTZ_Controller
{
    public partial class Form2 : Form
    {
        readonly Form1? mainForm = Application.OpenForms["Form1"]! as Form1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1? mainForm = Application.OpenForms["Form1"]! as Form1;
            FirstApi.Text = mainForm!.firstApi;
            HttpTimeout.Value = mainForm!.httpTimeout;
            PollingDelay.Value = mainForm!.pollingDelay;
            CgiTimeout.Value = mainForm!.cgiTimeoutValue;
            SwapJoysticks.Checked = mainForm!.swapJoysticks;
            VlcBuffer.Value = mainForm!.vlcBuffer;
            PollCameras.Checked = mainForm!.pollCameras;
            PollCamerasTime.Value = mainForm!.pollCamerasTime;
        }

        private void SettingsCloseButton_Click(object sender, EventArgs e)
        {
            mainForm!.firstApi = FirstApi.Text;
            mainForm!.httpTimeout = (int)HttpTimeout.Value;
            mainForm!.pollingDelay = (int)PollingDelay.Value;
            mainForm!.cgiTimeoutValue = (int)CgiTimeout.Value;
            mainForm!.swapJoysticks = SwapJoysticks.Checked;
            mainForm!.vlcBuffer = (int)VlcBuffer.Value;
            mainForm!.pollCameras = PollCameras.Checked;
            mainForm!.pollCamerasTime = (int)PollCamerasTime.Value;
            this.Close();
        }

        private void PollCameras_CheckedChanged(object sender, EventArgs e)
        {
            if(PollCameras.Checked) { PollCamerasTime.Enabled = true; PollCamerasLabel.Enabled = true;  } 
            else { PollCamerasTime.Enabled = false; PollCamerasLabel.Enabled = false; }
        }
    }
}
