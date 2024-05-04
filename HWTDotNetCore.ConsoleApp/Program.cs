// See https://aka.ms/new-console-template for more information
using HWTDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
/*SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "RV-IT-LP-202";//server name
stringBuilder.InitialCatalog = "DotNetTrainingBatch4";//database name
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@12345";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
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

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("------------------------------------");
}*/

/*AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();
adoDotNetExample.Create("Title","Author","Content");
adoDotNetExample.Update(11, "Test Title", "Test Author", "Test Content");
adoDotNetExample.Delete(11);
adoDotNetExample.Edit(11);
adoDotNetExample.Edit(1);*/

/*DapperExample dapperExample = new DapperExample();
dapperExample.Run();*/

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadKey();

