using FluentValidation;
using LibraryAPI.API;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using LibraryAPI.Services.Implementation;
using LibraryAPI.Validators;
using LibraryCL;
using LibraryCL.Repository;
using LibraryCL.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<IValidator<UserRegistrationDTO>, UserRegistrationValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpLogging();

app.Logger.LogInformation("Running application...");

app.RegisterUserAPI(app.Logger);

app.Run();
