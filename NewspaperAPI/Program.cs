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
using Microsoft.OpenApi.Models;
using NewspaperAPI.Services;

var builder = WebApplication.CreateBuilder(args);
AddSwaggerDoc(builder.Services);
void AddSwaggerDoc(IServiceCollection services)
{
    services.AddSwaggerGen(s =>
    {
        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Newspaper Web API using JWT Authorization with Bearer scheme. \r\n\r\n" +
            "Enter 'Bearer[space]' *Note that [space] is a space character and then your token in the token input below.\r\n\r\n" +
            "Example: 'Bearer ABC123'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        s.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Newspaper"
        });
    });
}
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

    config.AddPolicy("Admin", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "Adminr");
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

