using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HWTDotNetCore.ConsoleAppRestClientExample;

public class RestClientExample
{
    private readonly RestClient _client = new RestClient(new RestClientOptions("https://localhost:7089")
    {
        RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
    });
    private readonly string _blogEndpoint = "/api/blog";
    public async Task RunAsync()
    {
        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //await ReadAsync();
        //await EditAsync(2007);
        //await CreateAsync("Test 1", "Test 1", "Test 1");
        //await UpdateAsync(2007, "Test 2", "Test 2", "Test 2");
        //await PatchAsync(2007, author: "Test45", content: "Test45");
        //await EditAsync(2007);
        await DeleteAsync(2007);
    }
    public async Task ReadAsync()
    {
        //RestRequest request = new RestRequest(_blogEndpoint);
        //var response = await _client.GetAsync(request);
        RestRequest request = new RestRequest(_blogEndpoint, Method.Get);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
            List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
            foreach (var blog in lst)
            {
                Console.WriteLine(JsonConvert.SerializeObject(blog));
                Console.WriteLine($"Title => {blog.BlogTitle}");
                Console.WriteLine($"Author => {blog.BlogAuthor}");
                Console.WriteLine($"Content => {blog.BlogContent}");
            }
        }
    }

    public async Task EditAsync(int id)
    {
        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
            BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
            Console.WriteLine(JsonConvert.SerializeObject(item));
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }   

    public async Task CreateAsync(string title, string author, string content)
    {
        BlogModel model = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest request = new RestRequest(_blogEndpoint, Method.Post);
        request.AddJsonBody(model);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    public async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogModel model = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
        request.AddJsonBody(model);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    public async Task PatchAsync(int id, string title = null, string author = null, string content = null)
    {
        BlogModel model = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Patch);
        request.AddJsonBody(model);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    public async Task DeleteAsync(int id)
    {
        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
            //other process
            //continue
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
            //error message
            //break
        }
    }
}
