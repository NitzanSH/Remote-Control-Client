using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using DuplexClient.ServiceReference1;

namespace DuplexClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /* Capture screen
    Bitmap scrImg = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
    Graphics scr;
    scr.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
    testPictureBox.Image = (Image)scrImg;
    */
    public partial class MainWindow : Window
    {
        DuplexCalculator12Client server;
        System.Windows.Forms.Timer myTimer;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                server = new DuplexCalculator12Client();
                //server.SendScreenshot(null);
               
                myTimer = new System.Windows.Forms.Timer();
                myTimer.Tick += new EventHandler(screenShotSnaper);
                myTimer.Start();
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Server error.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }


        }

        public void CallBackClosed(string str)
        {
            System.Windows.MessageBox.Show("Closed Server says: " + str + "\nSo bye");
            Close();
        }
        

        private void screenShotSnaper(Object myObject, EventArgs myEventArgs)
        {
            Bitmap bitmap = CaptureScreen(true);
            //Graphics graphics;
            //bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //graphics = Graphics.FromImage(bitmap as System.Drawing.Image);
            //graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapimage));
                encoder.Save(memory);
                data = memory.ToArray();


                /*int a =*/ server.SendScreenshot(data);

            }

            Thread.Sleep(1);
            
        }



        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const int CURSOR_SHOWING = 0x00000001;

        public static Bitmap CaptureScreen(bool CaptureMouse)
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    if (CaptureMouse)
                    {
                        CURSORINFO pci;
                        pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out pci))
                        {
                            if (pci.flags == CURSOR_SHOWING)
                            {
                                DrawIcon(g.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("ASD");

        }
    }
}



