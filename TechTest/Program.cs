using System;
using System.Collections.Generic;
using System.Linq;
using URL_Parser;

namespace TechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Use var - don't use types
            var parser = new Parser();
            var printer = new UrlPrinter();

            foreach (var url in Urls)
            {
                var outputUrl = parser.Parse("https://www.youtube.com/results?search_query=test+search");
                printer.Print(outputUrl);
            }

            Console.ReadKey();
        }

        private static IEnumerable<string> Urls => new List<string>
        {
            "https://www.youtube.com/results?search_query=test+search",
            "http://www.google.com"
        };
    }
}
