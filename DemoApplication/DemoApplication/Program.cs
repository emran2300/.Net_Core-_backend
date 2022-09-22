using DemoApplication;
using DemoApplication.Core.Repo;
using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using DemoApplication.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DemoConnection");
builder.Services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepo<Admin,int,bool>, AdminRepo>();
builder.Services.AddScoped<IRepo<Token, string, Token>, TokenRepo>();
builder.Services.AddScoped<IRepo<User, int, bool>, UserRepo>();
builder.Services.AddScoped<IAuth, LoginMatchRepo>();

builder.Services.AddControllers();

//builder.Services.AddScoped<IRepo, CategoryRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        //ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// Configure the HTTP request pipeline.
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
