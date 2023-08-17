using BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BondGadgetCollection.Data
{
    internal class GadgetDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadgetsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Gadgets";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gadget = new GadgetModel();

                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
            }
            return returnList;
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "delete from dbo.Gadgets where Id = @Id ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);



                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = id;



                connection.Open();
                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            }
        }

        internal List<GadgetModel> SearchForName(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Gadgets where name like @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gadget = new GadgetModel();

                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
                return returnList;

            }
        }

        internal List<GadgetModel> SearchForDescription(string searchPhrase2)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Gadgets where description like @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase2 + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gadget = new GadgetModel();

                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
                return returnList;

            }
        }


        public GadgetModel FetchOne(int Id)
        {

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Gadgets where id=@Id ";


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;



                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                GadgetModel gadget = new GadgetModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);


                    }
                }
                return gadget;
            }
        }

        public int CreateOrUpdate(GadgetModel gadgetModel)
        {

            //DataBase Access

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (gadgetModel.Id <= 0)
                {
                    sqlQuery = "insert into dbo.Gadgets values(@Name, @Description, @AppearsIn, @WithThisActor) ";
                }
                else
                {
                    sqlQuery = "update dbo.Gadgets set Name = @Name, Description = @Description, AppearsIn = @AppearsIn, WithThisActor= @WithThisActor where Id = @Id ";
                }





                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = gadgetModel.Id;



                connection.Open();
                int newId = command.ExecuteNonQuery();

                return newId;
            }
        }




    }
}