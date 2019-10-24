using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using New_Three.Models;

namespace New_Three.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();
        public EmployeeService()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "tang",
                LastName = "lei",
                Gender = Gender.男

            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "zhang",
                LastName = "san",
                Gender = Gender.男

            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 2,
                FirstName = "li",
                LastName = "si",
                Gender = Gender.女

            });
            _employees.Add(new Employee
            {
                Id = 4,
                DepartmentId = 2,
                FirstName = "sun",
                LastName = "lei",
                Gender = Gender.男

            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 3,
                FirstName = "li",
                LastName = "wei",
                Gender = Gender.男

            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 3,
                FirstName = "wang",
                LastName = "lei",
                Gender = Gender.女

            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "qian",
                LastName = "lei",
                Gender = Gender.男

            });
        }
        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(()=> 
            {
                var employee = _employees.FirstOrDefault(e => e.Id == id);
                if (employee!=null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(x=>x.DepartmentId==departmentId).AsEnumerable());
        }
    }
}
