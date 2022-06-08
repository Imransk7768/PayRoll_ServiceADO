using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    }
}
