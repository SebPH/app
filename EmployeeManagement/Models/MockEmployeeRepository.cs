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
                new Employee() { Id = 1, Name = "Mary", Department = Departments.HR, Email = "mary@cambridgeassociates.com"},
                new Employee() { Id = 2, Name = "John", Department = Departments.IT, Email = "john@cambridgeassocates.com"},
                new Employee() { Id = 3, Name = "Sam", Department =  Departments.Finance, Email = "sam@cambridgeassocates.com"}
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
        
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    }
}
