using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Data;

namespace COVIDScreeningApi.Models
{
    public class ScreeningDataTable
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

        internal static ScreeningDataTable FromDataModel(Screening dataModel)
        {
            return new ScreeningDataTable
            {
                Id = dataModel.Id,
                Bodyache = dataModel.Bodyache,
                ContactNumber = dataModel.ContactNumber,
                DateOfScreening = dataModel.DateOfScreening,
                DryCough = dataModel.DryCough,
                Fatigue = dataModel.Fatigue,
                Fever = dataModel.Fever,
                Headache = dataModel.Headache,
                InContactWithCOVID = dataModel.InContactWithCOVID,
                Location = dataModel.Location,
                Nationality = dataModel.Nationality,
                Passport = dataModel.Passport,
                RunnyNose = dataModel.RunnyNose,
                ScreeningRepName = dataModel.ScreeningRepName,
                ShortnessOfBreath = dataModel.ShortnessOfBreath,
                SoreThroat = dataModel.SoreThroat,
                TraveledOutsideTheUS = dataModel.TraveledOutsideTheUS,
                VisitorName = dataModel.VisitorName
            };
        }
    }

    internal static class ScreeningDataTableExtensions
    {
        internal static ScreeningDataTable ToApiModel(this Screening target)
        {
            return ScreeningDataTable.FromDataModel(target);
        }
    }
}
