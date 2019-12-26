using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace EmployeeManagement.Controllers
{
    //[Route("[controller]/[action]")
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        // dependency injection - creates an instance of the MockEmployeeRepository
        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
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
        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id ?? 1);

            // View Data - Loosely typed - uses string keys to store and retrieve data
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "EmployeeDetails";

            // View Bag - Loosely typed - uses dynamic properties to store and retrieve data
            // View Bag is actually a wrapper around ViewData
            ViewBag.Employee = model;
            ViewBag.PageTitle = "Employee Details";

            throw new Exception("Error in Details View");

            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            // Using ViewModels
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                //Employee = _employeeRepository.GetEmployee(id ?? 1),
                Employee = employee,
                PageTitle = "Employee Details"
            };

            //return View();
            //return View(model);
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        //public IActionResult Create(Employee employee)
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                // Employee newEmployee = _employeeRepository.Add(employee);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);

                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpPost]
        //public IActionResult Create(Employee employee)
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if(model.Photos != null) 
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                // Employee newEmployee = _employeeRepository.Add(employee);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = employee.PhotoPath 
                };

                _employeeRepository.Update(employee);

                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }

        public ViewResult Test()
        {
            return View();
        }

    }
}
