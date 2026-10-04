using MicroBlog.Models;
using Repository_DependencyInjection.Models;
using System.Text.Json;

namespace Repository_DependencyInjection.Repositories
{
    public class JsonBlogRepository : IBlogRepository
    {
        private readonly string _filePath = "data/posts.json";

        public IEnumerable<Post> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Post>();
            }

            var json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Post>>(json)
                   ?? new List<Post>();
        }

        public Post GetById(int id)
        {
            return GetAll().FirstOrDefault(post => post.Id == id);
        }

        public void Add(Post post)
        {
            var posts = GetAll().ToList();

            posts.Add(post);

            var json = JsonSerializer.Serialize(posts, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

        public void Save()
        {
            // JSON is written immediately by Add().
        }
    }
}