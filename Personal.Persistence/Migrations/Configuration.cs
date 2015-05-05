using System.Collections.Generic;
using Personal.Entities;

namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personal.Persistence.DbPersonalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Personal.Persistence.DbPersonalContext";
        }

        protected override void Seed(Personal.Persistence.DbPersonalContext context)
        {
            var jobList = new List<Job>()
            { new Job(){
                JobId = "Job1",
                JobTitle = "Title 1",
                MaxSalary = 100,
                MinSalary = 1000},
                new Job()
                {
                    JobId = "Job3",
                JobTitle = "Title 3",
                MaxSalary = 100,
                MinSalary = 1000
                },
                new Job()
                {
                    JobId = "Job4",
                JobTitle = "Title 4",
                MaxSalary = 100,
                MinSalary = 1000
                }
            };

            foreach (var job in jobList)
            {
                context.Jobs.AddOrUpdate(x=> x.JobTitle, job);
            }

            var locationList = new List<Location>()
            {
                new Location()
                {
                    StreetAddress = "bla",
                    City = "Bucharest",
                    StateProvince = "Bucharest",
                    PostalCode = "130121",
                    LocationId = 1
                },
                new Location()
                {
                    StreetAddress = "bla",
                    City = "Bucharest",
                    StateProvince = "Bucharest",
                    PostalCode = "130121",
                    LocationId = 2
                },
                new Location()
                {
                    StreetAddress = "bla",
                    City = "Bucharest",
                    StateProvince = "Bucharest",
                    PostalCode = "130121",
                    LocationId = 3
                }
            };
            foreach (var loc in locationList)
                context.Locations.AddOrUpdate(x => x.LocationId, loc);

        }
    }
}
