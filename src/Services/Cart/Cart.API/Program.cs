using Cart.Application.Abstractions;
using Cart.Infrastructure.Repositories;
using Cart.Application.Extensions;
using Cart.Application.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureServices();

builder.Services.AddScoped<ICartRepository, CartRepository>(_ => new CartRepository(builder.Configuration.GetConnectionString("MongoDb")));

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
