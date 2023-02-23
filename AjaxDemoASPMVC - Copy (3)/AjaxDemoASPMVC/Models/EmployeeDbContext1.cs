using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace AjaxDemoASPMVC.Models
{
    public class EmployeeDbContext1:DbContext
    {
        public EmployeeDbContext1() : base()
        {

        }

        public EmployeeDbContext1(DbContextOptions<EmployeeDbContext1> options) : base(options) {
        }

        public DbSet<Employee1> employees1 { get; set; }
        public DbSet<Gender1> genders1 { get; set; }
        public DbSet<Department1> departments1 { get; set; }
        public DbSet<Designation1> designations1 { get; set; }
        public DbSet<Skill1> skills1 { get; set; }
        public DbSet<EmployeeSkill1> employeeskills1 { get; set; }
        public DbSet<Emp> emp { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
          /*  modelBuilder.Entity<Employee1>().HasOne<Gender1>(g => g.gender1) //gender1 from Employee1 tanble MODEL
               .WithMany(s => s.emp);//GENDER MODEL TAKEN From
*/
            modelBuilder.Entity<Gender1>()
        .HasIndex(u => u.Gender_Name) //Taken From Gender MODEL
        .IsUnique();





            /*   modelBuilder.Entity<Employee1>().HasOne<Designation1>(g => g.designation1) //TAKEN from EMPLOYEE1 MODEL
                 .WithMany(s => s.emp);  */

            modelBuilder.Entity<Designation1>()
        .HasIndex(u => u.Designation_Name) //Designation table MODElTAken value From 
        .IsUnique();


         /*   modelBuilder.Entity<Employee1>().HasOne<Department1>(g => g.depaartment1)//TAKEN from EMPLOYEE1 MODEL
              .WithMany(s => s.emp); //table MODElTAken value From Employee1
*/
            modelBuilder.Entity<Department1>()
        .HasIndex(u => u.Dept_Name) //from department MODEL
        .IsUnique();




            modelBuilder.Entity<EmployeeSkill1>().HasKey(sc => new { sc.Empid, sc.Skillid }); //ALL FROM EMPLOYEESKILLS1 intermidiate TABLE

            modelBuilder.Entity<EmployeeSkill1>()
    .HasOne<Employee1>(sc => sc.emp) //taken from INTERMIDEATE TABLE
    .WithMany(s => s.employeeSkill1)
    .HasForeignKey(sc => sc.Empid);


            modelBuilder.Entity<EmployeeSkill1>()
                .HasOne<Skill1>(sc => sc.skill1s)
                .WithMany(s => s.employeeSkill1)
                .HasForeignKey(sc => sc.Skillid);










        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer
                
        }
    }
}
