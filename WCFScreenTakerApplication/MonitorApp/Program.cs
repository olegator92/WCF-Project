using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorApp.ScreenService;
using System.Threading;
using Timer = System.Threading.Timer;

namespace MonitorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Timer object that knows to call TimerCallback
            // method once every 30 seconds.
            var timer = new Timer(TimerCallback, null, 0, 30000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            //Take screenshot
            var bmpScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                       Screen.PrimaryScreen.Bounds.Height,
                                       PixelFormat.Format32bppRgb);

            using (Graphics gr = Graphics.FromImage(bmpScreen))
            {
                gr.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                    0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            }

            var imgConverter = new ImageConverter();
            var screen = (byte[])imgConverter.ConvertTo(bmpScreen, typeof(byte[]));

            var time = DateTime.Now;
            Int32 cursorX = Cursor.Position.X;
            Int32 cursorY = Cursor.Position.Y;

            //Send data
            var client = new ScreenServiceClient();
            client.TakeScreen(screen, time, cursorX, cursorY);
        }
    }
}
