using DPA_Shopping.API.Controllers;
using DPA_Shopping.DOMAIN.Core.Interfaces;
using DPA_Shopping.DOMAIN.Infrastructure.Data;
using DPA_Shopping.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var _config = builder.Configuration;
var _cnx = _config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(_cnx));

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
