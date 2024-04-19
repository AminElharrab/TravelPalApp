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
        public static List<Travel> Travels { get; set; } = [];

        public static void TravelAdd(Travel travel)
        {
            Travels.Add(travel);
        }

        public static void TravelRemove(Travel travel)
        {
            if (UserManager.SignedInUser is User signedInUser)
            {
                signedInUser.Travels.Remove(travel);
            }
        }

    }
}
 