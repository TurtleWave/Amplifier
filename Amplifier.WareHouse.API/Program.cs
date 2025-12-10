using Amplifier.WareHouse.API.Controllers;
using Amplifier.WareHouse.Core;
using Amplifier.WareHouse.Core.Interfaces;
using Amplifier.WareHouse.Core.Mappers;
using Amplifier.WareHouse.Core.Services;
using Amplifier.WareHouse.DAL;
using Amplifier.WareHouse.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext, WareHouseContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("mssql"))
);

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Cost>, CostRepository>();
builder.Services.AddScoped<IRepository<Supply>, SupplyRepository>();

builder.Services.AddScoped<IService<Product>, ProductService>();
builder.Services.AddScoped<IService<Supply>, SupplyService>();
builder.Services.AddScoped<IService<Cost>, CostService>();

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();