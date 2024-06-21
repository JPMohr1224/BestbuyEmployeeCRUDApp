using System;
using Dapper;
using System.Data;
using BestbuyEmployeeCRUDApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestbuyEmployeeCRUDApp.Data
{
    public class EmployeeRepository : IEmployeeRepository
	{
        private readonly IDbConnection _conn;

        public EmployeeRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("SELECT * FROM EMPLOYEES; ");
        }

        public Employee GetEmployee(int id)
        {
            return _conn.QuerySingle<Employee>("SELECT * FROM EMPLOYEES WHERE EMPLOYEEID = @id", new { id = id });
        }


        public void UpdateEmployee(Employee employee)
        {
            _conn.Execute("UPDATE employees SET FirstName = @firstname, MiddleInitial = @middleinitial, LastName = @lastname, EmailAddress = @emailaddress WHERE EmployeeID = @id",
            new { firstname = employee.FirstName, middleinitial = employee.MiddleInitial, Lastname = employee.LastName, EmailAddress = employee.EmailAddress, id = employee.EmployeeID });
        }

        public void AddEmployee(Employee employeeToAdd)
        {
            _conn.Execute("INSERT INTO employees (FIRSTNAME, MIDDLEINITIAL, LASTNAME, EMAILADDRESS, TITLE, DATEOFBIRTH) VALUES (@firstname, @middleinitial, @lastname, @emailaddress, @title, @dateofbirth);",
                new { firstname = employeeToAdd.FirstName, middleinitial = employeeToAdd.MiddleInitial, lastname = employeeToAdd.LastName, emailaddress = employeeToAdd.EmailAddress, title = employeeToAdd.Title, dateofbirth = employeeToAdd.DateOfBirth });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }



        public void DeleteEmployee(Employee employee)
        {
            _conn.Execute("DELETE FROM EMPLOYEES WHERE EmployeeID = @id;", new { id = employee.EmployeeID });
            _conn.Execute("DELETE FROM Sales WHERE EmployeeID = @id;", new { id = employee.EmployeeID });
            
        }
    }
}

