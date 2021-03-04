using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var getAllFiles = File.ReadAllLines(@"C:\Users\Domovski\Downloads\Telegram Desktop\09_1.5_2\09_1.5_2\Сессия 1\txt1.txt");
            

            List<Service> listService = new List<Service>();

            foreach (var item in getAllFiles)
            {
                var del = item.Split('\t');
                listService.Add(new Service { 
                    Title = del[1], 
                    DurationInSeconds = Convert.ToInt32(del[2]), 
                    Cost = Convert.ToInt32(del[3]), 
                    Discount = Convert.ToInt32(del[4])
                });
            }


            BaseClass.db.Service.AddRange(listService);
            BaseClass.db.SaveChanges();
            
            Console.ReadKey();
        }
    }
}
