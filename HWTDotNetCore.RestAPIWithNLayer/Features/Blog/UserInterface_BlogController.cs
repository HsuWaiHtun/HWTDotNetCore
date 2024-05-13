using Microsoft.EntityFrameworkCore;

namespace HWTDotNetCore.RestAPIWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInterface_BlogController : ControllerBase
    {
        private readonly BusinessLogic_Blog _blBlog;
        public UserInterface_BlogController()
        {
            _blBlog = new BusinessLogic_Blog();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _blBlog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("no data found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            int result = _blBlog.CreateBlog(blog);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("no data found");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _blBlog.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }//update obj

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("no data found");
            }
            int result = _blBlog.PatchBlog(id, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }//update each field

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("no data found");
            }
           
            var result = _blBlog.DeleteBlog(id);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
