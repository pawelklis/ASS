using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;


namespace ASS.devices
{
    public class ModbusDeviceType
    {


        public void test()
        {
			ModbusClient modbusClient = new ModbusClient("COM1");
			//modbusClient.UnitIdentifier = 1; Not necessary since default slaveID = 1;
			//modbusClient.Baudrate = 9600;	// Not necessary since default baudrate = 9600
			//modbusClient.Parity = System.IO.Ports.Parity.None;
			//modbusClient.StopBits = System.IO.Ports.StopBits.Two;
				
			modbusClient.Connect();

			//modbusClient.ReceiveDataChanged += receivedata;

			var a =System.Text.Encoding.UTF8.GetString( modbusClient.receiveData);

			modbusClient.NumberOfRetries = 1;
			modbusClient.ConnectionTimeout = 500;

			Console.WriteLine("Value of Discr. Input #1: " + modbusClient.ReadDiscreteInputs(0, 1)[0].ToString());  //Reads Discrete Input #1
			Console.WriteLine("Value of Input Reg. #10: " + modbusClient.ReadInputRegisters(9, 1)[0].ToString());   //Reads Inp. Reg. #10

			

			modbusClient.WriteSingleCoil(4, true);      //Writes Coil #5
			modbusClient.WriteSingleRegister(19, 4711); //Writes Holding Reg. #20

			Console.WriteLine("Value of Coil #5: " + modbusClient.ReadCoils(4, 1)[0].ToString());   //Reads Discrete Input #1
			Console.WriteLine("Value of Holding Reg.. #20: " + modbusClient.ReadHoldingRegisters(19, 1)[0].ToString()); //Reads Inp. Reg. #10
			modbusClient.WriteMultipleRegisters(49, new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			modbusClient.WriteMultipleCoils(29, new bool[10] { true, true, true, true, true, true, true, true, true, true, });

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}




    }
}
