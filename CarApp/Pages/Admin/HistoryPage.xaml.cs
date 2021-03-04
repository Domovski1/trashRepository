using CarApp.Classes;
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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LvHistory.ItemsSource = BaseClass.db.History.ToList();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvHistory.ItemsSource = BaseClass.db.History.Where(x => x.login.Contains(TxbSearch.Text)).ToList();
            
        }

        private void BtnSortByDate_Click(object sender, RoutedEventArgs e)
        {
            LvHistory.ItemsSource = BaseClass.db.History.OrderByDescending(x => x.TimeLog).ToList();

        }
    }
}
