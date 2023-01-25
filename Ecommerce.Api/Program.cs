using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Ioc;
using Ecommerce.Ioc.Infrastructure;
using Ecommerce.Ioc.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Ecommerce.Ioc.Infrastructure.Ioc.IocInfrastructure(builder.Services, builder.Configuration);
Ecommerce.Ioc.Service.Ioc.IocService(builder.Services);

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
