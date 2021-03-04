using CarApp.Pages;
using CarApp.Properties;
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
using System.Windows.Threading;

namespace CarApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Таймер - задаёт время блокировки, второй же таймер для проверки выполняемости условия блокировки
        public static DispatcherTimer timer, checkTime;
        bool fiveMinutes = false;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());

            timer = new DispatcherTimer();
            checkTime = new DispatcherTimer();


            timer.Interval = new TimeSpan(0, 0, 5);
            checkTime.Interval = new TimeSpan(0, 0, 1);

            timer.Tick += Timer_Tick;
            checkTime.Tick += CheckTime_Tick;
            
        }

        private void CheckTime_Tick(object sender, EventArgs e)
        {
            Banner();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (fiveMinutes == false)
            {
                MessageBox.Show("До конца сеанса осталось 5 минут");
                fiveMinutes = true;
            } else
            {
                MainFrame.Navigate(new LoginPage());
                Banner();
                timer.Stop();
                checkTime.Start();
                Settings.Default.TimeBan = DateTime.Now.AddSeconds(5);
                Settings.Default.Save();
            }
        }


        /// <summary>
        /// Логика блокировки приложения
        /// </summary>
        void Banner()
        {
            if (DateTime.Now < Settings.Default.TimeBan)
            {
                this.IsEnabled = false;
            }
            else
            {
                this.IsEnabled = true;
                checkTime.Stop();
            }
        }
    }
}
