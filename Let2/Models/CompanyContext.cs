using System;
using System.Data.Entity;
using System.Linq;

namespace Let2.Models
{
    public class CompanyContext : DbContext
    {
     
        public CompanyContext()
            : base("name=CompanyDB")
        {
        }


         public virtual DbSet<Employee> Employees { get; set; }
    }

}