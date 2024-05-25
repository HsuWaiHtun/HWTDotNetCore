using HWTDotNetCore.ConsoleAppRefitExample;
using Refit;
using System.Net;

//try
//{
//    RefitClientExample refitClientExample = new RefitClientExample();
//    await refitClientExample.RunAsync();
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

RefitClientExample refitClientExample = new RefitClientExample();
await refitClientExample.RunAsync();

//var httpClient = new HttpClient(new HttpClientHandler
//{
//    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
//})
//{
//    BaseAddress = new Uri("https://localhost:7265")
//};
//var service = RestService.For<IBlogApi>(httpClient);

//var lst = await service.GetBlogs();
//foreach (var blog in lst)
//{
//    Console.WriteLine($"Id => {blog.BlogId}");
//    Console.WriteLine($"Title => {blog.BlogTitle}");
//    Console.WriteLine($"Author => {blog.BlogAuthor}");
//    Console.WriteLine($"Content => {blog.BlogContent}");
//    Console.WriteLine("___________________________________");
//}
