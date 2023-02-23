using AjaxDemoASPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AjaxDemoASPMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext1 _context;

        public EmployeeController(EmployeeDbContext1 context)
        {
            _context = context;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult Get()
        {
            

            var emps = _context.employees1.ToList();
            var gender = _context.genders1.ToList();
            var skills = _context.skills1.ToList();
            var empSkills = _context.employeeskills1.ToList();
            var depts = _context.departments1.ToList();
            var designation = _context.designations1.ToList();
            var rec = (from e in emps
                       join g in gender on e.gender1.Gender1Id equals g.Gender1Id
                       join d in depts on e.depaartment1.Department1Id equals d.Department1Id
                       join ds in designation on e.designation1.Designation1Id equals ds.Designation1Id
                       select
                      new REC
                      {
                          empId = e.Employee1Id,
                          firstName = e.FirstName,
                          lastName = e.LastName,
                          DateOfBirth = (DateTime)e.DateOfBirth,
                          gender = g.Gender_Name,
                          department = d.Dept_Name,
                          isActive = e.isActive,
                          designation = ds.Designation_Name


                      }
                      ).ToList();
            var sk = (from e in emps
                     // join g in gender on e.gender1.Gender1Id equals g.Gender1Id
                      join es in empSkills on e.Employee1Id equals es.Empid
                      join s in skills on es.Skillid equals s.Skill1Id group s by e.Employee1Id into g
                      select new SK
                      {
                          id = g.Key,
                          skill = g.Select(m => m.Skill_Name).ToList(),
                      }

                      ).ToList();

            sk.ForEach(item =>
            {
                rec.ForEach(it =>
                {
                    if (it.empId == item.id)
                    {
                        it.skills = item.skill;
                        
                    }
                });
            });

            //var obj = new Temp();
            //obj.emps = rec;
            //obj.skills = sk;
            return Ok(rec);
        }

       
    }

    //public class Temp
    //{
    //    public List<REC> emps { get; set; }
    //    public List<SK> skills { get; set; }
    //}

    public class SK
    {
        public int id { get; set; }
        public List<string> skill { get; set; }
    }
    public class REC
    {
        public int empId { get; set; }
        public string firstName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string lastName { get; set; }
        public string designation { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public List<string> skills { get; set; }
        public int isActive { get; internal set; }
    }
}
