namespace AjaxDemoASPMVC.Models
{
    public class EmployeeSkill1
    {
        public int Empid { get; set; }
        public int Skillid { get; set; }

        public Employee1 emp { get; set; }
        public Skill1 skill1s { get; set; }
    }
}
