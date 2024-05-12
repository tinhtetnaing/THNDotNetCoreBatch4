using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace THNDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-FRO936S", //server name
            InitialCatalog = "MyDB", //database name
            UserID = "sa", //user name
            Password = "sa@123" //password
        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection open....");
            string query = "select * from TBL_BLOG";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Console.WriteLine("Connection close....");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id: " + dr["BlogId"]);
                Console.WriteLine("Blog Title: " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author: " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content: " + dr["BlogContent"]);
                Console.WriteLine("-----------------------------");
            }
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[TBL_BLOG]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
        VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Saving successful" : "Saving failed";
            Console.WriteLine(message);
            connection.Close();
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[TBL_BLOG]
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
            string message = result > 0 ? "Update successful" : "Update failed";
            Console.WriteLine(message);
            connection.Close();
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE from TBL_BLOG where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Delete successful" : "Delete failed";
            Console.WriteLine(message);
            connection.Close();
        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection open....");
            string query = "select * from TBL_BLOG WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Console.WriteLine("Connection close....");

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blog Id: " + dr["BlogId"]);
            Console.WriteLine("Blog Title: " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author: " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content: " + dr["BlogContent"]);
            Console.WriteLine("-----------------------------");
        }
    }
}
