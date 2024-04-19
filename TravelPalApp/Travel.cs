using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalApp
{
    public class Travel
    {
        public string Destination { get; set; } = string.Empty;
        public Countries Country { get; set; }
        public int Travellers { get; set; }

        public Travel(string destination, Countries country, int travellers)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
        }

        public virtual string GetInfo()
        {
            return "";
        }    
        
    }
}
