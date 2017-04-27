using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogApril2017
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayFirstLine().ContinueWith(t =>
            {
                Console.WriteLine(t.Result);
            });
            Console.ReadLine();
        }

        public static async Task<string> DisplayFirstLine()
        {
            return await FileHandlerAsync.ReadAllLinesAsync(@"D:\oriol\Blog\Repository\AsyncProgramming\BlogApril2017\BlogApril2017TestDocument.txt");
        }
    }
}
