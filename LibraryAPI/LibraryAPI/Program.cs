using FluentValidation;
using LibraryAPI.API;
using LibraryAPI.DTO;
using LibraryAPI.Options;
using LibraryAPI.Services;
using LibraryAPI.Services.Implementation;
using LibraryAPI.Validators;
using LibraryCL;
using LibraryCL.Model;
using LibraryCL.Repository;
using LibraryCL.Repository.Implementation;
using LibraryCL.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.EnableAnnotations();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    assembly => assembly.MigrationsAssembly(typeof(LibraryDbContext).Assembly.FullName)).UseLazyLoadingProxies();
});

builder.Services.Configure<JWTOptions>(
    builder.Configuration.GetSection(JWTOptions.JWT));

var jwtOptions = builder.Configuration.GetSection(JWTOptions.JWT)
                                                     .Get<JWTOptions>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<LibraryDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddScoped<DbContext, LibraryDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUploadImageService, UploadImageDatabaseService>();

builder.Services.AddSingleton<IValidator<UserRegistrationDTO>, UserRegistrationValidator>();
builder.Services.AddSingleton<IValidator<UpdateUserEmailDTO>, UserEmailValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = jwtOptions.ValidAudience,
        ValidIssuer = jwtOptions.ValidIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
      .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
      .RequireAuthenticatedUser()
      .Build();

    options.AddPolicy(AuthorizationPolicies.Admin, policy =>
              policy.RequireRole(Roles.Admin));

    options.AddPolicy(AuthorizationPolicies.AdminLibrarian, policy =>
              policy.RequireRole(Roles.Admin, Roles.Librarian));

    options.AddPolicy(AuthorizationPolicies.AdminLibrarianUser, policy =>
              policy.RequireRole(Roles.Admin, Roles.Librarian, Roles.User));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseHttpLogging();

app.Logger.LogInformation("Running application...");

app.RegisterUserAPI(app.Logger);

app.UseAuthorization();

app.Run();
