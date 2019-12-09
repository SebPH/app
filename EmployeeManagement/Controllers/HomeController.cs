using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    //[Route("[controller]/[action]")
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        // dependency injection - creates an instance of the MockEmployeeRepository
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //[Route("")]
        //[Route("[action]")
        //[Route("~/home")
        // this is the homepage https://localhost:port/
        public ViewResult Index()
        {
            //return _employeeRepository.GetEmployee(1).Name;
            //return "Hello World";
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        //[Route("[action]/{id?}")
        // this is the details page:  https://localhost:port/home/details
        public ViewResult Details(int id = 1)
        {
            Employee model = _employeeRepository.GetEmployee(id);

            // View Data - Loosely typed - uses string keys to store and retrieve data
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "EmployeeDetails";

            // View Bag - Loosely typed - uses dynamic properties to store and retrieve data
            // View Bag is actually a wrapper around ViewData
            ViewBag.Employee = model;
            ViewBag.PageTitle = "Employee Details";

            // Using ViewModels
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"
            };

            //return View();
            //return View(model);
            return View(homeDetailsViewModel);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ViewResult Test()
        {
            return View();
        }

    }
}
