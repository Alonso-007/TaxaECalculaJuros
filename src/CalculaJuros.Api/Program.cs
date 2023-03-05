using CalculaJuros.Api.Domain.CalculoDeJuros;
using CalculaJuros.Api.Domain.ShowMeTheCode;
using CalculaJuros.Api.Endpoints.CalculaJuros;
using CalculaJuros.Api.Endpoints.Errors;
using CalculaJuros.Api.Endpoints.ShowMeTheCode;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console();
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICalcularJurosComposto, CalcularJurosComposto>();
builder.Services.AddScoped<IShowMeTheCodeGit, ShowMeTheCodeGit>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapMethods(CalculaJurosGet.Template, CalculaJurosGet.Methods, CalculaJurosGet.Handle);
app.MapMethods(ShowMeTheCodeGet.Template, ShowMeTheCodeGet.Methods, ShowMeTheCodeGet.Handle);

app.UseExceptionHandler(Error.Template);
app.Map(Error.Template, Error.Handle);

app.Run();