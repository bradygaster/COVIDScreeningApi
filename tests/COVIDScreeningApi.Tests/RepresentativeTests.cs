using System;
using System.Text.Json;
using Bogus;
using COVIDScreeningApi.Controllers;
using COVIDScreeningApi.Data;
using COVIDScreeningApi.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace COVIDScreeningApi.Tests {
    public class RepresentativeTests {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public RepresentativeTests (DataContext dataContext, IConfiguration configuration) {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [Fact]
        public void RepresentativeCanBeCreated () {
            Console.WriteLine (JsonSerializer.Serialize<RepresentativeData> (CreateRandomRepresentative (),
                new JsonSerializerOptions {
                    WriteIndented = true
                }));
        }

        [Fact]
        public void RepresentativeCanBeSavedToDatabase () {
            var controller = new RepresentativeDataController(_dataContext, _configuration);
            var rep = CreateRandomRepresentative();
            var result = controller.Post(rep);
            result.Value.Should().NotBeNull();
        }

        RepresentativeData CreateRandomRepresentative () {
            return new Faker<RepresentativeData> ()
                .RuleFor (x => x.Id, f => Guid.NewGuid ())
                .RuleFor (x => x.RepContact, f => f.Phone.PhoneNumber ())
                .RuleFor (x => x.RepLocation, f => f.Address.City ())
                .RuleFor (x => x.RepName, f => f.Name.FullName ())
                .FinishWith ((f, u) => {
                    u.RepEmail = f.Internet.Email (u.RepName);
                })
                .Generate ();
        }
    }
}