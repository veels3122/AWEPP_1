using AWEPP.Context;
using AWEPP.Repositories;
using AWEPP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<Aweppcontext>(options => options.UseSqlServer(conString));

// Registrar los servicios y repositorios en el contenedor
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankServices, BankServices>();

builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICitiesServices, CitiesServices>();

builder.Services.AddScoped<IContactsRepository, CustomerRepository>();
builder.Services.AddScoped<IContactsServices, ContactsServices>();

builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();

builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddScoped<ISavingRepository, SavingRepository>();
builder.Services.AddScoped<ISavingService, SavingService>();

builder.Services.AddScoped<ITypeAccesRepository, TypeAccesRepository>();
builder.Services.AddScoped<ITypeAccesServices, TypeAccesServices>();

builder.Services.AddScoped<ITypeAccesUserRepository, TypeAccesUserRepository>();
builder.Services.AddScoped<ITypeAccesUserServices, TypeAccesUserServices>();

builder.Services.AddScoped<ITypeAccountsRepository, TypeAccountsRepository>();
builder.Services.AddScoped<ITypeAccountsService, TypeAccountsService>();

builder.Services.AddScoped<ITypeExpensesRepository, TypeExpensesRepository>();
builder.Services.AddScoped<ITypeExpensesServices, TypeExpensesServices>();

builder.Services.AddScoped<ITypeIdentyRepository, TypeIdentyRepository>();
builder.Services.AddScoped<ITypeIdentyServices, TypeIdentyServices>();

builder.Services.AddScoped<ITypeProductsRepository, TypeProductsRepository>();
builder.Services.AddScoped<ITypeProductsServices, TypeProductsServices>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUsertypeServices, UserTypeServices>();
///////////////////////////////////////////////////////////////



// Agregar los controladores al contenedor
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
