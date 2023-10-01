using AutoMapper;
using EBuy.Core;
using EBuy.Core.Services;
using EBuy.Data;
using EBuy.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add Services 
builder.Services.AddTransient<IBusinessService, BusinessService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductPropertyTypeService, ProductPropertyTypeService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductPropertyService, ProductPropertyService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddDbContext<EBuyDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Connection"),
        x => x.MigrationsAssembly("EBuy.Data")
    )
);

builder.Services.AddAutoMapper(typeof(Program));
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
