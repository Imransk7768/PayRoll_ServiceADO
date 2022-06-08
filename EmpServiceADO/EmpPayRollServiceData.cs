using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpServiceADO
{
    public class EmpPayRollServiceData
    {
        private SqlConnection con;
        public void Connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=Employee_Payroll_DB";
        }
        public void AddEmployee(EmpModel emp) 
        {
            try
            {
                Connection();
                SqlCommand command = new SqlCommand("spAddEmployee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", emp.Name);
                command.Parameters.AddWithValue("@Age", emp.Age);
                command.Parameters.AddWithValue("@Salary", emp.Salary);
                command.Parameters.AddWithValue("@StartDate", emp.StartDate);
                command.Parameters.AddWithValue("@Gender", emp.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                command.Parameters.AddWithValue("@Department", emp.Department);
                command.Parameters.AddWithValue("@Deductions", emp.Deductions);
                command.Parameters.AddWithValue("@Taxable_Pay", emp.Taxable_Pay);
                command.Parameters.AddWithValue("@Income_Tax", emp.Income_Tax);
                command.Parameters.AddWithValue("@Net_Pay", emp.Net_Pay);
                con.Open();
                int result = command.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    Console.WriteLine("Data Added");
                }
                else
                {
                    Console.WriteLine("Data Not Added.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmpModel> GetEmployeeDetails()
        {
            Connection();
            List<EmpModel> EmpDetails = new List<EmpModel>();
            SqlCommand cmd = new SqlCommand("spGetEmp_Payroll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();

            con.Open();
            adapter.Fill(table);
            con.Close();
            foreach (DataRow dr in table.Rows)
            {

                EmpDetails.Add(
                    new EmpModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        Salary = Convert.ToInt32(dr["Salary"]),
                        StartDate = Convert.ToDateTime(dr["StartDate"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Department = Convert.ToString(dr["Department"]),
                        Deductions = Convert.ToDecimal(dr["Deductions"]),
                        Taxable_Pay = Convert.ToDecimal(dr["Taxable_Pay"]),
                        Income_Tax = Convert.ToDecimal(dr["Income_Tax"]),
                        Net_Pay = Convert.ToDecimal(dr["Net_Pay"])
                    }
                            );
            }
            return EmpDetails;
        }
        public void Update_EmpDetails(EmpModel emp)  
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    Console.WriteLine("Updated Sucessfull");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete_EmpDetails(EmpModel emp)           
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    Console.WriteLine("Row Deleted Sucessfully");
                }
                else
                {
                    Console.WriteLine("Deletion Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RetrieveDetailsByDate(DateTime date)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("spAddEmployeeDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StartDate", date);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result != 0)
            {
                Console.WriteLine("Retrieve Data Sucessfull");
            }
            else
            {
                Console.WriteLine("Selection Failed Sucessfull");
            }
        }
    }
}
