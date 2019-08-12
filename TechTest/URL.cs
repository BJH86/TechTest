using System;
using System.Collections.Generic;
using System.Text;

namespace URL_Parser
{
    // TODO: add access modifier
    public class URL
    {
        // TODO: remove, but also understand naming conventions
        // private fields tend to begin with _
        private List<string> path = null;
        private Dictionary<string, string> query = null;
        private string fragment = null;

        // TODO: Look at naming conventions
        // TODO: Rename parameters
        // Remember don't need a constructor every time
        //public URL(string scheme, string authority, string ahost, int aport, List<string> apath, Dictionary<string, string> aquery, string afragment)
        //{
        //    Scheme = scheme;
        //    Authority = authority;
        //    Host = ahost;
        //    Port = aport;
        //    Path = apath;
        //    Query = aquery;
        //    Fragment = afragment;
        //    Console.WriteLine("Parsed URL object formed");
        //}

        // TODO: set get and set
        // TODO: Learn about access modifiers
        public string Scheme { get; set; }

        public string Authority { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public List<string> Path
        { get { return path; } set { path = value; } }

        public Dictionary<string, string> Query
        { get { return query; } set { query = value; } }

        public string Fragment
        { get { return fragment; } set { fragment = value; } }
    }
}
