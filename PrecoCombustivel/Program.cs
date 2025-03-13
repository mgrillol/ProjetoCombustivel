using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PrecoCombustivel.Features.Combustivel;
using PrecoCombustivel.Infrastructure.Context;
using MediatR;
using System.Text.Json.Serialization;
using System.Text.Json;
using PrecoCombustivel.Features.Combustivel.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<CreateCombustivelCommand>());

builder.Services.AddControllers();


builder.Services.AddDbContext<CombustivelDbContext>(options =>
    options.UseInMemoryDatabase("PrecoCombustivelDB")
    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

builder.Services.AddScoped<CombustivelRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Preco Combustiveis API",
        Version = "v1"
    });

    x.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Opcional: Para lidar com nomes de propriedade sem diferenciar maiúsculas e minúsculas
    options.JsonSerializerOptions.WriteIndented = true; // Opcional: Para JSON formatado e legível
    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase; // Opcional: Para usar camelCase nas propriedades JSON
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; // Opcional: Para evitar problemas com referências circulares
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Preco Combustiveis API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
