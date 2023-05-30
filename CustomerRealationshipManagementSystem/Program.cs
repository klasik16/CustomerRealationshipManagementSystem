// Import necessary namespaces
using CustomerRealationshipManagementSystem.DataBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

// Create builder for the application
var builder = WebApplication.CreateBuilder(args);

// Read configuration file
var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");
IConfiguration config = configBuilder.Build();


// Add services to the container
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.Preserve);

// Set up Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
SetUpSwagger(builder.Services);

// Set up JWT authentication
SetUpAuthentication(builder.Services, config);

// Add necessary services and repositories
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Register DbContext
//builder.Services.AddScoped<IDbContext, UserService>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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

//Function to set up Swagger with JWT authentication
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
void SetUpAuthentication(IServiceCollection services, IConfiguration config)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]))
        };
    });

    services.AddAuthorization(options =>
    {
        options.AddPolicy("UserRole", policy => policy.RequireClaim(ClaimTypes.Role, "User", "Admin"));
    });
}