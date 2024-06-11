using MahApps.Metro.Controls;
using System;
using System.Windows;
using Windows.Media.Capture;
using MediaCaptureWPF;

namespace CameraView
{
    public partial class MainWindow : MetroWindow
    {
        private bool _initialized;
        private MediaCapture _capture;
        private readonly Camera _camera = new Camera();

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override async void OnActivated(EventArgs e)
        {
            if (_initialized)
                return;

            _initialized = true;

            try
            {
                _capture = new MediaCapture();

                await _capture.InitializeAsync(new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Video //No audio
                });

                var preview = new CapturePreview(_capture);

                this.Preview.Source = preview;

                await preview.StartAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(await _camera.CameraCaptutre(_capture))
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}