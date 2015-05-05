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
    public class EmployeeController : ApiController
    {
        private readonly IHrContext context;
        // GET: api/Employee
        public EmployeeController(IHrContext context)
        {
            this.context = context;
        }
        public IEnumerable<Employee> Get()
        {
            return context.Employees;
        }

        // GET: api/Employee/5
        public IHttpActionResult Get(int id)
        {
            var employeeDb = context.Employees.Find(id);
            if (employeeDb != null)
            {
                return Ok(employeeDb);
            }
            return NotFound();
        }

        // POST: api/Employee
        public IHttpActionResult Post(Employee employee)
        {
            var addedEmployee = context.Employees.Add(employee);

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "Employee",
                id = addedEmployee.EmployeeId
            }, addedEmployee);
        }

        // PUT: api/Employee/5
        public IHttpActionResult Put(Employee employee)
        {
            
                var dbEmployee = context.Employees.Find(employee.EmployeeId);
                if (dbEmployee != null)
                {
                    Mapper.Map(employee, dbEmployee);
                    return Ok(context.SaveChanges());
                }
                return NotFound();
            
        }

        // DELETE: api/Employee/5
        public IHttpActionResult Delete(int id)
        {
            var dbEmployee = context.Employees.Find(id);
            if (dbEmployee != null)
            {
                return Ok(context.Employees.Remove(dbEmployee));
            }

            return NotFound();
        }
    }
}
