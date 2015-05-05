    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Personal.Persistence;
using Personal.Entities;
using Shouldly;

namespace Personal.Tests
{
    public class JobsDatabaseTests
    {
        public void JobsCanBeSavedAndRetrieved()
        {
            var context = new DbPersonalContext();
            // Add
            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Chief Executive Officer",
                MinSalary = 100,
                MaxSalary = int.MaxValue
            };

            context.Jobs.Add(job);
            context.SaveChanges();

            // Retrieve
            var retrievedJob=context.Jobs.Single(j => j.JobId == job.JobId);

            // verificam ca entitatea salvata in baza de date este identica cu entitatea initiala

            retrievedJob.ShouldBe(job);

           // context.Jobs.Remove(retrievedJob);
            context.SaveChanges();

            var jobs = context.Jobs.Where(x => x.MaxSalary<2000 && x.MinSalary>800).ToList();
            
            

        }

        public void JobsCanBeUpdatedAndRetrieved()
        {
            var context = new DbPersonalContext();
            // Add
            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Chief Executive Officer",
                MinSalary = 100,
                MaxSalary = int.MaxValue
            };

            context.Jobs.Add(job);
            context.SaveChanges();

            job.JobTitle = "newJobTitle";
            context.SaveChanges();

            // Retrieve
            var retrievedJob = context.Jobs.Single(j => j.JobId == job.JobId);

            // verificam ca entitatea salvata in baza de date este identica cu entitatea initiala

            retrievedJob.JobTitle.ShouldBe(job.JobTitle);

            context.Jobs.Remove(retrievedJob);
            context.SaveChanges();



        }

    
        
    }
}
