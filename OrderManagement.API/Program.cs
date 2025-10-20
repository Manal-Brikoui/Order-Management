using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Data;
using OrderManagement.Infrastructure.Repository;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Application.UseCases.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<CreateOrderHandler>();


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.Run();
