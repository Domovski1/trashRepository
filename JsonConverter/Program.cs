using JsonConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new HttpClient();

            var data = client.GetStringAsync(@"https://jsonplaceholder.typicode.com/comments");

            var serializer = JsonSerializer.Deserialize<List<CommentsTable>>(data.Result);

            ResourcesImportBaseEntities db = new ResourcesImportBaseEntities();
            db.CommentsTable.AddRange(serializer);
            db.SaveChanges();

            Console.WriteLine("All done");
            Console.ReadKey();
        }
    }
}
