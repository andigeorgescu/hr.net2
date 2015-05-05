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
    class EmployeeTests
    {
        public void EmployeeCanBeSavedAndRetrieved()
        {
            
            var context = new DbPersonalContext();
            // Add
            var location = new Location()
            {
                City = "Bucharest",
                LocationId = 5,
                PostalCode = "130121",
                StateProvince = "Bucharest",
                StreetAddress = "spl. independentei"
            };

            var department = new Department()
            {
                DepartmentId = 1,
                DepartmentName = "C#",
                Location = location
            };
            var job = new Job()
            {
                JobId = "Bla",
                JobTitle = "C# Developer",
                MaxSalary = 5000,
                MinSalary = 300
            };
            var manager = new Employee()
            {
                EmployeeId = 2,
                CommisionPercent = 25,
                Email = "blabla@blabla.com",
                FirstName = "Blabla",
                HireDate = new DateTime(2011, 04, 11),
                LastName = "Ispir",
                PhoneNumber = "+407822687",
                Salary = 5000,
                Department = department,
                Job = job,
                Manager = null
            };
            
            var employee = new Employee()
            {
                EmployeeId = 1,
                CommisionPercent = 25,
                Email = "blabla@blabla.com",
                FirstName = "Andi",
                HireDate = new DateTime(2015,04,11),
                LastName = "Georgescu",
                PhoneNumber = "0735387367",
                Salary = 1500,
                Department = department,
                Job = job,
                Manager = manager

            };

            context.Employees.Add(employee);
            context.SaveChanges();

            // Retrieve
            var retrievedEmployee = context.Employees.Single(j => j.EmployeeId == employee.EmployeeId);

            // verificam ca entitatea salvata in baza de date este identica cu entitatea initiala

            retrievedEmployee.ShouldBe(employee);

            // context.Jobs.Remove(retrievedJob);
            context.SaveChanges();


        }

        public void EmployeeCanBeUpdatedAndRetrieved()
        {

            var context = new DbPersonalContext();
            // Add
            var location = new Location()
            {
                City = "Bucharest",
                LocationId = 7,
                PostalCode = "130121",
                StateProvince = "Bucharest",
                StreetAddress = "spl. independentei"
            };

            var department = new Department()
            {
                DepartmentId = 3,
                DepartmentName = "C#",
                Location = location
            };
            var job = new Job()
            {
                JobId = "Bla2",
                JobTitle = "C# Developer",
                MaxSalary = 5000,
                MinSalary = 300
            };
            var manager = new Employee()
            {
                EmployeeId = 3,
                CommisionPercent = 25,
                Email = "blabla@blabla.com",
                FirstName = "Blabla",
                HireDate = new DateTime(2011, 04, 11),
                LastName = "Ispir",
                PhoneNumber = "+407822687",
                Salary = 5000,
                Department = department,
                Job = job,
                Manager = null
            };

            var employee = new Employee()
            {
                EmployeeId = 4,
                CommisionPercent = 25,
                Email = "blabla@blabla.com",
                FirstName = "Andi",
                HireDate = new DateTime(2015, 04, 11),
                LastName = "Georgescu",
                PhoneNumber = "0735387367",
                Salary = 1500,
                Department = department,
                Job = job,
                Manager = manager

            };

            context.Employees.Add(employee);
            context.SaveChanges();

            employee.FirstName= "Andi";
            context.SaveChanges();

            // Retrieve
            var retrievedEmployee = context.Employees.Single(j => j.EmployeeId == employee.EmployeeId);

            // verificam ca entitatea salvata in baza de date este identica cu entitatea initiala

            retrievedEmployee.EmployeeId.ShouldBe(employee.EmployeeId);

            // context.Jobs.Remove(retrievedJob);
            context.SaveChanges();

            context.Employees.Remove(retrievedEmployee);
            context.SaveChanges();


        }

    }
}
