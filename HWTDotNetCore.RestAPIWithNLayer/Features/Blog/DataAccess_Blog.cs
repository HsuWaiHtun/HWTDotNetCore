using HWTDotNetCore.RestAPIWithNLayer.Db;

namespace HWTDotNetCore.RestAPIWithNLayer.Features.Blog
{
    public class DataAccess_Blog
    {
        private readonly AppDbContext _context;
        public DataAccess_Blog()
        {
            _context = new AppDbContext();
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var lst = _context.Blogs.FirstOrDefault(x=> x.BlogId == id);
            return lst;
        }
        public int CreateBlog(BlogModel requestModel)
        {
            _context.Blogs.Add(requestModel);
            int result = _context.SaveChanges();
            return result;
        }
        public int UpdateBlog(int id,BlogModel requestModel) 
        {
            var lst = _context.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if (lst is null) { return 0; }

            lst.BlogTitle = requestModel.BlogTitle;
            lst.BlogAuthor = requestModel.BlogAuthor;
            lst.BlogContent = requestModel.BlogContent;

            int result = _context.SaveChanges();
            return result;
        }
        public int PatchBlog(int id, BlogModel requestModel)
        {
            var lst = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (lst is null) { return 0; }
            if (!String.IsNullOrEmpty(requestModel.BlogTitle))
            {
                lst.BlogTitle = requestModel.BlogTitle;
            }
            if (!String.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                lst.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!String.IsNullOrEmpty(requestModel.BlogContent))
            {
                lst.BlogContent = requestModel.BlogContent;
            }
            int result = _context.SaveChanges();
            return result;
        }
        public int DeleteBlog(int id)
        {
            var lst = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (lst is null) { return 0; }
            _context.Blogs.Remove(lst);
            int result = _context.SaveChanges();
            return result;
        }
    }
}
