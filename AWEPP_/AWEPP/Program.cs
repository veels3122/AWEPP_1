using AWEPP.Context;
using AWEPP.Repositories;
using AWEPP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<Aweppcontext>(options => options.UseSqlServer(conString));

builder.Services.AddScoped<ITypeAccesRepository, TypeAccesRepository>();
builder.Services.AddScoped<ITypeAccesServices, TypeAccesServices>();
builder.Services.AddScoped<ITypeExpensesRepository, TypeExpensesRepository>();
builder.Services.AddScoped<ITypeExpensesServices, TypeExpensesServices>();
builder.Services.AddScoped<ITypeIdentyRepository, TypeIdentyRepository>();
builder.Services.AddScoped<ITypeIdentyServices, TypeIdentyServices>();
builder.Services.AddScoped<ITypeProductsRepository, TypeProductsRepository>();
builder.Services.AddScoped<ITypeProductsServices, TypeProductsServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
