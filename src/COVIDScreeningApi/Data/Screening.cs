using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Models;

namespace COVIDScreeningApi.Data
{
    public class Screening
    {
        public Guid Id { get; set; }
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
        public string PartitionKey { get; set; } = "default";

        internal static Screening FromApiModel(ScreeningDataTable apiModel)
        {
            return new Screening
            {
                Id = apiModel.Id,
                Bodyache = apiModel.Bodyache,
                ContactNumber = apiModel.ContactNumber,
                DateOfScreening = apiModel.DateOfScreening,
                DryCough = apiModel.DryCough,
                Fatigue = apiModel.Fatigue,
                Fever = apiModel.Fever,
                Headache = apiModel.Headache,
                InContactWithCOVID = apiModel.InContactWithCOVID,
                Location = apiModel.Location,
                Nationality = apiModel.Nationality,
                Passport = apiModel.Passport,
                RunnyNose = apiModel.RunnyNose,
                ScreeningRepName = apiModel.ScreeningRepName,
                ShortnessOfBreath = apiModel.ShortnessOfBreath,
                SoreThroat = apiModel.SoreThroat,
                TraveledOutsideTheUS = apiModel.TraveledOutsideTheUS,
                VisitorName = apiModel.VisitorName
            };
        }

        internal static void CopyPropertyValues(ScreeningDataTable from, Screening to)
        {
            to.Bodyache = from.Bodyache;
            to.ContactNumber = from.ContactNumber;
            to.DateOfScreening = from.DateOfScreening;
            to.DryCough = from.DryCough;
            to.Fatigue = from.Fatigue;
            to.Fever = from.Fever;
            to.Headache = from.Headache;
            to.InContactWithCOVID = from.InContactWithCOVID;
            to.Location = from.Location;
            to.Nationality = from.Nationality;
            to.Passport = from.Passport;
            to.RunnyNose = from.RunnyNose;
            to.ScreeningRepName = from.ScreeningRepName;
            to.ShortnessOfBreath = from.ShortnessOfBreath;
            to.SoreThroat = from.SoreThroat;
            to.TraveledOutsideTheUS = from.TraveledOutsideTheUS;
            to.VisitorName = from.VisitorName;
        }
    }
}
