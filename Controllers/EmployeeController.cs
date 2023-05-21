using Crud_Validation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Validation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Employee> data = _context.tbl_Employee.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployeeData(Employee model)
        {

            if (model.Id == 0 && ModelState.IsValid)
            {
                _context.tbl_Employee.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult EmpRegistration()
        {   
            return PartialView("_EmpRegistration.cshtml"); 
        }
    }
}