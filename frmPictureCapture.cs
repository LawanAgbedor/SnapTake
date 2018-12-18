using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace SnapTake
{
    public enum Buttons
    {
        Capture,
        Ready,
        Save,
        Stop
    }

    public enum ButtonState
    {
        Enabled,
        Disabled
    }

    public partial class frmPictureCapture : Form
    {
        private static Logger<frmPictureCapture> log = new Logger<frmPictureCapture>();

        private frmBusy busyForm = null;

        private List<Tuple<ButtonState, Buttons, Color>> ButtonStatusColor =
            new List<Tuple<ButtonState, Buttons, Color>>
            {
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Enabled, Buttons.Capture, Color.FromArgb(0, 192, 0)),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Enabled, Buttons.Ready, Color.FromArgb(255, 128, 0)),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Enabled, Buttons.Save, Color.FromArgb(Color.Blue.ToArgb())),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Enabled, Buttons.Stop, Color.FromArgb(Color.Red.ToArgb())),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Disabled, Buttons.Capture, Color.FromArgb(192, 255, 192)),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Disabled, Buttons.Ready, Color.FromArgb(255, 224, 192)),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Disabled, Buttons.Save, Color.FromArgb(192, 225, 255)),
                new Tuple<ButtonState, Buttons, Color>(ButtonState.Disabled, Buttons.Stop, Color.FromArgb(255, 192, 192)),
            };

        private bool takeAShot = false;
        private Bitmap capturedImage = null;
        private FilterInfoCollection videoCaptureDevices;
        private VideoCaptureDevice videoCaptureDevice;

        private Color GetButtonBackColor(Buttons button, ButtonState state)
        {
            return ButtonStatusColor.Find(a => a.Item1 == state && a.Item2 == button).Item3;
        }

        private Color GetButtonForeColor(ButtonState state)
        {
            return state == ButtonState.Enabled ? Color.White : Color.Gainsboro;
        }

        public void DisableButtonAll() {
            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
            {
                DisableButton(button);
            }
        }

        public void DisableButton(Buttons button)
        {
            EnableDisableButton(button, ButtonState.Disabled);
        }

        public void EnableButton(Buttons button)
        {
            EnableDisableButton(button, ButtonState.Enabled);
        }

        private void EnableDisableButton(Buttons button, ButtonState buttonState)
        {
            var state = buttonState == ButtonState.Enabled;
            var foreColor = btCapture.ForeColor = GetButtonForeColor(buttonState);
            switch (button)
            {
                case Buttons.Capture:
                    btCapture.Enabled = state;
                    btCapture.ForeColor = foreColor;
                    btCapture.BackColor = GetButtonBackColor(Buttons.Capture, buttonState); break;
                case Buttons.Ready: btReady.Enabled = state;
                    btReady.ForeColor = foreColor;
                    btReady.BackColor = GetButtonBackColor(Buttons.Ready, buttonState); break;
                case Buttons.Save: btSave.Enabled = state;
                    btSave.ForeColor = foreColor;
                    btSave.BackColor = GetButtonBackColor(Buttons.Save, buttonState); break;
                case Buttons.Stop: btStop.Enabled = state;
                    btStop.ForeColor = foreColor;
                    btStop.BackColor = GetButtonBackColor(Buttons.Stop, buttonState); break;
            }
        }

        public frmPictureCapture()
        {
            InitializeComponent();

            busyForm = new frmBusy(this);

            DisableButtonAll();

            videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo vd in videoCaptureDevices)
            {
                comboBoxCameras.Items.Add(vd.Name);
            }

            if (videoCaptureDevices.Count > 0)
            {
                comboBoxCameras.SelectedIndex = 0;

                videoCaptureDevice = new VideoCaptureDevice(videoCaptureDevices[comboBoxCameras.SelectedIndex].MonikerString);

                foreach (var capability in videoCaptureDevice.VideoCapabilities)
                {
                    comboBoxModes.Items.Add(CapabilitiesToString(capability));
                }

                videoCaptureDevice.NewFrame += new NewFrameEventHandler(VideoCaptureDevice_NewFrame);

                //Read from config
                var videoResolutionIndex = 0;
                var lastCameraResolutionIndex = ConfigurationManager.AppSettings.Get("LastCameraResolutionIndex");
                if (!string.IsNullOrWhiteSpace(lastCameraResolutionIndex))
                {
                    videoResolutionIndex = Convert.ToInt16(videoResolutionIndex);
                }

                SetVideoResolution(videoCaptureDevice.VideoCapabilities[videoResolutionIndex]);

                RepositionPicture();

                EnableButton(Buttons.Ready);

            }

        }

        private string CapabilitiesToString(VideoCapabilities capability)
        {
            return $"{capability.FrameSize.ToString()}:{capability.MaximumFrameRate}:{capability.BitCount}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public delegate void SetImageDelegate(Bitmap image);

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); }

            Bitmap tempBitmap = (Bitmap)eventArgs.Frame.Clone();

            SetImage(tempBitmap);

            if (takeAShot)
            {
                takeAShot = false;
                capturedImage = (Bitmap)tempBitmap.Clone();
                videoCaptureDevice.SignalToStop();
            }
        }

        private void SetImage(Bitmap image)
        {
            try
            {
                if (this.pictureBox1.InvokeRequired)
                {
                    SetImageDelegate callback = new SetImageDelegate(SetImage);
                    this.BeginInvoke(callback, image);
                }
                else
                {
                    if (image == null)
                        pictureBox1.InitialImage = image;

                    pictureBox1.Image = image;
                }
            }
            catch (Exception e) {
                log.LogFatal("Call to Set Image Failed with an Exception.", null, e);
            };
        }

        private void btReady_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.Start();
            DisableButtonAll();
            EnableButton(Buttons.Capture);
            EnableButton(Buttons.Stop);
        }

        private void btCapture_Click(object sender, EventArgs e)
        {
            takeAShot = true;
            DisableButtonAll();
            EnableButton(Buttons.Save);
            EnableButton(Buttons.Stop);
        }

        private void SaveSnapshot()
        {
            string fileName = GetSnapFileName();
            DisableButtonAll();
            capturedImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void SetVideoResolution(VideoCapabilities capability)
        {
            videoCaptureDevice.VideoResolution = capability;

            pictureBox1.Width = capability.FrameSize.Width;
            pictureBox1.Height = capability.FrameSize.Height;
        }

        private void RepositionPicture()
        {
            pictureBox1.Top = (panel1.Height - pictureBox1.Height) / 2;
            pictureBox1.Left = (panel1.Width - pictureBox1.Width) / 2;
        }

        private void comboBoxModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopVideo();
            SetVideoResolution(videoCaptureDevice.VideoCapabilities[comboBoxModes.SelectedIndex]);
            RepositionPicture();
            videoCaptureDevice.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            StopVideo();
            DisableButtonAll();
            EnableButton(Buttons.Ready);
            SetImage(null);
        }

        private void frmPictureCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StopVideo();
            }
            catch { }
            finally
            {
                try
                {
                    videoCaptureDevice.Stop();
                }
                catch { }
            }            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DisableButtonAll();
            SaveSnapshot();
            videoCaptureDevice.Start();
            EnableButton(Buttons.Capture);
            EnableButton(Buttons.Stop);
        }

        private void StopVideo()
        {
            videoCaptureDevice.SignalToStop();
            videoCaptureDevice.WaitForStop();
            videoCaptureDevice.Stop();
        }

        private void picSettingsButton_Click(object sender, EventArgs e)
        {
            busyForm.Show();
        }

        private void frmPictureCapture_Move(object sender, EventArgs e)
        {
            busyForm.RepositionMe();
        }

        private void frmPictureCapture_SizeChanged(object sender, EventArgs e)
        {
            busyForm.ResizeMe();
        }

        private void btSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultCamera = comboBoxCameras.SelectedValue.ToString();
            Properties.Settings.Default.DefaultResolution = comboBoxModes.SelectedValue.ToString();

            Properties.Settings.Default.Save();
        }

        private string GetSnapFileName()
        {
            return "test-snapshot.jpg";
        }
    }
}
