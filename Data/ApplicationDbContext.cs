using System.Collections.Generic;
using MVC2.Models;

namespace MVC2.Data
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
    }


}
