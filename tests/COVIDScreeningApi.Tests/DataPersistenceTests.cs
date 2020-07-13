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
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace COVIDScreeningApi.Tests
{
    public class DataPersistenceTests
    {
        private readonly DataContext _dataContext;
        public RepresentativeDataController RepresentativeDataController { get; }
        public PortsOfEntryController PortsOfEntryController { get; }
        public ScreeningDataTableController ScreeningDataTableController { get; }

        private readonly IConfiguration _configuration;
        public DataPersistenceTests(DataContext dataContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dataContext = dataContext;

            RepresentativeDataController = new RepresentativeDataController(_dataContext, _configuration);
            PortsOfEntryController = new PortsOfEntryController(_dataContext, _configuration);
            ScreeningDataTableController = new ScreeningDataTableController(_dataContext, _configuration);
        }

        [Fact]
        public void CanGenerateSampleData()
        {
            // create some ports of entry
            for(int i=0; i<10; i++) 
            {
                var portOfEntry = CreateRandomPortOfEntry();
                portOfEntry.Should().NotBeNull();
                var postResult = PortsOfEntryController.Post(portOfEntry);
                var createdReult = postResult.Result as CreatedResult;
                (createdReult.Value as PortsOfEntry).Should().NotBeNull();
                (createdReult.Value as PortsOfEntry).Id.Should().NotBe(Guid.Empty);
            }

            // create some reps
            for(int i=0; i<10; i++) 
            {
                var rep = CreateRandomRepresentative();
                var postResult = RepresentativeDataController.Post(rep);
                var createdReult = postResult.Result as CreatedResult;
                (createdReult.Value as RepresentativeData).Should().NotBeNull();
                (createdReult.Value as RepresentativeData).Id.Should().NotBe(Guid.Empty);
            }

            // get back the reps
            var reps = RepresentativeDataController.Get();

            // create some screenings
            for(int i=0; i<10; i++) 
            {
                var rep = GetRandomRepresentative(reps);
                rep.Should().NotBeNull();
                var screen = CreateRandomScreeningData(rep.RepName);
                var postResult = ScreeningDataTableController.Post(screen);
                var createdReult = postResult.Result as CreatedResult;
                (createdReult.Value as ScreeningDataTable).Should().NotBeNull();
                (createdReult.Value as ScreeningDataTable).Id.Should().NotBe(Guid.Empty);
            }
        }

        RepresentativeData GetRandomRepresentative()
        {
            var reps = RepresentativeDataController.Get();
            return GetRandomRepresentative(reps);
        }

        RepresentativeData GetRandomRepresentative(IEnumerable<RepresentativeData> reps)
        {
            return reps.ElementAt(new Random().Next(0, (reps.Count() - 1)));
        }

        RepresentativeData CreateRandomRepresentative()
        {
            return new Faker<RepresentativeData>()
                .RuleFor(x => x.Id, f => Guid.Empty)
                .RuleFor(x => x.RepContact, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.RepLocation, f => f.Address.City())
                .RuleFor(x => x.RepName, f => f.Name.FullName())
                .FinishWith((f, u) =>
                {
                    u.RepEmail = f.Internet.Email(u.RepName);
                })
                .Generate();
        }

        ScreeningDataTable CreateRandomScreeningData(string repName)
        {
            return new Faker<ScreeningDataTable>()
                .RuleFor(u => u.Bodyache, f => f.System.Random.Bool())
                .RuleFor(u => u.DryCough, f => f.System.Random.Bool())
                .RuleFor(u => u.Fatigue, f => f.System.Random.Bool())
                .RuleFor(u => u.Fever, f => f.System.Random.Bool())
                .RuleFor(u => u.Headache, f => f.System.Random.Bool())
                .RuleFor(u => u.RunnyNose, f => f.System.Random.Bool())
                .RuleFor(u => u.ShortnessOfBreath, f => f.System.Random.Bool())
                .RuleFor(u => u.SoreThroat, f => f.System.Random.Bool())
                .RuleFor(u => u.TraveledOutsideTheUS, f => f.System.Random.Bool())
                .RuleFor(u => u.Id, f => Guid.Empty)
                .RuleFor(u => u.InContactWithCOVID, f => f.System.Random.Bool())
                .RuleFor(u => u.Location, f => f.Address.City())
                .RuleFor(u => u.ContactNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.DateOfScreening, f => f.Date.Recent())
                .RuleFor(u => u.Nationality, "United States")
                .RuleFor(u => u.Passport, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.ScreeningRepName, repName)
                .RuleFor(u => u.VisitorName, f => f.Name.FullName())
                .Generate();
        }

        PortsOfEntry CreateRandomPortOfEntry()
        {
            return new Faker<PortsOfEntry>()
                .RuleFor(u => u.Id, f => Guid.Empty)
                .RuleFor(u => u.ItemsLabels, f => f.Address.City())
                .RuleFor(u => u.ItemsLatitudes, f => f.Address.Latitude(47.3022815, 47.5517946))
                .RuleFor(u => u.ItemsLongitudes, f => f.Address.Longitude(-122.7553483, -121.881312))
                .Generate();
        }
    }
}