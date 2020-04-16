using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wecker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //timer
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Start();
            timer.Tick += checkAlarms;
        }

        void checkAlarms(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_Appointments.Items.Count; i++)
            {
                Appointment t = (Appointment)LB_Appointments.Items[i];
                if(t.IsActive())
                {
                    t.Alarm();
                }
            }
        }

        private void Button_TerminHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            string titel = TB_Title.Text;
            int minuten, stunden;
            bool result;

            result = int.TryParse(TB_Hours.Text, out stunden);
            result &= int.TryParse(TB_Minutes.Text, out minuten);

            if(result && stunden >= 0 && stunden <= 23 && minuten >=0 && minuten <=59)
            {
                if (RB_Colour.IsChecked == true)
                {
                    Appointment Termin = new AppointmentColour(titel, stunden, minuten);
                    LB_Appointments.Items.Add(Termin);
                  
                }
                else
                {
                    Appointment Termin = new AppointmentSound(titel, stunden, minuten);
                    LB_Appointments.Items.Add(Termin);
                }
            }
            else
            {
                MessageBox.Show("Fehler");
            }
        }


        private void Button_TerminLoeschen_Click(object sender, RoutedEventArgs e)
        {
            int i = LB_Appointments.SelectedIndex;
            if (i >= 0)
            {
                LB_Appointments.Items.RemoveAt(i);
            }
        }
    }

}
