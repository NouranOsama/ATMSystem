using ATMSystem.Data;
using ATMSystem.Models;
using Microsoft.EntityFrameworkCore;
using ATMSystem.Data.Interfaces;
using ATMSystem.Data.Repositories;
using ATMSystem.Data.UnitOfWork;
using ATMSystem.Services.Implementations;
using ATMSystem.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Setup Serilog logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/atm_log.txt", rollingInterval: RollingInterval.Day) // log file per day
    .CreateLogger();

builder.Host.UseSerilog();

// Database connection
DatabaseConnection.Initialize(builder.Configuration);
builder.Services.AddSingleton(DatabaseConnection.Instance);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(DatabaseConnection.Instance.ConnectionString));

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // generic repo
builder.Services.AddScoped<IAccountRepository, AccountRepository>();     // custom repo
builder.Services.AddScoped<IATMRepository, ATMRepository>();             // custom repo

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IAtmService, AtmService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
