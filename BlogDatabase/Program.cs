using BlogDatabase.Entity;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<BlogDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
BlogDbContext dbContext = scope.ServiceProvider.GetService<BlogDbContext>();


app.MapPost("POST", async (BlogDbContext db) =>
{
    var user = new User
    {
        FullName = "John Doe",
        Email = "john.doe@gmail.com",
        Address = new Address
        {
            Country = "Poland",
            City = "Warsaw",
            Street = "D³uga"
        }
    };

    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();

    return user;
});

app.MapGet("GET", async (BlogDbContext db) =>
{
    return await db.Users.FirstAsync(u => u.FullName == "John Doe");
});

app.Run();
