using FibonacciRestApi.Abstractions;
using FibonacciRestApi.Persistence;
using FibonacciRestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFibonacciNumberService, FibonacciNumberService>();
builder.Services.AddScoped<IFibonacciNumberCalculator, FibonacciNumberCalculator>();
builder.Services.AddSingleton<IFibonacciNumberCacheRepository, FibonacciNumberCacheRepository>();

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
