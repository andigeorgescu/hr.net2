using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controllers
{
    public class LocationController : ApiController
    {
        private readonly IHrContext context;
        // GET: api/Location

        public LocationController(IHrContext context)
        {
            this.context = context;
        }

        public IEnumerable<Location> Get()
        {
            return context.Locations;
        }

        // GET: api/Location/5
        public IHttpActionResult Get(int id)
        {
            var locationDb = context.Locations.Find(id);
            if (locationDb != null)
            {
                return Ok(locationDb);
            }
            return NotFound();
        }

        // POST: api/Location
        public IHttpActionResult Post(Location location)
        {
            var addedLocation = context.Locations.Add(location);

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Location",
                id = addedLocation.LocationId
            }, addedLocation);
        }

        // PUT: api/Location/5
        public IHttpActionResult Put(Location location)
        {
            
                var dbLocation = context.Locations.Find(location.LocationId);
                if (dbLocation != null)
                {
                    Mapper.Map(location, dbLocation);
                    return Ok(context.SaveChanges());
                }
                return NotFound();
            
        }

        // DELETE: api/Location/5
        public IHttpActionResult Delete(int id)
        {
            var dbLocation = context.Locations.Find(id);
            if (dbLocation != null)
            {
                return Ok(context.Locations.Remove(dbLocation));
            }

            return NotFound();
        }
    }
}
