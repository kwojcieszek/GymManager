using System;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Media.MediaProperties;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.Storage;
using System.IO;
using Windows.Media.Capture;

namespace CameraView
{
    internal class Camera
    {
        public async Task<bool> CameraCaptutre(MediaCapture capture)
        {
            try
            {
                var pictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
                var file = await pictures.SaveFolder.CreateFileAsync("CameraCaptutre.jpg", CreationCollisionOption.ReplaceExisting);

                using (var captureStream = new InMemoryRandomAccessStream())
                {
                    await capture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), captureStream);

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
                File.Delete("CameraCaptutre.jpg");

                throw new Exception("Error while capturing image", ex);
            }

            return true;
        }
    }
}
