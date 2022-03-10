using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLAyer.Interfaces
{
    public interface IRegisterBL
    {
        public bool AddEmployee(EmployeeModel employeeModel);
    }
}
