using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using URL_Parser;

namespace TechTest
{
    public class UrlPrinter
    {
        public void Print(URL url)
        {
            Console.WriteLine("I'm writing an Url");
            Console.WriteLine($"Scheme: {url.Scheme}");
            Console.WriteLine($"Port: {url.Port}");
            Console.WriteLine($"Path: {string.Join(", ", url.Path)}");
            Console.WriteLine();

        }
    }
}
