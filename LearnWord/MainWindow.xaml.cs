using LearnWord.Classes;
using LearnWord.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using Word = Microsoft.Office.Interop.Word;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace LearnWord
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DemoTestBaseEntities db = new DemoTestBaseEntities();
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = db.Service.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                WordDocer();
                //Printer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        
        void WordDocer ()
        {
            var word = new Word.Application();
            try
            {
                var document = word.Documents.Open(Environment.CurrentDirectory + @"\" + "TEmplate.docx");
                var table = document.Tables[1];

                var service = db.Service.ToList();
                int i = 2;
                foreach (var item in service)
                {
                    table.Rows.Add();
                    table.Cell(i, 1).Range.Text = item.Title;
                    table.Cell(i, 2).Range.Text = Math.Round(item.Cost, 2).ToString();
                    table.Cell(i, 3).Range.Text = (item.DurationInSeconds / 60).ToString();
                    table.Cell(i, 4).Range.Text = (Convert.ToDouble(item.Cost) - (Convert.ToDouble(item.Cost) * Convert.ToDouble(item.Discount)) / 100).ToString();
                    i++;
                }

                document.SaveAs2(@"C:\Users\Domovski\Desktop\service.pdf", Word.WdSaveFormat.wdFormatPDF);
                document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
            }
        }


        void Printer()
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {

                printObj.PrintVisual(dg, "");
            } else
            {
                MessageBox.Show("Вы отменили принт");
            }
        }

        
        
        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var service = db.Service.ToList();

            service = service.Where(x => LevenshteinClass.Distance(TxbSearch.Text.ToLower(), x.Title.ToLower()) <= 3 && 
                                         LevenshteinClass.Distance(TxbSearch.Text.ToLower(), x.Title.ToLower()) != -1 ||
                                                          x.Title.ToLower().Contains(TxbSearch.Text.ToLower()) ).ToList();

            dg.ItemsSource = service;
        }

        private void ToCSV_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream stream = new FileStream(@"C:\Users\Domovski\Desktop\data.csv", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    var service = db.Service.ToList();

                    //Название заголовков
                    writer.WriteLine("Название; Длительность; Цена");

                    foreach (var item in service)
                    {
                        writer.WriteLine($"{item.Title}; {item.DurationInSeconds}; {item.Cost}");
                    }

                }
            }

        }

        private void ToJSON_Click(object sender, RoutedEventArgs e)
        {
            var service = db.Service.ToList();
            var option = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)};
            
            string str = JsonSerializer.Serialize<List<Service>>(service, option);

            File.WriteAllText(@"C:\Users\Domovski\Desktop\filejson.json", str);

        }
    }
}
