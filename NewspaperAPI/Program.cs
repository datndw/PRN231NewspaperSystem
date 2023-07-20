using System.Text;
using BussinessObject.Contracts;
using BussinessObject.Models;
using BussinessObject.Profiles;
using DataAccess.DbContexts;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewspaperAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("NewspaperDB");
builder.Services.AddDbContext<NewspaperDbContext>(options =>
{
    options.UseSqlServer(connectionString!, opt => opt.EnableRetryOnFailure());
});
builder.Services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<NewspaperDbContext>()
                .AddDefaultTokenProviders();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddTransient<NewspaperDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                        ValidAudience = builder.Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))

                    };
                });
builder.Services.AddAutoMapper(typeof(ApplicationProfile));
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("User", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "User");
    });

    config.AddPolicy("Writer", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "Writer");
    });

    config.AddPolicy("Administrator", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "Administrator");
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

