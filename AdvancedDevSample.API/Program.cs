using AdvancedDevSample.API.Middlewares;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Interfaces.Orders;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastruture.Repositories.Orders;
using AdvancedDevSample.Infrastruture.Repositories.Products;

var builder = WebApplication.CreateBuilder(args);

// Services DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

// Application services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Middleware erreurs
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger (déjà enregistré avant Build)
app.UseSwagger();
app.UseSwaggerUI();

// Controllers
app.MapControllers();

app.Run();
