﻿using Dapper;
using HWTDotNetCore.RestAPI.Models;
using HWTDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace HWTDotNetCore.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //Read
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "Select * from tbl_blog";
            /*using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();*/
            var lst = _dapperService.Query<BlogModel>(query);
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult EditBlogs(int id)
        {
            //string query = "Select * from tbl_blog where BlogId = @BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO[dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
        VALUES
           (@BlogTitle,
            @BlogAuthor,
            @BlogContent)";
            /*using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);*/
            int result = _dapperService.Execute(query,blog);
            string message = result > 0 ? "Saving successful" : "Saving fail";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
        ,[BlogAuthor] = @BlogAuthor
        ,[BlogContent] = @BlogContent
        WHERE BlogId = @BlogId";
            /*using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);*/
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating successful" : "Updating fail";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[blogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if (conditions.Length == 0)
            {
                return NotFound("No data to Update");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET {conditions}
            WHERE BlogId = @BlogId";
            /* using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
             int result = db.Execute(query, blog);*/
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating successful" : "Updating fail";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
        WHERE BlogId = @BlogId";
            /*using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new BlogModel() { BlogId = id });*/
            int result = _dapperService.Execute(query, new BlogModel() { BlogId = id });
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            string query = "Select * from tbl_blog where BlogId = @BlogId";
            /*using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();*/
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query,new BlogModel { BlogId = id});
            return item;
        }
    }
}
