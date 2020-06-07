using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Wecker
{
    abstract class Appointment
    {
        private int minutes { get; set; }
        private int hours { get; set; }
        private string title { get; set; }

        private static int n;

        public Appointment(string title, int hours, int minutes)
        {
            this.title = title;
            this.hours = hours;
            this.minutes = minutes;
            n++;
        }

        public override string ToString()
        {
            return hours.ToString("D2") + ":" + minutes.ToString("00") + " " +title;
        }

        public abstract void Alarm();
        

        public bool IsActive()
        {
            DateTime d = DateTime.Now;
            if (d.Hour == hours && d.Minute == minutes) return true;
            else return false;
        }

    }

    class AppointmentSound : Appointment
    {
        public AppointmentSound(string titel, int hours, int minutes ) : base(titel, hours, minutes)
        {            
        }

        public override string ToString()
        {
            return "K "+base.ToString();
        }

        public override void Alarm()
        {
            System.Media.SystemSounds.Beep.Play();
        }
    }

    class AppointmentColour : Appointment
    {
        private MainWindow mw;
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public AppointmentColour(string titel, int hours, int minutes, MainWindow mw0) : base(titel, hours, minutes)
        {
            this.mw = mw0;
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += AlarmOff;
        }

        private void AlarmOff(object sender, EventArgs e)
        {
            mw.Background=Brushes.White;
            timer.Stop();
        }

        public override string ToString()
        {
            return "F " + base.ToString();
        }

        public override void Alarm()
        {
            mw.Background = Brushes.Red;
            timer.Start();
        }
    }
}
