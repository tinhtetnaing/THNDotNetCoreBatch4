using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THNDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(11);
            //Create("TestTitle1", "TestAuthor1", "TestContent1");
            //Update(26, "TestTitle01", "TestAuthor01", "TestContent01");
            Delete(26);
            Read();
        }

        private void Read()
        {
            var lst = db.Blog.ToList();
            foreach (BlogViewModel item in lst)
            {
                Console.WriteLine("BlogId: " + item.BlogId);
                Console.WriteLine("BlogTitle: " + item.BlogTitle);
                Console.WriteLine("BlogAuthor: " + item.BlogAuthor);
                Console.WriteLine("BlogConent: " + item.BlogContent);
                Console.WriteLine("________________________________");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blog.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data Found");
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
            
            db.Blog.Add(item);
            int result = db.SaveChanges();
            
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blog.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blog.FirstOrDefault(x => x.BlogId == id);
            if(item is null ) 
            {
                Console.WriteLine("No Data Found");
                return;
            }

            db.Blog.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
