using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class Distance
    {
        public string Key { get; }
        public string Origin { get; }
        public string Destination { get; }
        public double Dist { get; }
        public double Time { get; }
        
        public Distance(string origin, string dest, double dist, double time)
        {
            Origin = origin;
            Destination = dest;
            Dist = dist;
            Time = time;
            Key = string.Concat(origin, '-', dest);
        }
        public Distance(string key, string origin, string dest, double dist, double time)
        {
            Key = Key;
            Origin = origin;
            Destination = dest;
            Dist = dist;
            Time = time;
        }

        public Distance(string line)
        {
            string[] vals = line.Split(',');
            Key = vals[0];
            Origin = vals[1];
            Destination = vals[2];
            Dist = Double.Parse(vals[3]);
            Time = Double.Parse(vals[4]);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Key, Origin, Destination, Dist, Time);
        }
    }
}
