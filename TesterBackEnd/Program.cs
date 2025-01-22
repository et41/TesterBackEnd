using Microsoft.EntityFrameworkCore;
using TesterBackEnd.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TesterDBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<TesterDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    builder.Services.AddDbContext<TesterDBContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING")));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
