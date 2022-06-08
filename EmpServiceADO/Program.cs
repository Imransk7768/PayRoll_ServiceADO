﻿using System;

namespace EmpServiceADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Payroll Service");
            EmpPayRollServiceData empData = new EmpPayRollServiceData();
            Console.WriteLine("1. Insert Emp Details\n2. Retrieve Emp Details\n");
            Console.Write("Enter option to Execute : ");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    EmpModel addMdl = new EmpModel();
                    addMdl.Name = "Shashank";
                    addMdl.Age = 33;
                    addMdl.Salary = 6000;
                    addMdl.StartDate = Convert.ToDateTime("07-02-2017");
                    addMdl.Gender = "M";
                    addMdl.PhoneNumber = "9123456777";
                    addMdl.Department = "Sales";
                    addMdl.Deductions = 500;
                    addMdl.Taxable_Pay = 500;
                    addMdl.Income_Tax = 500;
                    addMdl.Net_Pay = 2000;
                    empData.AddEmployee(addMdl);
                    break;
                case 2:
                    List<EmpModel> list = empData.GetEmployeeDetails();
                    foreach (var data in list)
                    {
                        Console.WriteLine(data.Id + ", " + data.Name + ", " + data.Salary + ", " + data.StartDate + ", " + data.Gender + " " + data.PhoneNumber
                            + " " + data.Department + " " + data.Deductions + " " + data.Taxable_Pay + " " + data.Income_Tax + " " + data.Net_Pay);
                    }
                    break;
                default:
                    Console.WriteLine("Execution Ends.");
                    break;
            }
        }
    }
}
