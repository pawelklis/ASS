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
    public partial class usLamp : UserControl
    {
        public LampType lamp { get; set; }
        public CarouselType carouser { get; set; }

        public string LampName { get; set; }
        public usLamp()
        {
            InitializeComponent();
        }

        private void usLamp_Load(object sender, EventArgs e)
        {
            label3.Text = LampName;

            lamp.OnLightOn += OnLampOn;
            lamp.OnLightOff += OnLampOff;

            btnLampColor.BackColor = Color.WhiteSmoke;
            numToLampOn.Value = lamp.TactsToTurnON;
            numToLampIoff.Value = lamp.TactsToTurnOff;
            button1.BackColor = lamp.LampColor;
            checkBox1.Checked = lamp.LampBlinking;
            numblinkinterval.Value = lamp.LampBlinkingInterval;
            numblinklenght.Value = lamp.LampBlinkingLenght;

            usSignal onSignal = new usSignal();
            onSignal.Signal = lamp.TurnOnSignal;
            onSignal.Left = 0;
            onSignal.Top = 105;
            this.Controls.Add(onSignal);

            usSignal offSignal = new usSignal();
            offSignal.Signal = lamp.TurnOffSignal;
            offSignal.Left = 0;
            offSignal.Top = 145;
            this.Controls.Add(offSignal);

        }

        void OnLampOn(object sender,EventArgs e)
        {

            btnLampColor.BackColor = lamp.LampColor;

        }
        void OnLampOff(object sender, EventArgs e)
        {
            btnLampColor.BackColor = Color.WhiteSmoke;
        }
        private void numToLampOn_ValueChanged(object sender, EventArgs e)
        {
            lamp.TactsToTurnON = (int)numToLampOn.Value;           
        }

        private void numToLampIoff_ValueChanged(object sender, EventArgs e)
        {
            lamp.TactsToTurnOff = (int)numToLampIoff.Value;
        }

        private void btnLampColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = lamp.LampColor;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                lamp.LampColor = cd.Color;
                button1.BackColor = lamp.LampColor;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lamp.LampBlinking = checkBox1.Checked;
        }

        private void numblinklenght_ValueChanged(object sender, EventArgs e)
        {
            lamp.LampBlinkingLenght = (int)numblinklenght.Value;
        }

        private void numblinkinterval_ValueChanged(object sender, EventArgs e)
        {
            lamp.LampBlinkingInterval = (int)numblinkinterval.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lamp.TurnOn(carouser.Signaling);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lamp.TurnOff(carouser.Signaling);
            
            if(lamp.blinkTimer!=null)
                lamp.blinkTimer.Stop();

        }
    }
}
