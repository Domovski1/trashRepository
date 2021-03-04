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

namespace CarApp.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void BtnToMainPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryPage());
        }
    }
}
