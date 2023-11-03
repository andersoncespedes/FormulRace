using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FormulRaceAPI.Extension;
using AutoMapper;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbFirstContext>(options => {
    string  Con = builder.Configuration.GetConnectionString("ConexSql");
    options.UseMySql(Con, ServerVersion.AutoDetect(Con));
});
builder.Services.AddExtension();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
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
