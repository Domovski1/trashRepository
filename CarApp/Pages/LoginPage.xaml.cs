using CarApp.Classes;
using CarApp.Model;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnCaptha_Click(object sender, RoutedEventArgs e)
        {
            TxbCaptcha1.Text = RandomCaptcha();
        }


        /// <summary>
        /// Логика для показа пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (PsbPassword.Visibility == Visibility.Visible)
            {
                TxbPassword.Text = PsbPassword.Password;
                TxbPassword.Visibility = Visibility.Visible;
                PsbPassword.Visibility = Visibility.Collapsed;
            } else
            {
                TxbPassword.Visibility = Visibility.Collapsed;
                PsbPassword.Visibility = Visibility.Visible;
            }
        }



        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            
                try
                {
                if (TxbCaptcha1.Text == TxtCaptcha.Text)
                {

                    var CurrentUser = BaseClass.db.User.FirstOrDefault(x => x.login == TxbLogin.Text && x.password == PsbPassword.Password);

                    if (CurrentUser != null)
                    {
                        NavigationService.Navigate(new HelloPage(CurrentUser));
                        History historySuccess = new History { login = TxbLogin.Text, password = PsbPassword.Password, TimeLog = DateTime.Now, success = true };
                        BaseClass.db.History.Add(historySuccess);
                        BaseClass.db.SaveChanges();
                    }
                    else
                    {
                        
                        History historyFalse = new History { login = TxbLogin.Text, password = PsbPassword.Password, TimeLog = DateTime.Now, success = false };
                        BaseClass.db.History.Add(historyFalse);
                        BaseClass.db.SaveChanges();

                        StckCaptcha.Visibility = Visibility.Visible;
                        TxbCaptcha1.Text = RandomCaptcha();

                        MessageBox.Show("Неверный логин или пароль");
                    }


                }
                else
                {
                    MessageBox.Show("Неверно введена капча", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }
           
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                } 
            
            
        }


        /// <summary>
        /// Генератор capthc
        /// </summary>
        /// <returns></returns>
        string RandomCaptcha()
        {
            string password = "";
            string Aplabet = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM";
            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                password += Aplabet[rand.Next(Aplabet.Length)];
                
            }

            return password;
        }
    }
}
