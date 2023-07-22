using MassTransit.Consumer.Configurations;
using MassTransit.Infrastructure.EF;
using MassTransit.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddJsonSettings();

// Add services to the container.

//Add Ef 
builder.Services.AddEfConfig(builder.Configuration);

// Add MassTransit
builder.Services.AddMassTransitConfig(builder.Configuration);

//Add Repositories
builder.Services.AddRepositoriesConfig();

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
