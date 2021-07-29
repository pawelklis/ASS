using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS;

namespace AutomaticSortingSystem
{
    public partial class usOthersets : UserControl
    {
        public CarouselType carousel { get; set; }
        public usOthersets()
        {
            InitializeComponent();
        }

        private void usOthersets_Load(object sender, EventArgs e)
        {
            Bind();
        }
        void Bind()
        {
            if(carousel.Dicts.WorkdetectionIntervalMS<0)
                    carousel.Dicts.WorkdetectionIntervalMS = 100;

            numwork.Value = carousel.Dicts.WorkdetectionIntervalMS;
            numalltacts.Value = carousel.Dicts.AllTactsCount;
            ckturnofftimer.Checked = carousel.Dicts.TurnOffLampByTimer;
            checkBox1.Checked = carousel.Dicts.CorrectDisposedMarkers;
            numparcelfactor.Value = carousel.Dicts.ParcelLenghtFactor;
            numtactlenghtcm.Value = carousel.Dicts.BetweenMarkresSpaceCM;
            numstopcorection.Value = carousel.Dicts.StopCorrection;
            txCamAdres.Text = carousel.Dicts.CamAdress1;
            ckautowork.Checked = carousel.Dicts.AutoWorkdetectioninterval;
            txCamadres2.Text = carousel.Dicts.CamAdress2;
            numSTOPTacts.Value = carousel.Dicts.StopSensorTactsCount;
            ckblack1.Checked = carousel.Dicts.blackCam1;
            ckBlack2.Checked = carousel.Dicts.blackCam2;
            numzum1.Value = carousel.Dicts.cam1zoom;
            numzum2.Value = carousel.Dicts.cam2zoom;
        }

        private void numwork_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.WorkdetectionIntervalMS = (int)numwork.Value;
        }

        private void numalltacts_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.AllTactsCount = (int)numalltacts.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carousel.Save();
        }

        private void ckturnofftimer_CheckedChanged(object sender, EventArgs e)
        {
            carousel.Dicts.TurnOffLampByTimer = ckturnofftimer.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            carousel.Dicts.CorrectDisposedMarkers = checkBox1.Checked;
        }

        private void numparcelfactor_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.ParcelLenghtFactor = (int)numparcelfactor.Value;
        }

        private void numtactlenghtcm_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.BetweenMarkresSpaceCM = (int)numtactlenghtcm.Value;
        }

        private void numstopcorection_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.StopCorrection = (int)numstopcorection.Value;
        }

        private void txCamAdres_TextChanged(object sender, EventArgs e)
        {
            carousel.Dicts.CamAdress1 = txCamAdres.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "ON")
            {
                button2.Text = "OFF";
                carousel.TurnOnCammera();

                carousel.CamScanner.OnBarcodeReaded += barcodeReaded;
                carousel.CamScanner.OnImageGrabbed += PictureGrabbedCam1;
            }
            else
            {
                button2.Text = "ON";
                carousel.TurnOffCamera();
            }
        }

        private void ckautowork_CheckedChanged(object sender, EventArgs e)
        {
            carousel.Dicts.AutoWorkdetectioninterval = ckautowork.Checked;
        }

        void barcodeReaded(object sender, CamScannerType.CamScannerEventArgs e)
        {
            if (ckPreview1.Checked)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = e.img;
            }
        }

        void PictureGrabbedCam1(object sender, CamScannerType.CamScannerEventArgs e)
        {
            if (checkBox3.Checked)
            {
                try
                {
                    
                pictureBox1.Image = null;
                pictureBox1.Image =(Image) e.img.Clone();
                }
                catch (Exception)
                {

            
                }
        
            }
        }
        void PictureGrabbedCam2(object sender, CamScannerType.CamScannerEventArgs e)
        {
            if (checkBox2.Checked)
            {
                try
                {
              pictureBox2.Image = null;
                    pictureBox2.Image = (Image)e.img.Clone();
                }
                catch (Exception)
                {

               
                }
      
            }
        }
        void barcodeReaded2(object sender, CamScannerType.CamScannerEventArgs e)
        {
            if (ckpreview2.Checked)
            {
                pictureBox2.Image = null;
                pictureBox2.Image = e.img;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "ON")
            {
                button3.Text = "OFF";
                carousel.TurnOnCamera2();

                carousel.CamScanner2.OnBarcodeReaded += barcodeReaded2;
                carousel.CamScanner2.OnImageGrabbed += PictureGrabbedCam2;
            }
            else
            {
                button3.Text = "ON";
                carousel.TurnOffCamera2();
            }
        }

        private void txCamadres2_TextChanged(object sender, EventArgs e)
        {
            carousel.Dicts.CamAdress2 = txCamadres2.Text;
        }

        private void numSTOPTacts_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.StopSensorTactsCount = (int)numSTOPTacts.Value;
        }

        private void ckPreview1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckblack1_CheckedChanged(object sender, EventArgs e)
        {
            carousel.Dicts.blackCam1 = ckblack1.Checked;
            try
            {
    carousel.CamScanner.BlackWhite = ckblack1.Checked;
            }
            catch (Exception)
            {


            }
        
        }

        private void ckBlack2_CheckedChanged(object sender, EventArgs e)
        {
            carousel.Dicts.blackCam2 = ckBlack2.Checked;
            try
            {
            carousel.CamScanner2.BlackWhite = ckBlack2.Checked;
            }
            catch (Exception)
            {

     
            }

        }

        private void numzum1_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.cam1zoom = (int)numzum1.Value;
            try { 
               carousel.CamScanner.zoom = (int)numzum1.Value;         

            }
            catch (Exception)
            {


            }

        }

        private void numzum2_ValueChanged(object sender, EventArgs e)
        {
            carousel.Dicts.cam2zoom = (int)numzum2.Value;
            try
            {
          carousel.CamScanner2.zoom = (int)numzum2.Value;
            }
            catch (Exception)
            {

               
            }
  
        }
    }
}
