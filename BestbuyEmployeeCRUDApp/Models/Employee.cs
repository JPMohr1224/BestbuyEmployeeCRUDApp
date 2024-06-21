using System;
namespace BestbuyEmployeeCRUDApp.Models
{
    public class Employee
    {
        public Employee()
        {
        }


        public int EmployeeID { get; set; }
        public string ? FirstName { get; set; }
        public char ? MiddleInitial { get; set; }
        public string ? LastName { get; set; }
        public string ? EmailAddress { get; set; }
        public string ? PhoneNumber { get; set; }
        public string ? Title { get; set; }
        public DateTime ? DateOfBirth { get; set; }
       // public IEnumerable<Category> Categories { get; set; }
    }
}

