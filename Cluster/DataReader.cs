using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cluster
{
    class DataReader
    {
        public HashSet<Flow> ReadFlow()
        {
            HashSet<Flow> set = new HashSet<Flow>();
            using (StreamReader reader = new StreamReader("flows.csv", Encoding.GetEncoding(437)))
            {
                //column names in first line in excel
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
        public List<Flow> ReadFlowList(bool x)
        {
            List<Flow> set = new List<Flow>();
            using (StreamReader reader = new StreamReader("flows.csv", Encoding.GetEncoding(437)))
            {
                //column names in first line in excel
                reader.ReadLine();
                while (!reader.EndOfStream)
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
            using (StreamReader reader = new StreamReader("distances.csv", Encoding.GetEncoding(437)))
            {
                //column names in first line in excel
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
        public List<Distance> ReadDistList()
        {
            List<Distance> set = new List<Distance>();
            using (StreamReader reader = new StreamReader("distances.csv", Encoding.GetEncoding(437)))
            {
                //column names in first line in excel
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
