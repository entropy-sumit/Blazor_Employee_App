using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class RegisterRL : IRegisterRL
    {
        public SqlConnection sqlConnection;
        public IConfiguration configuration;
        public RegisterRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EMPLOYEE_APP_BLAZOR"));
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("Sp_AddEmployees", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                    cmd.Parameters.AddWithValue("@Profile_Img", employeeModel.ProfileImg);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                    this.sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> listEmployee = new List<EmployeeModel>();
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EMPLOYEE_APP_BLAZOR"));
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel();

                        employeeModel.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                        employeeModel.Name = rdr["Name"].ToString();
                        employeeModel.Gender = rdr["Gender"].ToString();
                        employeeModel.ProfileImg = rdr["Profile_Img"].ToString();
                        employeeModel.Notes = rdr["Notes"].ToString();
                        employeeModel.Department = rdr["Department"].ToString();
                        employeeModel.Salary = rdr["Salary"].ToString();

                        listEmployee.Add(employeeModel);
                    }
                    sqlConnection.Close();
                }
                return listEmployee;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }

        }
        public EmployeeModel GetEmployeeData(int id)
        {
            EmployeeModel employee = new EmployeeModel();
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EMPLOYEE_APP_BLAZOR"));

            try
            {
                using (this.sqlConnection)
                {

                    SqlCommand cmd = new SqlCommand("sp_GetEmployeeByID", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", id);
                    this.sqlConnection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Notes = rdr["Notes"].ToString();
                        employee.Salary = rdr["Salary"].ToString();
                        employee.ProfileImg = rdr["Profile_Img"].ToString();
                        
                    }
                    sqlConnection.Close();
                }
                return employee; 
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public void UpdateEmployee(EmployeeModel employee)
        {
           
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EMPLOYEE_APP_BLAZOR"));
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Profile_Img", employee.ProfileImg);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                sqlConnection.Close();

            }
            
            catch(Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
            
        }
        public void DeleteEmployee(int id)
        {
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EMPLOYEE_APP_BLAZOR"));
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("usp_DeleteCustomer", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", id);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                this.sqlConnection.Close();

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

    }
}
