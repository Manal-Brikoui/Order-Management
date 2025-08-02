using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Data;
using OrderManagement.Infrastructure.Repository;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Application.UseCases.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. Ajouter DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Ajouter les Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// 3. Ajouter les cas d'usage
builder.Services.AddScoped<CreateOrderHandler>();

// 4. Ajouter les contrôleurs
builder.Services.AddControllers();

// 5. Ajouter Swagger pour la documentation API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Utilisation de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.Run();
