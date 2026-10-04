using Repository_DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{   // This page model is used to display a list of posts/articles in a card format on the index page.
    public class _PostCardModel : PageModel
    {
        public List<Models.Post> Posts { get; set; } = new List<Models.Post>();

        public void OnGet()
        {
            
        }
    }
}
