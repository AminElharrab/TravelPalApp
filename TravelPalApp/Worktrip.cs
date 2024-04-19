using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalApp
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip (string destination, Countries country, int travellers, string meetingDetails) : base (destination, country, travellers)
        {
                    
            MeetingDetails = meetingDetails;
        }
        public override string GetInfo()
        {
            return $"City: {Destination}, Travellers: {Travellers}, Country: {Country}\n Details: {MeetingDetails}";
        }
    }

}