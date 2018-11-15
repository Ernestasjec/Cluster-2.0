using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Cluster
{
    class DataReader
    {
        public HashSet<Flow> ReadFlow()
        {
            HashSet<Flow> set = new HashSet<Flow>();
            using (StreamReader reader = new StreamReader("flows.csv"))
            {
                //column names in first line
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Flow f = new Flow(line);
                    set.Add(f);
                }
            }
            return set;
        }
        public HashSet<Distance> ReadDist()
        {
            HashSet<Distance> set = new HashSet<Distance>();
            using (StreamReader reader = new StreamReader("distances.csv"))
            {
                //column names in first line
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Distance d = new Distance(line);
                    set.Add(d);
                }
            }
            return set;
        }
    }
    
}
