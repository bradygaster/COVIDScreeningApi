using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Data;

namespace COVIDScreeningApi.Models
{
    public class PortsOfEntry
    {
        public Guid Id { get; set; }
        public string ItemsLabels { get; set; }
        public double ItemsLongitudes { get; set; }
        public double ItemsLatitudes { get; set; }

        internal static PortsOfEntry FromDataModel(PortOfEntry dataModel)
        {
            return new PortsOfEntry
            {
                Id = dataModel.Id,
                ItemsLabels = dataModel.Label,
                ItemsLatitudes = dataModel.Latitude,
                ItemsLongitudes = dataModel.Longitude
            };
        }
    }

    internal static class PortsOfEntryExtensions
    {
        internal static PortsOfEntry ToApiModel(this PortOfEntry target)
        {
            return PortsOfEntry.FromDataModel(target);
        }
    }
}
