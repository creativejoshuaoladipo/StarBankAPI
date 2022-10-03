using Microsoft.EntityFrameworkCore;
using MoneyBank.Shared;

namespace StarBank.Server.Models
{
    public class StarBankDbContext : DbContext
    {
        public StarBankDbContext(DbContextOptions<StarBankDbContext> options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding Datas to the Department Table
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 1,
                DepartmentName = "IT"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 2,
                DepartmentName = "HR"
            });


            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 3,
                DepartmentName = "Payrool"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 4,
                DepartmentName = "Admin"
            });

            //Seeding Datas to the Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/sara.png"
            });




            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "David",
                LastName = "Samuel",
                Email = "david@infotech.com",
                DateOfBirth = new DateTime(1999, 9, 23),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/david.png"
            });



            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Slyvester",
                LastName = "Muoghalu",
                Email = "slyverster@infotech.com",
                DateOfBirth = new DateTime(1992, 9, 23),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/slyvester.png"
            });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Joy",
                LastName = "Silver",
                Email = "joy@infotech.com",
                DateOfBirth = new DateTime(1992, 9, 23),
                Gender = Gender.Male,
                DepartmentId = 4,
                PhotoPath = "images/slyvester.png"
            });

        }

    }
}
