# Repository & Dependency Injection

This project is a Week 5 MicroBlog assignment that demonstrates the Repository Pattern and Dependency Injection in an ASP.NET Core Razor Pages application.

## Repository Pattern

The application uses the `IBlogRepository` interface so that the Razor Pages do not need to know how blog posts are stored.

There are two repository implementations:

- `JsonBlogRepository` - stores blog posts in `data/posts.json`
- `InMemoryBlogRepository` - stores blog posts in memory

## Dependency Injection

The repository is registered in `Program.cs`.

### Using the JSON Repository

The application currently uses:

```csharp
builder.Services.AddSingleton<IBlogRepository, JsonBlogRepository>();
```

This stores blog posts in the `data/posts.json` file.

### Switching to the In-Memory Repository

To switch to the in-memory repository, change the registration in `Program.cs` to:

```csharp
builder.Services.AddSingleton<IBlogRepository, InMemoryBlogRepository>();
