

using Credisis.Estudos.Application;
using Credisis.Estudos.Application.Services.Cliente;
using Credisis.Estudos.Domain.Interfaces.Repository.Cliente;
using Credisis.Estudos.Infra.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
