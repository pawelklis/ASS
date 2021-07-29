using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Threading;

namespace ASS
{
    class CamScannerCVType
    {
        public class CamScannerEventArgs
        {
            public string Barcode { get; set; }
        }

        Emgu.CV.Capture captureX;


        VideoCapture capture;
        OpenCvSharp.Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;

        public string CameraAdres { get; set; }

        public EventHandler<CamScannerEventArgs> OnBarcodeReaded;


        // Declare required methods
        public void CaptureCamera(string camaddress)
        {
            CameraAdres = camaddress;
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            isCameraRunning = true;
            camera.Start();
            
        }
        public void STOP()
        {
            camera.Abort();
            capture.Release();

        }

        private void CaptureCameraCallback()
        {
            if (CameraAdres == null)
                CameraAdres = "";

            frame = new OpenCvSharp.Mat();

            int b = -1;
            if (int.TryParse(CameraAdres, out b))
            {
                capture = new VideoCapture(b);
                capture.Open(b);
            }
            else
            {
                capture = new VideoCapture(CameraAdres);
                capture.Open(CameraAdres);
            }





            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {
                    try
                    {
                        capture.Read(frame);
                        image = BitmapConverter.ToBitmap(frame);
                        string barcode = ScanZxing(image);
                        if (string.IsNullOrEmpty(barcode) == false)
                        {
                            CamScannerEventArgs args = new CamScannerEventArgs();
                            args.Barcode = barcode;

                            EventHandler<CamScannerEventArgs> handler = OnBarcodeReaded;
                            handler.Invoke(this, args);

                            ////Console.WriteLine(DateTime.Now + " " + barcode);
                            Console.Beep();
                        }
                    }
                    catch (Exception)
                    {


                    }

                }
            }
        }


          private string LastBarcode { get; set; }
     


        public string ScanZxing(System.Drawing.Bitmap image)
        {
            // create a barcode reader instance
            var barcodeReader = new BarcodeReader();

            // create an in memory bitmap


            // decode the barcode from the in memory bitmap
            var barcodeResult = barcodeReader.Decode(image);

            // output results to console
            ////Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
            ////Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}");

            return barcodeResult?.Text;
        }
    }
}
