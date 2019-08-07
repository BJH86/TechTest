using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace URL_Parser
{
    class URLParser
    {
        public static void ParseURL(URLobject atester, string asentence) {
            //
            // Assign tester sentence and regex pattern
            //
            string sentence = asentence;
            string regex = "[ ]";
            //
            // Split tester string based on whitespace
            //
            string[] result = Regex.Split(sentence, regex);
            atester.Authority = result[0];
            atester.Query = result[1];
            //
            //Output to console
            //
            Console.WriteLine("Authority: "+atester.Authority);
            Console.WriteLine("Query: " + atester.Query);



        }
    }
}
