using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using AjaxDemoASPMVC.Test;

namespace AjaxDemoASPMVC.Models
{
    public class Employee1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Employee1Id { get; set; }
        [Required]
        [StringLength(10)]
       // [RegularExpression(@"^([A-Za-z]).$" ,ErrorMessage ="Name Have Letters Only")]
      
        public string FirstName { get; set; }

        [Required]
        [StringLength(10)]
      //  [Remote(action: "IsLastNameUsed",controller:"Home")]
        public string LastName { get; set; }

        [Required]
        // [DataType(DataType.Date)]
        //  [DateValidation(ErrorMessage ="Date Is Not Valid")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       // [CustomDateValidation.ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
       // [Range(typeof(DateTime), "1/1/1960", "1/1/2023")] //Range Will Not Work With Date Attribute
       // [CurrentDate]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [Range(25000,90000)]
        public double Salary { get; set; }

        [Required(ErrorMessage ="Please Select The Gender")]
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

        public int isActive { get; set; }
    }
}
