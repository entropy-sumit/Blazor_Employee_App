using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IRegisterRL
    {
        public bool AddEmployee(EmployeeModel employeeModel);
        public IEnumerable<EmployeeModel> GetAllEmployee();
        public EmployeeModel GetEmployeeData(int id);
        public void UpdateEmployee(EmployeeModel employee);
        public void DeleteEmployee(int id);
    }
}
