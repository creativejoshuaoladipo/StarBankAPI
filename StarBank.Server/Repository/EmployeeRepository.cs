using Microsoft.EntityFrameworkCore;
using MoneyBank.Shared;
using StarBank.Server.Models;
using System.Linq;

namespace StarBank.Server.Repository
{
    //SOLID
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StarBankDbContext _dbContext;

        public EmployeeRepository(StarBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            //Step1:
            //Get Table
          var result = await _dbContext.Employees.AddAsync(employee);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var listOfEmployee = _dbContext.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();

            _dbContext.Employees.Remove(listOfEmployee);

        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {

            var listOfEmployee = await _dbContext.Employees.Include(c=>c.Department).ToListAsync();
            return listOfEmployee;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Email == email);
            return employee;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            //
            IQueryable<Employee> employee = _dbContext.Employees.Include(c=>c.Department);
            if (!string.IsNullOrEmpty(name))
            {
                employee = employee.Where(x => x.FirstName.Contains(name)|| x.LastName.Contains(name));
            }
            if (gender != null)
            {
                employee = employee.Where(x => x.Gender == gender);
            }

            return await employee.ToListAsync();

        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {       
            //Update - Edit 
            //Before you can edit Something you have to first etract the record from the database either by using the Id
            var employeeInDb = await _dbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == employee.EmployeeId);

            if(employeeInDb != null)
            {
                employeeInDb.Email = employee.Email;
                employeeInDb.DateOfBirth = employee.DateOfBirth;
                employeeInDb.FirstName = employee.FirstName;
                employeeInDb.LastName = employee.LastName;
                employeeInDb.PhotoPath = employee.PhotoPath;
                employeeInDb.DepartmentId = employee.DepartmentId;
                employeeInDb.Gender = employee.Gender;
            }
            //Since you are adding Values to the DB, you must remember to safe the changes to the Database
            await _dbContext.SaveChangesAsync();
            return employee;

        }
    }




}
