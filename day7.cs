using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"c:\\users\kewin\desktop\data.txt");

            Dictionary<string, int> map = new Dictionary<string, int>();                   
            List<string> path = new List<string> { "/" };
            List<String> dirs = new List<string>();
            int DirSize = 0;

            for (int i = 0; i < lines.Length ; i++)
            {
                string pathname = "";

                if (lines[i][2] == 'c')
                {                   
                   
                    var pathtemp = lines[i].Substring(5);
                                      
                    if( pathtemp == "..")
                    {
                        path.RemoveAt(path.Count - 1);                         
                    }
                    else
                    {
                        path.Add(pathtemp);
                        pathname = string.Join('/', path);
                        /*Console.WriteLine(pathname);*/
                        map.Add(pathname, DirSize);
                    }

                }
                

                if (lines[i][0] != '$')
                {

                    if (Char.IsDigit(lines[i][0]))
                    {
                        /*Console.WriteLine("Herre");*/
                        string size = (lines[i].Substring(0));

                        int lengthofnumber = lines[i].IndexOf(" ") + 1;
                        string numberonly = size.Substring(0, lengthofnumber);
                        int sizeofdir = Int32.Parse(numberonly);

                        /*Console.WriteLine(sizeofdir + "and the whol;e thing is" + DirSize);*/

                        var dirpath = string.Join('/', path);
                        map[dirpath] = map[dirpath] + sizeofdir;

                    }
                }

                             
            }

            
            foreach (var x in map)
            {
                string sub = x.Key;
                
                for (int j = 0; j < map.Count; j++)
                {
                    var item = map.ElementAt(j);

                    if (item.Key.Contains(sub) && sub.Count() != item.Key.Count())
                    {
                        map[x.Key] += item.Value;
                    }                 
                }

            }
         
            /*int total = 0;
            foreach(var kvp in map)
            {
                if(kvp.Value < 100000)
                {
                    total += kvp.Value;
                }       
            }*/
            
            int totalspace = 70000000;
            int spaceneeded = 30000000;
            int home = map["///"];
            int spaceremaining = totalspace - home;
            int spaceforremoval = spaceneeded - spaceremaining;
            int closest = 1000000000;

            foreach(var kvp in map)
            {
                

                if (kvp.Value > spaceforremoval && kvp.Value < closest)
                {
                    closest = kvp.Value;
                    /*Console.WriteLine(kvp.Value + "    " + closest);*/

                }
               
            }

            Console.WriteLine(closest);
         
        }

    }
}
