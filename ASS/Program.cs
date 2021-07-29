using ASS.devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    class Program
    {
        static CarouselType carousel;

        static void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            switch (e.Reason)
            {
                case Microsoft.Win32.SessionEndReasons.Logoff:
                    
                    break;

                case Microsoft.Win32.SessionEndReasons.SystemShutdown:
                    
                    break;

                
            }
        }
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
            try
            {
                carousel.Dicts.Save();
            }
            catch (Exception)
            {

               
            }
        }
        static void Main(string[] args)
        {
            Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);
            //ModbusDeviceType md = new ModbusDeviceType();
            //md.test();

            //SerialPortDevice spd = new SerialPortDevice();
            //spd.Connect("COM12",9600,200);
            //spd.OnRead += OnRead;

            //StartSensorType sensor1 = new StartSensorType();
            //sensor1.PortRS232.Connect("COM12", 9600, 200);
            //sensor1.PortRS232.OnRead += OnRead;


            //void OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
            //{
            //    //Console.WriteLine(e.MessagePort + ": " +e.message);
            //}


            carousel= new CarouselType();
            carousel = CarouselType.Load();
            carousel.TurnOn();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            //CamScannerType cam = new CamScannerType();
            //cam.CaptureCamera();


            //carousel.StopSensor.TactsCount = 40;
            //carousel.StopSensor.TactsCount = 50;


            //carousel.Dicts.Stands[0].StandItem3.Lamp1.TactsToTurnON = 8;
            //carousel.Dicts.Stands[0].StandItem3.Lamp1.TactsToTurnOff = 10;

            //carousel.Dicts.Stands[0].StandItem3.Lamp2.TactsToTurnON = 15;
            //carousel.Dicts.Stands[0].StandItem3.Lamp2.TactsToTurnOff = 17;

            //carousel.Dicts.Stands[0].StandItem3.Lamp3.TactsToTurnON = 20;
            //carousel.Dicts.Stands[0].StandItem3.Lamp3.TactsToTurnOff = 22;

            //carousel.Dicts.Stands[0].StandItem3.Lamp4.TactsToTurnON = 24;
            //carousel.Dicts.Stands[0].StandItem3.Lamp4.TactsToTurnOff = 26;

            //carousel.Save();
            //red
            //white
            //green/
            //blue


            //StandType s = new StandType();
            //s.Name = "Odrzut";
            //s.StandItem1.Direction = Dicts.RejectDirection();

            //carousel.Dicts.Stands.Add(s);
            //carousel.Save();


            //StandType stand = new StandType();
            //stand.Name = "Stanowisko 1";
            //stand.StandItem1.Direction = carousel.Dicts.Directions[0];
            //stand.StandItem2.Direction = carousel.Dicts.Directions[1];
            //stand.StandItem3.Direction = carousel.Dicts.Directions[2];
            //stand.StandItem4.Direction = carousel.Dicts.Directions[3];

            //stand.StandItem1.Lamp1.LampColor = Color.Red;
            //stand.StandItem1.Lamp2.LampColor = Color.Red;
            //stand.StandItem1.Lamp3.LampColor = Color.Red;
            //stand.StandItem1.Lamp4.LampColor = Color.Red;

            //stand.StandItem2.Lamp1.LampColor = Color.White;
            //stand.StandItem2.Lamp2.LampColor = Color.White;
            //stand.StandItem2.Lamp3.LampColor = Color.White;
            //stand.StandItem2.Lamp4.LampColor = Color.White;

            //stand.StandItem3.Lamp1.LampColor = Color.Green;
            //stand.StandItem3.Lamp2.LampColor = Color.Green;
            //stand.StandItem3.Lamp3.LampColor = Color.Green;
            //stand.StandItem3.Lamp4.LampColor = Color.Green;

            //stand.StandItem4.Lamp1.LampColor = Color.Blue;
            //stand.StandItem4.Lamp2.LampColor = Color.Blue;
            //stand.StandItem4.Lamp3.LampColor = Color.Blue;
            //stand.StandItem4.Lamp4.LampColor = Color.Blue;


            //stand.StandItem1.Lamp1.TurnOnSignal.Prefix = "27";
            //stand.StandItem1.Lamp1.TurnOnSignal.Content = "";
            //stand.StandItem1.Lamp1.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem1.Lamp2.TurnOnSignal.Prefix = "27";
            //stand.StandItem1.Lamp2.TurnOnSignal.Content = "";
            //stand.StandItem1.Lamp2.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem1.Lamp3.TurnOnSignal.Prefix = "27";
            //stand.StandItem1.Lamp3.TurnOnSignal.Content = "";
            //stand.StandItem1.Lamp3.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem1.Lamp4.TurnOnSignal.Prefix = "27";
            //stand.StandItem1.Lamp4.TurnOnSignal.Content = "";
            //stand.StandItem1.Lamp4.TurnOnSignal.Sufix = "13,10";



            //stand.StandItem2.Lamp1.TurnOnSignal.Prefix = "27";
            //stand.StandItem2.Lamp1.TurnOnSignal.Content = "";
            //stand.StandItem2.Lamp1.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem2.Lamp2.TurnOnSignal.Prefix = "27";
            //stand.StandItem2.Lamp2.TurnOnSignal.Content = "";
            //stand.StandItem2.Lamp2.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem2.Lamp3.TurnOnSignal.Prefix = "27";
            //stand.StandItem2.Lamp3.TurnOnSignal.Content = "";
            //stand.StandItem2.Lamp3.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem2.Lamp4.TurnOnSignal.Prefix = "27";
            //stand.StandItem2.Lamp4.TurnOnSignal.Content = "";
            //stand.StandItem2.Lamp4.TurnOnSignal.Sufix = "13,10";


            //stand.StandItem3.Lamp1.TurnOnSignal.Prefix = "27";
            //stand.StandItem3.Lamp1.TurnOnSignal.Content = "";
            //stand.StandItem3.Lamp1.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem3.Lamp2.TurnOnSignal.Prefix = "27";
            //stand.StandItem3.Lamp2.TurnOnSignal.Content = "";
            //stand.StandItem3.Lamp2.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem3.Lamp3.TurnOnSignal.Prefix = "27";
            //stand.StandItem3.Lamp3.TurnOnSignal.Content = "";
            //stand.StandItem3.Lamp3.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem3.Lamp4.TurnOnSignal.Prefix = "27";
            //stand.StandItem3.Lamp4.TurnOnSignal.Content = "";
            //stand.StandItem3.Lamp4.TurnOnSignal.Sufix = "13,10";



            //stand.StandItem4.Lamp1.TurnOnSignal.Prefix = "27";
            //stand.StandItem4.Lamp1.TurnOnSignal.Content = "";
            //stand.StandItem4.Lamp1.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem4.Lamp2.TurnOnSignal.Prefix = "27";
            //stand.StandItem4.Lamp2.TurnOnSignal.Content = "";
            //stand.StandItem4.Lamp2.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem4.Lamp3.TurnOnSignal.Prefix = "27";
            //stand.StandItem4.Lamp3.TurnOnSignal.Content = "";
            //stand.StandItem4.Lamp3.TurnOnSignal.Sufix = "13,10";

            //stand.StandItem4.Lamp4.TurnOnSignal.Prefix = "27";
            //stand.StandItem4.Lamp4.TurnOnSignal.Content = "";
            //stand.StandItem4.Lamp4.TurnOnSignal.Sufix = "13,10";

            //carousel.Dicts.Stands.Add(stand);

            //for (int i = 0; i < 11; i++)
            //{
            //    stand = new StandType();
            //    stand.Name ="Stanowisko " + i + 2;
            //    carousel.Dicts.Stands.Add(stand);
            //}



            //carousel.Save();


            //carousel.Dicts.StartSensorPort = "COM23";
            //carousel.Dicts.StopSensorPort = "COM24"	;
            //carousel.Dicts.TactSensorPort = "COM27";
            //carousel.Dicts.Scanner1Port = "COM12";
            //carousel.Dicts.SignalingPort = "COM1";
            //carousel.Dicts.StartSensorSpeed = 9600;
            //carousel.Dicts.StopSensorSpeed = 9600;
            //carousel.Dicts.TactSensorSpeed = 9600;
            //carousel.Dicts.Scanner1Speed = 9600;
            //carousel.Dicts.SignalingSpeed = 1200;
            //carousel.Dicts.StartSensorDelay = 0;
            //carousel.Dicts.StopSensorDelay = 0;
            //carousel.Dicts.TactSensorDelay = 0;
            //carousel.Dicts.Scanner1Delay = 200;
            //carousel.Dicts.SignalingDelay = 0;
            //carousel.Dicts.StartSensorName = "Start sensor";
            //carousel.Dicts.StopSensorName = "Stop sensor";
            //carousel.Dicts.TactSensorName = "Tact sensor";
            //carousel.Dicts.Scanner1Name = "Scanner";
            //carousel.Dicts.SignalingName = "Signaling";




            //carousel.TurnOn();


            //DirectionType d;
            //DirectionItemType item;
            //d= new DirectionType();d.Name = "Pruszcz Gd";
            //item = new DirectionItemType(); item.PnaFrom = "80000 "; item.PnaTo = "84999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "14400 "; item.PnaTo = "14499"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "14500 "; item.PnaTo = "14599"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "76200 "; item.PnaTo = "76299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "77100 "; item.PnaTo = "77199"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "77200 "; item.PnaTo = "77299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Lisi Ogon";
            //item = new DirectionItemType(); item.PnaFrom = "64800 "; item.PnaTo = "64899"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "64900 "; item.PnaTo = "64999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "77300 "; item.PnaTo = "77399"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "77400 "; item.PnaTo = "77499"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "78600 "; item.PnaTo = "77699"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Warszawa";
            //item = new DirectionItemType(); item.PnaFrom = "15000 "; item.PnaTo = "19999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "00000"; item.PnaTo = "09999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "96300 "; item.PnaTo = "96399"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "96500 "; item.PnaTo = "96599"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Łódź";
            //item = new DirectionItemType(); item.PnaFrom = "90000 "; item.PnaTo = "96299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "26300 "; item.PnaTo = "26399"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "96400 "; item.PnaTo = "96499"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "96600 "; item.PnaTo = "99999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Wrocław";
            //item = new DirectionItemType(); item.PnaFrom = "67200 "; item.PnaTo = "67299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "50000 "; item.PnaTo = "59999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "49300 "; item.PnaTo = "49399"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "49200 "; item.PnaTo = "49299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "48300 "; item.PnaTo = "48399"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "46100 "; item.PnaTo = "46199"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Komorniki";
            //item = new DirectionItemType(); item.PnaFrom = "75000 "; item.PnaTo = "78599"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "60000 "; item.PnaTo = "66199"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "67300 "; item.PnaTo = "69999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Olsztyn";
            //item = new DirectionItemType(); item.PnaFrom = "10000 "; item.PnaTo = "14999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Szczecin";
            //item = new DirectionItemType(); item.PnaFrom = "70000 "; item.PnaTo = "74999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Zabrze";
            //item = new DirectionItemType(); item.PnaFrom = "40000 "; item.PnaTo = "48999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "34300 "; item.PnaTo = "34399"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Kraków";
            //item = new DirectionItemType(); item.PnaFrom = "30000 "; item.PnaTo = "34299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "38300 "; item.PnaTo = "38299"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "34400 "; item.PnaTo = "34499"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Rudna Mała";
            //item = new DirectionItemType(); item.PnaFrom = "35000 "; item.PnaTo = "39999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Lublin";
            //item = new DirectionItemType(); item.PnaFrom = "20000 "; item.PnaTo = "24999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //item = new DirectionItemType(); item.PnaFrom = "08500 "; item.PnaTo = "08599"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);
            //d = new DirectionType(); d.Name = "Kielce";
            //item = new DirectionItemType(); item.PnaFrom = "25000 "; item.PnaTo = "29999"; item.WSR = ""; d.DirectionsPNAList.Add(item);
            //carousel.Dicts.Directions.Add(d);


            //carousel.Save();





            Console.ReadLine();
        }
    }
}
