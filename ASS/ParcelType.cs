using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS
{
    public class ParcelType
    {

        public class ParcelEventArgs
        {
            public string ParcelNumber { get; set; }
            public string ErrorMessage { get; set; }
            public ParcelType parcel { get; set; }
        }

        public int id { get; set; }

        public ShiftType Shift { get; set; }
        public string Number { get; set; }
        public string ShiftID { get; set; }
        public int TactCount { get; set; }
        public int Lenght { get; set; }
        public bool TurnOffbyTimer { get; set; }
        public ServiceReference1.Przesylka ZSTData { get; set; }

        public bool BehindDestination { get; set; }
        public bool NextRound { get; set; }

        public SignalingType signaling { get; set; }
        public string DestinationPNA { get; set; }

        public string ParcelPlateID { get; set; }

        public bool SecondRunt { get; set; }

        private Timer TimerToOff_1 { get; set; }
        private Timer TimerToOff_2 { get; set; }
        private Timer TimerToOff_3 { get; set; }
        private Timer TimerToOff_4 { get; set; }

        private int TimeElapsed_1 { get; set; }
        private int TimeElapsed_2 { get; set; }
        private int TimeElapsed_3 { get; set; }
        private int TimeElapsed_4 { get; set; }

        public int correctCounts { get; set; }
        public int OccupiedPlates { get; set; }

        bool isrunning { get; set; }
        public DateTime StopRunTime { get; set; }
        public DateTime StartRunTime { get; set; }

        public StandItemType Destination { get; set; }

        public EventHandler<ParcelEventArgs> ParcelError;
        public EventHandler<ParcelEventArgs> ParcelDataOK;
        public EventHandler<ParcelEventArgs> TactAdded;

        public event EventHandler OnLampOn_1;
        public event EventHandler OnLampOn_2;
      
        public event EventHandler OnLampOff_1;
        public event EventHandler OnLampOff_2;
       
        public void SetAddressAsync(List<StandType> stands, bool TurnOffLampByTimer)
        {
            if (this.Number.Length < 8)
                return;


          Task.Run(()=>SetAddress(stands, TurnOffLampByTimer));
        }
        public void SetAddress( List<StandType> stands, bool TurnOffLampByTimer)
        {
            this.TurnOffbyTimer = TurnOffLampByTimer;

            GetZSTData();

            if (ZSTData == null)
            {
                this.DestinationPNA = "999999";
                SetStand( stands);

                ParcelEventArgs args = new ParcelEventArgs();
                args.ParcelNumber = this.Number;
                args.ErrorMessage = "Brak danych w ZST " + this.Destination.Direction.Name;
                args.parcel = this;

                EventHandler<ParcelEventArgs> handler = ParcelError;
                handler.Invoke(this, args);
                return;
            }

            if (ZSTData.danePrzesylki == null)
            {


                this.DestinationPNA = "999999";
                SetStand( stands);

                ParcelEventArgs args = new ParcelEventArgs();
                args.ParcelNumber = this.Number;
                args.ErrorMessage = "Brak danych w ZST " + this.Destination.Direction.Name ;
                args.parcel = this;

                EventHandler<ParcelEventArgs> handler = ParcelError;
                handler.Invoke(this, args);



            }

            if (ZSTData.danePrzesylki != null)
            {
                this.DestinationPNA = ZSTData.danePrzesylki.urzadPrzezn.daneSzczegolowe.pna;
                SetStand( stands);

                if (this.Destination != null)
                {
                    ParcelEventArgs args = new ParcelEventArgs();
                    args.ParcelNumber = this.Number;
                    args.ErrorMessage = "Wyznaczono kierunek " + Destination.Direction.Name;
                    args.parcel = this;

                    EventHandler<ParcelEventArgs> handler = ParcelDataOK;
                    handler.Invoke(this, args);
                }
                else
                {
                    ParcelEventArgs args = new ParcelEventArgs();
                    args.ParcelNumber = this.Number;
                    args.ErrorMessage = "Brak w planie kierowania " + this.DestinationPNA;
                    args.parcel = this;

                    EventHandler<ParcelEventArgs> handler = ParcelError;
                    handler.Invoke(this, args);

                }
            }
        }
        private void GetZSTData()
        {
            ZSTData = TrackingInterface.SprawdzPrzesylke(this.Number);
        }
        private void SetStand(List<StandType> stands)
        {
            foreach (var stand in stands)
            {
                string parcelPNA = this.DestinationPNA;

                if (stand.StandItem1.Direction != null)
                {
                    if (stand.StandItem1.Direction.isInRange(parcelPNA))
                    {
                        this.Destination = stand.StandItem1;
                        stand.StandItem1.SortedParcels += 1;
                    }
                }

                if (stand.StandItem2.Direction != null)
                {
                    if (stand.StandItem2.Direction.isInRange(parcelPNA))
                    {
                        this.Destination = stand.StandItem2;
                        stand.StandItem2.SortedParcels += 1;
                    }
                }

                if (stand.StandItem3.Direction != null)
                {
                    if (stand.StandItem3.Direction.isInRange(parcelPNA))
                    {
                        this.Destination = stand.StandItem3;
                        stand.StandItem3.SortedParcels += 1;
                    }

                }

                if (stand.StandItem4.Direction != null)
                {
                    if (stand.StandItem4.Direction.isInRange(parcelPNA))
                    {
                        this.Destination = stand.StandItem4;
                        stand.StandItem4.SortedParcels += 1;
                    }

                }
            }

        }
        public void StartRun()
        {
            isrunning = true;
            this.StartRunTime = DateTime.Now;
        }
        public double RunTime()
        {
            TimeSpan ts;
            if (isrunning == true)
            {
                ts   = DateTime.Now - StartRunTime;
            }
            else
            {
                ts = StopRunTime - StartRunTime;
            }
        
            return (double)ts.TotalSeconds;
        }
        private void OnTimedEvent_Lamp1(object source, EventArgs e)
        {
            TimeElapsed_1 += 1;
            if (TimeElapsed_1 > this.Lenght)
            {
                this.Destination.Lamp1.TurnOff(signaling);
                TimerToOff_1.Stop();

                EventHandler ev = OnLampOff_1;
                ev?.Invoke(this, e);
            }
        }
        private void Lamp1_On()
        {
            if (TurnOffbyTimer == true)
            {
                TimeElapsed_1 = 0;
                TimerToOff_1 = new System.Timers.Timer(1);
                TimerToOff_1.Interval = 1;
                TimerToOff_1.Elapsed += OnTimedEvent_Lamp1;
                TimerToOff_1.Start();
            }
        }
        public void OnTimedEvent_Lamp2(object source, EventArgs e)
        {
            TimeElapsed_2 += 100;
            if (TimeElapsed_2 > this.Lenght)
            {
                this.Destination.Lamp2.TurnOff(signaling);
                TimerToOff_2.Stop();
                //this.Destination.Lamp1.TurnOff(signaling);

                EventHandler ev = OnLampOff_2;
                ev?.Invoke(this, e);

            }
        }
        public async void Lamp2_On()
        {
            if (TurnOffbyTimer == true)
            {
                TimeElapsed_2 = 0;
                TimerToOff_2 = new System.Timers.Timer(1);
                TimerToOff_2.Interval = 100;
                TimerToOff_2.Elapsed += OnTimedEvent_Lamp2;
                Task.Run(()=> TimerToOff_2.Start());
            }
        }


        public void AddToBase()
        {
            Task.Run(() => AddToBases());
        }
        private void AddToBases()
        {
            try
            {
                this.ShiftID = Shift.id.ToString();

                mySQLcore m = mySQLcore.DB_Main();
                mySQLcore.KillSleepConnections(m, 100);
                string js = this.ToJson();
                
              this.id=int.Parse( m.ExecuteScalar("INSERT INTO parcels (shiftid,number,content,stand,dest,tm) VALUES ('" + this.ShiftID +"','" + this.Number +"','" + js + "','" + "" + "','" + this.Destination.Direction.Name + "','" + this.StartRunTime + "');select last_insert_id();"));

            }
            catch (Exception ex)
            {

                
            }
        }

        public void UpdateTime()
        {
            try
            {
                    mySQLcore m = mySQLcore.DB_Main();
                    m.ExecuteNonQuery("update parcels set time='" + this.RunTime() + "' where id=" + this.id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string ToJson()
        {        

            string js =JsonConvert.SerializeObject(this.ZSTData.danePrzesylki);
            return js;
        }



        public async void CheckTacts()
        {

            //if (this.TactCount == this.Destination.Lamp1.TactsToTurnON - this.correctCounts-1)
            //{
            //  await  this.Destination.Lamp1.PrepareLamp(signaling);
            //}
            //if (this.TactCount == this.Destination.Lamp2.TactsToTurnON - this.correctCounts - 1)
            //{
            //  await  this.Destination.Lamp2.PrepareLamp(signaling);
            //}

            if (this.TactCount == this.Destination.Lamp1.TactsToTurnON - this.correctCounts)
            {
                isrunning = false;
                StopRunTime = DateTime.Now;
                //Lamp1_On();
                //await this.Destination.Lamp1.TurnOn(signaling);

                
                this.Destination.Lamp1ONTacts = this.Destination.Lamp1.TactsToTurnOff;

                EventArgs e = new EventArgs();
                EventHandler ev = OnLampOn_1;
                ev?.Invoke(this, e);
            }

            if (this.Destination.Lamp2ByTacts == true)
            {
                if (this.TactCount == this.Destination.Lamp2.TactsToTurnON - this.correctCounts)
                {
                    Lamp2_On();
                    await  this.Destination.Lamp2.TurnOn(signaling);
                    EventArgs e = new EventArgs();
                    EventHandler ev = OnLampOn_2;
                    ev?.Invoke(this, e);
                }
            }

     
            if (this.TactCount == this.Destination.Lamp1.TactsToTurnOff - this.correctCounts)
            {
                this.Destination.Lamp1.TurnOff(signaling);
                //this.Destination.Lamp1ON = false;
                EventHandler ev = OnLampOff_1;
                EventArgs e = new EventArgs();
                ev?.Invoke(this, e);
            }

            if (this.TurnOffbyTimer == false)
            {
                if (this.TactCount == this.Destination.Lamp2.TactsToTurnOff - this.correctCounts)
                {
                    this.Destination.Lamp2.TurnOff(signaling);
              
                    EventHandler ev = OnLampOff_2;
                    EventArgs e = new EventArgs();
                    ev?.Invoke(this, e);
                }
            }

         




            ParcelEventArgs args = new ParcelEventArgs();
            args.ParcelNumber = this.Number;
            args.ErrorMessage = "";
            args.parcel = this;

            EventHandler<ParcelEventArgs> handler = TactAdded;
            handler.Invoke(this, args);
            
      
        }

        public void AddTact()
        {
            this.TactCount += 1;
        }

    }
}
