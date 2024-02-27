using Day_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentContext db;
        public DepartmentController(DepartmentContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var std = db.Departments.ToList();
            if(std is null)
            {
                return NotFound();
            }
            else 
                return Ok(std);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var dep = db.Departments.Find(id);
            if (dep is null)
            {
                return NotFound(new { msg = $"Department with id {id} Not Found" });
            }
            else
                return Ok(new { msg = $"Department with {id} found", Std = dep });
        }
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByName(string name)
        {
            var deptt = db.Departments.FirstOrDefault(d => d.name.ToLower() == name.ToLower());

            if (deptt is null)
            {
                return NotFound(new { msg = $"Department with Name {name} Not Found" });
            }
            else
            {
                return Ok(new { msg = $"Department with {name} found ", Std = deptt });
            }
        }

        //[HttpPost]
        //public IActionResult Add(Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Departments.Add(department);
        //        db.SaveChanges();
        //        return Created($"  'http://localhost:5037/api/Student/{department.id}", department);
        //        //return Ok(student);
        //    }
        //    return BadRequest();

        //}
        [HttpPost]
        public IActionResult Add([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return Created($"http://localhost:5037/api/Department/{department.id}", department);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Update(department);
                db.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var olddept = db.Departments.Find(id);
            if(olddept is null)
            {
                return NotFound();
            }
            db.Remove(olddept);
            db.SaveChanges();
            return Ok(olddept);

        }
    }
}
