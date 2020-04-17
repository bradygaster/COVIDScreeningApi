using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDScreeningApi.Models
{
    public class ScreeningDataTable
    {
        public string VisitorName { get; set; }
        public string Location { get; set; }
        public string ScreeningRepName { get; set; }
        public string Passport { get; set; }
        public string ContactNumber { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfScreening { get; set; }
        public bool Fever { get; set; }
        public bool SoreThroat { get; set; }
        public bool RunnyNose { get; set; }
        public bool Fatigue { get; set; }
        public bool Headache { get; set; }
        public bool Bodyache { get; set; }
        public bool ShortnessOfBreath { get; set; }
        public bool DryCough { get; set; }
        public bool TraveledOutsideTheUS { get; set; }
        public bool InContactWithCOVID { get; set; }

    }
}
