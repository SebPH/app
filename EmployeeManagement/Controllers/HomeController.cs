using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        // dependency injection - creates an instance of the MockEmployeeRepository
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // this is the homepage https://localhost:port/
        public ViewResult Index()
        {
            //return _employeeRepository.GetEmployee(1).Name;
            //return "Hello World";
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        // this is the details page:  https://localhost:port/home/details
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);

            // View Data - Loosely typed - uses string keys to store and retrieve data
            ViewData["Employee"] = model;
            ViewData["PageTitle"] = "EmployeeDetails";

            // View Bag - Loosely typed - uses dynamic properties to store and retrieve data
            // View Bag is actually a wrapper around ViewData
            ViewBag.Employee = model;
            ViewBag.PageTitle = "Employee Details";

            // Using ViewModels
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            //return View();
            //return View(model);
            return View(homeDetailsViewModel);
        }

    }
}
