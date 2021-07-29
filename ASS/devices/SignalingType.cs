using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class SignalingType
    {
        public SerialPortDevice PortRS232 { get; set; }



        public SignalingType()
        {
            PortRS232 = new SerialPortDevice();
            PortRS232.OnRead += OnRead;
            PortRS232.OnWrite+= OnWrite;
        }



        void OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            ////Console.WriteLine(e.MessagePort + ": " + e.message);
        }
        void OnWrite(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
           
        }


    }
}
