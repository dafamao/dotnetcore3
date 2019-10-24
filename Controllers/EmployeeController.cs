using Microsoft.AspNetCore.Mvc;
using New_Three.Models;
using New_Three.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New_Three.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IDepartmentService departmentService,IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentService.GetById(departmentId);
            ViewBag.Title = $"Employees of{department.Name}";
            ViewBag.DepartmentId = departmentId;
            var employees = await _employeeService.GetByDepartmentId(departmentId);
            return View(employees);
        }

        public IActionResult Add(int departmentid)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentid
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            return RedirectToAction(nameof(Index), new { departmentId = model.DepartmentId });
        }

        public async Task<IActionResult> Fire(int employeeid)
        {
            var employee = await _employeeService.Fire(employeeid);
            return RedirectToAction(nameof(Index), new { departmentId = employee.DepartmentId });
        }

    }
}
