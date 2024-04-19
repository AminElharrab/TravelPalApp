﻿using System;
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
        public static List<IUser> users = new List<IUser>()
        {
            new Admin("admin", "password", Countries.Albania),
            new User("user", "password", Countries.Albania)
            {
                Travels = new List<Travel>()
                {
                new WorkTrip ("Tirana", Countries.Albania, 2, "lorem ipsum")
                {
                    Destination = "Tirana",
                    Country = Countries.Albania,
                    Travellers = 2,
                    MeetingDetails = "Lorem ipsum",
                },                
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
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password)) 
                return false;


            if (!ValidateUsername(user.Username))
                return false;

            users.Add(user);
            return true;
        }
        public static bool UpdateUsername(IUser user, string NewUsername)
        {
           if (user == null || string.IsNullOrEmpty(NewUsername))
                return false;

            if (!ValidateUsername(user.Username))
                return false;

            user.Username = NewUsername;
            return true;
        }
        private static bool ValidateUsername(string username)
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
        public static void RemoveUser(IUser user)
        {
            if (user == null)
                return;

            users.Remove(user);
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
