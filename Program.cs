using Scalar.AspNetCore;
using Parcial_p4_LuisEnmanuel.Servicios;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSingleton<NumbersService>();

var app = builder.Build();

await app.Services.GetRequiredService<NumbersService>().InitializeAsync();

app.MapOpenApi();

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();