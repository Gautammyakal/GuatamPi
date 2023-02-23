namespace AjaxDemoASPMVC.Models
{
    public class Skill1
    {
        public int Skill1Id { get; set; }
        public String Skill_Name { get; set; }
        public ICollection<EmployeeSkill1> employeeSkill1 { get; set; }
      //  List<Employee1> employee11s { get; set; }
    }
}
