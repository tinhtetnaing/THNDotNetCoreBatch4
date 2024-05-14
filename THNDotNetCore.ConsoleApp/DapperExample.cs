using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace THNDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(19);
            //Edit(100);
            //Create("Title1", "Author1", "Content1");
            Update(25, "UpdatedTitle1", "UpdatedAuthor1", "UpdatedContent1");
            Delete(25);
            Read();

        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogViewModel> lst = db.Query<BlogViewModel>("Select * from TBL_BLOG").ToList();

            foreach(BlogViewModel item in lst)
            {
                Console.WriteLine("BlogId: "+ item.BlogId);
                Console.WriteLine("BlogTitle: " + item.BlogTitle);
                Console.WriteLine("BlogAuthor: " + item.BlogAuthor);
                Console.WriteLine("BlogConent: " + item.BlogContent);
                Console.WriteLine("________________________________");
            }
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogViewModel>("Select * from TBL_BLOG where BlogId=@BlogId", new BlogViewModel { BlogId = id }).FirstOrDefault();  
            if(item == null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            Console.WriteLine("BlogId: " + item.BlogId);
            Console.WriteLine("BlogTitle: " + item.BlogTitle);
            Console.WriteLine("BlogAuthor: " + item.BlogAuthor);
            Console.WriteLine("BlogConent: " + item.BlogContent);
            Console.WriteLine("________________________________");
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogViewModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[TBL_BLOG]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
        VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogViewModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[TBL_BLOG]
           SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
         WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result>0?"Update Successful":"Update Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = new BlogViewModel()
            {
                BlogId = id,
                
            };
            string query = @"DELETE FROM [dbo].[TBL_BLOG] WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
