using AWEPP.Context;
using AWEPP.Repositories;
using AWEPP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<Aweppcontext>(options => options.UseSqlServer(conString));
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankServices, BankServices>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityServices, CitiesServices>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactServices, ContactServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerService>();


builder.Services.AddScoped<ITypeAccesRepository, TypeAccesRepository>();
builder.Services.AddScoped<ITypeAccesServices, TypeAccesServices>();
builder.Services.AddScoped<ITypeExpenseRepository, TypeExpensesRepository>();
builder.Services.AddScoped<ITypeExpensesServices, TypeExpensesServices>();
builder.Services.AddScoped<ITypeIdentyRepository, TypeIdentyRepository>();
builder.Services.AddScoped<ITypeIdentyServices, TypeIdentyServices>();
builder.Services.AddScoped<ITypeProductsRepository, TypeProductsRepository>();
builder.Services.AddScoped<ITypeProductsServices, TypeProductsServices>();

// Registrar los servicios y repositorios en el contenedor
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddScoped<ISavingRepository, SavingRepository>();
builder.Services.AddScoped<ISavingService, SavingService>();

builder.Services.AddScoped<ITypeAccountRepository, TypeAccountRepository>();
builder.Services.AddScoped<ITypeAccountsService, TypeAccountsService>();

builder.Services.AddScoped<IUsertypeRepository, UsertypeRepository>();
builder.Services.AddScoped<IUsertypeServices, UsertypeServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserHistoryRepository, UserHistoryRepository>();
builder.Services.AddScoped<IUserHistoryServices, UserHistoryServices>();
builder.Services.AddScoped<ITypeAccesUserRepository, TypeAccesUserRepository>();
builder.Services.AddScoped<ITypeAccesUserServices, TypeAccesUserServices>();

// Agregar los controladores al contenedor
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
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

