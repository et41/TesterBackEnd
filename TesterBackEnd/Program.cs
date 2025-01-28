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

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerUI(a =>
    //{
    //   a.SwaggerEndpoint("/swagger/v1/swagger.json", "Tester API V1");
    //   a.RoutePrefix = string.Empty;
    //});
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
