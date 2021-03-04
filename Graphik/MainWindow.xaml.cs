using System;
using System.Collections.Generic;
using System.IO;
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

namespace Graphik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GraphClass> GraphList = new List<GraphClass>();
        public MainWindow()
        {
            InitializeComponent();
            loader();

            chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("serias1"));

            chart.Series["serias1"].ChartArea = "Default";
            chart.Series["serias1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < GraphList.Count; i++)
            {
                chart.Series["serias1"].Points.AddXY(GraphList[i].date, GraphList[i].Point);
            }
        }


        void loader()
        {
            var file = File.ReadAllLines(@"C:\Users\Domovski\Desktop\data.txt");


            foreach (var item in file)
            {
                
                var del = item.Split(';');
                GraphList.Add(new GraphClass { 
                    date = Convert.ToDateTime(del[0]), 
                    Point = Convert.ToInt32(del[1])});
            }

            
        }
    }
}
