using MicroBlog.Models;

namespace Repository_DependencyInjection.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        void Add(Post post);
        void Save();
    }
}
