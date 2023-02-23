using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AjaxDemoASPMVC.Models
{
    public class EmployeeModel
    {

       
        public int Employee1Id { get; set; }
     

        public string FirstName { get; set; }

     
        public string LastName { get; set; }

       
        public DateTime? DateOfBirth { get; set; }
       
        public double Salary { get; set; }

        [Required(ErrorMessage = "Please Select The Gender")]
        public Gender1? gender1 { get; set; }
        // public int? dept { get; set; }
        [Required(ErrorMessage = "Please Select The Department")]
        public Department1? depaartment1 { get; set; }

        //public int? designation { get; set; }
        [Required(ErrorMessage = "Please Select The Designation")]
        public Designation1? designation1 { get; set; }

        public ICollection<EmployeeSkill1> employeeSkill1 { get; set; }
        // public List<int> SkillID { get; set; }

        [NotMapped]
        public List<Skill1> skill11s { get; set; }
    }
}
