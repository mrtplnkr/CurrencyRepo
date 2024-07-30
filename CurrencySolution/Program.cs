using Application;
using Application.Clients;
using CurrencyApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediator(c =>
{
    c.Namespace = "CurrencyApi";
});
builder.Services.AddScoped<ICurrencyHttpClient, CurrencyHttpClient>();

builder.Services.AddDbContext<ICurrencyDbContext, CurrencyDbContext>(opt =>
{
    opt.UseInMemoryDatabase("CurrencyDb");
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:4200");
                      });
});

var app = builder.Build();

app.UseCors("_myAllowSpecificOrigins");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
