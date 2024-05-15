using HWTDotNetCore.RestAPI.Db;
using HWTDotNetCore.RestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HWTDotNetCore.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly AppDbContext _context;
    public BlogController()
    {
        _context = new AppDbContext();
    }//constructor

    [HttpGet]
    public IActionResult Read()
    {
        var lst = _context.Blogs.ToList();
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("no data found");
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(BlogModel blog)
    {
        _context.Blogs.Add(blog);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Saving Successful" : "Saving Failed";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BlogModel blog) 
    {
        var item = _context.Blogs.First(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("no data found");
        }
        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;
        int result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful" : "Updating Failed";
        return Ok(message);
    }//update obj

    [HttpPatch("{id}")]
    public IActionResult Patch(int id,BlogModel blog) 
    {
        var item = _context.Blogs.First(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("no data found");
        }
        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            item.BlogTitle = blog.BlogTitle;
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            item.BlogAuthor = blog.BlogAuthor;
        }
        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            item.BlogContent = blog.BlogContent;
        }
        int result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful" : "Updating Failed";
        return Ok(message);
    }//update each field

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x=>x.BlogId == id);
        if (item is null)
        {
            return NotFound("no data found");
        }
        _context.Blogs.Remove(item);
        var result = _context.SaveChanges();
        string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
        return Ok(message);
    }

}
