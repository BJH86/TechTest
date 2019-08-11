using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace URL_Parser
{
    class Parser
    {
        public static void FullParse(URL atester, string asentence)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Full URL: " + asentence);
            Console.WriteLine("---------------");
            ParseURLScheme(atester, asentence);
            ParseURLHost(atester, asentence);
            ParseURLPort(atester, asentence);
            ParseURLAuthority(atester, asentence);
            ParseURLPath(atester, asentence);
            ParseURLQuery(atester, asentence);
            ParseURLFragment(atester, asentence);
            Console.WriteLine("---------------");
            Console.WriteLine("Parsed URL object formed");


        }
        public static void ParseURLScheme(URL atester, string asentence)
        {
            //
            // Assign tester url and regex pattern to find scheme
            //
            string sentence = asentence;
            string regex = "^[a-z A-Z 0-9]+[//|:|/.]";
            //
            // Match based on regex pattern
            //
            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> schemeList = new List<string>();
            //
            foreach (Match match in result)
                schemeList.Add(match.Value);
            //
            // If list contains the parsed information, remove : and / from string and assign first match to attribute
            //
            if (schemeList.Count > 0) {
                atester.Scheme = schemeList[0].Replace(":", "");
                atester.Scheme = atester.Scheme.Replace("/", "");
            }
            //
            //Output to console
            //
            Console.WriteLine("Scheme: " + atester.Scheme);
        }

        public static void ParseURLHost(URL atester, string asentence)
        {
            
            string sentence = asentence;
            string regex = "(//|www|:)[a-z + - @ 0-9.]+";
           
            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> hostList = new List<string>();
            
            foreach (Match match in result)
                hostList.Add(match.Value);
           
            if (hostList.Count > 0) {
                atester.Host = hostList[0].Replace("/", "");
            }
            Console.WriteLine("Host: " + atester.Host);
        }

        public static void ParseURLPort(URL atester, string asentence)
        {

            string sentence = asentence;
            string regex = ":[0-9]+";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> portList = new List<string>();

            foreach (Match match in result)
                portList.Add(match.Value);

            if (portList.Count > 0)
            {
                atester.Port = Convert.ToInt32(portList[0].Replace(":", ""));
            }
            Console.WriteLine("Port: " + atester.Port);
        }
        public static void ParseURLPath(URL atester, string asentence)
        {

            string sentence = asentence;
            string regex = "[^\\/]((\\/\\w+)*\\/)([\\w\\-\\.]+[^#?]+)";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> FullPathList = new List<string>();

            foreach (Match match in result)
                FullPathList.Add(match.Value);

            if (FullPathList.Count > 0)
            {
                string fullPath = FullPathList[0].Remove(0,2);
                String[] ParsedPathArray = fullPath.Split("/");
                List<string> ParsedPathList = new List<string>();
                foreach (String path in ParsedPathArray)
                    ParsedPathList.Add(path);
                atester.Path = ParsedPathList;
                Console.WriteLine("---------------");
                Console.WriteLine("Full Path: " + fullPath);

                for (int i = 0; i < atester.Path.Count; i++)
                {
                    Console.WriteLine("Path Element " + i + ": " + atester.Path[i]);
                }
            } 
        }

        public static void ParseURLFragment(URL atester, string asentence)
        {

            string sentence = asentence;
            string regex = "#.+";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> fragmentList = new List<string>();

            foreach (Match match in result)
                fragmentList.Add(match.Value);

            if (fragmentList.Count > 0)
            {
                atester.Fragment = fragmentList[0].Replace("#", "");
            }
            Console.WriteLine("Fragment: " + atester.Fragment);
        }

        public static void ParseURLAuthority(URL atester, string asentence)
        {

            string sentence = asentence;
            string regexHost = "(//|www|:)[a-z + - @ 0-9.]+";

            MatchCollection resultHost = Regex.Matches(sentence, regexHost);
            List<string> hostList = new List<string>();

            foreach (Match match in resultHost)
                hostList.Add(match.Value);

            if (hostList.Count > 0)
            {
                atester.Host = hostList[0].Replace("/", "");
            }
            string regexPort = ":[0-9]+";

            MatchCollection resultPort = Regex.Matches(sentence, regexPort);
            List<string> portList = new List<string>();

            foreach (Match match in resultPort)
                portList.Add(match.Value);

            if (portList.Count > 0)
            {
                atester.Port = Convert.ToInt32(portList[0].Replace(":", ""));
            }

            if (atester.Port != 0) { atester.Authority = atester.Host + ":" + Convert.ToString(atester.Port); }
            else atester.Authority = atester.Host;

            Console.WriteLine("Authority: " + atester.Authority);
        }
        public static void ParseURLQuery(URL atester, string asentence)
        {

            string sentence = asentence;
            string regex = "\\?.+\\=\\w+|\\+\\w+(#=\\#)";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> queryList = new List<string>();
            Dictionary<string, string> queryDict = new Dictionary<string, string>();

            foreach (Match match in result)
                queryList.Add(match.Value);
        
            if (queryList.Count > 0)
            {
                String fullQuery = queryList[0].Replace("?", "");
                String[] fullQueryArray = fullQuery.Split("&");

                for (int i = 0; i < fullQueryArray.Length; i++)
                {
                    String query = fullQueryArray[i];
                    String[] partQueryArray = query.Split("=");
                    queryDict.Add(partQueryArray[0], partQueryArray[1]);
                }

                atester.Query = queryDict;
                Console.WriteLine("---------------");
                Console.WriteLine("Full Query: " + fullQuery);

                foreach (KeyValuePair<string, string> pair in atester.Query)
                {
                    Console.WriteLine("Key: " + pair.Key);
                    Console.WriteLine("Value: " + pair.Value);
                }
                Console.WriteLine("---------------");

            }
      
        }
    } 


}