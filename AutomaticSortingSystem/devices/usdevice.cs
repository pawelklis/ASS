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
using System.IO.Ports;

namespace AutomaticSortingSystem.devices
{
    public partial class usdevice : UserControl
    {

      public Dicts dicts { get; set; }
        public CarouselType carousel { get; set; }

        public string DeviceName { get; set; }

        public usdevice()
        {
            InitializeComponent();
        }



        private void usdevice_Load(object sender, EventArgs e)
        {
            List<string> ports = SerialPort.GetPortNames().ToList();
            ports.Sort();

            comboBox1.Items.Clear();

            foreach(var s in ports)
            {
                comboBox1.Items.Add(s);
            }

            if (DeviceName.ToLower() == "startsensor")
            {
                comboBox1.SelectedItem = dicts.StartSensorPort;
                numspeed.Value = dicts.StartSensorSpeed;
                numDelay.Value = dicts.StartSensorDelay;
                textBox1.Text =  dicts.StartSensorName;

                if (carousel.StartSensor != null)
                {
                    if (carousel.StartSensor.PortRS232.IsOpen())
                    {
                        portstatus.Text = "Connected";
                        portstatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        portstatus.Text = "Disconnected";
                        portstatus.ForeColor = Color.Red;
                    }
                }
                    
            }
            if (DeviceName.ToLower() == "scanner1")
            {
                comboBox1.SelectedItem = dicts.Scanner1Port;
                numspeed.Value = dicts.Scanner1Speed;
                numDelay.Value = dicts.Scanner1Delay;
                textBox1.Text =  dicts.Scanner1Name;
                if (carousel.Scanner1 != null)
                {
                    if (carousel.Scanner1.PortRS232.IsOpen())
                    {
                        portstatus.Text = "Connected";
                        portstatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        portstatus.Text = "Disconnected";
                        portstatus.ForeColor = Color.Red;
                    }
                }
            }
            if (DeviceName.ToLower() == "signaling")
            {
                comboBox1.SelectedItem = dicts.SignalingPort;
                numspeed.Value = dicts.SignalingSpeed;
                numDelay.Value = dicts.SignalingDelay;
                textBox1.Text =  dicts.SignalingName;
                if (carousel.Signaling != null)
                {
                    if (carousel.Signaling.PortRS232.IsOpen())
                    {
                        portstatus.Text = "Connected";
                        portstatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        portstatus.Text = "Disconnected";
                        portstatus.ForeColor = Color.Red;
                    }
                }
            }
            if (DeviceName.ToLower() == "stopsensor")
            {
                comboBox1.SelectedItem = dicts.StopSensorPort;
                numspeed.Value = dicts.StopSensorSpeed;
                numDelay.Value = dicts.StopSensorDelay;
                textBox1.Text =  dicts.StopSensorName;
                if (carousel.StopSensor != null)
                {
                    if (carousel.StopSensor.PortRS232.IsOpen())
                    {
                        portstatus.Text = "Connected";
                        portstatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        portstatus.Text = "Disconnected";
                        portstatus.ForeColor = Color.Red;
                    }
                }
            }
            if (DeviceName.ToLower() == "tactsensor")
            {
                comboBox1.SelectedItem = dicts.TactSensorPort;
                numspeed.Value = dicts.TactSensorSpeed;
                numDelay.Value = dicts.TactSensorDelay;
                textBox1.Text =  dicts.TactSensorName;
                if (carousel.TactSensor != null)
                {
                    if (carousel.TactSensor.PortRS232.IsOpen())
                    {
                        portstatus.Text = "Connected";
                        portstatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        portstatus.Text = "Disconnected";
                        portstatus.ForeColor = Color.Red;
                    }
                }
            }


            if (DeviceName.ToLower() == "lenghtsensor")
            {
                comboBox1.SelectedItem = dicts.LenghtSensorPort;
                numspeed.Value = dicts.LenghtSensorSpeed;
                numDelay.Value = dicts.LenghtSensorDelay;
                textBox1.Text = dicts.LenghtSensorName;
                if (carousel.LenghtSensor != null)
                {
                    if (carousel.LenghtSensor.PortRS232.IsOpen())
                    {
                        portstatus.Text = "Connected";
                        portstatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        portstatus.Text = "Disconnected";
                        portstatus.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (DeviceName.ToLower() == "startsensor")
            {
                dicts.StartSensorDelay = (int)numDelay.Value;

            }
            if (DeviceName.ToLower() == "scanner1")
            {
                dicts.Scanner1Delay = (int)numDelay.Value;

            }
            if (DeviceName.ToLower() == "signaling")
            {
                dicts.SignalingDelay = (int)numDelay.Value;

            }
            if (DeviceName.ToLower() == "stopsensor")
            {
                dicts.StopSensorDelay = (int)numDelay.Value;

            }
            if (DeviceName.ToLower() == "tactsensor")
            {
                dicts.TactSensorDelay = (int)numDelay.Value;
            }
            if (DeviceName.ToLower() == "lenghtsensor")
            {
                dicts.LenghtSensorDelay = (int)numDelay.Value;
            }
        }

        private void numspeed_ValueChanged(object sender, EventArgs e)
        {
            if (DeviceName.ToLower() == "startsensor")
            {
                dicts.StartSensorSpeed = (int)numspeed.Value;

            }
            if (DeviceName.ToLower() == "scanner1")
            {
                dicts.Scanner1Speed = (int)numspeed.Value;

            }
            if (DeviceName.ToLower() == "signaling")
            {
                dicts.SignalingSpeed = (int)numspeed.Value;

            }
            if (DeviceName.ToLower() == "stopsensor")
            {
                dicts.StopSensorSpeed = (int)numspeed.Value;

            }
            if (DeviceName.ToLower() == "tactsensor")
            {
                dicts.TactSensorSpeed = (int)numspeed.Value;
            }
            if (DeviceName.ToLower() == "lenghtsensor")
            {
                dicts.LenghtSensorSpeed = (int)numspeed.Value;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeviceName.ToLower() == "startsensor")
            {
               dicts.StartSensorPort = comboBox1.SelectedItem.ToString();
    
            }
            if (DeviceName.ToLower() == "scanner1")
            {
                dicts.Scanner1Port = comboBox1.SelectedItem.ToString();

            }
            if (DeviceName.ToLower() == "signaling")
            {
                dicts.SignalingPort = comboBox1.SelectedItem.ToString();
       
            }
            if (DeviceName.ToLower() == "stopsensor")
            {
                dicts.StopSensorPort = comboBox1.SelectedItem.ToString();
     
            }
            if (DeviceName.ToLower() == "tactsensor")
            {
                dicts.TactSensorPort = comboBox1.SelectedItem.ToString();
            }
            if (DeviceName.ToLower() == "lenghtsensor")
            {
                dicts.LenghtSensorPort = comboBox1.SelectedItem.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (DeviceName.ToLower() == "startsensor")
            {
                dicts.StartSensorName = textBox1.Text;

            }
            if (DeviceName.ToLower() == "scanner1")
            {
                dicts.Scanner1Name = textBox1.Text;

            }
            if (DeviceName.ToLower() == "signaling")
            {
                dicts.SignalingName = textBox1.Text;

            }
            if (DeviceName.ToLower() == "stopsensor")
            {
                dicts.StopSensorName = textBox1.Text;

            }
            if (DeviceName.ToLower() == "tactsensor")
            {
                dicts.TactSensorName = textBox1.Text;
            }
            if (DeviceName.ToLower() == "lenghtsensor")
            {
                dicts.LenghtSensorName = textBox1.Text;
            }
        }
    }
}
