using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.Tests
{
    public class DepartmentTests
    {

        public void CanAddDepartments()
        {
            var context = new DbPersonalContext();
            var location = new Location()
            {
                City="City",
                PostalCode = "123",
                StreetAddress = "asdasd",
                StateProvince = "dasdsa"
            };

            var department = new Department()
            {
                Location = location,
                DepartmentName = "Dasda"
            };

            context.Departments.Add(department);
            context.SaveChanges();

        }
    }
}
