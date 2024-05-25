using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HWTDotNetCore.ConsoleAppRefitExample;

public class RefitClientExample
{
    private readonly IBlogApi _service = RestService.For<IBlogApi>(
        new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        })
        {
            BaseAddress = new Uri("https://localhost:7265")
        });
    
    public async Task RunAsync()
    {
        //await ReadAsync();
        //await EditAsync(1);
        //await EditAsync(100);
        //await CreateAsync("test", "test", "test");
        //await UpdateAsyn(2008,"Test", "Test", "Test");
        await DeleteAsync(2008);
        await DeleteAsync(2000);
    }

    private async Task ReadAsync()
    {
        var lst = await _service.GetBlogs();
        foreach (var blog in lst)
        {
            Console.WriteLine($"Id => {blog.BlogId}");
            Console.WriteLine($"Title => {blog.BlogTitle}");
            Console.WriteLine($"Author => {blog.BlogAuthor}");
            Console.WriteLine($"Content => {blog.BlogContent}");
            Console.WriteLine("___________________________________");
        }
    }

    private async Task EditAsync(int id)
    {
        try
        {
            var item = await _service.GetBlog(id);
            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("___________________________________");
        }
        catch(ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message );
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        var message = await _service.CreateBlog(blog);
        Console.WriteLine(message);
    }

    private async Task UpdateAsyn(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.UpdateBlog(id,blog);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        try
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
