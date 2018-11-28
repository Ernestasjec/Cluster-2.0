using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Cluster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double WCF = 308_525.05; // warehouse construction cost fixed      eur
        const double WCV = 539.91;     // warehouse construction cost variable   eur/ton
        const double WMF = 8_513.26;   // warehouse management cost fixed        eur/month
        const double WMV = 6.31;       // warehouse management cost variable     eur/ton/day
        const double TD = 125.41;      // truck delivery cost                    eur/ton/km
        const double RD = 3.95;        // railway delivery cost                  eur/ton/km
        const double TE = 0.062;       // truck emission CO2/km                  eur/km
        const double RE = 0.022;       // railway emission CO2/km                eur/km
        string[] WH = {"ITC4", "DEA1", "FR30", "SI03", "PL22", "EL52"}; // warehouse names
        public MainWindow()
        {
            InitializeComponent();
            DataReader dr = new DataReader();
            HashSet<Distance> distances = dr.ReadDist();
            HashSet<Flow> flows = dr.ReadFlow();

            var railFlow = flows.Where(x => x.Type.CompareTo("Rail") == 0).ToList();
            var roadFlow = flows.Where(x => x.Type.CompareTo("Road") == 0).ToList();
            Console.WriteLine("{0} {1}", railFlow.Count, roadFlow.Count);

            double railCost = 0, roadCost = 0;
            foreach (var i in railFlow)
            {
                //delivery cost
                //railCost += i.FlowTonKMs * RD;
                railCost += i.FlowTonKMs * TD;
                //CO2 cost
                //railCost += i.FlowTonKMs * RE;
                railCost += i.FlowTonKMs * TE;
            }
            foreach (var i in roadFlow)
            {
                //delivery cost
                roadCost += i.FlowTonKMs * TD;
                //CO2 cost
                roadCost += i.FlowTonKMs * TE;
            }
            Console.WriteLine("{0} \n{1}", railCost, roadCost);

            Part2(flows, distances);
        }
        void Part2(HashSet<Flow> flows, HashSet<Distance> distances )
        {
            double railCost = 0, roadCost = 0;
            using (StreamWriter writer = new StreamWriter("WH_out.txt"))
            {
                foreach (var item in flows)
	            {
                    if(WH.Contains(item.Load) && WH.Contains(item.Unload))
                    {
                        item.ContainsWarehouse = true;
                        writer.WriteLine(item);
                    }
	            }
            }
            
            /*var flowz = flows.Select(x => x.Load.CompareTo(WH.Any ( y => x.Load == y  || x.Unload == y))).ToList();
            foreach (Flow i in flowz)
	        {
                i.ContainsWarehouse = true; 
                Console.WriteLine(i);
	        }*/
            /*foreach (var i in railFlow)
            {
                //delivery cost
                //railCost += i.FlowTonKMs * RD;
                railCost += i.FlowTonKMs * TD;
                //CO2 cost
                //railCost += i.FlowTonKMs * RE;
                railCost += i.FlowTonKMs * TE;
            }
            foreach (var i in roadFlow)
            {
                if(i.Load)
                //delivery cost
                roadCost += i.FlowTonKMs * TD;
                //CO2 cost
                roadCost += i.FlowTonKMs * TE;
            }*/
            Console.WriteLine("{0} \n{1}", railCost, roadCost);
        }
    }
}
