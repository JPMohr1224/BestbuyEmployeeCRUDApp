using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestbuyEmployeeCRUDApp.Data;
using BestbuyEmployeeCRUDApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestbuyEmployeeCRUDApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var employee = repo.GetAllEmployees();
            return View(employee);
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee emp = repo.GetEmployee(id);
            if (emp == null)
            {
                return View("Employee NotFound");
            }
            return View(emp);
        }

        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            repo.UpdateEmployee(employee);

            return RedirectToAction("ViewEmployee", new { id = employee.EmployeeID });
        }

        public IActionResult ViewEmployee(int id)
        {
            var product = repo.GetEmployee(id);
            return View(product);
        }

        public IActionResult AddEmployee(Employee employeeToAdd)
        {
            
            return View(employeeToAdd);
        }

        public IActionResult AddEmployeeToDatabase (Employee employee)
        {
            repo.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(Employee employee)
        {
            repo.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}

