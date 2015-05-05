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
    public class DepartmentController : ApiController
    {
        private readonly IHrContext context;
        // GET: api/Department

        public DepartmentController(IHrContext context)
        {
            this.context = context;
        }
        public IEnumerable<Department> Get()
        {
            return context.Departments;
        }

        // GET: api/Department/5
        public IHttpActionResult Get(int id)
        {
            var departmentDb = context.Departments.Find(id);
            if (departmentDb != null)
            {
                return Ok(departmentDb);
            }
            return NotFound();
        }

        // POST: api/Department
        public IHttpActionResult Post(Department department)
        {
            var addedDepartment = context.Departments.Add(department);

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Department",
                id = addedDepartment.DepartmentId
            }, addedDepartment);
        }

        // PUT: api/Department/5
        public IHttpActionResult Put(Department department)
        {
            var dbDepartment = context.Departments.Find(department.DepartmentId);
            if (dbDepartment != null)
            {
                Mapper.Map(department, dbDepartment);
                return Ok(context.SaveChanges());
            }
            return NotFound();
            

        }

        // DELETE: api/Department/5
        public IHttpActionResult Delete(int id)
        {
            var dbDepartment = context.Departments.Find(id);
            if (dbDepartment != null)
            {
                return Ok(context.Departments.Remove(dbDepartment));
            }

            return NotFound();
        }
    }
}
