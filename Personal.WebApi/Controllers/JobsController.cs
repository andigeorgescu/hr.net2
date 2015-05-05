using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controller
{
    public class JobsController : ApiController
    {
        private readonly IHrContext context;

        public JobsController(IHrContext context)
        {
            this.context = context;
        }
        // GET: api/Jobs

        public IEnumerable<Job> Get()
        {
            return context.Jobs;
        }

        public IHttpActionResult Get(string id)
        {
            var jobDb = context.Jobs.Find(id);
            if (jobDb != null)
            {
                return Ok(jobDb);
            }
            return NotFound();
        }

        // GET: api/Jobs/5
        
        /*  public Job Get(string id)
        {
            return context.Jobs.Find(id);
        }
        */

        // POST: api/Jobs
        public IHttpActionResult Post(Job job)
        {
            var addedJob = context.Jobs.Add(job);

            return CreatedAtRoute("DefaultApi",new
            {
                controller="Jobs", id=addedJob.JobId
            },addedJob);
        }

        // PUT: api/Jobs/5
        /*public IHttpActionResult Put(Job job)
        {
            var dbJob = context.Jobs.Find(job.JobId);
            if (dbJob != null)
            {
                dbJob.JobTitle = job.JobTitle;
                dbJob.MaxSalary = job.MaxSalary;
                dbJob.MinSalary = job.MinSalary;
                return Ok(context.SaveChanges());
            }

            return NotFound();
        }
        */

        //Alternativa mai eficienta 
        public IHttpActionResult Put(Job job)
        {
            if (ModelState.IsValid)
            {
                var dbJob = context.Jobs.Find(job.JobId);
                if (dbJob != null)
                {
                    Mapper.Map(job, dbJob);
                    return Ok(context.SaveChanges());
                }
                return NotFound();
            }

            return BadRequest();
            
        }
        // DELETE: api/Jobs/5
        public IHttpActionResult Delete(int id)
        {
            
            var dbJob = context.Jobs.Find(id);
            if (dbJob != null)
            {
                return Ok(context.Jobs.Remove(dbJob));
            }

            return NotFound();

        }
    }
}
