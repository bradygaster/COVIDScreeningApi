using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Data;

namespace COVIDScreeningApi.Models
{
    public class RepresentativeData
    {
        public Guid Id { get; set; }
        public string RepName { get; set; }
        public string RepContact { get; set; }
        public string RepLocation { get; set; }
        public string RepEmail { get; set; }

        internal static RepresentativeData FromDataModel(Representative dataModel)
        {
            return new RepresentativeData
            {
                Id = dataModel.Id,
                RepContact = dataModel.RepContact,
                RepEmail = dataModel.RepEmail,
                RepLocation = dataModel.RepLocation,
                RepName = dataModel.RepName
            };
        }
    }

    internal static class RepresentativeDataExtensions
    {
        internal static RepresentativeData ToApiModel(this Representative target)
        {
            return RepresentativeData.FromDataModel(target);
        }
    }
}
