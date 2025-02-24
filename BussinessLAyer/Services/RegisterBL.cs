﻿using BussinessLAyer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLAyer.Services
{
    public class RegisterBL :IRegisterBL
    {
        private readonly IRegisterRL registerRL;
        public RegisterBL(IRegisterRL registerRL)
        {
            this.registerRL = registerRL;
        }
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return this.registerRL.AddEmployee(employeeModel);
            }
            catch(Exception)
            {
                throw;

            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return this.registerRL.GetAllEmployee();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public EmployeeModel GetEmployeeData(int id)
        {
            try
            {
                return this.registerRL.GetEmployeeData(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                this.registerRL.UpdateEmployee(employee);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void DeleteEmployee(int id)
        {
            try
            {
                this.registerRL.DeleteEmployee(id);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
