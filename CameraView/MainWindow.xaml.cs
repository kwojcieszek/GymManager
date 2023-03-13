using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using MediaCaptureWPF;

namespace CameraView
{
    public partial class MainWindow : MetroWindow
    {
        bool m_initialized;
        MediaCapture _capture;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override async void OnActivated(EventArgs e)
        {
            if (m_initialized)
                return;

            m_initialized = true;

            try
            {
                _capture = new MediaCapture();
                await _capture.InitializeAsync(new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Video // No audio
                });

                var preview = new CapturePreview(_capture);

                this.Preview.Source = preview;
                await preview.StartAsync();
            }
            catch
            {
            }
        }

        private async void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            await CameraCaptutre();
        }
        private async Task CameraCaptutre()
        {
            try
            {
                var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
                var file = await myPictures.SaveFolder.CreateFileAsync("CameraCaptutre.jpg", CreationCollisionOption.ReplaceExisting);

                using (var captureStream = new InMemoryRandomAccessStream())
                {
                    await _capture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), captureStream);

                    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(captureStream);
                        var encoder = await Windows.Graphics.Imaging.BitmapEncoder.CreateForTranscodingAsync(fileStream, decoder);

                        var properties = new BitmapPropertySet
                        {
                            {
                                "System.Photo.Orientation", new BitmapTypedValue(PhotoOrientation.Normal, PropertyType.UInt16)
                            }
                        };
                        await encoder.BitmapProperties.SetPropertiesAsync(properties);

                        await encoder.FlushAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                File.Delete("test.png");

                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}
