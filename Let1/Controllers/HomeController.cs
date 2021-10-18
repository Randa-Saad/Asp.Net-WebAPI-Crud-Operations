using Let1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Let1.Controllers
{
    public class HomeController : ApiController
    {
        public static List<Employee> Employees { get; set; } = 
            new List<Employee>{
             new Employee{Id=1,Name="randa",Age=23,Salary=7000},
             new Employee {Id=2,Name="saad",Age=24,Salary=10000},
             new Employee { Id = 3,Name = "hassan",Age = 25,Salary = 14000},
             new Employee{ Id = 4,Name = "zobair",Age = 27,Salary = 17000} };

        [HttpGet]
        [Route("api/home")]
        public List<Employee> GetEmployees()
        {
            return Employees;
        }
        [HttpGet]
        [Route("api/home/{id:int}")]
         public Employee GetEmployee(int id)
        {
            return Employees.FirstOrDefault(ww => ww.Id == id);
        }
        [HttpGet]
        [Route("api/home/{name:alpha}")]
        public Employee GetEmployeeByName(string name)
        {
            return Employees.FirstOrDefault(ww => ww.Name.ToLower() == name.ToLower());
        }


    }
}
