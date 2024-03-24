﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalApp
{
    public class User : IUser
    {
        public List<Travel> travels { get; set; } = new();
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }


        public User(string username, string password, Countries location)
        {
            Username = username;
            Password = password;
            Location = location;
        }

    }
}