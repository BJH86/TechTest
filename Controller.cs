using System;
using System.Text.RegularExpressions;

namespace URL_Parser
{
    class Controller
    {
        static void Main(string[] args)
        {
            //
            //Create 'empty' URLobject
            //
            URLobject url1 = new URLobject();
            //
            // Perform parse on given url string and output selected attributes
            //
            URLParser.ParseURL(url1, "Hello World");
            Console.ReadLine();
        }
    }
}
