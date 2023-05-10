using PescaArtesanalAPI.Models;
using PescaArtesanalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.Configure<PescaArtesanalDatabaseSettings>(
    builder.Configuration.GetSection("PescaArtesanalDatabase"));

//Aqui agregamos los servicios asociados para cada EndPoint
builder.Services.AddSingleton<DepartamentosService>();
builder.Services.AddSingleton<CuencasService>();
builder.Services.AddSingleton<MetodosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
