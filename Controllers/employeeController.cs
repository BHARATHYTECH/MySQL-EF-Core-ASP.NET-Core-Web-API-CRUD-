using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using learncsharp.Data;
using learncsharp.Models;

namespace learncsharp.Controllers
{
    [Route("api/[controller]")]
     [ApiController]
    public class employeeController : ControllerBase
    {
       // private readonly ILogger<employeeController> _logger;
            private readonly learncsharpContext _context;

        public employeeController(learncsharpContext context)
        {
            _context = context;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

// GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Employee;
        }
        /*public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }*/

        
    }
}