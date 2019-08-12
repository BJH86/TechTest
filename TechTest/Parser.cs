using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace URL_Parser
{
    class Parser
    {
        public URL Parse(string inputUrl)
        {

            var outputUrl = new URL
            {
                Scheme = ParseUrlScheme(inputUrl)
            };  

            ParseURLHost(outputUrl, inputUrl);
            ParseURLPort(outputUrl, inputUrl);
            ParseURLAuthority(outputUrl, inputUrl);
            ParseURLPath(outputUrl, inputUrl);
            ParseURLQuery(outputUrl, inputUrl);
            ParseURLFragment(outputUrl, inputUrl);

            return outputUrl;
        }

        private string ParseUrlScheme(string inputUrl)
        {
            // TODO: Use var
            // Strings are immutable, you can't mutate them
            string regex = "^[a-z A-Z 0-9]+[//|:|/.]";
            MatchCollection result = Regex.Matches(inputUrl, regex);

            // This is Linq, it's beautiful
            var schemeList = result.Select(match => match.Value).ToList();
            //List<string> schemeList = new List<string>();
            //foreach (Match match in result)
            //    schemeList.Add(match.Value);

            // Null coalescing operator returns string.empty
            return schemeList.FirstOrDefault()?.Replace(":", "").Replace("/", "");
        }

        private void ParseURLHost(URL outputUrl, string inputUrl)
        {

            string sentence = inputUrl;
            string regex = "(//|www|:)[a-z + - @ 0-9.]+";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> hostList = new List<string>();

            foreach (Match match in result)
                hostList.Add(match.Value);

            if (hostList.Count > 0)
            {
                outputUrl.Host = hostList[0].Replace("/", "");
            }
        }

        private void ParseURLPort(URL outputUrl, string inputUrl)
        {

            string sentence = inputUrl;
            string regex = ":[0-9]+";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> portList = new List<string>();

            foreach (Match match in result)
                portList.Add(match.Value);

            if (portList.Count > 0)
            {
                outputUrl.Port = Convert.ToInt32(portList[0].Replace(":", ""));
            }
        }
        private void ParseURLPath(URL outputUrl, string inputUrl)
        {

            string sentence = inputUrl;
            string regex = "[^\\/]((\\/\\w+)*\\/)([\\w\\-\\.]+[^#?]+)";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> FullPathList = new List<string>();

            foreach (Match match in result)
                FullPathList.Add(match.Value);

            if (FullPathList.Count > 0)
            {
                string fullPath = FullPathList[0].Remove(0, 2);
                String[] ParsedPathArray = fullPath.Split("/");
                List<string> ParsedPathList = new List<string>();
                foreach (String path in ParsedPathArray)
                    ParsedPathList.Add(path);
                outputUrl.Path = ParsedPathList;
            }
        }

        private void ParseURLFragment(URL outputUrl, string inputUrl)
        {

            string sentence = inputUrl;
            string regex = "#.+";

            MatchCollection result = Regex.Matches(sentence, regex);
            List<string> fragmentList = new List<string>();

            foreach (Match match in result)
                fragmentList.Add(match.Value);

            if (fragmentList.Count > 0)
            {
                outputUrl.Fragment = fragmentList[0].Replace("#", "");
            }
        }

        private void ParseURLAuthority(URL outputUrl, string inputUrl)
        {

            string sentence = inputUrl;
            string regexHost = "(//|www|:)[a-z + - @ 0-9.]+";

            MatchCollection resultHost = Regex.Matches(sentence, regexHost);
            List<string> hostList = new List<string>();

            foreach (Match match in resultHost)
                hostList.Add(match.Value);

            if (hostList.Count > 0)
            {
                outputUrl.Host = hostList[0].Replace("/", "");
            }
            string regexPort = ":[0-9]+";

            MatchCollection resultPort = Regex.Matches(sentence, regexPort);
            List<string> portList = new List<string>();

            foreach (Match match in resultPort)
                portList.Add(match.Value);

            if (portList.Count > 0)
            {
                outputUrl.Port = Convert.ToInt32(portList[0].Replace(":", ""));
            }

            if (outputUrl.Port != 0) { outputUrl.Authority = outputUrl.Host + ":" + Convert.ToString(outputUrl.Port); }
            else outputUrl.Authority = outputUrl.Host;
        }
        private void ParseURLQuery(URL outputUrl, string inputUrl)
        {

            string sentence = inputUrl;
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

                outputUrl.Query = queryDict;

            }

            //var test = queryList.Select(x => x.Split("&"));
            //var test2 = test.ToDictionary(x => x.First(), x => x.Last());
        }
    }


}