using Basket.Api.Data;
using Basket.Api.GrpcServices;
using Basket.Api.Repositories;
using Confluent.Kafka;
using Discount.Grpc.Protos;
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

#region gRPC Service

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(opt =>
    opt.Address = new Uri(builder.Configuration.GetValue<string>("GrpcSettings: DiscountGrpcUrl")));

builder.Services.AddScoped<DiscountGrpcService>();

#endregion


builder.Services.AddScoped<IBasketRepository,BasketRepository>();

builder.Services.AddScoped<IStyleRepository, StyleRepository>();



builder.Services.AddControllers();
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
