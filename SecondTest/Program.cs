using Microsoft.EntityFrameworkCore;
using SecondTest.Infrastructure;
using SecondTest.Infrastructure.Interfaces;
using SecondTest.Persistence;
using SecondTest.Persistence.Interfaces;
using SecondTest.Services;
using SecondTest.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

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

app.Run();
