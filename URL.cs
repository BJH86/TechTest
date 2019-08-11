using System;
using System.Collections.Generic;
using System.Text;

namespace URL_Parser
{
    class URL
    {
        private string scheme = null;
        private string authority = null;
        private string host = null;
        private int port = 0;
        private List<string> path = null;
        private Dictionary<string, string> query = null;
        private string fragment = null;

        //Constructor for empty Parsed URL object
        public URL() {
        Console.WriteLine("New URL object formed");
        }

        //Constructor with params for Parsed URL object (just for reminder)
        public URL(string ascheme, string aauthority, string ahost, int aport, List<string> apath, Dictionary<string, string> aquery, string afragment)
        {
            Scheme = ascheme;
            Authority = aauthority;
            Host = ahost;
            Port = aport;
            Path = apath;
            Query = aquery;
            Fragment = afragment;
            Console.WriteLine("Parsed URL object formed");
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

        public Dictionary<string, string> Query
        { get { return query; } set { query = value; } }

        public string Fragment
        { get { return fragment; } set { fragment = value; } }

    }
}
