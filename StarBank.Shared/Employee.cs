using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBank.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; } //PrimaryKey
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
        public int DepartmentId { get; set; } //ForeignKey
        public Department Department { get; set; } //Navigation Property

    }

}
