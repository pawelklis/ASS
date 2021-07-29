
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;



namespace camTester
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

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
            StartCam(camaddress, zom, blackwhite);
        }
        public void STOP()
        {

            captureX.Stop();
            captureX = null;
        }



        public void StartCam(string camaddress, int zom, bool blackwhite)
        {
            CameraAdres = camaddress;
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
                    //captureX.Grab();
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
        public Bitmap Zoom(Bitmap originalBitmap, int zoomFactor)
        {
            System.Drawing.Size newSize = new System.Drawing.Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
            Bitmap bmp = new Bitmap(originalBitmap, newSize);
            return bmp;
        }
        private string LastBarcode { get; set; }
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {

            try
            {
                Emgu.CV.Mat image = new Emgu.CV.Mat();
                captureX.Retrieve(image);

                System.Drawing.Image img = image.Bitmap;
                img = Zoom((Bitmap)img,1);

                pictureBox1.Image =(Image)img.Clone();


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

        Point P1;
        Point P2;

        public string OCRBarcode(System.Drawing.Bitmap image)
        {
            string bcr = "";

            BarcodeReader barcodeReader = new BarcodeReader();
            barcodeReader.AutoRotate = true;
            barcodeReader.TryInverted = false;
            barcodeReader.Options.PureBarcode = true;
            barcodeReader.Options.TryHarder = true;
            
            
            

            var res = barcodeReader.Decode(image);
            bcr = res.Text;

            label1.Invoke(new Action(() => label1.Text = bcr));

            List<Point> points = new List<Point>();
            foreach(var p in res.ResultPoints)
            {
                points.Add(new Point((int)p.X, (int)p.Y));
            }

            P1 = points[0];
            P2 = points[1];

            Pen redPen = new Pen(Color.Red, 4);

            Graphics GR = pictureBox1.CreateGraphics();
            GR.DrawLine(redPen, points[0], points[1]);

            pictureBox2.Image = (Image)image.Clone();

            Graphics GR2 = pictureBox2.CreateGraphics();

            Pen redPen2 = new Pen(Color.Red, 4);
            GR2.DrawLine(redPen2, points[0], points[1]);

            Console.Beep();

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

        private void button1_Click(object sender, EventArgs e)
        {
            captureX = null;
            StartCam(textBox1.Text, 1, false);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (P1 != null)
            {
                Pen redPen = new Pen(Color.Red, 4);
            
                e.Graphics.DrawLine(redPen, P1, P2);
            }
        }
    }
}
