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
            URL url1 = new URL();
            //
            // Carry out full parse of URL
            //
            Parser.FullParse(url1, "https://www.youtube.com/results?search_query=test+search");
           Console.ReadLine();
        }
    }
}
