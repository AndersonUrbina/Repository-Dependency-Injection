using Repository_DependencyInjection.Models;
using Repository_DependencyInjection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add the repository implementation to the DI(Dependency Injection) container.
builder.Services.AddSingleton<IBlogRepository, JsonBlogRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

builder.Services.AddSingleton<IBlogRepository, JsonBlogRepository>();