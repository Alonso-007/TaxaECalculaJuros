using Serilog;
using Taxas.Api.Domain.TaxasDeJuros;
using Taxas.Api.Endpoints.Errors;
using Taxas.Api.Endpoints.TaxasDeJuros;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaxasPercentuais, TaxasPercentuais>();

builder.WebHost.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapMethods(TaxasDeJurosGet.Template, TaxasDeJurosGet.Methods, TaxasDeJurosGet.Handle);

app.UseExceptionHandler(Error.Template);
app.Map(Error.Template, Error.Handle);

app.Run();