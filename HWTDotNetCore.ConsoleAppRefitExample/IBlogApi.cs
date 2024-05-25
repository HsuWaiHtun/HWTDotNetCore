using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTDotNetCore.ConsoleAppRefitExample;
public interface IBlogApi
{
    [Get("/api/UserInterface_Blog")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/UserInterface_Blog/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/UserInterface_Blog")]
    Task<string> CreateBlog(BlogModel blog);

    [Put("/api/UserInterface_Blog/{id}")]
    Task<string> UpdateBlog(int id, BlogModel blog);

    [Delete("/api/UserInterface_Blog/{id}")]
    Task<string> DeleteBlog(int id);
}

public class BlogModel
{
public int BlogId { get; set; }
public string? BlogTitle { get; set; }//string? - Allow null value
public string? BlogAuthor { get; set; }
public string? BlogContent { get; set; }
}