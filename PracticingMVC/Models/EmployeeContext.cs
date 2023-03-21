using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticingMVC.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeInMVC")
        {

        }
        public DbSet<Employee> employees { get; set;}
    }
}