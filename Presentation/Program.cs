using Application.Interfaces;
using Application.UseCase.Service;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DemoSwaggerAnnotation",
        Version = "v1",
    });
    c.EnableAnnotations();
});


// custom
builder.Services.AddScoped<MarketDbContext>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductQuery, ProductQuery> ();
builder.Services.AddScoped<IProductCommand,ProductCommand>();
builder.Services.AddScoped<ICategoryQuery, CategoryQuery>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleQuery, SaleQuery>();
builder.Services.AddScoped<ISaleCommand, SaleCommand>();
builder.Services.AddScoped<ProductServiceUtils>();
builder.Services.AddScoped<SaleServiceUtils>();




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

