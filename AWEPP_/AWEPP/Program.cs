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
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICitiesServices, CitiesServices>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IContactsServices, ContactServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerService>();


builder.Services.AddScoped<ITypeAccesRepository, TypeAccesRepository>();
builder.Services.AddScoped<ITypeAccesServices, TypeAccesServices>();
builder.Services.AddScoped<ITypeExpensesRepository, TypeExpensesRepository>();
builder.Services.AddScoped<ITypeExpensesServices, TypeExpensesServices>();
builder.Services.AddScoped<ITypeIdentyRepository, TypeIdentyRepository>();
builder.Services.AddScoped<ITypeIdentyServices, TypeIdentyServices>();
builder.Services.AddScoped<ITypeProductsRepository, TypeProductsRepository>();
builder.Services.AddScoped<ITypeProductsServices, TypeProductsServices>();

// Registrar los servicios y repositorios en el contenedor
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IExpensesServices, ExpenseServices>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductsServices, ProductServices>();

builder.Services.AddScoped<ISavingRepository, SavingRepository>();
builder.Services.AddScoped<ISavingServices, SavingServices>();

builder.Services.AddScoped<ITypeAccountsRepository, TypeAccountsRepository>();
builder.Services.AddScoped<ITypeAccountsServices, TypeAccountServices>();

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

