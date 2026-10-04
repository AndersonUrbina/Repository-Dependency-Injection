using MicroBlog.Models;
using Repository_DependencyInjection.Models;

namespace Repository_DependencyInjection.Repositories
{
    public class InMemoryBlogRepository : IBlogRepository
    {
        private readonly List<Post> _posts = new List<Post>();

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.FirstOrDefault(post => post.Id == id);
        }

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public void Save()
        {
            // Nothing to save because the posts are stored in memory.
        }
    }
}