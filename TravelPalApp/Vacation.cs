﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalApp
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, Countries country, int travellers, bool allInclusive) : base(destination, country, travellers)
        {
            AllInclusive = allInclusive;
        }
        public override string GetInfo()
        {
            return $"Destination {Destination} in {Country} with travellers {Travellers}. Is 'all inclusive' {AllInclusive}";
        }
    }
}
