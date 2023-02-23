using Microsoft.EntityFrameworkCore.Internal;

namespace AjaxDemoASPMVC.Models
{

    [Serializable]
    public class BindData

        
    {

       // public BindData() { }
        public Employee1 bindemp { get; set; }

        public List<Department1> binddepartment { get; set; }

        // public string DepartmentName { get; set; }
        public int departmentId { get; set; }
        public int genderId { get; set; }
        public List<Gender1> bindgender { get; set; }
        public int designationId { get; set; }
        public List<Designation1> binddesignation { get; set; }


        // public int DesignationId { get; set; }
        public List<int> bindSkillId { get; set; }
        public List<Skill1> bindskill { get; set; }
        //public List<int> skillId { get; set; }

    }
}
