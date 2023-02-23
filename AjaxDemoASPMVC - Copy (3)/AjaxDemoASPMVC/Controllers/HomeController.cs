using AjaxDemoASPMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AjaxDemoASPMVC.Controllers
{
    public class HomeController : Controller
    {


        private readonly EmployeeDbContext1 _context;

        public HomeController(EmployeeDbContext1 context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
           // List<Employee1> employees= _context.employees1.ToList();
            List<Gender1> genders = _context.genders1.ToList();
            List<Department1> departments = _context.departments1.ToList();
            List<Designation1> designations = _context.designations1.ToList();
            List<Skill1> skills = _context.skills1.ToList();


         

          //  Employee1 emp = new Employee1();
            BindData b = new BindData();
            b.bindgender = genders;
            b.binddesignation = designations;
            b.bindskill = skills;
            b.binddepartment = departments;

            ViewBag.Genders = genders;
            ViewBag.Departments = departments;
            ViewBag.Designations = designations;
            ViewBag.Skills = skills;
            ViewBag.BindData = b;

            return View(b);
        }
       // [Authorize]
        [HttpPost]
        //[Bind("DesignationId,DepartmentName")]
        public IActionResult Create(BindData b)
        {  
            
            var gender = _context.genders1.Single(p => p.Gender1Id == b.genderId);
            var dept = _context.departments1.Single(p => p.Department1Id == b.departmentId);
            var desgn = _context.designations1.Single(p => p.Designation1Id == b.designationId);
            //    var skills=_context.entityskills.Single(s =>s.EntitySkillId== b.bindSkillId)
            var emp = new Employee1
            {
                FirstName = b.bindemp.FirstName,
                LastName = b.bindemp.LastName,
                DateOfBirth = b.bindemp.DateOfBirth,
                depaartment1 = dept,
                gender1 = gender,
                designation1 = desgn,

                Salary = b.bindemp.Salary,


            };
            var EmployeeSkills = new List<EmployeeSkill1>();
            foreach (var num in b.bindSkillId)
            {
                var skill = _context.skills1.Single(p => p.Skill1Id == num);
                EmployeeSkills.Add(new EmployeeSkill1() { emp = emp, skill1s = skill });
            }

         /*   var employeeSkill = new List<EmployeeSkill1>();
            foreach (var num in empskills)
            {
                var skill = _context.employeeskills1.Single(p => p.skillId == num);
                EmployeeSkills.Add(new EmployeeSkill1() { emp = emp, skill1s = skill });
            }*/






            emp.employeeSkill1 = EmployeeSkills;

            _context.employees1.AddRange(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }



        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult SearchByName(string firstName)
        {
         SqlParameter parameter = new SqlParameter("@FirstName",firstName);
          var emp = _context.employees1.FromSqlRaw($"searchByName @FirstName",parameter);
           return View(emp);
        }



     
   public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employees1 == null)
            {
                return NotFound();
            }

            var entityEmployee = await _context.employees1.Include(d => d.designation1).Include(g => g.gender1)
                .Include(d => d.depaartment1).Include(s => s.employeeSkill1).ThenInclude(s => s.skill1s)
                .FirstOrDefaultAsync(m => m.Employee1Id == id);
            if (entityEmployee == null)
            {
                return NotFound();
            }
            ViewBag.Employee1 = entityEmployee;


            return View();
        }

     

      // GET: EntityEmployees/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null || _context.employees1 == null)
             {
                 return NotFound();
             }

             var entityEmployee = await _context.employees1.Include(d => d.designation1).Include(g => g.gender1)
                 .Include(d => d.depaartment1).Include(s => s.employeeSkill1).ThenInclude(s => s.skill1s).FirstOrDefaultAsync(m => m.Employee1Id == id);
             if (entityEmployee == null)
             {
                 return NotFound();
             }

             List<Gender1> genders = _context.genders1.ToList();
             List<Department1> departments = _context.departments1.ToList();
             List<Designation1> designations = _context.designations1.ToList();
             List<Skill1> skills = _context.skills1.ToList();
             ViewBag.Genders = genders;
             ViewBag.Departments = departments;
             ViewBag.Designations = designations;
             ViewBag.Skills = skills;


             return View(entityEmployee);
         }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String[] Arjun, Employee1 newentityEmployee)
        {

            var entityEmployee = await _context.employees1.Include(d => d.designation1).Include(g => g.gender1)
                 .Include(d => d.depaartment1).Include(s => s.employeeSkill1).ThenInclude(s => s.skill1s).FirstOrDefaultAsync(m => m.Employee1Id == newentityEmployee.Employee1Id);


            entityEmployee.FirstName = newentityEmployee.FirstName;
            entityEmployee.LastName = newentityEmployee.LastName;
            entityEmployee.DateOfBirth = newentityEmployee.DateOfBirth;
            entityEmployee.Salary = newentityEmployee.Salary;
          //  List<Skill1> skills = _context.skills1.ToList();

            if (newentityEmployee.gender1.Gender1Id != entityEmployee.gender1.Gender1Id)
            { 
                var gender = _context.genders1.Single(p => p.Gender1Id == newentityEmployee.gender1.Gender1Id);
                entityEmployee.gender1 = gender;

            }

            if (newentityEmployee.depaartment1.Department1Id != entityEmployee.depaartment1.Department1Id)
            {
                
                var dept = _context.departments1.Single(p => p.Department1Id == newentityEmployee.depaartment1.Department1Id);
                entityEmployee.depaartment1 = dept;

            }


            if (newentityEmployee.designation1.Designation1Id != entityEmployee.designation1.Designation1Id)
            {
              
                var desgn = _context.designations1.Single(p => p.Designation1Id == newentityEmployee.designation1.Designation1Id);
                entityEmployee.designation1 = desgn;
            }

          //   newentityEmployee.employeeSkill1=entityEmployee.employeeSkill1;
            //  newentityEmployee.employeeSkill1=

            var EmployeeSkills = new List<EmployeeSkill1>();
            foreach (var num in Arjun)
            {
                var skill = _context.skills1.Single(p => p.Skill_Name == num);
                EmployeeSkills.Add(new EmployeeSkill1() { emp = entityEmployee, skill1s = skill });
            }






            entityEmployee.employeeSkill1 = EmployeeSkills;



            //_context.employees1.Remove(entityEmployee);

             _context.employees1.Update(entityEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        //for EXIST WE HAVE TO ADD IT
        private bool Employee1Exists(int id)
        {
            return (_context.employees1?.Any(e => e.Employee1Id == id)).GetValueOrDefault();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: EntityEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employees1 == null)
            {
                return NotFound();
            }

            var entityEmployee = await _context.employees1
                .FirstOrDefaultAsync(m => m.Employee1Id == id);
            if (entityEmployee == null)
            {
                return NotFound();
            }

            return View(entityEmployee);
        }

        // POST: EntityEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employees1 == null)
            {
                return Problem("Entity set 'EntityEmployeeDbContext.entityemp'  is null.");
            }
            var entityEmployee = await _context.employees1.FindAsync(id);
            if (entityEmployee != null)
            {
                _context.employees1.Remove(entityEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> active(string? firstName , string? lastName , string? gender , string? Department, string? Designation,DateTime? FromDate,DateTime? ToDate)
        {

            var formattedFromDate = FromDate?.ToString("yyyy-MM-dd");
            var formattedToDate = ToDate?.ToString("yyyy-MM-dd");

            var emp = _context.emp.FromSqlInterpolated($"EXEC GetEmployeeSkillsWithFilter {firstName} , {lastName} ,{gender} ,{Department},{Designation},{formattedFromDate},{formattedToDate} ");

            return Ok(emp);
        }

    }

  

    
}