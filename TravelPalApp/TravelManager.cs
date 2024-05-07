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

        public static List<Travel> GetAllUserTravels()
        {
            //Skapar lista av alla användares resor
            List<Travel> allUserTravels = [];

            foreach (var user in UserManager.users)
            {
                if (user is User)
                {
                    User u = (User)user;

                    // Lägger till alla resor från användaren i allUserTravels
                    allUserTravels.AddRange(u.Travels);
                }
            }

            return allUserTravels;
        }
    }
}
 