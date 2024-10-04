using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace CurdUsingADO.Models
{
    public class DBContextEmployee
    {
        
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;


        public List<Employee> GetEmployees()
        {
           List<Employee> EmployeeList = new List<Employee>();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("spGetEmployeee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.Name = dr.GetValue(1).ToString();
                emp.Age=Convert.ToInt32(dr.GetValue(2).ToString());
                emp.Salary=Convert.ToDecimal(dr.GetValue(3).ToString());   
                emp.City=dr.GetValue(4).ToString();
                emp.Gender = dr.GetValue(5).ToString();

                EmployeeList.Add(emp);
            }
            con.Close();


            return EmployeeList;
        }
        

        public bool AddEmployees(Employee emp)
        {
            con = new SqlConnection(cs);
             cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@city", emp.City);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close() ;


            if (i > 0)
            {
               return true;
            }
            else
            {
                return false;
            }


        }
           
        public bool UpdateEmployee(Employee emp)
        {
            con = new SqlConnection(cs);
            cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@city", emp.City);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);

            con.Open() ;
            int i = cmd.ExecuteNonQuery();
            con.Close() ;

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteEmployee(int id)
        {
            con = new SqlConnection (cs);
            cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}