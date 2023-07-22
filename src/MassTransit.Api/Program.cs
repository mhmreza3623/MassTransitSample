using Autofac.Core;
using AutoMapper;
using MassTransit.Core.Mapper;
using MassTransit.Infrastructure.EF;
using MassTransit.Infrastructure.Middlewares;
using MassTransit.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using MassTransit.Application.Handlera;
using MassTransit.Infrastructure.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

//Add Json cofigs
builder.Host.AddJsonSettings();

//Add Ef 
builder.Services.AddEfConfig(builder.Configuration);

// Add MassTransit
builder.Services.AddMassTransitConfig(builder.Configuration);

//Add Repositories
builder.Services.AddRepositoriesConfig();

//builder.Services.AddTransient<ITransientService>();

//add mediateR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTopicHandler).GetTypeInfo().Assembly));


//Add AutoMapper
var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new EntityMapper()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Add services to the container.
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


app.UseCustomeMiddlewares();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
