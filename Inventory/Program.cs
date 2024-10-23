global using Inventory.DataContext;
global using Inventory.Models;
global using Helpers;
global using Inventory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Inventory.Repositories;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .Enrich.WithThreadId()
//    .Enrich.WithThreadName()
//    .Enrich.WithEnvironmentName()
//    .Enrich.WithMachineName()
//    .WriteTo.Console(new JsonFormatter(renderMessage: true, closingDelimiter: Environment.NewLine))
//    .WriteTo.File(new JsonFormatter(renderMessage: true, closingDelimiter: Environment.NewLine),
//    "Log/log.text", rollingInterval: RollingInterval.Day)
//    .CreateLogger();
// Add services to the container.
//Log.Logger = new LoggerConfiguration().ReadFrom.Configuration()

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HostedDatabase"));
});

builder.Services.AddScoped<IProductService, ProductRepositories>();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

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
