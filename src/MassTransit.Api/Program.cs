using MassTransit.Api.Configurations;
using MassTransit.Infrastructure.EF;
using MassTransit.Infrastructure.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddJsonSettings();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddEfConfig(builder.Configuration);

builder.Services.AddMassTransitConfig(builder.Configuration);


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
