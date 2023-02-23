namespace AjaxDemoASPMVC.Models
{
    public class EmployeeForm
    {
        public int EmployeeId { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public double Salary { get; set; } 

        public String gender { get; set; }

        public String department { get; set; }

        public String designation { get; set; }

        public string[] skills { get; set; }


    }
}
