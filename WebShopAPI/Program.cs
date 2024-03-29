﻿using System.Net.Mime;
using System.Text;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebShopApplication;
using WebShopApplication.DTOs;
using WebShopApplication.Helpers;
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
    configuration.CreateMap<OptionDTO, Option>();
    configuration.CreateMap<OptionGroupDTO, OptionGroup>();
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IWebShopCategoryRepository, WebShopCategoryRepository>();
builder.Services.AddTransient<IWebShopOptionRepository, WebShopOptionRepository>();
builder.Services.AddTransient<IWebShopItemRepository, WebShopRepository>();
builder.Services.AddTransient<IWebShopServiceRepository, WebShopServiceRepository>();
builder.Services.AddTransient<IWebShopOptionGroupRepository, WebShopOptionGroupRepository>();
builder.Services.AddTransient<IItemOptionRepository, ItemOptionRepositoryRepository>();


builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(
    "Data source=../../../db.db"));


var test = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//dependency, Application
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWebShopServiceItem, WebShopServiceItem>();
builder.Services.AddScoped<IWebShopServiceOption, WebShopServiceOption>();
builder.Services.AddScoped<IWebShopServiceOptionGroups, WebShopServiceOptionGroups>();
builder.Services.AddScoped<IWebShopServiceCategory, WebShopServiceCategory>();
//dependency, Infrastructure
builder.Services.AddScoped<IWebShopItemRepository, WebShopRepository>();
builder.Services.AddScoped<IWebShopOptionGroupRepository, WebShopOptionGroupRepository>();
builder.Services.AddScoped<IWebShopServiceRepository, WebShopServiceRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            ("D6ECEF6F47921E86EAB135CA49744")))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", (policy) => { policy.RequireRole("Admin");});
    options.AddPolicy("SuperAdminPolicy", (policy) => { policy.RequireRole("SuperAdmin");});
}); 

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();