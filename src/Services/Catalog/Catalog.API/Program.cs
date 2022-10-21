using Catalog.Application.Abstractions;
using Catalog.Application.Extensions;
using Catalog.Infrastructure.Repositories;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureServices();

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>(_ => new(builder.Configuration.GetConnectionString("Postgres")));

// MassTransit
builder.Services.AddMassTransit(config =>
{
    var assembly = Assembly.GetExecutingAssembly();

    config.AddConsumers(assembly);
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:Host"]);
        cfg.ConfigureEndpoints(ctx);
    });
});

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
