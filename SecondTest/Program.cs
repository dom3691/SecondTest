using Microsoft.EntityFrameworkCore;
using SecondTest.Infrastructure;
using SecondTest.Infrastructure.Interfaces;
using SecondTest.Persistence;
using SecondTest.Persistence.Interfaces;
using SecondTest.Services;
using SecondTest.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logFilePath = builder.Configuration["Logging:FilePath"] ?? @"C:\Logs\SecondTest\log-.txt";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        logFilePath,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7)
    .CreateLogger();

// Add services to the container.

//REPOSITORIES
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//SERVICES
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

try
{
    Log.Information("SecondTest application started successfully");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "SecondTest application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
