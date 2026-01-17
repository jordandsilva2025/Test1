using Microsoft.AspNetCore.Mvc;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Department = "IT", Salary = 50000 },
                new Employee { Id = 2, Name = "Sara", Department = "HR", Salary = 45000 }
            };

            return View(employees);
        }
    }
}
