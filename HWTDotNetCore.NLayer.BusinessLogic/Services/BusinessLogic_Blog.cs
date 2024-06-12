using HWTDotNetCore.NLayer.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using HWTDotNetCore.NLayer.DataAccess.Models;

namespace HWTDotNetCore.NLayer.BusinessLogic.Services
{
    public class BusinessLogic_Blog
    {
        private readonly DataAccess_Blog _daBlog;
        public BusinessLogic_Blog()
        {
            _daBlog = new DataAccess_Blog();
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _daBlog.GetBlogs();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var lst = _daBlog.GetBlog(id);
            return lst;
        }
        public int CreateBlog(BlogModel requestModel)
        {
            int result = _daBlog.CreateBlog(requestModel);
            return result;
        }
        public int UpdateBlog(int id, BlogModel requestModel)
        {
            int result = _daBlog.UpdateBlog(id, requestModel);
            return result;
        }
        public int PatchBlog(int id, BlogModel requestModel)
        {
            int result = _daBlog.PatchBlog(id, requestModel);
            return result;
        }
        public int DeleteBlog(int id)
        {
            int result = _daBlog.DeleteBlog(id);
            return result;
        }
    }
}
