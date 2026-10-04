using MicroBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository_DependencyInjection.Models;

namespace MicroBlog.Pages
{
    public class DetailsModel : PageModel
    {
        //Receive id root parameter from the URL
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        //Fetch article by Id
        public Post Post { get; set; } = new Post();

        private readonly IBlogRepository _blogRepository;

        public DetailsModel(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void OnGet()
        {
            Post = _blogRepository.GetById(Id);

            if (Post == null)
            {
                // Show message if no post is found
                ViewData["Message"] = "No posts found.";
            }
        }
    }
}
