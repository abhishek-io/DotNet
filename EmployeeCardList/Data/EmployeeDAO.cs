using EmployeeCardList.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeCardList.Data
{
    internal class EmployeeDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeCardsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<EmployeeModel> FetchAll()
        {
            List<EmployeeModel> returnList = new List<EmployeeModel>();

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.EmployeeCards";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();

                        emp.Id = reader.GetInt32(0);
                        emp.Name = reader.GetString(1);
                        emp.Department = reader.GetString(2);
                        emp.Designation = reader.GetString(3);
                        emp.Phone = reader.GetString(4);

                        returnList.Add(emp);
                    }
                }
            }
            return returnList;
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "delete from dbo.EmployeeCards where Id = @Id ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);



                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = id;



                connection.Open();
                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            }
        }

        internal List<EmployeeModel> SearchForName(string searchPhrase)
        {
            List<EmployeeModel> returnList = new List<EmployeeModel>();

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from employeecards where Name like @searchForMe or Department like @searchForMe or Designation like @searchForMe or Phone like @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();

                        emp.Id = reader.GetInt32(0);
                        emp.Name = reader.GetString(1);
                        emp.Department = reader.GetString(2);
                        emp.Designation = reader.GetString(3);
                        emp.Phone = reader.GetString(4);

                        returnList.Add(emp);
                    }
                }
                return returnList;

            }
        }

        


        public EmployeeModel FetchOne(int Id)
        {

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.EmployeeCards where id=@Id ";


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;



                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                EmployeeModel emp = new EmployeeModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        emp.Id = reader.GetInt32(0);
                        emp.Name = reader.GetString(1);
                        emp.Department = reader.GetString(2);
                        emp.Designation = reader.GetString(3);
                        emp.Phone = reader.GetString(4);


                    }
                }
                return emp;
            }
        }

        public int CreateOrUpdate(EmployeeModel employeeModel)
        {

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (employeeModel.Id <= 0)
                {
                    sqlQuery = "insert into dbo.EmployeeCards values(@Name, @Department, @Designation, @Phone) ";
                }
                else
                {
                    sqlQuery = "update dbo.EmployeeCards set Name = @Name, Department = @Department, Designation = @Designation, Phone= @Phone where Id = @Id ";
                }





                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = employeeModel.Name;
                command.Parameters.Add("@Designation", System.Data.SqlDbType.VarChar, 1000).Value = employeeModel.Designation;
                command.Parameters.Add("@Department", System.Data.SqlDbType.VarChar, 1000).Value = employeeModel.Department;
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 1000).Value = employeeModel.Phone;
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = employeeModel.Id;



                connection.Open();
                int newId = command.ExecuteNonQuery();

                return newId;
            }
        }




    }
}