using LibraryAPI.Services;
using LibraryAPI.Services.Implementation;
using LibraryCL;
using LibraryCL.Model;
using LibraryCL.Repository;
using LibraryCL.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations());
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    assembly => assembly.MigrationsAssembly(typeof(LibraryDbContext).Assembly.FullName)).UseLazyLoadingProxies();
});

builder.Services.AddScoped<DbContext, LibraryDbContext>();

builder.Services.AddScoped<IGenericDbRepository<User>, GenericDbRepository<User>>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();