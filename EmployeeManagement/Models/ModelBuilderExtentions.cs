using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Departments.Payroll,
                    Email = "mary@cambrigeassociates.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Sarah",
                    Department = Departments.Payroll,
                    Email = "sarah@cambrigeassociates.com"
                }
            );
        }
    }
}
