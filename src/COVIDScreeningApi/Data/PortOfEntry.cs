using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Models;

namespace COVIDScreeningApi.Data
{
    public class PortOfEntry
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string PartitionKey { get; set; } = "default";

        internal static PortOfEntry FromApiModel(PortsOfEntry dataModel)
        {
            return new PortOfEntry
            {
                Id = dataModel.Id,
                Label = dataModel.ItemsLabels,
                Latitude = dataModel.ItemsLatitudes,
                Longitude = dataModel.ItemsLongitudes
            };
        }

        internal static void CopyPropertyValues(PortsOfEntry from, PortOfEntry to)
        {
            to.Label = from.ItemsLabels;
            to.Latitude = from.ItemsLatitudes;
            to.Longitude = from.ItemsLongitudes;
        }
    }
}
