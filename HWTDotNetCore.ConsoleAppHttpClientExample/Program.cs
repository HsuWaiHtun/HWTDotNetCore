//using Newtonsoft.Json;
//using System.ComponentModel.DataAnnotations;

//Console.WriteLine("Hello, World!");
//Console App - Client(Frontend)
//Asp.Net Core Web Api - Server(Backend)
//HttpClientHandler clientHandler = new HttpClientHandler();
//clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
//HttpClient client = new HttpClient(clientHandler);

//var response = await client.GetAsync("https://localhost:7089/api/blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
//    foreach (var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine($"Title => {blog.BlogTitle}");
//        Console.WriteLine($"Author => {blog.BlogAuthor}");
//        Console.WriteLine($"Content => {blog.BlogContent}");
//    }
//}
//public class BlogModel
//{
//    public int BlogId { get; set; }
//    public string? BlogTitle { get; set; }//string? - Allow null value
//    public string? BlogAuthor { get; set; }
//    public string? BlogContent { get; set; }
//}

using HWTDotNetCore.ConsoleAppHttpClientExample;

HttpClientExample clientExample = new HttpClientExample();
await clientExample.RunAsync();