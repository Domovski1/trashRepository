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

namespace CarApp.Pages.Inspector
{
    /// <summary>
    /// Логика взаимодействия для InspectorMainPage.xaml
    /// </summary>
    public partial class InspectorMainPage : Page
    {

        DateTime TimeEntered, TimeNow;
        DispatcherTimer timer;
        public InspectorMainPage()
        {
            InitializeComponent();
            //MainWindow.timer.Start();
            timer = new DispatcherTimer();

            TimeEntered = new DateTime();
            TimeEntered = DateTime.Now;

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeNow = DateTime.Now;
            // Слишком много цифр после запятой
            TxbTime.Content = TimeNow.Subtract(TimeEntered).ToString();
        }

        private void BtnChechFines_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCheckAuto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNewFine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnToMainPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }


        
    }
}
