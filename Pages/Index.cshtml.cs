using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository_DependencyInjection.Models;

namespace MicroBlog.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Post> Posts { get; set; } = new List<Models.Post>();

        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogRepository _blogRepository;

        public IndexModel(
            ILogger<IndexModel> logger,
            IBlogRepository blogRepository)
        {
            _logger = logger;
            _blogRepository = blogRepository;
        }

        public void OnGet()
        {
            var posts = _blogRepository.GetAll().ToList();

            foreach (var post in posts)
            {
                if (post.Body.Length > 300)
                {
                    post.Body = post.Body.Substring(0, 300) + "...";
                }
            }

            Posts = posts;
        }
    }
}