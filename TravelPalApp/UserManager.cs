using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace TravelPalApp
{
    public static class UserManager
    {
        // Lista för att lagra users
        public static List<IUser> users = new List<IUser>()
        {
            new Admin("admin", "password", Countries.Albania),
            new User("user", "password", Countries.Albania)
            {
                Travels = new List<Travel>()
                {
                // Exempel på Worktrip
                new WorkTrip ("Tirana", Countries.Albania, 2, "lorem ipsum")
                {
                    Destination = "Tirana",
                    Country = Countries.Albania,
                    Travellers = 2,
                    MeetingDetails = "Lorem ipsum",
                },
                // Exempel på Vacation
                new Vacation("Tirana", Countries.Albania, 2, allinclusive)
                {
                    Destination="Tirana",
                    Country = Countries.Albania,
                    Travellers = 2,
                    AllInclusive = true
                }

            }
        }
    };
        private static bool allinclusive;

        public static IUser? SignedInUser { get; private set; }

        public static bool AddUser(IUser user)
        {
            // Checkar null eller tomt fält för username och password
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return false;

            // Kontrollerar om det finns dubbletter av användarnamn
            if (!ValidateUsername(user.Username))
                return false;
            // Lägger till användare
            users.Add(user);
            return true;
        }

        private static bool ValidateUsername(string username)
        // Kontrollerar om username är tillgängligt
        {
            bool isAvailable = true;

            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }
        public static bool SignInUser(string username, string password)
        {

            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)

                {
                    SignedInUser = user;
                    return true;
                }
            }
            return false;
        }
        public static void SignOutUser()
        {
            SignedInUser = null;
        }

    }
}
