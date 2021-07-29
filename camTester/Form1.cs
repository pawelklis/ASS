using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ZXing;
using OpenCvSharp;
using System.Management;
using Emgu.CV;

namespace camTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnumerateCameras(camIdList);
            GetAllConnectedCameras();
        }

        public static List<CameraDevice> GetAllConnectedCameras()
        {
            int i = 0;
            var cameras = new List<CameraDevice>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                int openCvIndex = 0;
                foreach (var device in searcher.Get())
                {
                    cameras.Add(new CameraDevice()
                    {
                        Name = device["Caption"].ToString(),
                        Status = device["Status"].ToString(),
                        DeviceId = device["DeviceId"].ToString(),
                        OpenCvId = i
                    }); ; ;
                    ++i;
                }
            }
            return cameras;
        }

        public class CameraDevice
        {
            public int OpenCvId { get; set; }

            public string Name { get; set; }
            public string DeviceId { get; set; }
            public string Status { get; set; }
        }


        VideoCapture capture;
        OpenCvSharp.Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;


        // Declare required methods
        public void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            isCameraRunning = true;
            camera.Start();
        }
        public string ScanZxing(System.Drawing.Bitmap image)
        {
            // create a barcode reader instance
            var barcodeReader = new BarcodeReader();

            // create an in memory bitmap


            // decode the barcode from the in memory bitmap
            var barcodeResult = barcodeReader.Decode(image);

            // output results to console
            //Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
            //Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}");

            return barcodeResult?.Text;
        }
        private void CaptureCameraCallback()
        {
            try
            {
             

                frame = new OpenCvSharp.Mat();
                // capture = new VideoCapture((int)numericUpDown2.Value);
                try
                {
           capture = new VideoCapture((int)numericUpDown2.Value);
                capture.Open((int)numericUpDown2.Value);
                }
                catch (Exception)
                {

                    throw;
                }
     

                if (capture.IsOpened())
                {
                    while (isCameraRunning)
                    {
                        int zom = (int)numericUpDown1.Value;

                        capture.Read(frame);
                    image =Zoom( BitmapConverter.ToBitmap(frame), zom);

                    image = BitmapConverter.ToBitmap(frame);
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                        }
                        pictureBox1.Image =Zoom( MakeGrayscale3( image),zom);


                        string barcode = ScanZxing(Zoom( MakeGrayscale3(    BitmapConverter.ToBitmap(frame)   )   ,zom));
                        if (string.IsNullOrEmpty(barcode) == false)
                        {

                            listBox1.Invoke(new Action(() => listBox1.Items.Insert(0, DateTime.Now + " " + barcode)));


                            //Console.WriteLine(DateTime.Now + " " + barcode);
                            //Console.Beep();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

              
            }

        
        }

        public Bitmap Zoom(Bitmap originalBitmap,int zoomFactor)
        {
            System.Drawing.Size newSize = new System.Drawing.Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
            Bitmap bmp = new Bitmap(originalBitmap, newSize);
            return bmp;
        }

        public Bitmap ToGrayScale(Bitmap Bmp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return Bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            ck:

            CaptureCamera();

        }
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //return original;

            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);
            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });
            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();
            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);
            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
    
    public static Bitmap ConvertTo1Bit(Bitmap input)
        {
            var masks = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            var output = new Bitmap(input.Width, input.Height, PixelFormat.Format1bppIndexed);
            var data = new sbyte[input.Width, input.Height];
            var inputData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            try
            {
                var scanLine = inputData.Scan0;
                var line = new byte[inputData.Stride];
                for (var y = 0; y < inputData.Height; y++, scanLine += inputData.Stride)
                {
                    Marshal.Copy(scanLine, line, 0, line.Length);
                    for (var x = 0; x < input.Width; x++)
                    {
                        data[x, y] = (sbyte)(64 * (GetGreyLevel(line[x * 3 + 2], line[x * 3 + 1], line[x * 3 + 0]) - 0.5));
                    }
                }
            }
            finally
            {
                input.UnlockBits(inputData);
            }
            var outputData = output.LockBits(new Rectangle(0, 0, output.Width, output.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            try
            {
                var scanLine = outputData.Scan0;
                for (var y = 0; y < outputData.Height; y++, scanLine += outputData.Stride)
                {
                    var line = new byte[outputData.Stride];
                    for (var x = 0; x < input.Width; x++)
                    {
                        var j = data[x, y] > 0;
                        if (j) line[x / 8] |= masks[x % 8];
                        var error = (sbyte)(data[x, y] - (j ? 32 : -32));
                        if (x < input.Width - 1) data[x + 1, y] += (sbyte)(7 * error / 16);
                        if (y < input.Height - 1)
                        {
                            if (x > 0) data[x - 1, y + 1] += (sbyte)(3 * error / 16);
                            data[x, y + 1] += (sbyte)(5 * error / 16);
                            if (x < input.Width - 1) data[x + 1, y + 1] += (sbyte)(1 * error / 16);
                        }
                    }
                    Marshal.Copy(line, 0, scanLine, outputData.Stride);
                }
            }
            finally
            {
                output.UnlockBits(outputData);
            }
            return output;
        }

        public static double GetGreyLevel(byte r, byte g, byte b)
        {
            return (r * 0.299 + g * 0.587 + b * 0.114) / 255;
        }



        public List<CapDriver> drivers;
        static public List<int> camIdList = new List<int>();
       // static OpenCVDeviceEnumerator enumerator = new OpenCVDeviceEnumerator();

        public struct CapDriver
        {
            public int enumValue;
            public string enumName;
            public string comment;
        };
        public bool EnumerateCameras(List<int> camIdx)
        {
            camIdx.Clear();

            // list of all CAP drivers (see highgui_c.h)
            drivers = new List<CapDriver>();

            //drivers.Add(new CapDriver { enumValue = CaptureDevice.Fireware, "CV_CAP_MIL", "MIL proprietary drivers" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.VFW, enumName = "VFW", comment = "platform native" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.V4L, enumName = "V4L", comment = "platform native" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Firewire, enumName = "FireWire", comment = "IEEE 1394 drivers" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Fireware, enumName = "Fireware", comment = "IEEE 1394 drivers" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Qt, enumName = "Qt", comment = "Quicktime" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Unicap, enumName = "Unicap", comment = "Unicap drivers" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.DShow, enumName = "DSHOW", comment = "DirectShow (via videoInput)" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.PVAPI, enumName = "PVAPI", comment = "PvAPI, Prosilica GigE SDK" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.OpenNI, enumName = "OpenNI", comment = "OpenNI(for Kinect) " });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.OpenNI_ASUS, enumName = "OpenNI_ASUS", comment = "OpenNI(for Asus Xtion) " });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Android, enumName = "Android", comment = "Android" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.XIAPI, enumName = "XIAPI", comment = "XIMEA Camera API" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.AVFoundation, enumName = "AVFoundation", comment = "AVFoundation framework for iOS (OS X Lion will have the same API)" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Giganetix, enumName = "Giganetix", comment = "Smartek Giganetix GigEVisionSDK" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.MSMF, enumName = "MSMF", comment = "Microsoft Media Foundation (via videoInput)" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.WinRT, enumName = "WinRT", comment = "Microsoft Windows Runtime using Media Foundation" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.IntelPERC, enumName = "IntelPERC", comment = "Intel Perceptual Computing SDK" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.OpenNI2, enumName = "OpenNI2", comment = "OpenNI2 (for Kinect)" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.OpenNI2_ASUS, enumName = "OpenNI2_ASUS", comment = "OpenNI2 (for Asus Xtion and Occipital Structure sensors)" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.GPhoto2, enumName = "GPhoto2", comment = "gPhoto2 connection" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.GStreamer, enumName = "GStreamer", comment = "GStreamer" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.FFMPEG, enumName = "FFMPEG", comment = "Open and record video file or stream using the FFMPEG library" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Images, enumName = "Images", comment = "OpenCV Image Sequence (e.g. img_%02d.jpg)" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Aravis, enumName = "Aravis", comment = "Aravis SDK" });
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Android, enumName = "Android", comment = "andr" }); 
            drivers.Add(new CapDriver { enumValue = (int)CaptureDevice.Any, enumName = "any", comment = "andr" });


            string driverName, driverComment;
            int driverEnum;
            OpenCvSharp.Mat frame = new OpenCvSharp.Mat();
            bool found;
            Console.WriteLine("Searching for cameras IDs...");
            for (int drv = 0; drv < drivers.Count; drv++)
            {
                driverName = drivers[drv].enumName;
                driverEnum = drivers[drv].enumValue;
                driverComment = drivers[drv].comment;
                Console.WriteLine("Testing driver " + driverName);
                found = false;

                int maxID = 100; //100 IDs between drivers
                if (driverEnum == (int)CaptureDevice.VFW)
                    maxID = 10; //VWF opens same camera after 10 ?!?


                for (int idx = 0; idx < maxID; idx++)
                {

                    VideoCapture cap = new VideoCapture(driverEnum + idx);  // open the camera
                    if (cap.IsOpened())                  // check if we succeeded
                    {
                        found = true;
                        camIdx.Add(driverEnum + idx);  // vector of all available cameras
                        cap.Read(frame);
                        if (frame.Empty())
                            Console.WriteLine(driverName + "+" + idx + "\t opens: OK \t grabs: FAIL");
                        else
                            Console.WriteLine(driverName + "+" + idx + "\t opens: OK \t grabs: OK");
                    }
                    cap.Release();
                }
                if (!found) Console.WriteLine("Nothing !");

            }


            return (camIdx.Count() > 0); // returns success
        }
        Capture captureX;
        private void button2_Click(object sender, EventArgs e)
        {
            if (captureX == null)
            {
                try
                {
                   captureX = new Capture("http://127.0.0.1:5050/video");
                    captureX.ImageGrabbed += Capture_ImageGrabbed;
                    captureX.Grab();
                    captureX.Start();
                }


                catch (NullReferenceException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                catch (TypeInitializationException exc)
                {
                    MessageBox.Show(
                       "Attention: You have to copy all the assemblies and native libraries from an official release of EmguCV to the directory of the demo." +
                       Environment.NewLine + Environment.NewLine + exc);
                }
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            Emgu.CV.Mat image = new Emgu.CV.Mat();
            captureX.Retrieve(image);
            pictureBox1.Image = image.Bitmap;
        }


    }























}

