using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Let2.Models;

namespace Let2.Controllers
{
    public class EmployeeController : ApiController
    {
        CompanyContext db;

        public EmployeeController() => db = new CompanyContext();

        public IHttpActionResult GetEmployees()
        {
            var emps = db.Employees.ToList();
            if (emps.Count >0)
                return Ok(emps);
            return StatusCode(HttpStatusCode.NotFound);
           
        }
        public IHttpActionResult GetById(int id)
        {
            var emp = db.Employees.Find(id);
                if(emp is null)
                return NotFound();
                return Ok(emp);
        }
         
        public IHttpActionResult GetByName(string name)
        {
            var emp = db.Employees.FirstOrDefault(ww => ww.Name.ToLower() == name.ToLower());
            if (emp is null)
                return NotFound();
            return Ok(emp);
        }

        public IHttpActionResult Post(Employee emp)
        {
            if (!ModelState.IsValid)
                return BadRequest("empty it enter not model state is valid ==employee data is wrong");
            if (emp is null)
                return BadRequest("empty employee object");
            if (EmployeeExists(emp.Id))
                return Conflict();
            else
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }
           
            return CreatedAtRoute("DefaultApi", new{id = emp.Id},emp);

        }

        public IHttpActionResult Put([FromUri]int id,[FromBody]Employee newemp)
        {
            if (newemp is null)
                return StatusCode(HttpStatusCode.NoContent);
            if (!EmployeeExists(newemp.Id))
                return BadRequest("wrong id of employee");
            if (!ModelState.IsValid)
                return BadRequest("wrong data");
            if (id != newemp.Id)
                return Conflict();
            db.Entry(newemp).State = EntityState.Modified;
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = newemp.Id }, newemp);
        }
        public bool EmployeeExists(int id)
        {
            return db.Employees.Count(ww => ww.Id == id) > 0;
        }

        public IHttpActionResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp is null)
                return StatusCode(HttpStatusCode.NoContent);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return Ok();
        }

    }
    
}
