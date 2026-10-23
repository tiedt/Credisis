

using Credisis.Estudos.API.Helper;
using Credisis.Estudos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddServices();
builder.Services.AddRepository();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CredisisEstudosDbContext>(options =>
    options.UseSqlServer(connection, sql => sql.EnableRetryOnFailure()));
var app = builder.Build();

using(var scoper = app.Services.CreateScope())
{
    var context = scoper.ServiceProvider.GetRequiredService<CredisisEstudosDbContext>();
    context.Database.Migrate();
}

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
