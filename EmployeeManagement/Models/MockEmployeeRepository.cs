using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        // using dependency injection
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@cambridgeassociates.com"},
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@cambridgeassocates.com"},
                new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "sam@cambridgeassocates.com"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            /*Func<Employee, bool> operation = e => e.Id == Id*/;
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
