using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            DisplayFileContentAsync().ContinueWith(t => { Console.WriteLine(t.Result); });
            GetTemperatureAsync().ContinueWith(t => { Console.WriteLine($"Temperature: {t.Result}"); });
            Console.ReadLine();
        }

        public static async Task<string> DisplayFileContentAsync()
        {
            return await FileHandlerAsync.ReadAllLinesAsync(
                @"D:\oriol\Blog\Repository\AsyncProgramming\BlogApril2017\BlogApril2017TestDocument.txt");
        }

        public static async Task<string> GetTemperatureAsync()
        {
            var result = await APIHandlerAsync.GetWeatherAsync();
            return result.Main.temp.ToString(CultureInfo.InvariantCulture);
        }
    }
}