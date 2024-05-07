using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalApp
{
   public class Admin(string username, string password, Countries location) : IUser
    {
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
        public Countries Location { get; set; } = location;
    }
}