using CarApp.Model;
using CarApp.Pages.Admin;
using CarApp.Pages.Inspector;
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

namespace CarApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для HelloPage.xaml
    /// </summary>
    public partial class HelloPage : Page
    {
        public User user { get; set; }
        public HelloPage(User getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (user.roleID == 1)
            {

                NavigationService.Navigate(new InspectorMainPage());
            }
            else if (user.roleID == 2)
            {
                NavigationService.Navigate(new AdminMainPage());
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (user.roleID == 1)
            {

                TxbHello.Text = $"Добрый день, {user.surname} {user.name}! Ваша роль: {user.Role.Title}!";
                ImgBox.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg"));
            }
            else if (user.roleID == 2)
            {

                TxbHello.Text = $"Добрый день, {user.surname} {user.name}! Ваша роль: {user.Role.Title}!";
                ImgBox.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/2.jpg"));
            }
            
        }
    }
}
