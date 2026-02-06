using Microsoft.EntityFrameworkCore;
using OrderStore.Application.Services;
using OrderStore.DataAccess;
using OrderStore.DataAccess.Repos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:5173") // адрес твоего React dev
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<OrderStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(OrderStoreDbContext)));
});
builder.Services.AddScoped<IOrdersService, OrdersService > ();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
var app = builder.Build();
app.UseCors();
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();