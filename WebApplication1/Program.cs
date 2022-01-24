using ClienteAPI.Application.Services.Interfaces;
using ClienteAPI.Infra.Context;
using ClienteAPI.Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using AutoMapper;
using ClienteAPI.Application.Mappers;
using ClienteAPI.Application.Services;
using ClienteAPI.Application.Validation;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ClienteAPI.Infra.External_Services.Interfaces;
using ClienteAPI.Infra.External_Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClienteRequestValidator>());

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClienteProfile());
                mc.AddProfile(new EnderecoProfile());
            });
IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<Context>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteServices, ClienteServices>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IEnderecoServices, EnderecoServices>();
builder.Services.AddTransient<IAdressProvider, AdressProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente.Api", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
