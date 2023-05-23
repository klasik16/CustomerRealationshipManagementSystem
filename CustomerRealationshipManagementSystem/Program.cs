// Import necessary namespaces
using CustomerRealationshipManagementSystem.DataBase.Data;
using CustomerRealationshipManagementSystem.DataBase.Interfaces;
using CustomerRealationshipManagementSystem.DataBase.Repositories;
using CustomerRealationshipManagementSystem.Services.Interfaces;
using CustomerRealationshipManagementSystem.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

// Create builder for the application
var builder = WebApplication.CreateBuilder(args);

// Read configuration file
var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");
IConfiguration config = configBuilder.Build();

// Add services to the container
builder.Services.AddControllers();

// Set up Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
SetUpSwagger(builder.Services);

// Set up JWT authentication
SetUpAuthentication(builder.Services);

// Add necessary services and repositories
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddHttpContextAccessor();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Function to set up Swagger with JWT authentication
void SetUpSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT Token",
            Type = SecuritySchemeType.Http
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new string[]{}
            }
        });
    });
}

// Function to set up JWT authentication
void SetUpAuthentication(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["JWT:ValidIssuer"],
            ValidAudience = config["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Token"]))
        };
    });
}