using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWTDotNetCore.ConsoleApp.Dtos;

namespace HWTDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        // private readonly AppDbContext db = new AppDbContext();
        private readonly AppDbContext db;
        public EFCoreExample(AppDbContext db) {
            this.db = db; 
        }
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(16);
            //Create("title", "author", "content");
            Update(1002, "Title 2", "Author 2", "Content 2");
            Delete(1002);
        }
        private void Read()
        {
            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-------------------------");
            }
        }
        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            //foreach(var x in BlogDto){
            //if(x.BlogId == id)
            //}
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }
        public void Create(string title, string author, string content)
        {
            BlogDto item = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving fail";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            //foreach(var x in BlogDto){
            //if(x.BlogId == id)
            //}
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating successful" : "Updating fail";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting successful" : "Deleting fail";// to know database changes
            Console.WriteLine(message);
        }
    }
}
