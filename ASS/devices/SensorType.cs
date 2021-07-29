using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class SensorType
    {
      

        public SerialPortDevice PortRS232 { get; set; }



        public SensorType()
        {
            PortRS232 = new SerialPortDevice();
            PortRS232.OnRead += OnRead;
        }
      


        async void OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            ////Console.WriteLine(e.MessagePort + ": " + e.message);
       
        }


      

    }



}
