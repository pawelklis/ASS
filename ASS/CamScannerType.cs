
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ZXing;
using static System.Net.Mime.MediaTypeNames;
using Emgu.CV;
using System.Drawing.Imaging;

namespace ASS
{
    public class CamScannerType
    {

        public class CamScannerEventArgs
        {
            public string Barcode { get; set; }

            public System.Drawing.Image img { get; set; }
        }

        Emgu.CV.Capture captureX;


       
        public string CameraAdres { get; set; }
        public int zoom { get; set; }
        public bool BlackWhite { get; set; }


        public EventHandler<CamScannerEventArgs> OnBarcodeReaded;
        public EventHandler<CamScannerEventArgs> OnImageGrabbed;


        // Declare required methods
        public void CaptureCamera(string camaddress, int zom, bool blackwhite)
        {
           
            CameraAdres = camaddress;
                 StartCam(camaddress,zom,blackwhite);
        }
        public void STOP()
        {
       
            captureX.Stop();
            captureX = null;
        }

     

        public void StartCam(string camaddress,int zom,bool blackwhite)
        {
            this.zoom = zom;
            this.BlackWhite = blackwhite;

            if (captureX == null)
            {
                try
                {

                    int b = -1;
                    if (int.TryParse(CameraAdres, out b))
                    {
                        captureX = new Emgu.CV.Capture(b);
                    }
                    else
                    {
                        captureX = new Emgu.CV.Capture(CameraAdres);
                    }

                    //captureX = new Emgu.CV.Capture(CameraAdres); //"http://127.0.0.1:5050/video"
                    captureX.ImageGrabbed += Capture_ImageGrabbed;
                    captureX.Grab();
                    captureX.Start();
                }


                catch (NullReferenceException exception)
                {
                    
                }
                catch (TypeInitializationException exc)
                {
       
                }
            }
        }
        private string LastBarcode { get; set; }
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {

            try
            {   
                Emgu.CV.Mat image = new Emgu.CV.Mat();
                captureX.Retrieve(image);

                System.Drawing.Image img = image.Bitmap;
                if (this.zoom < 1)
                    this.zoom = 1;

                if (this.zoom != 1)
                {
                    img = Zoom((Bitmap)img,this.zoom);
                }
                if(this.BlackWhite == true){
                    img = MakeGrayscale3((Bitmap)img.Clone());
                }

                try
                {
                    CamScannerEventArgs args = new CamScannerEventArgs();
                    args.Barcode = "";
                    args.img = img;

                    EventHandler<CamScannerEventArgs> handler = OnImageGrabbed;
                    handler.Invoke(this, args);
                }
                catch (Exception)
                {

                   
                }

                string barcode = "";

                barcode = OCRBarcode((Bitmap)img);

                
                if (string.IsNullOrEmpty(barcode) == false)
                {
                    if (LastBarcode != barcode)
                    {
                        LastBarcode = barcode;

                        CamScannerEventArgs args = new CamScannerEventArgs();
                        args.Barcode = barcode;
                        args.img = img;

                        EventHandler<CamScannerEventArgs> handler = OnBarcodeReaded;
                        handler.Invoke(this, args);

                        ////Console.WriteLine(DateTime.Now + " " + barcode);
                        Console.Beep();
                    }
                }
                else
                {
                    barcode = ScanZxing((Bitmap)img);
                    if (string.IsNullOrEmpty(barcode) == false)
                    {
                        if (LastBarcode != barcode)
                        {
                            LastBarcode = barcode;

                            CamScannerEventArgs args = new CamScannerEventArgs();
                            args.Barcode = barcode;
                            args.img = img;

                            EventHandler<CamScannerEventArgs> handler = OnBarcodeReaded;
                            handler.Invoke(this, args);

                            ////Console.WriteLine(DateTime.Now + " " + barcode);
                            Console.Beep();
                        }
                    }
                }
            }
            catch (Exception)
            {

              
            }

            if (captureX == null)
                return;

 
            //pictureBox1.Image = image.Bitmap;


        }

        public string OCRBarcode(System.Drawing.Bitmap image)
        {
            string bcr = "";

            BarcodeReader barcodeReader = new BarcodeReader();
            var res = barcodeReader.Decode(image);
            bcr = res.Text;

            return bcr;
        }

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


        public Bitmap Zoom(Bitmap originalBitmap, int zoomFactor)
        {
            System.Drawing.Size newSize = new System.Drawing.Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
            Bitmap bmp = new Bitmap(originalBitmap, newSize);
            return bmp;
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












    }
}
