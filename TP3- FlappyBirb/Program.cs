using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TP3__FlappyBirb.Data;
using TP3__FlappyBirb.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TP3__FlappyBirbContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("TP3__FlappyBirbContext") ?? throw new InvalidOperationException("Connection string 'TP3__FlappyBirbContext' not found."));
    options.UseLazyLoadingProxies();
});

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();

    });
});
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TP3__FlappyBirbContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
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

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
