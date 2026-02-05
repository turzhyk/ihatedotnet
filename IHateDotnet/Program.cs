using Microsoft.EntityFrameworkCore;
using OrderStore.Application.Services;
using OrderStore.DataAccess;
using OrderStore.DataAccess.Repos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(OrderStoreDbContext)));
});
builder.Services.AddScoped<IOrdersService, OrdersService > ();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();