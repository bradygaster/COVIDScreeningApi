using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Models;

namespace COVIDScreeningApi.Data
{
    public class Representative
    {
        public Guid Id { get; set; }
        public string RepName { get; set; }
        public string RepContact { get; set; }
        public string RepLocation { get; set; }
        public string RepEmail { get; set; }
        public string PartitionKey { get; set; } = "default";

        internal static Representative FromApiModel(RepresentativeData apiModel)
        {
            return new Representative
            {
                Id = apiModel.Id,
                RepContact = apiModel.RepContact,
                RepEmail = apiModel.RepEmail,
                RepLocation = apiModel.RepLocation,
                RepName = apiModel.RepName
            };
        }
    }
}
