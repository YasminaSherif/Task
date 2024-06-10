using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BLL.AutoMapperProfiles;
using DAL.Repositories.Contracts;
using DAL.Repositories;
using BLL.Services.Contracts;
using BLL.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:41473")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddScoped<IProductRepository, ProductRepositiory>();
builder.Services.AddScoped<IClientRepository, ClientRepositiory>();
builder.Services.AddScoped<IClientProductRepository, ClientProductRepository>();

builder.Services.AddAutoMapper(typeof(ClientProfile), typeof(ProductProfile), typeof(ClientProductProfile));

builder.Services.AddScoped<IClientService, ClientServices>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<IClinetProductService, ClientProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
