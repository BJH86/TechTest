using System;
using System.Collections.Generic;
using System.Text;

namespace URL_Parser
{
    class URLobject
    {
        private string scheme;
        private string authority;
        private string host;
        private int port;
        private List<string> path;
        private string query;
        private string fragment;

        //Constructor for URLobject
        public URLobject() {
        Console.WriteLine("URL object formed");
        }

        //Constructor with params for URLobject
        public URLobject(string ascheme, string aauthority, string ahost, int aport, List<string> apath, string aquery, string afragment)
        {
            Scheme = ascheme;
            Authority = aauthority;
            Host = ahost;
            Port = aport;
            Path = apath;
            Query = aquery;
            Fragment = afragment;
            Console.WriteLine("URL object formed");
        }

        // Setters and Getters for URLobject
        public string Scheme
        {get { return scheme;} set { scheme = value; }}

        public string Authority
        { get { return authority; } set { authority = value; } }

        public string Host
        { get { return host; } set { host = value; } }

        public int Port
        { get { return port; } set { port = value; } }

        public List<string> Path
        { get { return path; } set { path = value; } }

        public string Query
        { get { return query; } set { query = value; } }

        public string Fragment
        { get { return fragment; } set { fragment = value; } }

    }
}
