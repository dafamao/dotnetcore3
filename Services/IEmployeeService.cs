using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using New_Three.Models;

namespace New_Three.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> Fire(int id);
    }
}
