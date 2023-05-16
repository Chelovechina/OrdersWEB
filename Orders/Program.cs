using Microsoft.EntityFrameworkCore;
using Orders.BLL.Interfaces;
using Orders.BLL.Services;
using Orders.DLL.Data;
using Orders.DLL.Interfaces;
using Orders.DLL.Repositories;
using Orders.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DLL services to the container.
builder.Services.AddScoped<IRepository<Item>, ItemRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
builder.Services.AddScoped<IRepository<Provider>, ProviderRepository>();

// BLL services to the container.
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderItemService, OrderItemService>();
builder.Services.AddTransient<IProviderService, ProviderService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connecting DB
var connection = builder.Configuration.GetSection("DB").Value;
builder.Services.AddDbContext<AppDBcontext>(options => options.UseSqlServer(connection));


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
