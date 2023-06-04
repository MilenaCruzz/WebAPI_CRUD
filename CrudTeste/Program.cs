using CrudTeste.Infrastructure.DbConnection;
using CrudTeste.Infrastructure.Repositories;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Service;
using CrudTeste.Service.Interfaces;
using System.Data.SqlClient;
using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using CrudTeste.Service.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DbSession>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHumanResourcesRepository, HumanResourcesRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<Profile, AutoMapperConfig>();

string connectionString = "Data Source= localhost\\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=SSPI;Persist Security Info=False;";
builder.Services.AddScoped<IDbConnection>(provider => new SqlConnection(connectionString));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHumanResourcesService, HumanResourcesService>();
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
