using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;
using Personal.Persistence;
using Shouldly;

namespace Personal.Tests
{
    class LocationDatabaseTests
    {
        public void LocationsCanBeSavedAndRetrieved()
        {
        HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var context = new DbPersonalContext();
            // Add
            var location = new Location
            {
                StreetAddress = "Spl. Independentei",
                PostalCode = "100",
                City = "Bucharest",
                StateProvince = "Bucharest"
            };

            context.Locations.Add(location);
            context.SaveChanges();

            // Retrieve
            var retrievedLocation = context.Locations.Single(j => j.LocationId == location.LocationId);

            // verificam ca entitatea salvata in baza de date este identica cu entitatea initiala

            retrievedLocation.ShouldBe(location);

            // context.Jobs.Remove(retrievedJob);
            context.SaveChanges();


        }

        public void LocationsCanBeUpdatedAndRetrieved()
        {
            var context = new DbPersonalContext();
            // Add
            var location = new Location
            {
                LocationId = 1,
                StreetAddress = "Spl. Independentei",
                PostalCode = "100",
                City = "Bucharest",
                StateProvince = "Bucharest"
            };

            context.Locations.Add(location);
            context.SaveChanges();

            location.City = "Targoviste";
            context.SaveChanges();

            // Retrieve
            var retrievedLocation = context.Locations.Single(j => j.LocationId == location.LocationId);

            // verificam ca entitatea salvata in baza de date este identica cu entitatea initiala

            retrievedLocation.City.ShouldBe(location.City);

            context.Locations.Remove(retrievedLocation);
            context.SaveChanges();
        }
    }
}
