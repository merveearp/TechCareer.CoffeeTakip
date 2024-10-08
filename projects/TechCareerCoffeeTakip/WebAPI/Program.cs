using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Service.Abstract;
using Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BaseDbContext>(

    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")
    
    ));
builder.Services.AddScoped<ICoffeeRepository,CoffeeRepository>();   
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICoffeeService, CoffeeService>();
builder.Services.AddScoped<IProductService, ProductService>();


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
