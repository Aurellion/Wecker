using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wecker
{
    class Appointment
    {
        private int minutes { get; set; }
        private int hours { get; set; }
        private string title { get; set; }

        public Appointment(string title, int hours, int minutes)
        {
            this.title = title;
            this.hours = hours;
            this.minutes = minutes;
        }

        public override string ToString()
        {
            return hours.ToString("D2") + ":" + minutes.ToString("00") + " " +title;
        }

        public virtual void Alarm()
        {

        }

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
        public AppointmentColour(string titel, int hours, int minutes) : base(titel, hours, minutes)
        {
        }

        public override string ToString()
        {
            return "F " + base.ToString();
        }

        public override void Alarm()
        {
            //hier ergaenzen
        }
    }
}
