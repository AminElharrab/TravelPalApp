using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp;

namespace TravelPalApp
{
    public static class TravelManager
    {
        public static List<Travel> Travels { get; set; } = new();

        public static void TravelRemove(Travel travel)
        {
            Travels.Remove(travel);
        }
        public static void TravelAdd(Travel travel)
        {
            Travels.Add(travel);
        }
    }
}
 