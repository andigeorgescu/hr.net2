using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Persistence
{
    public class DbPersonalContext:DbContext, IHrContext
    {
        public DbSet<Entities.Job> Jobs { get; set; }
        public DbSet<Entities.Location> Locations { get; set; }
        public DbSet<Entities.Employee> Employees { get; set; }
        public DbSet<Entities.Department> Departments { get; set; }

        public DbPersonalContext() : base("Personal")
        {
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ColumnOrderingConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

