using Microsoft.EntityFrameworkCore;
using BankingApp.API.Data;
using BankingApp.API.Services;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankDbContext>(options => 
    { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

builder.Services.AddScoped<IBankAccountsService, BankAccountsService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    
}
//Wypierdalaj mi z tym
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();