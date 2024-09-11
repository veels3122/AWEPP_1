using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;

var builder = WebApplication.CreateBuilder(args);

//add services to the container
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AplicacionContext>(option => option.UseSqlServer(conString));
// Add services to the container.

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
