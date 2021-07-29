using ASS.devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ASS
{
    public class LampType
    {
        private bool BlinkingOn { get; set; }
        public System.Timers.Timer blinkTimer { get; set; }
        private DateTime blinkEndTime {get;set;}
        private SignalingType Signaling { get; set; }

        private System.Timers.Timer secondOffTimer { get; set; }

        public bool LampisON;

        public int TactsToTurnON { get; set; }
        public int TactsToTurnOff { get; set; }
        public bool LampBlinking { get; set; }
        public int LampBlinkingLenght { get; set; }
        public int LampBlinkingInterval { get; set; }
        public Color LampColor { get; set; }
        public SignalType TurnOnSignal { get; set; }
        public SignalType TurnOffSignal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public EventHandler OnLightOn;
        [JsonIgnore]
        [IgnoreDataMember]
        public EventHandler OnLightOff;

        public LampType()
        {
            TurnOnSignal = new SignalType();
            TurnOffSignal = new SignalType();
        }
      


     
        public async Task TurnOn(SignalingType signaling)
        {                            
                await TurnOnAsyncThread4(signaling);          
        }

        private Task TurnOnAsyncThread4(SignalingType signaling)
        {
            Lighton(signaling);
            return Task.CompletedTask;
        }

        private void Lighton(SignalingType signaling)
        {
            if (signaling == null)
                return;
            try
            {
                LampisON = true;
                signaling.PortRS232.WriteBytes(TurnOnSignal.FullSignal());


                EventHandler handler = OnLightOn;
                handler?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {

            }
        }

        public void TurnOff(SignalingType signaling,bool RepeatOff=true)
        {
            
            Task.Run(()=>TurnOffAsync(signaling,RepeatOff));
        }


        private void TurnOffAsync(SignalingType signaling, bool repeatOff)
        {
            if (signaling == null)
                return;


            try
            {
                LampisON = false;
                signaling.PortRS232.WriteBytes(TurnOffSignal.FullSignal());

                EventHandler handler = OnLightOff;
                handler?.Invoke(this, new EventArgs());
            }
            catch (Exception)
            {                

            }

            if (repeatOff == true)
            {
                    secondOffTimer = new Timer();
                    secondOffTimer.Interval = 300;
                    secondOffTimer.Elapsed += OnTimer2offTimedEvent;
                    secondOffTimer.Start();

                void OnTimer2offTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
                {
                    try
                    {
                        LampisON = false;
                        signaling.PortRS232.WriteBytes(TurnOffSignal.FullSignal());
                    }
                    catch (Exception)
                    {

                    }

                    Timer tm = (Timer)source;
                    tm.Stop();


                    secondOffTimer.Stop();
                    secondOffTimer.Enabled = false;
                    secondOffTimer.AutoReset = false;
                }
            }


        }


    }
}
