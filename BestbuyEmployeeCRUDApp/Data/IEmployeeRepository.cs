using System;
using System.Collections.Generic;
using BestbuyEmployeeCRUDApp.Models;

namespace BestbuyEmployeeCRUDApp.Data
{
	public interface IEmployeeRepository
	{
		public IEnumerable<Employee> GetAllEmployees();
		public Employee GetEmployee(int id);
		public void UpdateEmployee(Employee employee);
		public void AddEmployee(Employee employeeToInsert);
		public void DeleteEmployee(Employee employee);
		

	}


}


