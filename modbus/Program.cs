using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using SimpleTCP;

namespace modbus
{
    class Program
    {
        static SimpleTcpClient client;
        static SimpleTcpServer data_server;

        static void Main(string[] args)
        {


            modbusClientType m = new modbusClientType();
            m.Start();

            //data_server = new SimpleTcpServer();
            //data_server.Delimiter = 0x13;
            //data_server.StringEncoder = Encoding.UTF8;
            //data_server.DataReceived += Server_DataReceived;
            //System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            //data_server.Start(ip, Convert.ToInt32("4002"));


            //client = new SimpleTcpClient();
            //client.StringEncoder = Encoding.UTF8;
            //client.DataReceived += Client_DataReceived;
            //client = new SimpleTcpClient().Connect("192.168.127.254", Convert.ToInt32("4001"));

            //TimeSpan ts = new TimeSpan(0, 0, 5);
            //var response = client.WriteLineAndGetReply("mmm", ts).Data;
            //string resp = client.WriteLineAndGetReply("0", ts).MessageString;




            //ModbusClient modbusClient = new ModbusClient("10.212.1.5", 4002);    //Ip-Address and Port of Modbus-TCP-Server
            //modbusClient.Connect();                                                    //Connect to Server
            //modbusClient.WriteMultipleCoils(4, new bool[] { true, true, true, true, true, true, true, true, true, true });    //Write Coils starting with Address 5
            //bool[] readCoils = modbusClient.ReadCoils(9, 10);                        //Read 10 Coils from Server, starting with address 10
            //int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 10);    //Read 10 Holding Registers from Server, starting with Address 1

            //// Console Output
            //for (int i = 0; i < readCoils.Length; i++)
            //    Console.WriteLine("Value of Coil " + (9 + i + 1) + " " + readCoils[i].ToString());

            //for (int i = 0; i < readHoldingRegisters.Length; i++)
            //    Console.WriteLine("Value of HoldingRegister " + (i + 1) + " " + readHoldingRegisters[i].ToString());
            //modbusClient.Disconnect();                                                //Disconnect from Server
            //Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }

        void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
        }

        static void Server_DataReceived(object sender, SimpleTCP.Message e)
        {

        }

    }
}
