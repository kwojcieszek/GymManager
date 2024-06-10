using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GymManager.Views;
using WpfScreenHelper;

namespace GymManager.Common
{
    public static class Helper
    {
        public static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);

            foreach(var b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetActiveWindow();

        public static bool GetApplicationActive()
        {
            var result = false;

            Invoke(() => result = AppView.ApplicationMainWindowIsActive);

            return result;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }

        public static TaskBarLocation GetTaskBar()
        {
            var taskBarLocation = TaskBarLocation.BOTTOM;
            var taskBarOnTopOrBottom = Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width;

            if(taskBarOnTopOrBottom)
            {
                if(Screen.PrimaryScreen.WorkingArea.Top > 0)
                {
                    taskBarLocation = TaskBarLocation.TOP;
                }
            }
            else
            {
                if(Screen.PrimaryScreen.WorkingArea.Left > 0)
                {
                    taskBarLocation = TaskBarLocation.LEFT;
                }
                else
                {
                    taskBarLocation = TaskBarLocation.RIGHT;
                }
            }

            return taskBarLocation;
        }

        public static int GetTaskBarHeigh()
        {
            return (int)(Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height);
        }

        public static int GetTaskBarStart()
        {
            return (int)(Screen.PrimaryScreen.Bounds.Height - GetTaskBarHeigh());
        }

        public static Window GetWindow(object dataContext)
        {
            if(Application.Current == null)
            {
                return null;
            }

            foreach(Window window in Application.Current.Windows)
            {
                if(window.DataContext == dataContext)
                {
                    return window;
                }
            }

            return null;
        }

        public static BitmapImage ImageToBitmapImage(byte[] array)
        {
            using var ms = new MemoryStream(array);
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            using var ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);

            return ms.ToArray();
        }

        public static void Invoke(Action action)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(action));
        }

        public enum TaskBarLocation
        {
            TOP,
            BOTTOM,
            LEFT,
            RIGHT
        }
    }
}