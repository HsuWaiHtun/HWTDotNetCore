using Dapper;
using HWTDotNetCore.RestAPI.Models;
using HWTDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HWTDotNetCore.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        //private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNet2Controller(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            /*SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection(Data Source = RV - IT - LP - 202; Initial Catalog = DotNetTrainingBatch4; User ID = sa; Password = sa@12345);
            connection.Open();
            Console.WriteLine("Connection Open");
            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            //List<BlogModel> lst = new List<BlogModel>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);
            //    BlogModel model = new BlogModel()
            //    {
            //          BlogId = Convert.ToInt32(dr["BlogId"]),
            //          BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //          BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //          BlogContent = Convert.ToString(dr["BlogContent"]),
            //    };
            //    lst.Add(blog);
            //}
            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel()
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),
            }).ToList();*/
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {           
            string query = "select * from tbl_blog where BlogId = @BlogId";
            /*not include params
            AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            parameters[0] = new AdoDotNetParameter("@BlogId", id);
            var lst = _adoDotNetService.Query<BlogModel>(query, parameters);*/
            /*SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
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
                return NotFound("No data Found");
            }
            DataRow dr = dt.Rows[0];
            var item = new BlogModel()
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),
            };*/
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            if (item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO[dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
        VALUES
           (@BlogTitle,
            @BlogAuthor,
            @BlogContent)";
            /*SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();*/
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                                                         new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                                                         new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "Saving successful" : "Saving fail";
            return Ok(message);
            //return StatusCode(500, message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId = @BlogId";
            /*SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();*/
            int result = _adoDotNetService.Execute(query,
               new AdoDotNetParameter("@BlogId", id),
               new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
               new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
               new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "Saving successful" : "Saving fail";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            if (item is null)
            {
                return NotFound("No data found");
            }
            query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId = @BlogId";
            blog.BlogId = id;
            if (blog.BlogTitle.IsNullOrEmpty())
            {
                blog.BlogTitle = item.BlogTitle;
            }
            if (blog.BlogAuthor.IsNullOrEmpty())
            {
                blog.BlogAuthor = item.BlogAuthor;
            }
            if (blog.BlogContent.IsNullOrEmpty())
            {
                blog.BlogContent = item.BlogContent;
            }
            int result = _adoDotNetService.Execute(query,
               new AdoDotNetParameter("@BlogId", id),
               new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
               new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
               new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "Updating field successful" : "Updating field fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @BlogId";
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
            return Ok(message);
        }

        private bool FindById(int id)
        {
            string query = "Select * from tbl_blog where BlogId = @BlogId";
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));
            if (query is null)
            {
                return false;
            }
            return true;
        }
    }
}