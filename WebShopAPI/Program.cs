using System.Net.Mime;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopInfrastructure;
using WebsShopDomain;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("initializing");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


var mapper = new MapperConfiguration(configuration =>
{
    configuration.CreateMap<ItemDTO, Item>();
    configuration.CreateMap<ItemCategoryDTO, Category>();
    configuration.CreateMap<OptionDTOs, Option>();
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IWebShopCategoryRepository, WebShopCategoryRepository>();
builder.Services.AddTransient<IWebShopOptionRepository, WebShopOptionRepository>();
builder.Services.AddTransient<IWebShopItemRepository, WebShopRepository>();

builder.Services.AddDbContext<WebShopDbContext>(options => options.UseSqlite(
    "Data source=../../../db.db"
));


WebShopApplication
    .DepencyResolver
    .DependencyReolverService
    .RegisterApplicationLayer(builder.Services);

WebShopInfrastructure
    .DependencyResolver
    .DependencyResolverService
    .RegisterInfrastructure(builder.Services);
    

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    
}
app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.SetIsOriginAllowed(origin => true);
});


//app.UseAuthorization();

app.MapControllers();

app.Run();