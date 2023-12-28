using Basket.Api.Data;
using Basket.Api.Repositories;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("BasketDb");
});

builder.Services.AddDbContext<TestDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BasketDbSQLServer"));
});

builder.Services.AddScoped<IBasketRepository,BasketRepository>();

builder.Services.AddScoped<IStyleRepository, StyleRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
