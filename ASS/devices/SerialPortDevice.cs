using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASS
{
    public class SerialPortDevice
    {
        private SerialPort _serialPort { get; set; }
        public string PortName { get; set; }
        public string ParentName { get; set; }
        public int ReadDelay { get; set; }
        public int ReadsCount { get; set; }
        public int WriteCounts { get; set; }
        private bool Connected { get; set; }
        public bool isOn { get; set; }


        public EventHandler<SerialPortEventArgs> OnRead;
        public EventHandler<SerialPortEventArgs> OnWrite;
        public EventHandler<SerialPortEventArgs> OnError;
        public class SerialPortEventArgs : EventArgs
        {
            public string message { get; set; }
            public string ParentName { get; set; }
            public string MessagePort { get; set; }
        }

        public bool IsOpen()
        {
            if (_serialPort == null)
                return false;

            if (_serialPort.IsOpen == false)
            {
                Connected = false;
            }
            else
            {
                Connected = true;
            }


            if (Connected == false)
            {
                try
                {
                    _serialPort.Open();
                    Connected = true;
                }
                catch (Exception ex)
                {
                    Connected = false;
                }
            }
            try
            {
                return Connected;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (_serialPort == null)
                _serialPort = new SerialPort();
            if (_serialPort.IsOpen == true)
                _serialPort.Close();
        }


        public void Connect(string portname, bool ison, int PortSpeed = 1200, int readDelay = 0, string parentName = "", bool CheckingDevice = false)
        {
            this.isOn = ison;
            if (this.isOn)
                Task.Run(() => ConnectAsync(portname, PortSpeed, readDelay, parentName, CheckingDevice));
        }


        /// <summary>
        /// Dla maszyny speed =1200, dla skanera readDelay=200
        /// </summary>
        /// <param name="portname"></param>
        /// <param name="PortSpeed"></param>
        /// <param name="readDelay"></param>
        /// <returns></returns>
        public void ConnectAsync(string portname, int PortSpeed = 1200, int readDelay = 0, string parentName = "", bool CheckingDevice = false)
        {
            this.PortName = portname;
            this.ReadDelay = readDelay;
            this.ParentName = parentName;

            if (_serialPort == null)
                _serialPort = new SerialPort();

            try
            {
                if (_serialPort.IsOpen == false)
                {
                    _serialPort = new SerialPort();
                    _serialPort.PortName = PortName;
                    _serialPort.BaudRate = PortSpeed;
                    _serialPort.Parity = Parity.None;
                    _serialPort.DataBits = 8;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.Handshake = Handshake.None;

                    _serialPort.DataReceived += DataReceived;
                    _serialPort.ErrorReceived += ErrorReceived;
                    _serialPort.PinChanged += PinChanged;


                    _serialPort.ReadTimeout = 500;
                    _serialPort.WriteTimeout = 500;

                    _serialPort.DtrEnable = true;
                    _serialPort.RtsEnable = true;

                    _serialPort.Open();

                    this.Connected = true;

                    //return "Rozłącz";
                }
                else
                {
                    if (CheckingDevice == false)
                    {
                        _serialPort.Close();
                        this.Connected = false;
                        //return "Połącz";
                    }
                    else
                    {
                        this.Connected = true;
                        //return "ok";
                    }
                }
            }
            catch (Exception ex)
            {
                Connected = false;                
            }
        }

        public void PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            this.Connected = false;
            try
            {
                _serialPort.Close();
            }
            catch (Exception)
            {


            }

            SerialPortEventArgs args = new SerialPortEventArgs();
            args.message = "Error";
            args.MessagePort = _serialPort.PortName;
            args.ParentName = ParentName;
            EventHandler<SerialPortEventArgs> handler = OnRead;
            handler.Invoke(this, args);
        }
        public void ErrorReceived(object sender, EventArgs e)
        {

            this.Connected = false;

            SerialPortEventArgs args = new SerialPortEventArgs();
            args.message = "Error";
            args.MessagePort = _serialPort.PortName;
            args.ParentName = ParentName;
            EventHandler<SerialPortEventArgs> handler = OnRead;
            handler.Invoke(this, args);
        }

        public void DataReceived(object sender, EventArgs e)
        {
            Task.Run(() => ReadData());
        }


        public void ReadData()
        {
            if (this.ReadDelay > 0)
            {     
                System.Threading.Thread.Sleep(this.ReadDelay);
            }


            ReadsCount += 1;
            string message = "";
            string x = _serialPort.ReadExisting();
            if (!string.IsNullOrEmpty(x))
            {
                message = x.Replace("\r", "").Replace("]C1", "").Replace("\n", "");

                SerialPortEventArgs args = new SerialPortEventArgs();
                args.message = message;
                args.MessagePort = _serialPort.PortName;
                args.ParentName = ParentName;
                EventHandler<SerialPortEventArgs> handler = OnRead;
                handler.Invoke(this, args);
            }
        }



        public virtual void Read()
        {
            while (_serialPort.IsOpen)
            {
                try
                {
                    if (_serialPort.IsOpen == true)
                    {
                        try
                        {
                            string message = "";

                            //int bytes = _serialPort.BytesToRead;
                            byte[] buffer = new byte[_serialPort.ReadBufferSize];
                            _serialPort.Read(buffer, 0, buffer.Length);

                            if (ReadDelay != 0)
                                System.Threading.Thread.Sleep(ReadDelay);

                            message = System.Text.Encoding.UTF8.GetString(buffer);

                            if (message != "")
                            {
                                message = message.Replace("\r", "").Replace("]C1", "").Replace("\n", "");

                                SerialPortEventArgs args = new SerialPortEventArgs();
                                args.message = message;
                                args.MessagePort = _serialPort.PortName;
                                args.ParentName = ParentName;
                                EventHandler<SerialPortEventArgs> handler = OnRead;
                                handler.Invoke(this, args);
                            }
                        }
                        catch (Exception ec) { }
                    }
                }
                catch (TimeoutException) { }
            }
        }

        public async void WriteString(string message)
        {
            WriteCounts += 1;

            Task tasd = new Task(() => WriteStrings(message));
            tasd.Start();
        }

        private void WriteStrings(string message)
        {
            try
            {
                _serialPort.Write(message);

                SerialPortEventArgs args = new SerialPortEventArgs();
                args.message = message;
                args.MessagePort = _serialPort.PortName;
                args.ParentName = ParentName;
                EventHandler<SerialPortEventArgs> handler = OnRead;
                handler.Invoke(this, args);
            }
            catch (Exception ex)
            {
                try
                {
                    _serialPort.Write(message);
                }
                catch (Exception)
                {
                   
                }
            }

        }

        public async void WriteBytes(string bytes)
        {
            //await Task.Run(() => WriteBytes(bytes));
            WriteCounts += 1;

            Task tasd = new Task(() => WriteBytess(bytes));
            tasd.Start();
        }

        private void WriteBytess(string bytes)
        {
            try
            {
                string[] st = bytes.Split(char.Parse(","));

                List<byte> sendBits = new List<byte>();


                foreach (var s in st)
                {
                    sendBits.AddRange(stringToByte(s));
                }
                try
                {
                    if (_serialPort.IsOpen)
                        _serialPort.Write(sendBits.ToArray(), 0, sendBits.Count);

                    SerialPortEventArgs args = new SerialPortEventArgs();
                    args.message = bytes;
                    args.MessagePort = _serialPort.PortName;
                    args.ParentName = ParentName;
                    EventHandler<SerialPortEventArgs> handler = OnWrite;
                    handler.Invoke(this, args);
                }
                catch (Exception ex)
                {
                    try
                    {
                        _serialPort.Write(sendBits.ToArray(), 0, sendBits.Count);

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
            catch (Exception ex)
            {


            }
        }

        private byte[] stringToByte(string value)
        {
            List<byte> prefixList = new List<byte>();
            if (value != null)
            {
                foreach (var s in value.Split(','))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(s))
                            prefixList.Add(byte.Parse(s.Replace(" ", "")));
                    }
                    catch (Exception)
                    {

                        byte[] bity = Encoding.ASCII.GetBytes(s);
                        prefixList.AddRange(bity.ToArray());
                    }
                }
            }
            return prefixList.ToArray();
        }
    }
}
