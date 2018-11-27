using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class Flow
    {
        public string Load { get; }
        public string Unload { get; }
        public string Type { get; }
        public double FlowTons { get; }
        public double FlowTonKMs { get; }

        public Flow(string load, string unload, string type, double flowTons, double flowTonKMs)
        {
            Load = Load;
            Unload = unload;
            Type = type;
            FlowTons = flowTons;
            FlowTonKMs = flowTonKMs;
        }
        public Flow(string line)
        {
            string[] vals = line.Split(',');
            Load = vals[0];
            Unload = vals[1];
            Type = vals[2];
            FlowTons = Double.Parse(vals[3]);
            FlowTonKMs = Double.Parse(vals[4]);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Load, Unload, Type, FlowTons, FlowTonKMs);
        }
        public string getType()
        {
            return Type;
        }
    }
}
