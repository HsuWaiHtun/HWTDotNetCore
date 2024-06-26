﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTDotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        //    private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        //    {
        //        DataSource = "RV-IT-LP-202",
        //        InitialCatalog = "DotNetTrainingBatch4",
        //        UserID = "sa",
        //        Password = "sa@12345"
        //    };

        private readonly SqlConnectionStringBuilder _stringBuilder;

        public AdoDotNetExample(SqlConnectionStringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        public void Read()
        {

            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection(Data Source = RV - IT - LP - 202; Initial Catalog = DotNetTrainingBatch4; User ID = sa; Password = sa@12345);
            connection.Open();
            Console.WriteLine("Connection Open");
            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            Console.WriteLine("Connection Close");
            //DataSet => DataTables
            //DataTable => DataRows
            //DataRow => DataColumns
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id => " + dr["BlogId"]);
                Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + dr["BlogContent"]);
                Console.WriteLine("------------------------------------");
            }
        }
        public void Edit(int id)
        {

            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection(Data Source = RV - IT - LP - 202; Initial Catalog = DotNetTrainingBatch4; User ID = sa; Password = sa@12345);
            connection.Open();
            Console.WriteLine("Connection Open");
            string query = "select * from tbl_blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blog Id => " + dr["BlogId"]);
            Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + dr["BlogContent"]);
            Console.WriteLine("------------------------------------");
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO[dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
        VALUES
           (@BlogTitle,
            @BlogAuthor,
            @BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving successful" : "Saving fail";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Updating successful" : "Updating fail";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Deleting successful" : "Deleting fail";// to know database changes
            Console.WriteLine(message);
        }
    }
}
