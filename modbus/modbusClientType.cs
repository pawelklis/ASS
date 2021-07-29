using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace modbus
{



    public class modbusClientType
    {
        SimpleTcpClient client;
        SimpleTcpServer data_server;

        public void Start()
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
            client = new SimpleTcpClient().Connect("192.168.127.254", Convert.ToInt32("4001"));
            client.DelimiterDataReceived += Client2_DataReceived;
            TimeSpan ts = new TimeSpan(0, 0, 5);
            var response = client.WriteLineAndGetReply("mmm", ts).Data;
            string resp = client.WriteLineAndGetReply("0", ts).MessageString;



            data_server = new SimpleTcpServer();
            data_server.Delimiter = 0x13;
            data_server.StringEncoder = Encoding.UTF8;
            data_server.DataReceived += Server_DataReceived;
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            data_server.Start(ip, Convert.ToInt32("4001"));
        }

        void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            Console.WriteLine(e.MessageString);
        }
        void Client2_DataReceived(object sender, SimpleTCP.Message e)
        {
            Console.WriteLine(e.MessageString);
        }

        static void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            Console.WriteLine(e.MessageString);
        }

    }



}
