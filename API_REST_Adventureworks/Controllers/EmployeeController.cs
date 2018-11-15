using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_REST_Adventureworks.Models.HumanResources;
using API_REST_Adventureworks.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace API_REST_Adventureworks.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [Produces("application/json")]
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var employees = db.Employees.ToList();
                return Ok(employees);
            } catch (Exception exe)
            {
                return BadRequest(exe);
            }
        }

        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var employees = db.Employees.Find(id);
                return Ok(employees);
            }
            catch (Exception exe)
            {
                return BadRequest(exe);
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            try
            {
                var employees = db.Employees.Add(employee);
                db.SaveChanges();
                return Ok(employee);
            }
            catch (Exception exe)
            {
                return BadRequest(exe);
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("")]
        public async Task<IActionResult> update([FromBody] Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(employee);
            }
            catch (Exception exe)
            {
                return BadRequest(exe);
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                db.Employees.Remove(db.Employees.Find(id));
                db.SaveChanges();
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(exe);
            }
        }
    }
}