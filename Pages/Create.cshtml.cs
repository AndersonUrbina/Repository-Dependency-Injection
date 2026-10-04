using MicroBlog.Models;
using Repository_DependencyInjection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository_DependencyInjection.Models;

namespace MicroBlog.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Post Post { get; set; }

        private readonly IBlogRepository _blogRepository;

        public CreateModel(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set post ID as an auto-incrementing value
            var posts = _blogRepository.GetAll().ToList();
            Post.Id = posts.Count > 0 ? posts.Max(p => p.Id) + 1 : 1;

            // Set the CreatedUtc property to the current UTC time
            Post.CreatedUtc = DateTime.UtcNow;

            // Save the post using the repository
            _blogRepository.Add(Post);
            _blogRepository.Save();

            // Redirect to the index page after the post is created
            return RedirectToPage("/Index");
        }
    }
}

//PLAN
//create the page to create a new post
//save the posts on a .json file
//pull the posts from the .json file and display them on the index page
//click on a post on the index page and then redirect to the details page where all the details of the post are displayed