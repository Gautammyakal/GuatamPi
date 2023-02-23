namespace AjaxDemoASPMVC.Models
{
    public class Emp
    {
        public int empId { get; set; }
        public string firstName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string lastName { get; set; }
        public string designation { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public string skills { get; set; }
        public int isActive { get; internal set; }
    }
}
