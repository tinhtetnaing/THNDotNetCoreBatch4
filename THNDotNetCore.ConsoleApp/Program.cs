
// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THNDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");


//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "DESKTOP-FRO936S"; //server name
//stringBuilder.InitialCatalog = "MyDB"; //database name
//stringBuilder.UserID = "sa"; //user name
//stringBuilder.Password = "sa@123"; //password
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//connection.Open();
//Console.WriteLine("Connection open....");

//string query = "select * from TBL_BLOG";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);   
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection close....");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id: " + dr["BlogId"]);
//    Console.WriteLine("Blog Title: " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author: " + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content: " + dr["BlogContent"]);
//    Console.WriteLine("-----------------------------");

//}

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(19, "UpdatedTitle", "UpdatedAuthor", "UpdatedContent");
//adoDotNetExample.Edit(22);
//adoDotNetExample.Delete(22);
//adoDotNetExample.Read();

DapperExample dapperExample = new DapperExample();
dapperExample.Run();

Console.ReadKey();
 